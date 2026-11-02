namespace zurag_zurah
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
            btnLine = new Button();
            btnRect = new Button();
            btnColor = new Button();
            cmbWidth = new ComboBox();
            colorDialog1 = new ColorDialog();
            SuspendLayout();
            // 
            // btnLine
            // 
            btnLine.Location = new Point(0, 0);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(94, 29);
            btnLine.TabIndex = 0;
            btnLine.Text = "Шугам";
            btnLine.UseVisualStyleBackColor = true;
            // 
            // btnRect
            // 
            btnRect.Location = new Point(111, 0);
            btnRect.Name = "btnRect";
            btnRect.Size = new Size(110, 29);
            btnRect.TabIndex = 1;
            btnRect.Text = "Дөрвөлжин";
            btnRect.UseVisualStyleBackColor = true;
            // 
            // btnColor
            // 
            btnColor.Location = new Point(254, 0);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(150, 29);
            btnColor.TabIndex = 2;
            btnColor.Text = "Өнгө солих";
            btnColor.UseVisualStyleBackColor = true;
            // 
            // cmbWidth
            // 
            cmbWidth.FormattingEnabled = true;
            cmbWidth.Items.AddRange(new object[] { "2", "5", "10", "15" });
            cmbWidth.Location = new Point(439, 12);
            cmbWidth.Name = "cmbWidth";
            cmbWidth.Size = new Size(151, 28);
            cmbWidth.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cmbWidth);
            Controls.Add(btnColor);
            Controls.Add(btnRect);
            Controls.Add(btnLine);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnLine;
        private Button btnRect;
        private Button btnColor;
        private ComboBox cmbWidth;
        private ColorDialog colorDialog1;
    }
}
