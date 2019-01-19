using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace task_5_dop
{
    public partial class MainForm : Form
    {
        private int indexRow;
        private int indexColumn;

        public MainForm()
        {
            InitializeComponent();
        }


        private void SegmentData_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = (TextBox)e.Control;
            tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            tb.LostFocus += Tb_LostFocus;
        }

        private void Tb_LostFocus(object sender, EventArgs e)
        {
            indexRow = SegmentData.CurrentCell.RowIndex;
            indexColumn = SegmentData.CurrentCell.ColumnIndex;
            string tb = (sender as TextBox).Text;
            tb = editText(tb);
            SegmentData.Rows[indexRow].Cells[indexColumn].Value = tb;
        }

        private string editText(string tb)
        {
            if (tb.Length == 0)
                return "0";
            else
            {
                Double.TryParse(tb, out double var);
                return var.ToString();
            }
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox text = sender as TextBox;
            e.Handled = !CorrectWriteFunction(e.KeyChar, text);
        }

        private bool CorrectWriteFunction(char ch, TextBox text)
        {
            switch (ch)
            {
                case '\b':
                    return true;

                case '-':
                    if (text.Text.Length == 0)
                    {
                        return true;
                    }
                    else if (text.SelectionStart == 0)
                    {
                        if (text.Text[0] != '-')
                        {
                            return true;
                        }
                    }
                    return false;

                default:
                    {
                        if (Char.IsDigit(ch))
                            return true;
                        else if (ch != ',' && !Char.IsDigit(ch) && ch != '\b')
                            return false;
                        else if (ch == ',')
                        {
                            if (IsPoint(text.Text))
                                return true;
                            else
                                return false;
                        }
                        return false;
                    }
            }
        }

        private bool IsPoint(string text)
        {
            int CountPoint = 0; int Index = 0;
            if (text.Length == 0)
                return false;
            while ((Index = text.IndexOf(',', Index + 1)) != -1)
                CountPoint++;
            if (CountPoint > 0)
                return false;
            return true;
        }

        private void SegmentData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            indexColumn = e.ColumnIndex;
        }

        private void CreateGraphic_Click(object sender, EventArgs e)
        {
            // проверка на количество отрезков
            if(SegmentData.Rows.Count <= 1)
            {
                MessageBox.Show("Добавьте хотя бы один отрезок");
                return;
            }
            StringBuilder _out = new StringBuilder();

            // конструируем лист отрезков
            List<Segment> segm = new List<Segment>();
            for(int i = 0;i<SegmentData.Rows.Count-1;i++)
            {
                Double.TryParse(SegmentData.Rows[i].Cells[0].Value.ToString(), out double n1);
                Double.TryParse(SegmentData.Rows[i].Cells[1].Value.ToString(), out double n2);
                Double.TryParse(SegmentData.Rows[i].Cells[2].Value.ToString(), out double n3);
                Double.TryParse(SegmentData.Rows[i].Cells[3].Value.ToString(), out double n4);

                // проверка на вырожденные отрезки
                if((n1 == n3) && (n2 == n4))
                {
                    _out.AppendLine($"Отрезок {i + 1} вырожденный. На графике отображён не будет");
                    continue;
                }

                segm.Add(new Segment(n1, n2, n3, n4));
            }
            if(_out.ToString() != "")
            {
                MessageBox.Show(_out.ToString());
                if (segm.Count == 0)
                    return;
            }

            // очищаем предыдущий график
            ChartGraphic.Series.Clear();

            // вычисляем размеры графика
            double MinX = segm[0].MinX, MaxX = segm[0].MaxX, MinY = segm[0].MinY, MaxY = segm[0].MaxY;
            for (int i = 1; i < segm.Count; i++)
            {
                if (MinX > segm[i].MinX)
                    MinX = segm[i].MinX;
                if (MaxX < segm[i].MaxX)
                    MaxX = segm[i].MaxX;
                if (MinY > segm[i].MinY)
                    MinY = segm[i].MinY;
                if (MaxY < segm[i].MaxY)
                    MaxY = segm[i].MaxY;
            }

            // вычисляем пересечения отрезков, если таковые есть
            for (int i = 0;i<segm.Count;i++)
            {
                for(int j = i + 1;j<segm.Count;j++)
                {
                    PointF? p = segm[i].GetPointIntersectionInequality(segm[j]);
                    if (p != null)
                    {
                        segm[i].AddPoint(p.Value.X, p.Value.Y);
                    }
                }
            }

            // сортируем отрезки слева направо и сверух вниз
            for(int i = 0;i<segm.Count;i++) // тут может быть ошибка, но я не подобрал отрезков таких...если встретишь ошибку, пиши
            {
                segm[i].XY.Sort(new SortedPointsDrawLineLeftToRightX());
                segm[i].XY.Sort(new SortedPointsDrawLineLeftToRightY());
            }

            // настраиваем отображение графика
            DoubleBuffered = true;
            double max = MaxX > MaxY ? MaxX : MaxY; max += 5;
            ChartGraphic.ChartAreas[0].AxisX.Maximum = MaxX; ;
            ChartGraphic.ChartAreas[0].AxisX.Minimum = MinX;
            ChartGraphic.ChartAreas[0].AxisY.Maximum = MaxY;
            ChartGraphic.ChartAreas[0].AxisY.Minimum = MinY;
            ChartGraphic.ChartAreas[0].AxisX.Interval = 1; 
            ChartGraphic.ChartAreas[0].AxisY.Interval = 1;
            //ChartGraphic.ChartAreas[0].AxisX.Title = "X\u2082";
            //ChartGraphic.ChartAreas[0].AxisY.Title = "X\u2081";
            //ChartGraphic.ChartAreas[0].AxisY.TextOrientation = TextOrientation.Horizontal;
            ChartGraphic.ChartAreas[0].AxisX.Crossing = 0;
            ChartGraphic.ChartAreas[0].AxisY.Crossing = 0;
            ChartGraphic.ChartAreas[0].AxisX.IntervalOffset = 0;
            ChartGraphic.ChartAreas[0].AxisY.IntervalOffset = 0;

            // отрисовываем все отрезки и точки пересечения
            for (int i = 0; i < segm.Count; i++)
            {
                ChartGraphic.Series.Add("");
                ChartGraphic.Series[i].IsVisibleInLegend = false;
                ChartGraphic.Series[i].ChartType = SeriesChartType.Line;
                for(int j = 0;j<segm[i].XY.Count;j++)
                {
                    ChartGraphic.Series[i].Points.AddXY(segm[i].XY[j].X, segm[i].XY[j].Y);
                    ChartGraphic.Series[i].Points[j].Label = string.Format("[" + segm[i].XY[j].X + ";" + segm[i].XY[j].Y + "]");
                    ChartGraphic.Series[i].Points[j].MarkerStyle = MarkerStyle.Circle;
                }
            }

        }

        private void ClearTable_Click(object sender, EventArgs e)
        {
            SegmentData.Rows.Clear();
        }
    }

    class SortedPointsDrawLineLeftToRightX : IComparer<PointF>
    {
        public int Compare(PointF p1, PointF p2)
        {
            if (p1.X > p2.X)
                return 1;
            return -1;
        }
    }

    class SortedPointsDrawLineLeftToRightY : IComparer<PointF>
    {
        public int Compare(PointF p1, PointF p2)
        {
            if (p1.Y > p2.Y)
                return 1;
            return -1;
        }
    }
}
