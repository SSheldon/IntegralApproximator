using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace IntegralApproximation
{
    public enum IntegralApproximationType
    { LeftSum, RightSum, MidpointSum, Trapezoidal, Simpson }

    public partial class IntegralApproximator : Form
    {
        Approximation approx;
        Parser parser;
        Control lastActiveInputBox;
        Timer timer;

        public IntegralApproximator()
        {
            InitializeComponent();
        }

        private void IntegralApproximator_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            try
            {
                parser = new Parser();
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                MessageBox.Show("Could not load MTParser, likely because it has not been registered.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += (object sender, EventArgs e) =>
                {
                    Control c = ActiveControl;
                    if ((c is TextBox && !(c as TextBox).ReadOnly) || c is DomainUpDown)
                        lastActiveInputBox = c;
                };
            timer.Start();

            this.AcceptButton = this.button1;
            this.lastActiveInputBox = textBox1;

            approx = new Approximation(parser);
            approx.Function = "(x-2)^2+2";
            approx.Start = 0;
            approx.End = 4;
            approx.Intervals = 4;

            textBox1.Text = approx.Function;
            textBox2.Text = approx.Start.ToString();
            textBox3.Text = approx.End.ToString();
            //by changing the text, the index changes, causing the index to be reset
            //and the surrounding numbers to be generated
            domainUpDown1.Text = approx.Intervals.ToString();

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

        //must be called when parameters or window are updated
        private void UpdateGraph(bool recalculate = false)
        {
            zg1.GraphPane.CurveList.Clear();
            zg1.GraphPane.CurveList.AddRange(approx.Graph(
                zg1.GraphPane.XAxis.Scale.Min, zg1.GraphPane.XAxis.Scale.Max, XStep));
            zg1.Refresh();

            if (recalculate) textBox5.Text = approx.Calculate().ToString();
        }

        private void UpdateParameters()
        {
            if (parser.IsValidExpression(textBox2.Text) && parser.IsValidExpression(textBox3.Text) &&
                parser.Evaluate(textBox2.Text) < parser.Evaluate(textBox3.Text))
            {
                approx.Start = parser.Evaluate(textBox2.Text);
                approx.End = parser.Evaluate(textBox3.Text);
            }
            else MessageBox.Show("Invalid interval endpoint.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            int parsed;
            if (Int32.TryParse(domainUpDown1.Text, out parsed) && parsed >= 1)
                approx.Intervals = parsed;
            else MessageBox.Show("Invalid number of subintervals.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (textBox1.Text != "" && parser.IsValidFunction(textBox1.Text))
                approx.Function = textBox1.Text;
            else MessageBox.Show("Invalid equation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            approx.Type = (IntegralApproximationType)comboBox1.SelectedIndex;

            UpdateGraph(recalculate: true);
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
                int index = (sender as Button).TabIndex;
                if (index == 29)
                    control.Text = control.Text.Remove(control.Text.Length - 1);
                else if (index == 35)
                    control.Text = "";
                else
                    control.Text += InsertKeyValue(index);                    
                ActiveControl = control;
                if (control is TextBox) (control as TextBox).Select(control.Text.Length, 0);
                if (control is DomainUpDown) (control as DomainUpDown).Select(control.Text.Length, 0);
            }
        }

        private string InsertKeyValue(int index)
        {
            switch (index)
            {
                case 0:  return "sqrt(";
                case 1:  return "abs(";
                case 2:  return "fact(";
                case 3:  return "sin(";
                case 4:  return "cos(";
                case 5:  return "tan(";
                case 6:  return "^2";
                case 7:  return "log10(";
                case 8:  return "log(";
                case 9:  return "asin(";
                case 10: return "acos(";
                case 11: return "atan(";
                case 12: return "floor(";
                case 13: return "ceil(";
                case 14: return "round(";
                case 15: return "1/sin(";
                case 16: return "1/cos(";
                case 17: return "1/tan(";
                case 18: return "x";
                case 19: return "pi";
                case 20: return "e";
                case 21: return "sinh(";
                case 22: return "cosh(";
                case 23: return "tanh(";
                case 24: return "%";
                case 25: return "7";
                case 26: return "4";
                case 27: return "1";
                case 28: return "0";
                //   29 is backspace
                case 30: return "(";
                case 31: return "8";
                case 32: return "5";
                case 33: return "2";
                case 34: return ".";
                //   35 is clear
                case 36: return ")";
                case 37: return "9";
                case 38: return "6";
                case 39: return "3";
                case 40: return "x";
                case 41: return "^";
                case 42: return "/";
                case 43: return "*";
                case 44: return "-";
                case 45: return "+";
                default: return "";
            }
        }
    }
}
