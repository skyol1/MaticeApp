using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MaticeApp.Highlighters
{
    public class SarrusHighlighter : MatrixHighlihgter
    {
        private List<Rectangle> _highlightRectangles = new List<Rectangle>();
        public Color secondaryColor;
        public SarrusHighlighter(Matrix dstMatrix, Color color1, Color color2) : base(dstMatrix, color1) { secondaryColor = color2; }
        public override void Highlight(int row, int column)
        {
            int rows = dstMatrix.RowsCount;
            int cols = dstMatrix.ColumnsCount;
            var color = highlightColor;

            // "\" shape
            int d = row - column;
            if (d >= 0 && d + (cols - 1) < rows)
            {
                int startRow = d, startCol = 0;

                for (int k = 0; k < cols; k++)
                {
                    int r0 = startRow + k, c0 = startCol + k;

                    AddHighlightMultiple(r0, c0, r0, c0, color);
                }
            }

            // "/" shape
            int s = row + column - (cols - 1);
            if (s >= 0 && s + (cols - 1) < rows)
            {
                int startRow = s, startCol = cols - 1;
                for (int k = 0; k < cols; k++)
                {
                    int r0 = startRow + k, c0 = startCol - k;
                    AddHighlightMultiple(r0, c0, r0, c0, secondaryColor);
                }
            }
        }


        public override void ClearHighlight()
        {
            RemoveHighlights();
        }

        private void AddHighlightMultiple(int rowA, int colA, int rowB, int colB, Color color)
        {
            if (rowA > rowB)
            {
                var tempRow = rowA;
                rowA = rowB;
                rowB = tempRow;
            }
            if (colA > colB)
            {
                var tempCol = colA;
                colA = colB;
                colB = tempCol;
            }
            // Calculate the position and size of the rectangle
            double top = rowA * Matrix.RowHeight;
            double left = colA * dstMatrix.CellWidth;
            double height = (rowB - rowA + 1) * Matrix.RowHeight;
            double width = (colB - colA + 1) * dstMatrix.CellWidth;

            // Create the rectangle for highlighting
            Rectangle newHighlightRectangle = new Rectangle
            {
                Stroke = Brushes.Red, // Color of the highlight border
                StrokeThickness = 2,
                Fill = new SolidColorBrush(color), // Semi-transparent fill
                Width = width,
                Height = height,
                IsHitTestVisible = false // Make sure the highlight doesn't block interaction
            };
            _highlightRectangles.Add(newHighlightRectangle);
            // Position the rectangle over the diagonal
            Canvas.SetLeft(newHighlightRectangle, left);
            Canvas.SetTop(newHighlightRectangle, top);

            // Add the rectangle to the highlight canvas
            dstMatrix.GetHighlightCanvas().Children.Add(newHighlightRectangle);
            isHighlighted = true;
        }

        protected void RemoveHighlights()
        {
            foreach (var highlight in _highlightRectangles)
            {
                dstMatrix.GetHighlightCanvas().Children.Remove(highlight);
            }
            _highlightRectangles.Clear();
            isHighlighted = false;
        }

    }
}
