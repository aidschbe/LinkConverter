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
				UriBuilder builder = new(link);

				Uri uri = builder.Uri;

				string domainUrl = uri.DnsSafeHost;

				IPHostEntry domain = Dns.GetHostEntry(domainUrl);

				IPAddress domainIp = domain.AddressList.First();

				string result = domainIp + uri.AbsolutePath;

				convertedLinks.Add(result);
			}
		}

		return convertedLinks;
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

			long? totalBytes = response.Content.Headers.ContentLength;
			long bytes = 0;
			int? percentComplete = (int)((double)bytes / totalBytes * 100);

			Task download = stream.CopyToAsync(file);

			Task report = Task.Run(() =>
			{
				while (!download.IsCompleted)
				{
					bytes = file.Length;
					int? oldPercentage = percentComplete;
					percentComplete = (int)((double)bytes / totalBytes * 100);

					if (percentComplete > 100)
					{
						continue;
					}

					if (oldPercentage != percentComplete)
					{
						percent.Report((int)percentComplete);
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
