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

		private void ButtonDownloadPath_Click(object sender, EventArgs e)
		{
			folderBrowserDialogDownloadPath.ShowDialog();

			textBoxDownloadPath.Text = folderBrowserDialogDownloadPath.SelectedPath;
		}

		private async void ButtonDownload_Click(object sender, EventArgs e)
		{
			List<string> links = CheckLinksForValidity();

			IProgress<string> fileNum = new Progress<string>(file => labelDownloadStatus.Text = file);
			IProgress<int> progress = new Progress<int>(percent => progressBarDownload.Value = percent);

			await AsyncDownload(links, progress, fileNum);
		}

		private async Task AsyncDownload(List<string> links, IProgress<int> progress, IProgress<string> fileNum)
		{
			var fileCount = 0;

			foreach (var link in links)
			{
				fileCount++;

				fileNum.Report($"File {fileCount} of {links.Count}");

				var download = IpConverter.Download(link, textBoxDownloadPath.Text, progress);

				await download;
			}

			labelDownloadStatus.Text = "Finished!";

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
