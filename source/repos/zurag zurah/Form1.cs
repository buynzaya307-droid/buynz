using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace zurag_zurah
{
    public partial class Form1 : Form
    {
        private bool drawing = false;
        private Color penColor = Color.Black;
        private float penWidth = 2f;
        private string mode = "rect"; // Anhdagchaar dorwoljin

        private List<Shape> shapes = new List<Shape>();
        private Shape currentShape = null;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // Eventuudiig holboh
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ComboBox deer anhnii utga songoh (Hэр ni cmbWidth bol)
            if (cmbWidth != null && cmbWidth.Items.Count > 0)
            {
                cmbWidth.SelectedIndex = 0;
            }
        }

        // 1. Shugam songoh towch
        private void btnLine_Click(object sender, EventArgs e)
        {
            mode = "line";
        }

        // 2. Dorwoljin songoh towch
        private void btnRect_Click(object sender, EventArgs e)
        {
            mode = "rect";
        }

        // 3. Ongo solih towch (ColorDialog ashiglah)
        private void btnColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    penColor = colorDialog.Color;
                }
            }
        }

        // 4. Zuraasnii orgon solih (ComboBox)
        private void cmbWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWidth.SelectedItem != null)
            {
                if (float.TryParse(cmbWidth.SelectedItem.ToString(), out float width))
                {
                    penWidth = width;
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drawing = true;

                if (mode == "line")
                {
                    currentShape = new LineDraw(penColor, penWidth, e.Location);
                }
                else if (mode == "rect")
                {
                    currentShape = new RectDraw(penColor, penWidth, e.Location);
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing && currentShape != null)
            {
                currentShape.End = e.Location;
                this.Invalidate(); // Dahin zuruulah
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing && currentShape != null)
            {
                currentShape.End = e.Location;
                shapes.Add(currentShape); // Jagsaaltad hadgalah
                currentShape = null;
                drawing = false;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Umnuh zursan buh dursuudee zugeer haruulah
            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }

            // Odoo yag odoo chirtj baigaa durs
            if (currentShape != null)
            {
                currentShape.Draw(g);
            }
        }
    }
}