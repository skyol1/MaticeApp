using MaticeApp.Highlighters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for UCInverznaMatica.xaml
    /// </summary>
    public partial class UCInverznaMatica : UserControl
    {
        public UCInverznaMatica()
        {
            InitializeComponent();
            SetMatrices();
            SetPopups();
        }

        private void SetMatrices()
        {
            string[,] matrixData =
            {
                { "D_11_", "D_21_", "...", "D_n1_"  },
                { "D_12_", "D_22_", "...", "D_n2_"  },
                { "⋮", "⋮", "⋱", "⋮" },
                { "D_1n_", "D_2n_", "...", "D_nn_"  },
            };
            matrix1.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "1", "2", "3", "4" },
                { "5", "6", "7", "8" },
                { "9", "10", "11", "12" },
                { "13", "14", "15", "16" }
            };
            matrix1_1.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                { "1", "2", "4" },
                { "9", "10", "12" },
                { "13", "14", "16" }
            };
            matrix1_2.BracketType = Matrix.Bracket.Straight;
            matrix1_2.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                {"6", "-7"},
                {"2", "-2"}
            };
            matrix2.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                {"-2", "7"},
                {"-2", "6"}
            };
            matrix3.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                {"-1", "3.5"},
                {"-1", "3"}
            };
            matrix4.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                {"-3", "-10", "-6"},
                {"4", "2", "4"},
                {"3", "-5", "1"}
            };
            matrix5.SetMatrix(matrixData);

            matrixData = new string[,]
            {
                {"22", "40", "-28"},
                {"8", "15", "-12"},
                {"-26", "-45", "34"}
            };
            matrix6.SetMatrix(matrixData);
            
            matrixData = new string[,]
            {
                {"2.2", "4", "-2.8"},
                {"0.8", "1.5", "-1.2"},
                {"-2.6", "-4.5", "3.4"}
            };
            matrix7.SetMatrix(matrixData);
        }

        private void SetPopups()
        {
            DeterminantHighlighter highlighterMatrix1_1 = new DeterminantHighlighter(matrix1_1, Color.FromArgb(40, 0, 255, 0), Color.FromArgb(40, 0, 0, 255));
            highlighterMatrix1_1.Highlight(1, 2);
        }
    }
}
