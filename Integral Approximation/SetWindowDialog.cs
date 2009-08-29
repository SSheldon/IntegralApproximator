using System;
using System.Windows.Forms;
using MTPARSERCOMLib;

namespace Integral_Approximation
{
    public partial class SetWindowDialog : Form
    {
        MTParserClass parser;

        public SetWindowDialog(double xMin, double xMax, double xScale, 
            double yMin, double yMax, double yScale, bool axesOn, bool gridOn, MTParserClass parser)
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
            try
            {
                parser.undefineAllVars();
                if (parser.evaluate(textBox1.Text) >= parser.evaluate(textBox2.Text) ||
                    parser.evaluate(textBox4.Text) >= parser.evaluate(textBox5.Text) ||
                    parser.evaluate(textBox3.Text) <= 0 || parser.evaluate(textBox6.Text) <= 0)
                {
                    MessageBox.Show("Invalid values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    (Owner as IntegralApproximator).SetWindow(
                        parser.evaluate(textBox1.Text),
                        parser.evaluate(textBox2.Text),
                        parser.evaluate(textBox3.Text),
                        parser.evaluate(textBox4.Text),
                        parser.evaluate(textBox5.Text),
                        parser.evaluate(textBox6.Text),
                        checkBox1.Checked,
                        checkBox2.Checked);
                    Close();
                }
            }
            catch
            {
                MessageBox.Show("Invalid values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
