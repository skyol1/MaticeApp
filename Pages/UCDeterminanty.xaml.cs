using MaticeApp.Highlighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaticeApp
{
    /// <summary>
    /// Interaction logic for UCDeterminanty.xaml
    /// </summary>
    public partial class UCDeterminanty : UserControl
    {
        DeterminantHighlighter highlighterMatrix4_1, highlighterMatrix5_1, highlighterMatrix6_5;

        public UCDeterminanty()
        {
            InitializeComponent();
            SetMatrices();
            SetPopups();
            SetHighlighters();
        }

        private void SetMatrices()
        {
            string[,] matrixData =
            {
                { "-5" }
            };
            matrix1.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "1", "2" },
                { "3", "4" }
            };
            matrix2.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "1", "-1", "5" },
                { "1", "3", "3" },
                { "-2", "5", "-4" }
            };
            matrix3_0.SetMatrix(matrixData);
            matrix3_1.BracketType = Matrix.Bracket.Straight;
            matrix3_1.SetMatrix(matrixData);
            matrix3_1.MakeSarrus();
            matrix3_1.ChangeToHighlightBorders();

            matrixData = new string[,]
            {
                { "1", "5", "2", "3" },
                { "-3", "-13", "-7", "-8" },
                { "2", "0", "12", "-10" },
                { "-4", "-18", "-6", "-17" },
            };
            matrix4_0.SetMatrix(matrixData);

            matrix4_1.BracketType = Matrix.Bracket.Straight;
            matrix4_1.SetMatrix(matrixData);

            matrix5_0.SetMatrix(matrixData);

            matrix5_1.BracketType = Matrix.Bracket.Straight;
            matrix5_1.SetMatrix(matrixData);

            matrix6_0.SetMatrix(matrixData);

            matrix6_1.SetMatrix(matrixData);
            matrix6_1.RowAddMultiplied(0, 1, "3");

            matrixData = new string[,]
            {
                { "1", "5", "2", "3" },
                { "0", "2", "-1", "1" },
                { "2", "0", "12", "-10" },
                { "-4", "-18", "-6", "-17" },
            };
            matrix6_2.SetMatrix(matrixData);
            matrix6_2.RowAddMultiplied(0, 2, "-2");

            matrixData = new string[,]
            {
                { "1", "5", "2", "3" },
                { "0", "2", "-1", "1" },
                { "0", "-10", "8", "-16" },
                { "-4", "-18", "-6", "-17" },
            };
            matrix6_3.SetMatrix(matrixData);
            matrix6_3.RowAddMultiplied(0, 3, "4");

            matrixData = new string[,]
            {
                { "1", "5", "2", "3" },
                { "0", "2", "-1", "1" },
                { "0", "-10", "8", "-16" },
                { "0", "2", "2", "-5" },
            };
            matrix6_4.SetMatrix(matrixData);

            matrix6_5.BracketType = Matrix.Bracket.Straight;
            matrix6_5.SetMatrix(matrixData);

            matrix6_6.SetMatrix(matrixData);
            matrix6_6.RowAddMultiplied(1, 2, "5");

            matrixData = new string[,]
            {
                { "1", "5", "2", "3" },
                { "0", "2", "-1", "1" },
                { "0", "0", "3", "-11" },
                { "0", "2", "2", "-5" },
            };
            matrix6_7.SetMatrix(matrixData);
            matrix6_7.RowAddMultiplied(1, 3, "-1");

            matrixData = new string[,]
            {
                { "1", "5", "2", "3" },
                { "0", "2", "-1", "1" },
                { "0", "0", "3", "-11" },
                { "0", "0", "3", "-6" },
            };
            matrix6_8.SetMatrix(matrixData);
            matrix6_8.RowAddMultiplied(2, 3, "-1");

            matrixData = new string[,]
            {
                { "1", "5", "2", "3" },
                { "0", "2", "-1", "1" },
                { "0", "0", "3", "-11" },
                { "0", "0", "0", "5" },
            };
            matrix6_9.SetMatrix(matrixData);

            matrix6_10.BracketType = Matrix.Bracket.Straight;
            matrix6_10.SetMatrix(matrixData);



            matrixData = new string[,]
            {
                { "-13", "-7", "-8" },
                { "0", "12", "-10" },
                { "-18", "-6", "-17" },
            };
            matrix4_1_0.BracketType = Matrix.Bracket.Straight;
            matrix4_1_0.SetMatrix(matrixData);
            matrix4_1_0.MakeSarrus();

            matrixData = new string[,]
            {
                { "-3", "-7", "-8" },
                { "2", "12", "-10" },
                { "-4", "-6", "-17" },
            };
            matrix4_1_1.BracketType = Matrix.Bracket.Straight;
            matrix4_1_1.SetMatrix(matrixData);
            matrix4_1_1.MakeSarrus();

            matrixData = new string[,]
            {
                { "-3", "-13", "-8" },
                { "2", "0", "-10" },
                { "-4", "-18", "-17" },
            };
            matrix4_1_2.BracketType = Matrix.Bracket.Straight;
            matrix4_1_2.SetMatrix(matrixData);
            matrix4_1_2.MakeSarrus();

            matrixData = new string[,]
            {
                { "-3", "-13", "-7" },
                { "2", "0", "12" },
                { "-4", "-18", "-6" },
            };
            matrix4_1_3.BracketType = Matrix.Bracket.Straight;
            matrix4_1_3.SetMatrix(matrixData);
            matrix4_1_3.MakeSarrus();



            matrixData = new string[,]
            {
                { "5", "2", "3" },
                { "-13", "-7", "-8" },
                { "-18", "-6", "-17" }
            };
            matrix5_1_1.BracketType = Matrix.Bracket.Straight;
            matrix5_1_1.SetMatrix(matrixData);
            matrix5_1_1.MakeSarrus();

            matrixData = new string[,]
            {
                { "1", "5", "3" },
                { "-3", "-13", "-8" },
                { "-4", "-18", "-17" }
            };
            matrix5_1_3.BracketType = Matrix.Bracket.Straight;
            matrix5_1_3.SetMatrix(matrixData);
            matrix5_1_3.MakeSarrus();

            matrixData = new string[,]
            {
                { "1", "5", "2", },
                { "-3", "-13", "-7", },
                { "-4", "-18", "-6", }
            };
            matrix5_1_4.BracketType = Matrix.Bracket.Straight;
            matrix5_1_4.SetMatrix(matrixData);
            matrix5_1_4.MakeSarrus();



            matrixData = new string[,]
            {
                { "2", "-1", "1" },
                { "-10", "8", "-16" },
                { "2", "2", "-5" }
            };
            matrix6_5_1.SetMatrix(matrixData);
            matrix6_5_1.MakeSarrus();
        }

        private void SetPopups()
        {
            highlighterMatrix4_1 = new DeterminantHighlighter(matrix4_1, Color.FromArgb(40, 0, 255, 0), Color.FromArgb(40, 0, 0, 255));
            highlighterMatrix5_1 = new DeterminantHighlighter(matrix5_1, Color.FromArgb(40, 0, 255, 0), Color.FromArgb(40, 0, 0, 255));
            highlighterMatrix6_5 = new DeterminantHighlighter(matrix6_5, Color.FromArgb(40, 0, 255, 0), Color.FromArgb(40, 0, 0, 255));
        }

        private void SetHighlighters()
        {
            matrix3_1.highlighters.Add(new SarrusHighlighter(matrix3_1, Color.FromArgb(40, 0, 255, 0), Color.FromArgb(40, 0, 0, 255)));
            matrix3_1.highlighters.Add(new ScalarConditionalHighlighter(Saurus1, Color.FromArgb(40, 0, 255, 0),
                (Tuple<int, int> a) => { return a.Item1 - a.Item2 == 0; }));
            matrix3_1.highlighters.Add(new ScalarConditionalHighlighter(Saurus2, Color.FromArgb(40, 0, 255, 0),
                (Tuple<int, int> a) => { return a.Item1 - a.Item2 == 1; }));
            matrix3_1.highlighters.Add(new ScalarConditionalHighlighter(Saurus3, Color.FromArgb(40, 0, 255, 0),
                (Tuple<int, int> a) => { return a.Item1 - a.Item2 == 2; }));

            matrix3_1.highlighters.Add(new ScalarConditionalHighlighter(Saurus4, Color.FromArgb(40, 0, 0, 255),
                (Tuple<int, int> a) => { return a.Item1 + a.Item2 == 2; }));
            matrix3_1.highlighters.Add(new ScalarConditionalHighlighter(Saurus5, Color.FromArgb(40, 0, 0, 255),
                (Tuple<int, int> a) => { return a.Item1 + a.Item2 == 3; }));
            matrix3_1.highlighters.Add(new ScalarConditionalHighlighter(Saurus6, Color.FromArgb(40, 0, 0, 255),
                (Tuple<int, int> a) => { return a.Item1 + a.Item2 == 4; }));
        }


        private void HighlightBorder_4_1_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            switch (border.Tag.ToString())
            {
                case "4_1_0":
                    highlighterMatrix4_1.Highlight(0, 0);
                    break;
                case "4_1_1":
                    highlighterMatrix4_1.Highlight(0, 1);
                    break;
                case "4_1_2":
                    highlighterMatrix4_1.Highlight(0, 2);
                    break;
                case "4_1_3":
                    highlighterMatrix4_1.Highlight(0, 3);
                    break;
            }
        }
        private void HighlightBorder_4_1_MouseLeave(object sender, MouseEventArgs e)
        {
            highlighterMatrix4_1.ClearHighlight();
        }

        private void HighlightBorder_5_1_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            switch (border.Tag.ToString())
            {
                case "5_1_1":
                    highlighterMatrix5_1.Highlight(2, 0);
                    break;
                case "5_1_2":
                    highlighterMatrix5_1.Highlight(2, 1);
                    break;
                case "5_1_3":
                    highlighterMatrix5_1.Highlight(2, 2);
                    break;
                case "5_1_4":
                    highlighterMatrix5_1.Highlight(2, 3);
                    break;
            }
        }
        private void HighlightBorder_5_1_MouseLeave(object sender, MouseEventArgs e)
        {
            highlighterMatrix5_1.ClearHighlight();
        }

        private void HighlightBorder_6_5_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = (Border)sender;
            switch (border.Tag.ToString())
            {
                case "6_5_1":
                    highlighterMatrix6_5.Highlight(0, 0);
                    break;
            }
        }
        private void HighlightBorder_6_5_MouseLeave(object sender, MouseEventArgs e)
        {
            highlighterMatrix6_5.ClearHighlight();
        }
    }
}
