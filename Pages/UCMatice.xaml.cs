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
using static MaticeApp.Utils;

namespace MaticeApp
{
    /// <summary>
    /// Interaction logic for UCMatice.xaml
    /// </summary>
    public partial class UCMatice : UserControl
    {
        public UCMatice()
        {
            InitializeComponent();
            SetMatrices();
            SetHighlighters();
        }

        private void SetHighlighters() // Temporary solution
        {
            SarrusHighlighter matrix2Highlighter = new SarrusHighlighter(matrix2, Color.FromArgb(40, 0, 255, 0), Color.FromArgb(40, 0, 255, 0));
            matrix2Highlighter.Highlight(0, 0);
            SarrusHighlighter matrix4Highlighter = new SarrusHighlighter(matrix4, Color.FromArgb(40, 0, 255, 0), Color.FromArgb(40, 0, 255, 0));
            matrix4Highlighter.Highlight(0, 0);

            SarrusHighlighter matrix5Highlighter = new SarrusHighlighter(matrix5, Color.FromArgb(40, 0, 255, 0), Color.FromArgb(40, 0, 255, 0));
            matrix5Highlighter.Highlight(0, 2);
            SarrusHighlighter matrix7Highlighter = new SarrusHighlighter(matrix7, Color.FromArgb(40, 0, 255, 0), Color.FromArgb(40, 0, 255, 0));
            matrix7Highlighter.Highlight(0, 2);

            SingleElementHighlighter matrix3Highlighter1 = new SingleElementHighlighter(matrix3, Color.FromArgb(40, 0, 255, 0));
            matrix3Highlighter1.Highlight(0, 0);
            SingleElementHighlighter matrix3Highlighter2 = new SingleElementHighlighter(matrix3, Color.FromArgb(40, 0, 255, 0));
            matrix3Highlighter2.Highlight(1, 1);
            SingleElementHighlighter matrix3Highlighter3 = new SingleElementHighlighter(matrix3, Color.FromArgb(40, 0, 255, 0));
            matrix3Highlighter3.Highlight(2, 2);

            SingleElementHighlighter matrix6Highlighter1 = new SingleElementHighlighter(matrix6, Color.FromArgb(40, 0, 255, 0));
            matrix6Highlighter1.Highlight(0, 3);
            SingleElementHighlighter matrix6Highlighter2 = new SingleElementHighlighter(matrix6, Color.FromArgb(40, 0, 255, 0));
            matrix6Highlighter2.Highlight(1, 2);
            SingleElementHighlighter matrix6Highlighter3 = new SingleElementHighlighter(matrix6, Color.FromArgb(40, 0, 255, 0));
            matrix6Highlighter3.Highlight(2, 1);
        }

        private void SetMatrices()
        {
            string[,] matrixData =
            {
                { "a_11_", "a_12_", "...", "a_1n_" },
                { "a_21_", "a_22_", "...", "a_2n_" },
                { "⋮", "⋮", "⋱", "⋮" },
                { "a_m1_", "a_m2_", "...", "a_mn_" }
            };
            matrix1.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "a_11_", "a_12_", "a_13_" },
                { "a_21_", "a_22_", "a_23_" },
                { "a_31_", "a_32_", "a_33_" }
            };
            matrix2.SetMatrix(matrixData);
            matrix5.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "a_11_", "a_12_", "a_13_", "a_14_" },
                { "a_21_", "a_22_", "a_23_", "a_24_" },
                { "a_31_", "a_32_", "a_33_", "a_34_" }
            };
            matrix3.SetMatrix(matrixData);
            matrix6.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "a_11_", "a_12_", "a_13_" },
                { "a_21_", "a_22_", "a_23_" },
                { "a_31_", "a_32_", "a_33_" },
                { "a_41_", "a_42_", "a_43_" }
            };
            matrix4.SetMatrix(matrixData);
            matrix7.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "r_1_", "r_2_", "...", "r_n_" }
            };
            matrix8.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "c_1_" },
                { "c_2_" },
                { "⋮" },
                { "c_m_" },
            };
            matrix9.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "0", "0", "...", "0" },
                { "0", "0", "...", "0" },
                { "⋮", "⋮", "⋱", "⋮"},
                { "0", "0", "...", "0" }
            };
            matrix10.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "a_11_", "a_12_", "a_13_", "...", "a_1n_"},
                { "0", "a_22_", "a_23_", "...", "a_2n_"},
                { "0", "0", "a_33_", "...", "a_3n_"},
                { "⋮", "⋮", "⋮", "⋱", "⋮"},
                { "0", "0", "0", "...", "a_nn_"}
            };
            matrix11.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "b_11_", "0", "0", "...", "0"},
                { "b_21_", "b_22_", "0", "...", "0"},
                { "b_31_", "b_32_", "b_33_", "...", "0"},
                { "⋮", "⋮", "⋮", "⋱", "⋮"},
                { "b_n1_", "b_n2_", "b_n3_", "...", "b_nn_"}
            };
            matrix12.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "1", "0", "0", "...", "0"},
                { "0", "1", "0", "...", "0"},
                { "0", "0", "1", "...", "0"},
                { "⋮", "⋮", "⋮", "⋱", "⋮"},
                { "0", "0", "0", "...", "1"}
            };
            matrix13.SetMatrix(matrixData);
        }

        private void Matrix_Loaded(object sender, RoutedEventArgs e)
        {
            Matrix ?matrix = (sender as Matrix);
            if (matrix == null || matrix.Tag == null) return;
            switch (matrix.Tag.ToString())
            {
                case "":
                    break;
            }
        }
    }
}
