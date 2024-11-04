namespace ImageViewer
{
    partial class ImageViewer
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
            PbImage = new PictureBox();
            BtnImage = new Button();
            ((System.ComponentModel.ISupportInitialize)PbImage).BeginInit();
            SuspendLayout();
            // 
            // PbImage
            // 
            PbImage.Location = new Point(12, 12);
            PbImage.Name = "PbImage";
            PbImage.Size = new Size(351, 353);
            PbImage.SizeMode = PictureBoxSizeMode.Zoom;
            PbImage.TabIndex = 0;
            PbImage.TabStop = false;
            // 
            // BtnImage
            // 
            BtnImage.Location = new Point(12, 371);
            BtnImage.Name = "BtnImage";
            BtnImage.Size = new Size(351, 47);
            BtnImage.TabIndex = 1;
            BtnImage.Text = "이미지 출력";
            BtnImage.UseVisualStyleBackColor = true;
            BtnImage.Click += OnShowImage;
            // 
            // ImageViewer
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(375, 430);
            Controls.Add(BtnImage);
            Controls.Add(PbImage);
            Name = "ImageViewer";
            Text = "GUI 중간고사";
            ((System.ComponentModel.ISupportInitialize)PbImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PbImage;
        private Button BtnImage;
    }
}
