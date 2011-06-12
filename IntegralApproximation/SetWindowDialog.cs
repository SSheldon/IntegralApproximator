using System;
using System.Windows.Forms;

namespace IntegralApproximation
{
    public partial class SetWindowDialog : Form
    {
        Parser parser;

        public SetWindowDialog(double xMin, double xMax, double xScale, 
            double yMin, double yMax, double yScale, bool axesOn, bool gridOn, Parser parser)
        {
            InitializeComponent();

            this.parser = parser;

            this.AcceptButton = button1;
            this.CancelButton = button2;

            textBox1.Text = xMin.ToString();
            textBox2.Text = xMax.ToString();
            textBox3.Text = xScale.ToString();
            textBox4.Text = yMin.ToString();
            textBox5.Text = yMax.ToString();
            textBox6.Text = yScale.ToString();
            checkBox1.Checked = axesOn;
            checkBox2.Checked = gridOn;

            checkBox2.Enabled = axesOn;
            if (!axesOn) checkBox2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (parser.IsValidExpression(textBox1.Text) && parser.IsValidExpression(textBox2.Text) &&
                parser.IsValidExpression(textBox3.Text) && parser.IsValidExpression(textBox4.Text) &&
                parser.IsValidExpression(textBox5.Text) && parser.IsValidExpression(textBox6.Text))
            {
                double xMin   = parser.Evaluate(textBox1.Text);
                double xMax   = parser.Evaluate(textBox2.Text);
                double xScale = parser.Evaluate(textBox3.Text);
                double yMin   = parser.Evaluate(textBox4.Text);
                double yMax   = parser.Evaluate(textBox5.Text);
                double yScale = parser.Evaluate(textBox6.Text);

                if (xMin >= xMax || yMin >= yMax || xScale <= 0 || yScale <= 0)
                    MessageBox.Show("Invalid values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    (Owner as IntegralApproximator).SetWindow(
                        xMin,
                        xMax,
                        xScale,
                        yMin,
                        yMax,
                        yScale,
                        checkBox1.Checked,
                        checkBox2.Checked);
                    Close();
                }
            }
            else MessageBox.Show("Invalid values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (Owner as IntegralApproximator).SetWindow(-10, 10, 1, -10, 10, 1, true, true);
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Enabled = checkBox1.Checked;
            if (!checkBox1.Checked) checkBox2.Checked = false;
        }
    }
}
