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
        private string mode = "Дөрвөлжин"; // Анхдагч горим

        private List<Shape> shapes = new List<Shape>();
        private Shape currentShape = null;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // Mouse event-үүд
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;

            // ComboBox болон товчлууруудыг холбох
            if (cmbShape != null) cmbShape.SelectedIndexChanged += cmbShape_SelectedIndexChanged;
            if (cmbWidth != null) cmbWidth.SelectedIndexChanged += cmbWidth_SelectedIndexChanged;

            // Баллуур товчийг дархад баллуур горимд шилжих
            Control[] foundEraserBtn = this.Controls.Find("btnClear", true); // Designer дээрх баллуурын товч
            if (foundEraserBtn.Length > 0 && foundEraserBtn[0] is Button bEraser)
            {
                bEraser.Click += (s, e) => { mode = "eraser"; };
            }

            Control[] foundColorBtn = this.Controls.Find("btnColor", true);
            if (foundColorBtn.Length > 0 && foundColorBtn[0] is Button bColor)
            {
                bColor.Click += btnColor_Click;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (cmbShape != null && cmbShape.Items.Count > 0)
            {
                cmbShape.SelectedIndex = 1;
            }
            if (cmbWidth != null && cmbWidth.Items.Count > 0)
            {
                cmbWidth.SelectedIndex = 0;
            }
        }

        private void cmbShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbShape.SelectedItem != null)
            {
                string selected = cmbShape.SelectedItem.ToString();
                if (selected == "Шугам") mode = "line";
                else if (selected == "Дөрвөлжин") mode = "rect";
                else if (selected == "Дугуй") mode = "ellipse";
                else if (selected == "Гурвалжин") mode = "triangle";
            }
        }

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

                if (mode == "eraser")
                {
                    EraseShapeAt(e.Location);
                }
                else if (mode == "line")
                {
                    currentShape = new LineDraw(penColor, penWidth, e.Location);
                }
                else if (mode == "rect")
                {
                    currentShape = new RectDraw(penColor, penWidth, e.Location);
                }
                else if (mode == "ellipse")
                {
                    currentShape = new EllipseDraw(penColor, penWidth, e.Location);
                }
                else if (mode == "triangle")
                {
                    currentShape = new TriangleDraw(penColor, penWidth, e.Location);
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                if (mode == "eraser")
                {
                    // Хулганаа чирэх үед зам дагуу тасралтгүй арчих
                    EraseShapeAt(e.Location);
                }
                else if (currentShape != null)
                {
                    currentShape.End = e.Location;
                    this.Invalidate();
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                if (mode != "eraser" && currentShape != null)
                {
                    currentShape.End = e.Location;
                    shapes.Add(currentShape);
                    currentShape = null;
                }
                drawing = false;
                this.Invalidate();
            }
        }

        // Сайжруулсан баллуурын функц (Зөвхөн хүрсэн цэг дээрх хамгийн дээрх дүрсийг устгана)
        private void EraseShapeAt(Point location)
        {
            int eraserRadius = (int)(penWidth * 2);
            if (eraserRadius < 5) eraserRadius = 5;

            Shape shapeToRemove = null;

            // Жагсаалтыг хойноос нь (хамгийн сүүлд зурсан дүрсээс эхлэн) шалгах
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                var shape = shapes[i];

                int minX = Math.Min(shape.Start.X, shape.End.X);
                int maxX = Math.Max(shape.Start.X, shape.End.X);
                int minY = Math.Min(shape.Start.Y, shape.End.Y);
                int maxY = Math.Max(shape.Start.Y, shape.End.Y);

                Rectangle bounds = new Rectangle(
                    minX - eraserRadius,
                    minY - eraserRadius,
                    (maxX - minX) + (eraserRadius * 2),
                    (maxY - minY) + (eraserRadius * 2)
                );

                if (bounds.Contains(location))
                {
                    shapeToRemove = shape;
                    break; // Нэг удаад зөвхөн нэг дүрсийг олж устгаад зогсоно
                }
            }

            if (shapeToRemove != null)
            {
                shapes.Remove(shapeToRemove);
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var shape in shapes)
            {
                shape.Draw(g);
            }

            if (currentShape != null)
            {
                currentShape.Draw(g);
            }
        }
    }
}