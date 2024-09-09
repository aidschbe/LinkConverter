using System.IO.Enumeration;

namespace LinkConverter
{

	public partial class FormMain : Form
	{
		public FormMain()
		{
			InitializeComponent();
		}

		private void ButtonConvert_Click(object sender, EventArgs e)
		{
			textBoxLinkOutput.Clear();

			var ipLinks = IpConverter.Convert(textBoxLinkInput.Lines);

			foreach (var link in ipLinks)
			{
				textBoxLinkOutput.Text += link + Environment.NewLine;
			}
		}

		private void buttonDownloadPath_Click(object sender, EventArgs e)
		{
			folderBrowserDialogDownloadPath.ShowDialog();

			textBoxDownloadPath.Text = folderBrowserDialogDownloadPath.SelectedPath;
		}

		private async void ButtonDownload_Click(object sender, EventArgs e)
		{
			progressBarDownload.Value = 0;

			List<string> links = CheckLinksForValidity();

			await AsyncDownload(links);
		}

		private async Task AsyncDownload(List<string> links)
		{
			var fileNum = 0;

			foreach (var link in links)
			{
				fileNum++;

				labelDownloadStatus.Text = $"File {fileNum} of {links.Count}";

				var progress = IpConverter.Download(link, textBoxDownloadPath.Text);

				await foreach (var status in progress)
				{
					if (status.HasValue)
					{
						progressBarDownload.Value = (int)status.Value;
					}
				}

				labelDownloadStatus.Text = "Finished!";
			}
		}

		private List<string> CheckLinksForValidity()
		{
			List<string> links = [];

			foreach (var line in textBoxLinkInput.Lines)
			{
				Uri? result;

				bool isUri = Uri.TryCreate(line, UriKind.Absolute, out result);
				if (isUri)
				{
					links.Add(line);
				}
			}

			return links;
		}
	}
}
