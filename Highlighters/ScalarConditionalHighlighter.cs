using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Documents;
using System.Windows.Media;

namespace MaticeApp.Highlighters
{
    public class ScalarConditionalHighlighter : BaseHighlighter
    {
        private Run dstRun;
        Predicate<Tuple<int, int>> condition;
        public ScalarConditionalHighlighter(Run dstRun, Color color,Predicate<Tuple<int,int>> pred) : base(color) { this.dstRun = dstRun; condition = pred; }
        public override void ClearHighlight()
        {
            RemoveHighlight();
        }
        public override void Highlight(int row, int column)
        {
            if (condition(new Tuple<int, int>(row, column)))
                AddHighlight(highlightColor);
        }
        protected void AddHighlight(Color color)
        {
            if (isHighlighted) { return; }
            dstRun.Background = new SolidColorBrush(highlightColor);
            isHighlighted = true;
        }
        protected void RemoveHighlight()
        {
            if (!isHighlighted) { return; }
            dstRun.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            isHighlighted = false;
        }
    }
}