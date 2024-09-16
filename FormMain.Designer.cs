namespace LinkConverter
{
	partial class FormMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			labelLinkInput = new Label();
			labelLinkOutput = new Label();
			textBoxLinkInput = new TextBox();
			buttonConvert = new Button();
			textBoxLinkOutput = new TextBox();
			textBoxDownloadPath = new TextBox();
			labelDownloadPath = new Label();
			buttonDownloadPath = new Button();
			folderBrowserDialogDownloadPath = new FolderBrowserDialog();
			progressBarDownload = new ProgressBar();
			buttonDownload = new Button();
			labelDownloadStatus = new Label();
			labelTitle = new Label();
			SuspendLayout();
			// 
			// labelLinkInput
			// 
			labelLinkInput.AutoSize = true;
			labelLinkInput.Location = new Point(12, 99);
			labelLinkInput.Name = "labelLinkInput";
			labelLinkInput.Size = new Size(73, 15);
			labelLinkInput.TabIndex = 0;
			labelLinkInput.Text = "Input Link(s)";
			// 
			// labelLinkOutput
			// 
			labelLinkOutput.AutoSize = true;
			labelLinkOutput.Location = new Point(12, 282);
			labelLinkOutput.Name = "labelLinkOutput";
			labelLinkOutput.Size = new Size(100, 15);
			labelLinkOutput.TabIndex = 1;
			labelLinkOutput.Text = "Converted Link(s)";
			// 
			// textBoxLinkInput
			// 
			textBoxLinkInput.AcceptsReturn = true;
			textBoxLinkInput.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			textBoxLinkInput.Location = new Point(12, 117);
			textBoxLinkInput.Multiline = true;
			textBoxLinkInput.Name = "textBoxLinkInput";
			textBoxLinkInput.Size = new Size(442, 116);
			textBoxLinkInput.TabIndex = 2;
			// 
			// buttonConvert
			// 
			buttonConvert.Location = new Point(12, 239);
			buttonConvert.Name = "buttonConvert";
			buttonConvert.Size = new Size(187, 23);
			buttonConvert.TabIndex = 3;
			buttonConvert.Text = "Convert Link(s)";
			buttonConvert.UseVisualStyleBackColor = true;
			buttonConvert.Click += ButtonConvert_Click;
			// 
			// textBoxLinkOutput
			// 
			textBoxLinkOutput.AcceptsReturn = true;
			textBoxLinkOutput.Anchor = AnchorStyles.Left | AnchorStyles.Right;
			textBoxLinkOutput.Location = new Point(12, 300);
			textBoxLinkOutput.Multiline = true;
			textBoxLinkOutput.Name = "textBoxLinkOutput";
			textBoxLinkOutput.Size = new Size(442, 116);
			textBoxLinkOutput.TabIndex = 4;
			// 
			// textBoxDownloadPath
			// 
			textBoxDownloadPath.Anchor = AnchorStyles.Right;
			textBoxDownloadPath.Location = new Point(461, 117);
			textBoxDownloadPath.Name = "textBoxDownloadPath";
			textBoxDownloadPath.Size = new Size(337, 23);
			textBoxDownloadPath.TabIndex = 5;
			// 
			// labelDownloadPath
			// 
			labelDownloadPath.AutoSize = true;
			labelDownloadPath.Location = new Point(461, 99);
			labelDownloadPath.Name = "labelDownloadPath";
			labelDownloadPath.Size = new Size(91, 15);
			labelDownloadPath.TabIndex = 6;
			labelDownloadPath.Text = "Download Path:";
			// 
			// buttonDownloadPath
			// 
			buttonDownloadPath.Location = new Point(804, 117);
			buttonDownloadPath.Name = "buttonDownloadPath";
			buttonDownloadPath.Size = new Size(75, 23);
			buttonDownloadPath.TabIndex = 7;
			buttonDownloadPath.Text = "Browse";
			buttonDownloadPath.UseVisualStyleBackColor = true;
			buttonDownloadPath.Click += ButtonDownloadPath_Click;
			// 
			// progressBarDownload
			// 
			progressBarDownload.Location = new Point(460, 210);
			progressBarDownload.Name = "progressBarDownload";
			progressBarDownload.Size = new Size(338, 23);
			progressBarDownload.TabIndex = 8;
			// 
			// buttonDownload
			// 
			buttonDownload.Location = new Point(804, 210);
			buttonDownload.Name = "buttonDownload";
			buttonDownload.Size = new Size(75, 23);
			buttonDownload.TabIndex = 9;
			buttonDownload.Text = "Download";
			buttonDownload.UseVisualStyleBackColor = true;
			buttonDownload.Click += ButtonDownload_Click;
			// 
			// labelDownloadStatus
			// 
			labelDownloadStatus.AutoSize = true;
			labelDownloadStatus.BackColor = SystemColors.Control;
			labelDownloadStatus.Location = new Point(594, 192);
			labelDownloadStatus.Name = "labelDownloadStatus";
			labelDownloadStatus.Size = new Size(96, 15);
			labelDownloadStatus.TabIndex = 10;
			labelDownloadStatus.Text = "Download Status";
			labelDownloadStatus.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// labelTitle
			// 
			labelTitle.AutoSize = true;
			labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			labelTitle.Location = new Point(272, 38);
			labelTitle.Name = "labelTitle";
			labelTitle.Size = new Size(390, 32);
			labelTitle.TabIndex = 11;
			labelTitle.Text = "Convert Links or Download Directly";
			// 
			// FormMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(891, 450);
			Controls.Add(labelTitle);
			Controls.Add(labelDownloadStatus);
			Controls.Add(buttonDownload);
			Controls.Add(progressBarDownload);
			Controls.Add(buttonDownloadPath);
			Controls.Add(labelDownloadPath);
			Controls.Add(textBoxDownloadPath);
			Controls.Add(textBoxLinkOutput);
			Controls.Add(buttonConvert);
			Controls.Add(textBoxLinkInput);
			Controls.Add(labelLinkOutput);
			Controls.Add(labelLinkInput);
			Name = "FormMain";
			Text = "Download via IP";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelLinkInput;
		private Label labelLinkOutput;
		private TextBox textBoxLinkInput;
		private Button buttonConvert;
		private TextBox textBoxLinkOutput;
		private TextBox textBoxDownloadPath;
		private Label labelDownloadPath;
		private Button buttonDownloadPath;
		private FolderBrowserDialog folderBrowserDialogDownloadPath;
		private ProgressBar progressBarDownload;
		private Button buttonDownload;
		private Label labelDownloadStatus;
		private Label labelTitle;
	}
}
