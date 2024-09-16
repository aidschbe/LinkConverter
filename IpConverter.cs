using System.Net;

namespace LinkConverter;

internal class IpConverter
{

	public static List<string> Convert(IEnumerable<string> links)
	{
		List<string> convertedLinks = [];

		foreach (var link in links)
		{
			if (link.Length > 0)
			{
				convertedLinks.Add(ResolveUrl(link));
			}
		}

		return convertedLinks;
	}

	private static string ResolveUrl(string link)
	{
		UriBuilder builder = new(link);

		Uri uri = builder.Uri;

		string domainUrl = uri.DnsSafeHost;

		IPHostEntry domain = Dns.GetHostEntry(domainUrl);

		IPAddress domainIp = domain.AddressList.First();

		string result = domainIp + uri.AbsolutePath;
		return result;
	}

	public static async Task Download(string link, string path, IProgress<int> percent)
	{
		percent.Report(0);

		CreateClient(link, out Uri uri, out HttpClient client);

		using (var response = await client.GetAsync(uri.AbsolutePath, HttpCompletionOption.ResponseHeadersRead))
		using (var stream = await response.Content.ReadAsStreamAsync())
		{
			string filename = link.Substring(link.LastIndexOf("/"));
			filename = Uri.UnescapeDataString(filename);
			FileStream file = File.Create(path + "/" + filename); 

			long? fileSize = response.Content.Headers.ContentLength;
			long bytesDownloaded = 0;
			int? downloadPercent = (int)((double)bytesDownloaded / fileSize * 100);

			Task download = stream.CopyToAsync(file);

			Task report = Task.Run(() =>
			{
				while (!download.IsCompleted)
				{
					bytesDownloaded = file.Length;
					int? oldPercentage = downloadPercent;
					downloadPercent = (int)((double)bytesDownloaded / fileSize * 100);

					if (downloadPercent > 100)
					{
						continue;
					}

					if (oldPercentage != downloadPercent)
					{
						percent.Report((int)downloadPercent);
					}

				}
			});

			await report;
		}
	}

	private static void CreateClient(string link, out Uri uri, out HttpClient client)
	{
		UriBuilder builder = new UriBuilder(link);

		uri = builder.Uri;
		string domainUrl = uri.DnsSafeHost;

		IPHostEntry domain = Dns.GetHostEntry(domainUrl);

		IPAddress domainIp = domain.AddressList.First();

		client = new()
		{
			BaseAddress = new Uri("http://" + domainIp.ToString())
		};
	}
}
