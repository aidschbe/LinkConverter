using System.Collections;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using System.Web;

namespace LinkConverter;

internal class IpConverter
{

	public static List<string> Convert(IEnumerable<string> links)
	{
		List<string> convertedLinks = new List<string>();

		foreach (var link in links)
		{
			if (link.Length > 0)
			{
				UriBuilder builder = new UriBuilder(link);

				Uri uri = builder.Uri;

				var domainUrl = uri.DnsSafeHost;

				IPHostEntry domain = Dns.GetHostEntry(domainUrl);

				var domainIp = domain.AddressList.FirstOrDefault();

				var result = domainIp + uri.AbsolutePath;

				convertedLinks.Add(result);
			}
		}

		return convertedLinks;
	}

	public static async IAsyncEnumerable<double?> Download(string link, string path)
	{

		UriBuilder builder = new UriBuilder(link);

		Uri uri = builder.Uri;

		string domainUrl = uri.DnsSafeHost;

		IPHostEntry domain = Dns.GetHostEntry(domainUrl);

		IPAddress domainIp = domain.AddressList.First();

		HttpClient client = new()
		{
			BaseAddress = new Uri("http://" + domainIp.ToString())
		};

		using (var response = await client.GetAsync(uri.AbsolutePath, HttpCompletionOption.ResponseHeadersRead))
		using (var stream = await response.Content.ReadAsStreamAsync())
		{
			string filename = link.Substring(link.LastIndexOf("/"));
			filename = System.Uri.UnescapeDataString(filename);
			FileStream file = File.Create(path + "/" + filename);


			long? totalBytes = response.Content.Headers.ContentLength;
			long bytes = 0;
			double? percentComplete = (double)bytes / totalBytes * 100;

			Task download = stream.CopyToAsync(file);

			do
			{
				bytes = file.Length;
				percentComplete = (double)bytes / totalBytes * 100;
				yield return percentComplete;
			}
			while (percentComplete < 100);

			file.Close();

			yield return percentComplete;
		}
	}
}
