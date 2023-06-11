namespace SOFTWARE
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.grbox_Connect = new System.Windows.Forms.GroupBox();
            this.btn_Con_Dis = new System.Windows.Forms.Button();
            this.Ports = new System.Windows.Forms.Label();
            this.cbox_Port = new System.Windows.Forms.ComboBox();
            this.grbox_Setting = new System.Windows.Forms.GroupBox();
            this.txt_TStop = new System.Windows.Forms.TextBox();
            this.lbTStop = new System.Windows.Forms.Label();
            this.lb_Kd = new System.Windows.Forms.Label();
            this.lb_Ki = new System.Windows.Forms.Label();
            this.Clear = new System.Windows.Forms.Button();
            this.lb_Kp = new System.Windows.Forms.Label();
            this.Don_vi = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.txt_Kd = new System.Windows.Forms.TextBox();
            this.txt_Ki = new System.Windows.Forms.TextBox();
            this.txt_Kp = new System.Windows.Forms.TextBox();
            this.txt_Setpoint = new System.Windows.Forms.TextBox();
            this.Set = new System.Windows.Forms.Label();
            this.cbox_Select = new System.Windows.Forms.ComboBox();
            this.lb_Select = new System.Windows.Forms.Label();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Plot_Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timControl = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbox_Connect.SuspendLayout();
            this.grbox_Setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Plot_Chart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbox_Connect
            // 
            this.grbox_Connect.Controls.Add(this.btn_Con_Dis);
            this.grbox_Connect.Controls.Add(this.Ports);
            this.grbox_Connect.Controls.Add(this.cbox_Port);
            this.grbox_Connect.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbox_Connect.Location = new System.Drawing.Point(12, 12);
            this.grbox_Connect.Name = "grbox_Connect";
            this.grbox_Connect.Size = new System.Drawing.Size(213, 132);
            this.grbox_Connect.TabIndex = 0;
            this.grbox_Connect.TabStop = false;
            this.grbox_Connect.Text = "CONNECT";
            // 
            // btn_Con_Dis
            // 
            this.btn_Con_Dis.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Con_Dis.Location = new System.Drawing.Point(47, 78);
            this.btn_Con_Dis.Name = "btn_Con_Dis";
            this.btn_Con_Dis.Size = new System.Drawing.Size(120, 37);
            this.btn_Con_Dis.TabIndex = 3;
            this.btn_Con_Dis.Text = "Connect";
            this.btn_Con_Dis.UseVisualStyleBackColor = true;
            this.btn_Con_Dis.Click += new System.EventHandler(this.btn_Con_Dis_Click);
            // 
            // Ports
            // 
            this.Ports.AutoSize = true;
            this.Ports.Location = new System.Drawing.Point(21, 32);
            this.Ports.Name = "Ports";
            this.Ports.Size = new System.Drawing.Size(43, 22);
            this.Ports.TabIndex = 1;
            this.Ports.Text = "Port";
            // 
            // cbox_Port
            // 
            this.cbox_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Port.FormattingEnabled = true;
            this.cbox_Port.Location = new System.Drawing.Point(88, 29);
            this.cbox_Port.Name = "cbox_Port";
            this.cbox_Port.Size = new System.Drawing.Size(112, 30);
            this.cbox_Port.TabIndex = 0;
            // 
            // grbox_Setting
            // 
            this.grbox_Setting.Controls.Add(this.txt_TStop);
            this.grbox_Setting.Controls.Add(this.lbTStop);
            this.grbox_Setting.Controls.Add(this.lb_Kd);
            this.grbox_Setting.Controls.Add(this.lb_Ki);
            this.grbox_Setting.Controls.Add(this.Clear);
            this.grbox_Setting.Controls.Add(this.lb_Kp);
            this.grbox_Setting.Controls.Add(this.Don_vi);
            this.grbox_Setting.Controls.Add(this.btn_Reset);
            this.grbox_Setting.Controls.Add(this.txt_Kd);
            this.grbox_Setting.Controls.Add(this.txt_Ki);
            this.grbox_Setting.Controls.Add(this.txt_Kp);
            this.grbox_Setting.Controls.Add(this.txt_Setpoint);
            this.grbox_Setting.Controls.Add(this.Set);
            this.grbox_Setting.Controls.Add(this.cbox_Select);
            this.grbox_Setting.Controls.Add(this.lb_Select);
            this.grbox_Setting.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbox_Setting.Location = new System.Drawing.Point(12, 169);
            this.grbox_Setting.Name = "grbox_Setting";
            this.grbox_Setting.Size = new System.Drawing.Size(213, 351);
            this.grbox_Setting.TabIndex = 1;
            this.grbox_Setting.TabStop = false;
            this.grbox_Setting.Text = "SETTING";
            // 
            // txt_TStop
            // 
            this.txt_TStop.Enabled = false;
            this.txt_TStop.Location = new System.Drawing.Point(106, 245);
            this.txt_TStop.Name = "txt_TStop";
            this.txt_TStop.Size = new System.Drawing.Size(101, 30);
            this.txt_TStop.TabIndex = 21;
            this.txt_TStop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_TStop_KeyPress);
            // 
            // lbTStop
            // 
            this.lbTStop.AutoSize = true;
            this.lbTStop.Location = new System.Drawing.Point(14, 243);
            this.lbTStop.Name = "lbTStop";
            this.lbTStop.Size = new System.Drawing.Size(58, 44);
            this.lbTStop.TabIndex = 20;
            this.lbTStop.Text = "TStop\r\n (ms)";
            // 
            // lb_Kd
            // 
            this.lb_Kd.AutoSize = true;
            this.lb_Kd.Location = new System.Drawing.Point(47, 201);
            this.lb_Kd.Name = "lb_Kd";
            this.lb_Kd.Size = new System.Drawing.Size(34, 22);
            this.lb_Kd.TabIndex = 19;
            this.lb_Kd.Text = "Kd";
            // 
            // lb_Ki
            // 
            this.lb_Ki.AutoSize = true;
            this.lb_Ki.Location = new System.Drawing.Point(47, 165);
            this.lb_Ki.Name = "lb_Ki";
            this.lb_Ki.Size = new System.Drawing.Size(30, 22);
            this.lb_Ki.TabIndex = 18;
            this.lb_Ki.Text = "Ki";
            // 
            // Clear
            // 
            this.Clear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clear.Location = new System.Drawing.Point(106, 308);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(101, 37);
            this.Clear.TabIndex = 17;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // lb_Kp
            // 
            this.lb_Kp.AutoSize = true;
            this.lb_Kp.Location = new System.Drawing.Point(47, 129);
            this.lb_Kp.Name = "lb_Kp";
            this.lb_Kp.Size = new System.Drawing.Size(34, 22);
            this.lb_Kp.TabIndex = 17;
            this.lb_Kp.Text = "Kp";
            // 
            // Don_vi
            // 
            this.Don_vi.AutoSize = true;
            this.Don_vi.Location = new System.Drawing.Point(14, 54);
            this.Don_vi.Name = "Don_vi";
            this.Don_vi.Size = new System.Drawing.Size(0, 22);
            this.Don_vi.TabIndex = 16;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Enabled = false;
            this.btn_Reset.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.Location = new System.Drawing.Point(8, 308);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(95, 37);
            this.btn_Reset.TabIndex = 4;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // txt_Kd
            // 
            this.txt_Kd.Enabled = false;
            this.txt_Kd.Location = new System.Drawing.Point(106, 198);
            this.txt_Kd.Name = "txt_Kd";
            this.txt_Kd.Size = new System.Drawing.Size(101, 30);
            this.txt_Kd.TabIndex = 12;
            this.txt_Kd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Kd_KeyPress);
            // 
            // txt_Ki
            // 
            this.txt_Ki.Enabled = false;
            this.txt_Ki.Location = new System.Drawing.Point(106, 162);
            this.txt_Ki.Name = "txt_Ki";
            this.txt_Ki.Size = new System.Drawing.Size(101, 30);
            this.txt_Ki.TabIndex = 10;
            this.txt_Ki.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Ki_KeyPress);
            // 
            // txt_Kp
            // 
            this.txt_Kp.Enabled = false;
            this.txt_Kp.Location = new System.Drawing.Point(106, 126);
            this.txt_Kp.Name = "txt_Kp";
            this.txt_Kp.Size = new System.Drawing.Size(101, 30);
            this.txt_Kp.TabIndex = 8;
            this.txt_Kp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Kp_KeyPress);
            // 
            // txt_Setpoint
            // 
            this.txt_Setpoint.Enabled = false;
            this.txt_Setpoint.Location = new System.Drawing.Point(106, 79);
            this.txt_Setpoint.Name = "txt_Setpoint";
            this.txt_Setpoint.Size = new System.Drawing.Size(101, 30);
            this.txt_Setpoint.TabIndex = 6;
            this.txt_Setpoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Setpoint_KeyPress);
            // 
            // Set
            // 
            this.Set.AutoSize = true;
            this.Set.Location = new System.Drawing.Point(6, 82);
            this.Set.Name = "Set";
            this.Set.Size = new System.Drawing.Size(75, 22);
            this.Set.TabIndex = 5;
            this.Set.Text = "Setpoint";
            // 
            // cbox_Select
            // 
            this.cbox_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbox_Select.Enabled = false;
            this.cbox_Select.FormattingEnabled = true;
            this.cbox_Select.Items.AddRange(new object[] {
            "Speed",
            "Position",
            "Not Select"});
            this.cbox_Select.Location = new System.Drawing.Point(88, 29);
            this.cbox_Select.Name = "cbox_Select";
            this.cbox_Select.Size = new System.Drawing.Size(119, 30);
            this.cbox_Select.TabIndex = 4;
            this.cbox_Select.SelectedIndexChanged += new System.EventHandler(this.cbox_Select_SelectedIndexChanged);
            // 
            // lb_Select
            // 
            this.lb_Select.AutoSize = true;
            this.lb_Select.Location = new System.Drawing.Point(6, 32);
            this.lb_Select.Name = "lb_Select";
            this.lb_Select.Size = new System.Drawing.Size(59, 22);
            this.lb_Select.TabIndex = 0;
            this.lb_Select.Text = "Select";
            // 
            // btn_Stop
            // 
            this.btn_Stop.Enabled = false;
            this.btn_Stop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Stop.Location = new System.Drawing.Point(106, 35);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(101, 37);
            this.btn_Stop.TabIndex = 20;
            this.btn_Stop.Text = "Stop";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.Enabled = false;
            this.btn_Start.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Start.Location = new System.Drawing.Point(6, 35);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(95, 37);
            this.btn_Start.TabIndex = 15;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Plot_Chart
            // 
            chartArea1.Name = "ChartArea1";
            this.Plot_Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Plot_Chart.Legends.Add(legend1);
            this.Plot_Chart.Location = new System.Drawing.Point(231, 12);
            this.Plot_Chart.Name = "Plot_Chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.LegendText = "SP";
            series1.Name = "SP";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.LegendText = "PV";
            series2.Name = "PV";
            this.Plot_Chart.Series.Add(series1);
            this.Plot_Chart.Series.Add(series2);
            this.Plot_Chart.Size = new System.Drawing.Size(1191, 597);
            this.Plot_Chart.TabIndex = 18;
            this.Plot_Chart.Text = "chart1";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "DC MOTOR PID CONTROLLER";
            this.Plot_Chart.Titles.Add(title1);
            // 
            // timControl
            // 
            this.timControl.Interval = 50;
            this.timControl.Tick += new System.EventHandler(this.timControl_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Start);
            this.groupBox1.Controls.Add(this.btn_Stop);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 526);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 83);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RUN";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1434, 621);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Plot_Chart);
            this.Controls.Add(this.grbox_Setting);
            this.Controls.Add(this.grbox_Connect);
            this.Name = "Form1";
            this.Text = "DC MOTOR CONTROLLER";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbox_Connect.ResumeLayout(false);
            this.grbox_Connect.PerformLayout();
            this.grbox_Setting.ResumeLayout(false);
            this.grbox_Setting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Plot_Chart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbox_Connect;
        private System.Windows.Forms.Button btn_Con_Dis;
        private System.Windows.Forms.Label Ports;
        private System.Windows.Forms.ComboBox cbox_Port;
        private System.Windows.Forms.GroupBox grbox_Setting;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.TextBox txt_Kd;
        private System.Windows.Forms.TextBox txt_Ki;
        private System.Windows.Forms.TextBox txt_Kp;
        private System.Windows.Forms.TextBox txt_Setpoint;
        private System.Windows.Forms.Label Set;
        private System.Windows.Forms.ComboBox cbox_Select;
        private System.Windows.Forms.Label lb_Select;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Label Don_vi;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.DataVisualization.Charting.Chart Plot_Chart;
        private System.Windows.Forms.Label lb_Kd;
        private System.Windows.Forms.Label lb_Ki;
        private System.Windows.Forms.Label lb_Kp;
        private System.Windows.Forms.Timer timControl;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_TStop;
        private System.Windows.Forms.Label lbTStop;
    }
}

