using System;
using System.Drawing;
using System.Windows.Forms;


namespace DrawingApp
{
    public partial class Form1 : Form
    {
        private bool isDrawing;
        private Point startPoint;
        private Point endPoint;
        private Bitmap drawingBitmap;
        private Graphics drawingGraphics;
        public Form1()
        {
            InitializeComponent();
            InitializeDrawing();
        }

       
        private void InitializeDrawing()
        {
            drawingBitmap = new Bitmap(drawingPanel.Width, drawingPanel.Height);
            drawingGraphics = Graphics.FromImage(drawingBitmap);
            drawingGraphics.Clear(Color.White); // Set the background color
        }


        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            startPoint = e.Location;
        }

        private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                endPoint = e.Location;
                drawingPanel.Invalidate(); // Causes the panel to be redrawn
            }
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                isDrawing = false;
                endPoint = e.Location;

                // Draw the final line or shape on the bitmap
                drawingGraphics.DrawLine(Pens.Black, startPoint, endPoint);

                drawingPanel.Invalidate(); // Causes the panel to be redrawn
            }
        }

        private void drawingPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(drawingBitmap, Point.Empty);

            if (isDrawing)
            {
                // Draw a preview of the line or shape being drawn
                e.Graphics.DrawLine(Pens.Black, startPoint, endPoint);
            }
        }
    }
}
