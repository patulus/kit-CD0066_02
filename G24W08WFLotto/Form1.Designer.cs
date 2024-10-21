namespace G24W08WFLotto
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
            Num1 = new Label();
            Num2 = new Label();
            Num3 = new Label();
            Num4 = new Label();
            Num5 = new Label();
            Num6 = new Label();
            btnGenerate = new Button();
            SuspendLayout();
            // 
            // Num1
            // 
            Num1.BackColor = SystemColors.Info;
            Num1.Font = new Font("맑은 고딕", 36F);
            Num1.Location = new Point(12, 9);
            Num1.Name = "Num1";
            Num1.Size = new Size(169, 283);
            Num1.TabIndex = 0;
            Num1.Text = "0";
            Num1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Num2
            // 
            Num2.BackColor = SystemColors.Info;
            Num2.Font = new Font("맑은 고딕", 36F);
            Num2.Location = new Point(187, 9);
            Num2.Name = "Num2";
            Num2.Size = new Size(169, 283);
            Num2.TabIndex = 0;
            Num2.Text = "0";
            Num2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Num3
            // 
            Num3.BackColor = SystemColors.Info;
            Num3.Font = new Font("맑은 고딕", 36F);
            Num3.Location = new Point(362, 9);
            Num3.Name = "Num3";
            Num3.Size = new Size(169, 283);
            Num3.TabIndex = 0;
            Num3.Text = "0";
            Num3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Num4
            // 
            Num4.BackColor = SystemColors.Info;
            Num4.Font = new Font("맑은 고딕", 36F);
            Num4.Location = new Point(537, 9);
            Num4.Name = "Num4";
            Num4.Size = new Size(169, 283);
            Num4.TabIndex = 0;
            Num4.Text = "0";
            Num4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Num5
            // 
            Num5.BackColor = SystemColors.Info;
            Num5.Font = new Font("맑은 고딕", 36F);
            Num5.Location = new Point(712, 9);
            Num5.Name = "Num5";
            Num5.Size = new Size(169, 283);
            Num5.TabIndex = 0;
            Num5.Text = "0";
            Num5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Num6
            // 
            Num6.BackColor = SystemColors.Info;
            Num6.Font = new Font("맑은 고딕", 36F);
            Num6.Location = new Point(887, 9);
            Num6.Name = "Num6";
            Num6.Size = new Size(169, 283);
            Num6.TabIndex = 0;
            Num6.Text = "0";
            Num6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(12, 303);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(1044, 50);
            btnGenerate.TabIndex = 1;
            btnGenerate.Text = "번호 생성";
            btnGenerate.UseVisualStyleBackColor = true;
            // Q.         (1)       (2)
            btnGenerate.Click += OnGenerate;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 365);
            Controls.Add(btnGenerate);
            Controls.Add(Num6);
            Controls.Add(Num5);
            Controls.Add(Num4);
            Controls.Add(Num3);
            Controls.Add(Num2);
            Controls.Add(Num1);
            Name = "Form1";
            Text = "로또";
            ResumeLayout(false);
        }

        #endregion

        private Label Num1;
        private Label Num2;
        private Label Num3;
        private Label Num4;
        private Label Num5;
        private Label Num6;
        private Button btnGenerate;
    }
}
