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
            btnColor = new Button();
            cmbWidth = new ComboBox();
            colorDialog1 = new ColorDialog();
            cmbShape = new ComboBox();
            btnClear = new Button();
            SuspendLayout();
            // 
            // btnColor
            // 
            btnColor.BackColor = Color.FromArgb(255, 192, 192);
            btnColor.Location = new Point(186, 12);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(151, 28);
            btnColor.TabIndex = 2;
            btnColor.Text = "Өнгө солих";
            btnColor.UseVisualStyleBackColor = false;
            // 
            // cmbWidth
            // 
            cmbWidth.BackColor = Color.FromArgb(255, 192, 192);
            cmbWidth.FormattingEnabled = true;
            cmbWidth.Items.AddRange(new object[] { "2", "5", "10", "15" });
            cmbWidth.Location = new Point(362, 12);
            cmbWidth.Name = "cmbWidth";
            cmbWidth.Size = new Size(98, 28);
            cmbWidth.TabIndex = 3;
            cmbWidth.Text = "Хэмжээ";
            // 
            // cmbShape
            // 
            cmbShape.BackColor = Color.FromArgb(255, 192, 192);
            cmbShape.FormattingEnabled = true;
            cmbShape.Items.AddRange(new object[] { "Шугам", "Дөрвөлжин", "Дугуй", "Гурвалжин" });
            cmbShape.Location = new Point(12, 12);
            cmbShape.Name = "cmbShape";
            cmbShape.Size = new Size(152, 28);
            cmbShape.TabIndex = 4;
            cmbShape.Text = "Дүрс";
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(255, 192, 192);
            btnClear.Location = new Point(493, 15);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(94, 29);
            btnClear.TabIndex = 5;
            btnClear.Text = "Баллуур";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(800, 450);
            Controls.Add(btnClear);
            Controls.Add(cmbShape);
            Controls.Add(cmbWidth);
            Controls.Add(btnColor);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button btnColor;
        private ComboBox cmbWidth;
        private ColorDialog colorDialog1;
        private ComboBox cmbShape;
        private Button btnClear;
    }
}
