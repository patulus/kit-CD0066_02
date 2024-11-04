namespace G24W10WFCardDealer
{
    partial class Form1
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
            Card1 = new PictureBox();
            CardDealButton = new Button();
            ((System.ComponentModel.ISupportInitialize)Card1).BeginInit();
            SuspendLayout();
            // 
            // Card1
            // 
            Card1.Image = Properties.Resources.red_joker;
            Card1.Location = new Point(12, 12);
            Card1.Name = "Card1";
            Card1.Size = new Size(270, 390);
            Card1.SizeMode = PictureBoxSizeMode.Zoom;
            Card1.TabIndex = 0;
            Card1.TabStop = false;
            // 
            // CardDealButton
            // 
            CardDealButton.Location = new Point(12, 408);
            CardDealButton.Name = "CardDealButton";
            CardDealButton.Size = new Size(270, 54);
            CardDealButton.TabIndex = 1;
            CardDealButton.Text = "카드 분배";
            CardDealButton.UseVisualStyleBackColor = true;
            CardDealButton.Click += OnDeal;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 474);
            Controls.Add(CardDealButton);
            Controls.Add(Card1);
            Name = "Form1";
            Text = "카드 딜러";
            ((System.ComponentModel.ISupportInitialize)Card1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Card1;
        private Button CardDealButton;
    }
}
