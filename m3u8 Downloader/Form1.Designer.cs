namespace m3u8_Downloader
{
    partial class formMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbSavePath = new System.Windows.Forms.Label();
            this.lbSourceUrl = new System.Windows.Forms.Label();
            this.lbFileName = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.tbSavePath = new System.Windows.Forms.TextBox();
            this.tbSourceUrl = new System.Windows.Forms.TextBox();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.lbCopyRight = new System.Windows.Forms.Label();
            this.lbExtension = new System.Windows.Forms.Label();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.tbFfmpegPath = new System.Windows.Forms.TextBox();
            this.btnFfmpegPath = new System.Windows.Forms.Button();
            this.lbFfmpegPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbSavePath
            // 
            this.lbSavePath.AutoSize = true;
            this.lbSavePath.Location = new System.Drawing.Point(13, 56);
            this.lbSavePath.Name = "lbSavePath";
            this.lbSavePath.Size = new System.Drawing.Size(65, 12);
            this.lbSavePath.TabIndex = 0;
            this.lbSavePath.Text = "下載目的地";
            // 
            // lbSourceUrl
            // 
            this.lbSourceUrl.AutoSize = true;
            this.lbSourceUrl.Location = new System.Drawing.Point(12, 107);
            this.lbSourceUrl.Name = "lbSourceUrl";
            this.lbSourceUrl.Size = new System.Drawing.Size(44, 12);
            this.lbSourceUrl.TabIndex = 1;
            this.lbSourceUrl.Text = "來源Url";
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Location = new System.Drawing.Point(12, 155);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.Size = new System.Drawing.Size(29, 12);
            this.lbFileName.TabIndex = 2;
            this.lbFileName.Text = "檔名";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(340, 211);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "下載";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(358, 74);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(57, 23);
            this.btnSavePath.TabIndex = 4;
            this.btnSavePath.Text = "選擇...";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // tbSavePath
            // 
            this.tbSavePath.Location = new System.Drawing.Point(15, 75);
            this.tbSavePath.Name = "tbSavePath";
            this.tbSavePath.ReadOnly = true;
            this.tbSavePath.Size = new System.Drawing.Size(337, 22);
            this.tbSavePath.TabIndex = 5;
            // 
            // tbSourceUrl
            // 
            this.tbSourceUrl.Location = new System.Drawing.Point(15, 124);
            this.tbSourceUrl.Name = "tbSourceUrl";
            this.tbSourceUrl.Size = new System.Drawing.Size(337, 22);
            this.tbSourceUrl.TabIndex = 6;
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(14, 172);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(337, 22);
            this.tbFileName.TabIndex = 7;
            // 
            // lbCopyRight
            // 
            this.lbCopyRight.AutoSize = true;
            this.lbCopyRight.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lbCopyRight.Location = new System.Drawing.Point(286, 237);
            this.lbCopyRight.Name = "lbCopyRight";
            this.lbCopyRight.Size = new System.Drawing.Size(139, 12);
            this.lbCopyRight.TabIndex = 8;
            this.lbCopyRight.Text = "COPYRIGHTS © 2020 Visy";
            // 
            // lbExtension
            // 
            this.lbExtension.AutoSize = true;
            this.lbExtension.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbExtension.Location = new System.Drawing.Point(352, 177);
            this.lbExtension.Name = "lbExtension";
            this.lbExtension.Size = new System.Drawing.Size(40, 16);
            this.lbExtension.TabIndex = 9;
            this.lbExtension.Text = ".mp4";
            // 
            // pbDownload
            // 
            this.pbDownload.BackColor = System.Drawing.SystemColors.GrayText;
            this.pbDownload.ForeColor = System.Drawing.Color.Red;
            this.pbDownload.Location = new System.Drawing.Point(14, 211);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(315, 23);
            this.pbDownload.TabIndex = 10;
            // 
            // tbFfmpegPath
            // 
            this.tbFfmpegPath.Location = new System.Drawing.Point(16, 26);
            this.tbFfmpegPath.Name = "tbFfmpegPath";
            this.tbFfmpegPath.ReadOnly = true;
            this.tbFfmpegPath.Size = new System.Drawing.Size(337, 22);
            this.tbFfmpegPath.TabIndex = 13;
            // 
            // btnFfmpegPath
            // 
            this.btnFfmpegPath.Location = new System.Drawing.Point(359, 25);
            this.btnFfmpegPath.Name = "btnFfmpegPath";
            this.btnFfmpegPath.Size = new System.Drawing.Size(57, 23);
            this.btnFfmpegPath.TabIndex = 12;
            this.btnFfmpegPath.Text = "選擇...";
            this.btnFfmpegPath.UseVisualStyleBackColor = true;
            this.btnFfmpegPath.Click += new System.EventHandler(this.btnFfmpegPath_Click);
            // 
            // lbFfmpegPath
            // 
            this.lbFfmpegPath.AutoSize = true;
            this.lbFfmpegPath.Location = new System.Drawing.Point(14, 7);
            this.lbFfmpegPath.Name = "lbFfmpegPath";
            this.lbFfmpegPath.Size = new System.Drawing.Size(87, 12);
            this.lbFfmpegPath.TabIndex = 11;
            this.lbFfmpegPath.Text = "ffmepg啟動位置";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 250);
            this.Controls.Add(this.tbFfmpegPath);
            this.Controls.Add(this.btnFfmpegPath);
            this.Controls.Add(this.lbFfmpegPath);
            this.Controls.Add(this.pbDownload);
            this.Controls.Add(this.lbExtension);
            this.Controls.Add(this.lbCopyRight);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.tbSourceUrl);
            this.Controls.Add(this.tbSavePath);
            this.Controls.Add(this.btnSavePath);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lbFileName);
            this.Controls.Add(this.lbSourceUrl);
            this.Controls.Add(this.lbSavePath);
            this.Name = "formMain";
            this.Text = "m3u8 Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSavePath;
        private System.Windows.Forms.Label lbSourceUrl;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.TextBox tbSavePath;
        private System.Windows.Forms.TextBox tbSourceUrl;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label lbCopyRight;
        private System.Windows.Forms.Label lbExtension;
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.TextBox tbFfmpegPath;
        private System.Windows.Forms.Button btnFfmpegPath;
        private System.Windows.Forms.Label lbFfmpegPath;
    }
}

