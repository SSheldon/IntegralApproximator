using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace IntegralApproximation
{
    public partial class IntegralApproximator : Form
    {
        double start, end;
        int intervals;
        string function;
        Parser parser;
        Control lastActiveInputBox;
        Timer timer;

        public IntegralApproximator()
        {
            InitializeComponent();

            start = 0;
            end = 4;
            intervals = 4;
            function = "(x-2)^2+2";

            parser = new Parser();

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += (object sender, EventArgs e) =>
                {
                    Control c = ActiveControl;
                    if ((c is TextBox && !(c as TextBox).ReadOnly) || c is DomainUpDown)
                        lastActiveInputBox = c;
                };
            timer.Start();
        }

        private void IntegralApproximator_Load(object sender, EventArgs e)
        {
            this.AcceptButton = this.button1;
            this.lastActiveInputBox = textBox1;

            textBox1.Text = function;
            textBox2.Text = start.ToString();
            textBox3.Text = end.ToString();
            //by changing the text, the index changes, causing the index to be reset
            //and the surrounding numbers to be generated
            domainUpDown1.Text = intervals.ToString();

            InitializeGraph();
            zg1.ZoomEvent += new ZedGraphControl.ZoomEventHandler(zg1_ZoomEvent);

            //by setting the index, UpdateGraph() is called
            comboBox1.SelectedIndex = 0;
        }

        private void InitializeGraph()
        {
            //Lock the graph
            //zg1.IsEnableZoom = false;
            //zg1.IsEnableHPan = false;
            //zg1.IsEnableVPan = false;            
            zg1.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(RemoveStuff);

            GraphPane pane = zg1.GraphPane;
            pane.Margin.Top = 0;
            pane.Margin.Bottom = -4;
            pane.Margin.Left = -5;
            pane.Margin.Right = 1;
            pane.Title.IsVisible = false;
            pane.Legend.IsVisible = false;
            pane.XAxis.Title.IsVisible = false;
            pane.YAxis.Title.IsVisible = false;
            pane.XAxis.Scale.IsVisible = false;
            pane.YAxis.Scale.IsVisible = false;
            pane.XAxis.MinorTic.IsAllTics = false;
            pane.YAxis.MinorTic.IsAllTics = false;
            pane.XAxis.MajorTic.IsOpposite = false;
            pane.YAxis.MajorTic.IsOpposite = false;
            pane.XAxis.Cross = 0;
            pane.YAxis.Cross = 0;
            pane.XAxis.MajorGrid.DashOn = 0;
            pane.XAxis.MajorGrid.Color = Color.LightGray;
            pane.YAxis.MajorGrid.DashOn = 0;
            pane.YAxis.MajorGrid.Color = Color.LightGray;

            SetWindow(-10, 10, 1, -10, 10, 1, true, true);
        }

        void RemoveStuff(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
        {
            for (int counter = menuStrip.Items.Count - 1; counter >= 0; counter--)
            {
                if (menuStrip.Items[counter].Tag.ToString() == "set_default" ||
                    menuStrip.Items[counter].Tag.ToString() == "page_setup" ||
                    menuStrip.Items[counter].Tag.ToString() == "print" ||
                    menuStrip.Items[counter].Tag.ToString() == "show_val")
                {
                    menuStrip.Items.Remove(menuStrip.Items[counter]);
                }
            }
        }

        public void SetWindow(double xMin, double xMax, double xScale, double yMin, double yMax, double yScale, bool axesOn, bool gridOn)
        {
            zg1.GraphPane.XAxis.Scale.Min = xMin;
            zg1.GraphPane.XAxis.Scale.Max = xMax;
            zg1.GraphPane.XAxis.Scale.MajorStep = xScale;
            zg1.GraphPane.YAxis.Scale.Min = yMin;
            zg1.GraphPane.YAxis.Scale.Max = yMax;
            zg1.GraphPane.YAxis.Scale.MajorStep = yScale;
            zg1.GraphPane.XAxis.IsVisible = axesOn;
            zg1.GraphPane.YAxis.IsVisible = axesOn;
            zg1.GraphPane.XAxis.MajorGrid.IsVisible = gridOn;
            zg1.GraphPane.YAxis.MajorGrid.IsVisible = gridOn;

            UpdateGraph();
        }

        #region Graphing Methods

        private void GraphFunction()
        {
            double[] x = CalculateFunctionXValues(zg1.GraphPane.XAxis.Scale.Min, zg1.GraphPane.XAxis.Scale.Max);
            LineItem function = zg1.GraphPane.AddCurve("Function", x, Function(x), Color.Red, SymbolType.None);
            function.Line.IsSmooth = false;
        }

        private void GraphLeftSum()
        {
            double[] x = CalculateIntervalXValues();
            double[] leftEndpoints = new double[intervals];
            for (int counter = 0; counter < intervals; counter++)
            {
                leftEndpoints[counter] = x[counter];
            }
            GraphRectangles(Function(leftEndpoints));
        }

        private void GraphRightSum()
        {
            double[] x = CalculateIntervalXValues();
            double[] rightEndpoints = new double[intervals];
            for (int counter = 0; counter < intervals; counter++)
            {
                rightEndpoints[counter] = x[counter + 1];
            }
            GraphRectangles(Function(rightEndpoints));
        }

        private void GraphMidpointSum()
        {
            double[] x = CalculateIntervalXValues();
            double[] midpoints = new double[intervals];
            for (int counter = 0; counter < intervals; counter++)
            {
                midpoints[counter] = (x[counter] + x[counter + 1]) / 2D;
            }
            GraphRectangles(Function(midpoints));
        }

        private void GraphTrapezoidalApprox()
        {
            GraphSeperators();

            LineItem approx = zg1.GraphPane.AddCurve("Approx", CalculateIntervalPoints(), Color.Blue, SymbolType.None);
            approx.Line.Fill = new Fill(Color.LightBlue);
        }

        private void GraphSimpsonRule()
        {
            GraphSeperators();

            PointPairList points = new PointPairList();
            double[] endpoints = CalculateIntervalXValues();

            for (int interval = 0; interval < intervals; interval++)
            {
                double a = endpoints[interval];
                double b = endpoints[interval + 1];
                double[] x = CalculateFunctionXValues(a, b);
                points.Add(x, InterpolatedQuadraticFunction(x, a, b));
                //Common endpoints are being added twice...
            }

            LineItem approx = zg1.GraphPane.AddCurve("Approx", points, Color.Blue, SymbolType.None);
            approx.Line.Fill = new Fill(Color.LightBlue);
            approx.Line.IsSmooth = false;
        }

        private void GraphSeperators()
        {
            GraphSeperators(CalculateIntervalPoints());
        }

        private void GraphSeperators(PointPairList endpoints)
        {
            PointPairList points = new PointPairList();
            endpoints.Sort(SortType.XValues);

            points.Add(endpoints[0]);
            for (int counter = 0; counter < endpoints.Count - 1; counter++)
            {
                points.Add(endpoints[counter].X, 0);
                points.Add(endpoints[counter + 1].X, 0);
                points.Add(endpoints[counter + 1]);
            }

            LineItem seperator = zg1.GraphPane.AddCurve("Seperator", points, Color.Blue, SymbolType.None);
        }

        private void GraphRectangles(double[] heights)
        {
            if (heights.Length != intervals) return;
            double[] x = CalculateIntervalXValues();

            PointPairList endpoints = new PointPairList();
            endpoints.Add(x[0], heights[0]);
            for (int counter = 1; counter < intervals; counter++) endpoints.Add(x[counter], heights[counter]);
            endpoints.Add(x[intervals], heights[intervals - 1]);
            GraphSeperators(endpoints);

            PointPairList points = new PointPairList();
            for (int counter = 0; counter < intervals; counter++)
            {
                points.Add(x[counter], heights[counter]);
                points.Add(x[counter + 1], heights[counter]);
            }
            LineItem approx = zg1.GraphPane.AddCurve("Approx", points, Color.Blue, SymbolType.None);
            approx.Line.Fill = new Fill(Color.LightBlue);
        }

        #endregion

        private PointPairList CalculateIntervalPoints()
        {
            double[] x = CalculateIntervalXValues();
            return new PointPairList(x, Function(x));
        }

        private double[] CalculateIntervalXValues()
        {
            double[] x = new double[intervals + 1];
            x[0] = start;
            for (int counter = 1; counter < intervals; counter++)
            {
                x[counter] = start + (double)counter * ((end - start) / (double)intervals);
            }
            x[intervals] = end;
            return x;
        }

        private double[] CalculateFunctionXValues(double start, double end)
        {
            double[] x = new double[(int)Math.Floor((end - start) / XStep) + 1];
            for (int counter = 0; counter < x.Length; counter++)
            {
                x[counter] = start + XStep * (double)counter;
            }
            return x;
        }

        private double[] Function(double[] x)
        {
            return parser.Evaluate(function, x);
        }

        private double Function(double x)
        {
            return parser.Evaluate(function, x);
        }

        private double InterpolatedQuadraticFunction(double x, double a, double b)
        {
            double m = (a + b) / 2D;
            return Function(a) * (((x - m) * (x - b)) / ((a - m) * (a - b))) +
                Function(m) * (((x - a) * (x - b)) / ((m - a) * (m - b))) +
                Function(b) * (((x - a) * (x - m)) / ((b - a) * (b - m)));
        }

        private double[] InterpolatedQuadraticFunction(double[] x, double a, double b)
        {
            double[] y = new double[x.Length];
            double m = (a + b) / 2D;
            double fA = Function(a);
            double fM = Function(m);
            double fB = Function(b);

            for (int counter = 0; counter < x.Length; counter++)
            {
                y[counter] = fA * (((x[counter] - m) * (x[counter] - b)) / ((a - m) * (a - b))) +
                    fM * (((x[counter] - a) * (x[counter] - b)) / ((m - a) * (m - b))) +
                    fB * (((x[counter] - a) * (x[counter] - m)) / ((b - a) * (b - m)));
            }
            return y;
        }

        #region Approximation Methods

        private double CalculateRightSum()
        {
            double[] x = new double[intervals];
            for (int counter = 0; counter < intervals; counter++)
            {
                x[counter] = start + ((end - start) / (double)intervals) * (double)(counter + 1);
            }
            return Function(x).Sum() * ((end - start) / (double)intervals);
        }

        private double CalculateLeftSum()
        {
            double[] x = new double[intervals];
            for (int counter = 0; counter < intervals; counter++)
            {
                x[counter] = start + ((end - start) / (double)intervals) * (double)(counter);
            }
            return Function(x).Sum() * ((end - start) / (double)intervals);
        }

        private double CalculateMidpointSum()
        {
            double[] x = new double[intervals];
            for (int counter = 0; counter < intervals; counter++)
            {
                x[counter] = start + ((end - start) / (double)intervals) * ((double)counter + .5D);
            }
            return Function(x).Sum() * ((end - start) / (double)intervals);
        }

        private double CalculateTrapezoidalApprox()
        {
            return (CalculateRightSum() + CalculateLeftSum()) / 2D;
        }

        private double CalculateSimpsonRule()
        {
            return (2D * CalculateMidpointSum() + CalculateTrapezoidalApprox()) / 3D;
        }

        #endregion

        //must be called when parameters or window are updated
        private void UpdateGraph()
        {
            zg1.GraphPane.CurveList.Clear();

            GraphFunction();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    GraphLeftSum();
                    break;
                case 1:
                    GraphRightSum();
                    break;
                case 2:
                    GraphMidpointSum();
                    break;
                case 3:
                    GraphTrapezoidalApprox();
                    break;
                case 4:
                    GraphSimpsonRule();
                    break;
            }

            zg1.Refresh();
        }

        private void UpdateParameters()
        {
            if (parser.IsValidExpression(textBox2.Text) && parser.IsValidExpression(textBox3.Text) &&
                parser.Evaluate(textBox2.Text) < parser.Evaluate(textBox3.Text))
            {
                start = parser.Evaluate(textBox2.Text);
                end = parser.Evaluate(textBox3.Text);
            }
            else MessageBox.Show("Invalid interval endpoint.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            int parsed;
            if (!Int32.TryParse(domainUpDown1.Text, out parsed))
            {
                MessageBox.Show("Invalid number of subintervals.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (parsed < 1) MessageBox.Show("Invalid number of subintervals.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else intervals = parsed;
            }

            if (textBox1.Text != "" && parser.IsValidFunction(textBox1.Text))
                function = textBox1.Text;
            else MessageBox.Show("Invalid equation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            UpdateGraph();
            UpdateApproximation();
        }

        //must be called when parameters are updated
        private void UpdateApproximation()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    textBox5.Text = CalculateLeftSum().ToString();
                    break;
                case 1:
                    textBox5.Text = CalculateRightSum().ToString();
                    break;
                case 2:
                    textBox5.Text = CalculateMidpointSum().ToString();
                    break;
                case 3:
                    textBox5.Text = CalculateTrapezoidalApprox().ToString();
                    break;
                case 4:
                    textBox5.Text = CalculateSimpsonRule().ToString();
                    break;
            }
        }

        double XStep
        {
            get
            {
                //for 1 line segment per pixel
                //Step = (Resolution * (Max - Min)) / Pixels
                return (zg1.GraphPane.XAxis.Scale.Max - zg1.GraphPane.XAxis.Scale.Min) /
                  (zg1.Size.Width - (6 + (int)zg1.GraphPane.Margin.Left) - (int)zg1.GraphPane.Margin.Right);
            }
        }

        void zg1_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            UpdateGraph();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateParameters();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetWindowDialog a = new SetWindowDialog(
                zg1.GraphPane.XAxis.Scale.Min,
                zg1.GraphPane.XAxis.Scale.Max,
                zg1.GraphPane.XAxis.Scale.MajorStep,
                zg1.GraphPane.YAxis.Scale.Min,
                zg1.GraphPane.YAxis.Scale.Max,
                zg1.GraphPane.YAxis.Scale.MajorStep,
                zg1.GraphPane.XAxis.IsVisible,
                zg1.GraphPane.XAxis.MajorGrid.IsVisible,
                parser);
            a.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = tabControl1.Visible ? false : true;
            button3.Text = tabControl1.Visible ? "Hide Insert Keys" : "Show Insert Keys";
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            domainUpDown1.Items.Clear();
            int parsed;
            if (Int32.TryParse(domainUpDown1.Text, out parsed))
            {
                domainUpDown1.Items.Add(parsed < 1 ? "1" : (parsed + 1).ToString());
                domainUpDown1.Items.Add(parsed.ToString());
                if (parsed > 1) domainUpDown1.Items.Add((parsed - 1).ToString());
                domainUpDown1.SelectedIndex = 1;
            }
        }

        private void InsertKey_Click(object sender, EventArgs e)
        {
            Control control = lastActiveInputBox;

            if ((control is TextBox && !(control as TextBox).ReadOnly) || control is DomainUpDown)
            {
                switch ((sender as Button).TabIndex)
                {
                    case 0:
                        control.Text += "sqrt(";
                        break;
                    case 1:
                        control.Text += "abs(";
                        break;
                    case 2:
                        control.Text += "fact(";
                        break;
                    case 3:
                        control.Text += "sin(";
                        break;
                    case 4:
                        control.Text += "cos(";
                        break;
                    case 5:
                        control.Text += "tan(";
                        break;
                    case 6:
                        control.Text += "^2";
                        break;
                    case 7:
                        control.Text += "log10(";
                        break;
                    case 8:
                        control.Text += "log(";
                        break;
                    case 9:
                        control.Text += "asin(";
                        break;
                    case 10:
                        control.Text += "acos(";
                        break;
                    case 11:
                        control.Text += "atan(";
                        break;
                    case 12:
                        control.Text += "floor(";
                        break;
                    case 13:
                        control.Text += "ceil(";
                        break;
                    case 14:
                        control.Text += "round(";
                        break;
                    case 15:
                        control.Text += "1/sin(";
                        break;
                    case 16:
                        control.Text += "1/cos(";
                        break;
                    case 17:
                        control.Text += "1/tan(";
                        break;
                    case 18:
                        control.Text += "x";
                        break;
                    case 19:
                        control.Text += "pi";
                        break;
                    case 20:
                        control.Text += "e";
                        break;
                    case 21:
                        control.Text += "sinh(";
                        break;
                    case 22:
                        control.Text += "cosh(";
                        break;
                    case 23:
                        control.Text += "tanh(";
                        break;
                    case 24:
                        control.Text += "%";
                        break;
                    case 25:
                        control.Text += "7";
                        break;
                    case 26:
                        control.Text += "4";
                        break;
                    case 27:
                        control.Text += "1";
                        break;
                    case 28:
                        control.Text += "0";
                        break;
                    case 29:
                        control.Text = control.Text.Remove(control.Text.Length - 1);
                        break;
                    case 30:
                        control.Text += "(";
                        break;
                    case 31:
                        control.Text += "8";
                        break;
                    case 32:
                        control.Text += "5";
                        break;
                    case 33:
                        control.Text += "2";
                        break;
                    case 34:
                        control.Text += ".";
                        break;
                    case 35:
                        control.Text = "";
                        break;
                    case 36:
                        control.Text += ")";
                        break;
                    case 37:
                        control.Text += "9";
                        break;
                    case 38:
                        control.Text += "6";
                        break;
                    case 39:
                        control.Text += "3";
                        break;
                    case 40:
                        control.Text += "x";
                        break;
                    case 41:
                        control.Text += "^";
                        break;
                    case 42:
                        control.Text += "/";
                        break;
                    case 43:
                        control.Text += "*";
                        break;
                    case 44:
                        control.Text += "-";
                        break;
                    case 45:
                        control.Text += "+";
                        break;
                }
                ActiveControl = control;
                if (control is TextBox) (control as TextBox).Select(control.Text.Length, 0);
                if (control is DomainUpDown) (control as DomainUpDown).Select(control.Text.Length, 0);
            }
        }
    }
}
