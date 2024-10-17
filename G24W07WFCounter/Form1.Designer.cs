namespace G24W07WFCounter
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
            btnAdd = new Button();
            labelCount = new Label();
            btnSub = new Button();
            btnReset = new Button();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 400);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "증가";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += OnAdd;
            // 
            // labelCount
            // 
            labelCount.BackColor = SystemColors.Info;
            labelCount.Font = new Font("맑은 고딕", 36F);
            labelCount.Location = new Point(12, 9);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(435, 372);
            labelCount.TabIndex = 1;
            labelCount.Text = "0";
            labelCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSub
            // 
            btnSub.Location = new Point(353, 400);
            btnSub.Name = "btnSub";
            btnSub.Size = new Size(94, 29);
            btnSub.TabIndex = 2;
            btnSub.Text = "감소";
            btnSub.UseVisualStyleBackColor = true;
            btnSub.Click += OnSub;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(187, 400);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(94, 29);
            btnReset.TabIndex = 3;
            btnReset.Text = "초기화";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += OnReset;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(459, 441);
            Controls.Add(btnReset);
            Controls.Add(btnSub);
            Controls.Add(labelCount);
            Controls.Add(btnAdd);
            Name = "Form1";
            Text = "카운터";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAdd;
        private Label labelCount;
        private Button btnSub;
        private Button btnReset;
    }
}
