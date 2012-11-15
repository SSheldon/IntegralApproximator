namespace IntegralApproximation
{
    partial class IntegralApproximator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntegralApproximator));
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button15 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button40 = new System.Windows.Forms.Button();
            this.button46 = new System.Windows.Forms.Button();
            this.button45 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button44 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.button43 = new System.Windows.Forms.Button();
            this.button31 = new System.Windows.Forms.Button();
            this.button42 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button41 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.button39 = new System.Windows.Forms.Button();
            this.button35 = new System.Windows.Forms.Button();
            this.button38 = new System.Windows.Forms.Button();
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button47 = new System.Windows.Forms.Button();
            this.button48 = new System.Windows.Forms.Button();
            this.button49 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zg1
            // 
            this.zg1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zg1.Location = new System.Drawing.Point(12, 12);
            this.zg1.Name = "zg1";
            this.zg1.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zg1.ScrollGrace = 0D;
            this.zg1.ScrollMaxX = 0D;
            this.zg1.ScrollMaxY = 0D;
            this.zg1.ScrollMaxY2 = 0D;
            this.zg1.ScrollMinX = 0D;
            this.zg1.ScrollMinY = 0D;
            this.zg1.ScrollMinY2 = 0D;
            this.zg1.Size = new System.Drawing.Size(542, 542);
            this.zg1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Left Riemann Sum",
            "Right Riemann Sum",
            "Midpoint Sum",
            "Trapezoidal Rule Approximation",
            "Simpson\'s Rule Approximation"});
            this.comboBox1.Location = new System.Drawing.Point(560, 14);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(590, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 20);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(694, 147);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Graph";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(656, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(656, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Stop:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(620, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Subintervals:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(694, 67);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(86, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(694, 93);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(86, 20);
            this.textBox3.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(602, 147);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Set Window";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(560, 202);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(220, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Show Insert Keys";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(560, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Approximation:";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(636, 176);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(144, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(560, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "f(x) =";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-3, 554);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(262, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Created by Steven Sheldon steven.sheldon@live.com";
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.domainUpDown1.Location = new System.Drawing.Point(694, 119);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(86, 20);
            this.domainUpDown1.TabIndex = 6;
            this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(560, 231);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(226, 206);
            this.tabControl1.TabIndex = 47;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button15);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.button10);
            this.tabPage1.Controls.Add(this.button11);
            this.tabPage1.Controls.Add(this.button12);
            this.tabPage1.Controls.Add(this.button13);
            this.tabPage1.Controls.Add(this.button14);
            this.tabPage1.Controls.Add(this.button16);
            this.tabPage1.Controls.Add(this.button17);
            this.tabPage1.Controls.Add(this.button18);
            this.tabPage1.Controls.Add(this.button19);
            this.tabPage1.Controls.Add(this.button20);
            this.tabPage1.Controls.Add(this.button21);
            this.tabPage1.Controls.Add(this.button22);
            this.tabPage1.Controls.Add(this.button23);
            this.tabPage1.Controls.Add(this.button24);
            this.tabPage1.Controls.Add(this.button25);
            this.tabPage1.Controls.Add(this.button26);
            this.tabPage1.Controls.Add(this.button27);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(218, 180);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Advanced";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(112, 64);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(47, 23);
            this.button15.TabIndex = 14;
            this.button15.Text = "round";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "√x";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 35);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "| x |";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 64);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 23);
            this.button6.TabIndex = 2;
            this.button6.Text = "x!";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(6, 93);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 23);
            this.button7.TabIndex = 3;
            this.button7.Text = "sin";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(6, 122);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(47, 23);
            this.button8.TabIndex = 4;
            this.button8.Text = "cos";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(6, 151);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(47, 23);
            this.button9.TabIndex = 5;
            this.button9.Text = "tan";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(59, 6);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(47, 23);
            this.button10.TabIndex = 6;
            this.button10.Text = "x²";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(59, 35);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(47, 23);
            this.button11.TabIndex = 7;
            this.button11.Text = "log";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(59, 64);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(47, 23);
            this.button12.TabIndex = 8;
            this.button12.Text = "ln";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(59, 93);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(47, 23);
            this.button13.TabIndex = 9;
            this.button13.Text = "arcsin";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(59, 122);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(47, 23);
            this.button14.TabIndex = 10;
            this.button14.Text = "arccos";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(59, 151);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(47, 23);
            this.button16.TabIndex = 11;
            this.button16.Text = "arctan";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(112, 6);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(47, 23);
            this.button17.TabIndex = 12;
            this.button17.Text = "floor";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(112, 35);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(47, 23);
            this.button18.TabIndex = 13;
            this.button18.Text = "ceil";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(112, 93);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(47, 23);
            this.button19.TabIndex = 15;
            this.button19.Text = "csc";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(112, 122);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(47, 23);
            this.button20.TabIndex = 16;
            this.button20.Text = "sec";
            this.button20.UseVisualStyleBackColor = true;
            this.button20.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(112, 151);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(47, 23);
            this.button21.TabIndex = 17;
            this.button21.Text = "cot";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(165, 6);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(47, 23);
            this.button22.TabIndex = 18;
            this.button22.Text = "var";
            this.button22.UseVisualStyleBackColor = true;
            this.button22.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button23
            // 
            this.button23.Location = new System.Drawing.Point(165, 35);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(47, 23);
            this.button23.TabIndex = 19;
            this.button23.Text = "pi";
            this.button23.UseVisualStyleBackColor = true;
            this.button23.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(165, 64);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(47, 23);
            this.button24.TabIndex = 20;
            this.button24.Text = "e";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button25
            // 
            this.button25.Location = new System.Drawing.Point(165, 93);
            this.button25.Name = "button25";
            this.button25.Size = new System.Drawing.Size(47, 23);
            this.button25.TabIndex = 21;
            this.button25.Text = "sinh";
            this.button25.UseVisualStyleBackColor = true;
            this.button25.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button26
            // 
            this.button26.Location = new System.Drawing.Point(165, 122);
            this.button26.Name = "button26";
            this.button26.Size = new System.Drawing.Size(47, 23);
            this.button26.TabIndex = 22;
            this.button26.Text = "cosh";
            this.button26.UseVisualStyleBackColor = true;
            this.button26.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button27
            // 
            this.button27.Location = new System.Drawing.Point(165, 151);
            this.button27.Name = "button27";
            this.button27.Size = new System.Drawing.Size(47, 23);
            this.button27.TabIndex = 23;
            this.button27.Text = "tanh";
            this.button27.UseVisualStyleBackColor = true;
            this.button27.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button40);
            this.tabPage2.Controls.Add(this.button46);
            this.tabPage2.Controls.Add(this.button45);
            this.tabPage2.Controls.Add(this.button29);
            this.tabPage2.Controls.Add(this.button44);
            this.tabPage2.Controls.Add(this.button30);
            this.tabPage2.Controls.Add(this.button43);
            this.tabPage2.Controls.Add(this.button31);
            this.tabPage2.Controls.Add(this.button42);
            this.tabPage2.Controls.Add(this.button32);
            this.tabPage2.Controls.Add(this.button41);
            this.tabPage2.Controls.Add(this.button33);
            this.tabPage2.Controls.Add(this.button34);
            this.tabPage2.Controls.Add(this.button39);
            this.tabPage2.Controls.Add(this.button35);
            this.tabPage2.Controls.Add(this.button38);
            this.tabPage2.Controls.Add(this.button36);
            this.tabPage2.Controls.Add(this.button37);
            this.tabPage2.Controls.Add(this.button47);
            this.tabPage2.Controls.Add(this.button48);
            this.tabPage2.Controls.Add(this.button49);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(218, 180);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Basic";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button40
            // 
            this.button40.Location = new System.Drawing.Point(112, 93);
            this.button40.Name = "button40";
            this.button40.Size = new System.Drawing.Size(47, 23);
            this.button40.TabIndex = 39;
            this.button40.Text = "3";
            this.button40.UseVisualStyleBackColor = true;
            this.button40.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button46
            // 
            this.button46.Location = new System.Drawing.Point(165, 122);
            this.button46.Name = "button46";
            this.button46.Size = new System.Drawing.Size(47, 23);
            this.button46.TabIndex = 45;
            this.button46.Text = "+";
            this.button46.UseVisualStyleBackColor = true;
            this.button46.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button45
            // 
            this.button45.Location = new System.Drawing.Point(165, 93);
            this.button45.Name = "button45";
            this.button45.Size = new System.Drawing.Size(47, 23);
            this.button45.TabIndex = 44;
            this.button45.Text = "−";
            this.button45.UseVisualStyleBackColor = true;
            this.button45.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button29
            // 
            this.button29.Location = new System.Drawing.Point(6, 35);
            this.button29.Name = "button29";
            this.button29.Size = new System.Drawing.Size(47, 23);
            this.button29.TabIndex = 25;
            this.button29.Text = "7";
            this.button29.UseVisualStyleBackColor = true;
            this.button29.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button44
            // 
            this.button44.Location = new System.Drawing.Point(165, 64);
            this.button44.Name = "button44";
            this.button44.Size = new System.Drawing.Size(47, 23);
            this.button44.TabIndex = 43;
            this.button44.Text = "×";
            this.button44.UseVisualStyleBackColor = true;
            this.button44.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button30
            // 
            this.button30.Location = new System.Drawing.Point(6, 64);
            this.button30.Name = "button30";
            this.button30.Size = new System.Drawing.Size(47, 23);
            this.button30.TabIndex = 26;
            this.button30.Text = "4";
            this.button30.UseVisualStyleBackColor = true;
            this.button30.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button43
            // 
            this.button43.Location = new System.Drawing.Point(165, 35);
            this.button43.Name = "button43";
            this.button43.Size = new System.Drawing.Size(47, 23);
            this.button43.TabIndex = 42;
            this.button43.Text = "÷";
            this.button43.UseVisualStyleBackColor = true;
            this.button43.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button31
            // 
            this.button31.Location = new System.Drawing.Point(6, 93);
            this.button31.Name = "button31";
            this.button31.Size = new System.Drawing.Size(47, 23);
            this.button31.TabIndex = 27;
            this.button31.Text = "1";
            this.button31.UseVisualStyleBackColor = true;
            this.button31.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button42
            // 
            this.button42.Location = new System.Drawing.Point(165, 6);
            this.button42.Name = "button42";
            this.button42.Size = new System.Drawing.Size(47, 23);
            this.button42.TabIndex = 41;
            this.button42.Text = "^";
            this.button42.UseVisualStyleBackColor = true;
            this.button42.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button32
            // 
            this.button32.Location = new System.Drawing.Point(6, 122);
            this.button32.Name = "button32";
            this.button32.Size = new System.Drawing.Size(47, 23);
            this.button32.TabIndex = 28;
            this.button32.Text = "0";
            this.button32.UseVisualStyleBackColor = true;
            this.button32.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button41
            // 
            this.button41.Location = new System.Drawing.Point(112, 122);
            this.button41.Name = "button41";
            this.button41.Size = new System.Drawing.Size(47, 23);
            this.button41.TabIndex = 40;
            this.button41.Text = "var";
            this.button41.UseVisualStyleBackColor = true;
            this.button41.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button33
            // 
            this.button33.Location = new System.Drawing.Point(6, 151);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(47, 23);
            this.button33.TabIndex = 29;
            this.button33.Text = "<--";
            this.button33.UseVisualStyleBackColor = true;
            this.button33.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button34
            // 
            this.button34.Location = new System.Drawing.Point(59, 6);
            this.button34.Name = "button34";
            this.button34.Size = new System.Drawing.Size(47, 23);
            this.button34.TabIndex = 30;
            this.button34.Text = "(";
            this.button34.UseVisualStyleBackColor = true;
            this.button34.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button39
            // 
            this.button39.Location = new System.Drawing.Point(112, 64);
            this.button39.Name = "button39";
            this.button39.Size = new System.Drawing.Size(47, 23);
            this.button39.TabIndex = 38;
            this.button39.Text = "6";
            this.button39.UseVisualStyleBackColor = true;
            this.button39.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button35
            // 
            this.button35.Location = new System.Drawing.Point(59, 35);
            this.button35.Name = "button35";
            this.button35.Size = new System.Drawing.Size(47, 23);
            this.button35.TabIndex = 31;
            this.button35.Text = "8";
            this.button35.UseVisualStyleBackColor = true;
            this.button35.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button38
            // 
            this.button38.Location = new System.Drawing.Point(112, 35);
            this.button38.Name = "button38";
            this.button38.Size = new System.Drawing.Size(47, 23);
            this.button38.TabIndex = 37;
            this.button38.Text = "9";
            this.button38.UseVisualStyleBackColor = true;
            this.button38.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button36
            // 
            this.button36.Location = new System.Drawing.Point(59, 64);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(47, 23);
            this.button36.TabIndex = 32;
            this.button36.Text = "5";
            this.button36.UseVisualStyleBackColor = true;
            this.button36.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button37
            // 
            this.button37.Location = new System.Drawing.Point(112, 6);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(47, 23);
            this.button37.TabIndex = 36;
            this.button37.Text = ")";
            this.button37.UseVisualStyleBackColor = true;
            this.button37.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button47
            // 
            this.button47.Location = new System.Drawing.Point(59, 93);
            this.button47.Name = "button47";
            this.button47.Size = new System.Drawing.Size(47, 23);
            this.button47.TabIndex = 33;
            this.button47.Text = "2";
            this.button47.UseVisualStyleBackColor = true;
            this.button47.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button48
            // 
            this.button48.Location = new System.Drawing.Point(59, 151);
            this.button48.Name = "button48";
            this.button48.Size = new System.Drawing.Size(153, 23);
            this.button48.TabIndex = 35;
            this.button48.Text = "Clear";
            this.button48.UseVisualStyleBackColor = true;
            this.button48.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // button49
            // 
            this.button49.Location = new System.Drawing.Point(59, 122);
            this.button49.Name = "button49";
            this.button49.Size = new System.Drawing.Size(47, 23);
            this.button49.TabIndex = 34;
            this.button49.Text = ".";
            this.button49.UseVisualStyleBackColor = true;
            this.button49.Click += new System.EventHandler(this.InsertKey_Click);
            // 
            // IntegralApproximator
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.domainUpDown1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.zg1);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IntegralApproximator";
            this.Text = "Integral Approximator";
            this.Load += new System.EventHandler(this.IntegralApproximator_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button40;
        private System.Windows.Forms.Button button46;
        private System.Windows.Forms.Button button45;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button44;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.Button button43;
        private System.Windows.Forms.Button button31;
        private System.Windows.Forms.Button button42;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button41;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button34;
        private System.Windows.Forms.Button button39;
        private System.Windows.Forms.Button button35;
        private System.Windows.Forms.Button button38;
        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button47;
        private System.Windows.Forms.Button button48;
        private System.Windows.Forms.Button button49;
    }
}

