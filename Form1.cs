using System.IO.Enumeration;

namespace LinkConverter
{

	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void buttonConvert_Click(object sender, EventArgs e)
		{
			textBoxLinkOutput.Clear();

			IpConverter converter = new IpConverter();

			var ipLinks = converter.Convert(textBoxLinkInput.Lines);

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

		private async void buttonDownload_Click(object sender, EventArgs e)
		{
			progressBarDownload.Value = 0;

			IpConverter converter = new IpConverter();

			List<string> links = new List<string>();

			foreach (var line in textBoxLinkInput.Lines)
			{
				Uri? result;

				bool isUri = Uri.TryCreate(line, UriKind.Absolute, out result);
				if (isUri)
				{
					links.Add(line);
				}
			}

			var fileNum = 0;


			foreach (var link in links)
			{
				fileNum++;

				labelDownloadStatus.Text = $"File {fileNum} of {links.Count}";

				var progress = converter.Download(link, textBoxDownloadPath.Text);

				await foreach (var status in progress)
				{
					if (status.HasValue)
					{
						progressBarDownload.Value = (int)status.Value;
					}
				}
			}
		}
	}
}
