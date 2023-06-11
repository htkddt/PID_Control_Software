using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using ZedGraph;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace SOFTWARE
{
    public partial class Form1 : Form
    {
        string Data_read, strCmd, strOpt, strData;
        int i, realtime, compare, Encoder_value;
        float time;
        double speed, position;

        bool bSpeed;
        bool bPosition;

        Byte[] bSTX = { 0x02 };
        Byte[] bETX = { 0x03 };
        Byte[] bACK = { 0x06 };
        Byte[] bSYNC = { 0x16 };

        Byte[] LOAD = { 0x4C, 0x4F, 0x41, 0x44 };
        Byte[] DEMO = { 0x44, 0x45, 0x4D, 0x4F };
        Byte[] STOP = { 0x53, 0x54, 0x4F, 0x50 };

        Byte[] SPE = { 0x53, 0x50, 0x45 };
        Byte[] POS = { 0x50, 0x4F, 0x53 };

        Byte[] optSetpoint = { 0x4F,0x53, 0x70 };
        Byte[] optKp = { 0x4F,0x4B, 0x70 };
        Byte[] optKi = { 0x4F,0x4B, 0x69 };
        Byte[] optKd = { 0x4F,0x4B, 0x64 };

        Byte[] bOPT = { 0x00, 0x00, 0x00 };

        Byte[] bDATA = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

        Byte[] Tx_Protocol = new Byte[18];
        Byte[] Rx_Protocol = new Byte[18];

        public Form1()
        {
            InitializeComponent();
            string[] myport = SerialPort.GetPortNames();
            cbox_Port.Items.AddRange(myport);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var chartArea = Plot_Chart.ChartAreas[0];
            chartArea.AxisX.LabelStyle.Format = "";
            chartArea.AxisY.LabelStyle.Format = "";
            chartArea.AxisX.LabelStyle.IsEndLabelVisible = true;
            chartArea.AxisY.LabelStyle.IsEndLabelVisible = true;

            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 10;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 200;

            chartArea.AxisX.Interval = 1;
            chartArea.AxisY.Interval = 50;
            chartArea.AxisX.Title = "Time (ms)";
            chartArea.AxisY.Title = "Speed/Position";

            Plot_Chart.Series[0].ChartType = SeriesChartType.Line;
            Plot_Chart.Series[0].Color = Color.Blue;
            Plot_Chart.Series[0].BorderWidth = 2;
            Plot_Chart.Series[0].IsVisibleInLegend = true;

            Plot_Chart.Series[1].ChartType = SeriesChartType.Line;
            Plot_Chart.Series[1].Color = Color.Red;
            Plot_Chart.Series[1].BorderWidth = 2;
            Plot_Chart.Series[1].IsVisibleInLegend = true;
        }

        private void btn_Con_Dis_Click(object sender, EventArgs e)
        {
            try
            {
                if (btn_Con_Dis.Text == "Connect")
                {
                    serialPort1.PortName = cbox_Port.Text;
                    serialPort1.BaudRate = int.Parse("115200");
                    serialPort1.DataBits = int.Parse("8");
                    serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
                    serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                    serialPort1.Open();
                    btn_Con_Dis.Text = "Disconnect";
                    cbox_Port.Enabled = false;
                    cbox_Select.Enabled = true;
                    cbox_Select.SelectedIndex = 2;
                    txt_Setpoint.Enabled = true;
                    txt_Kp.Enabled = true;
                    txt_Ki.Enabled = true;
                    txt_Kd.Enabled = true;
                    txt_TStop.Enabled = true;
                    btn_Start.Enabled = true;
                    btn_Stop.Enabled = true;
                    btn_Reset.Enabled = true;
                }
                else if (btn_Con_Dis.Text == "Disconnect")
                {
                    serialPort1.Close();
                    btn_Con_Dis.Text = "Connect";
                    cbox_Port.Enabled = true;
                    cbox_Select.SelectedIndex = 2;
                    cbox_Select.Enabled = false;
                    txt_Setpoint.Text = "";
                    txt_Setpoint.Enabled = false;
                    txt_Setpoint.Text = "";
                    txt_Kp.Enabled = false;
                    txt_Kp.Text = "";
                    txt_Ki.Enabled = false;
                    txt_Ki.Text = "";
                    txt_Kd.Enabled = false;
                    txt_Kd.Text = "";
                    txt_TStop.Enabled = false;
                    btn_Start.Enabled = false;
                    btn_Stop.Enabled = false;
                    btn_Reset.Enabled = false;
                    Plot_Chart.Series[0].Points.Clear();
                    Plot_Chart.Series[1].Points.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Data_read += serialPort1.ReadExisting();
            Invoke(new EventHandler(ShowData));
        }

        private void ShowData(object sender, EventArgs e)
        {
            try
            {
                if (Data_read[0] == bSTX[0] && Data_read[16] == bACK[0] && Data_read[17] == bETX[0])
                {
                    for (i = 1; i < 5; i++)
                    {
                        strCmd += Data_read[i].ToString();
                    }
                    for (i = 5; i < 8; i++)
                    {
                        strOpt += Data_read[i].ToString();
                    }
                    for (i = 8; i < 16; i++)
                    {
                        strData += Data_read[i].ToString();
                    }
                }
                Rx_Protocol = Encoding.ASCII.GetBytes(Data_read);
                for (i = 1; i < 5; i++)
                {
                    if (Rx_Protocol[i] != Tx_Protocol[i])
                    {
                        compare = 0;
                    }
                    else
                    {
                        compare = 1;
                    }
                }
                if (compare == 1)
                {
                    if (strCmd == Encoding.UTF8.GetString(LOAD))
                    {
                        if (strOpt == Encoding.UTF8.GetString(SPE)) 
                        {
                            bSpeed = true;
                            bPosition = false;
                        }
                        else if (strOpt == Encoding.UTF8.GetString(POS))
                        {
                            bSpeed = false;
                            bPosition = true;
                        }
                    }
                    if (strCmd == Encoding.UTF8.GetString(DEMO))
                    {
                        Encoder_value = int.Parse(strData);
                    }
                }
                Data_read = "";
                strCmd = "";
                strOpt = "";
                strData = "";
            }
            catch (Exception ex) { }
        }

        private void PlotChart(float dataX_Time, double dataY_SP, double dataY_PV)
        {
            Plot_Chart.Series[0].Points.AddXY(dataX_Time, dataY_SP);
            Plot_Chart.Series[1].Points.AddXY(dataX_Time, dataY_PV);
            var chartArea = Plot_Chart.ChartAreas[0];
            if (dataX_Time > chartArea.AxisX.Maximum)
            {
                chartArea.AxisX.Maximum += 1000;
                chartArea.AxisX.Interval += 100;
            }
            if (dataY_SP > chartArea.AxisY.Maximum)
            {
                chartArea.AxisY.Maximum = dataY_SP + 10;
                if ((chartArea.AxisY.Maximum) / (chartArea.AxisY.Interval) >= 10)
                    chartArea.AxisY.Interval = Math.Floor((chartArea.AxisY.Maximum - chartArea.AxisY.Minimum) / 5);
            }
            if (dataY_SP < chartArea.AxisY.Minimum)
            {
                chartArea.AxisY.Minimum = dataY_SP - 5;
                if ((chartArea.AxisY.Minimum) / (chartArea.AxisY.Interval) >= 10)
                    chartArea.AxisY.Interval = Math.Floor((chartArea.AxisY.Maximum - chartArea.AxisY.Minimum) / 5);
            }
            if (dataY_PV > chartArea.AxisY.Maximum)
            {
                chartArea.AxisY.Maximum = dataY_PV + 10;
                if ((chartArea.AxisY.Maximum) / (chartArea.AxisY.Interval) >= 10)
                    chartArea.AxisY.Interval = Math.Floor((chartArea.AxisY.Maximum - chartArea.AxisY.Minimum) / 5);
            }
            if (dataY_PV < chartArea.AxisY.Minimum)
            {
                chartArea.AxisY.Minimum = dataY_PV - 5;
                if ((chartArea.AxisY.Minimum) / (chartArea.AxisY.Interval) >= 10)
                    chartArea.AxisY.Interval = Math.Floor((chartArea.AxisY.Maximum - chartArea.AxisY.Minimum) / 5);
            }
        }

        private void cbox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_Select.Text == "Speed")
            {
                Send_Process(Tx_Protocol, bSTX, LOAD, SPE, bDATA, bSYNC, bETX);
                //txt_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Received" + "\r\n";
                Don_vi.Text = "(rpm)";
            }
            else if (cbox_Select.Text == "Position")
            {
                Send_Process(Tx_Protocol, bSTX, LOAD, POS, bDATA, bSYNC, bETX);
                //txt_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Received" + "\r\n";
                Don_vi.Text = "(deg)";
            }
            txt_TStop.Text = "3000";
        }

        private void txt_Setpoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                Send_Process(Tx_Protocol, bSTX, LOAD, optSetpoint, Encoding.ASCII.GetBytes(txt_Setpoint.Text), bSYNC, bETX);
                //txt_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Received" + "\r\n";
            }
        }

        private void txt_Kp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                Send_Process(Tx_Protocol, bSTX, LOAD, optKp, Encoding.ASCII.GetBytes(txt_Kp.Text), bSYNC, bETX);
                //txt_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Received" + "\r\n";
            }
        }

        private void txt_Ki_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Send_Process(Tx_Protocol, bSTX, LOAD, optKi, Encoding.ASCII.GetBytes(txt_Ki.Text), bSYNC, bETX);
                //txt_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Received" + "\r\n";
            }
        }

        private void txt_Kd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Send_Process(Tx_Protocol, bSTX, LOAD, optKd, Encoding.ASCII.GetBytes(txt_Kd.Text), bSYNC, bETX);
                //txt_Received.Text += BitConverter.ToString(Tx_Protocol) + "\r\n" + "Received" + "\r\n";
            }
        }

        private void txt_TStop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (cbox_Select.Text == "Not Select" || txt_Setpoint.Text == "" || txt_Kp.Text == "" || txt_Ki.Text == "" || txt_Kd.Text == "")
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (checkDigit(txt_Setpoint.Text) == false || checkDigit(txt_Kp.Text) == false || checkDigit(txt_Ki.Text) == false || checkDigit(txt_Kd.Text) == false)
                {
                    MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Plot_Chart.Series[0].Points.Clear();
                    Plot_Chart.Series[1].Points.Clear();

                    var chartArea = Plot_Chart.ChartAreas[0];

                    chartArea.AxisX.Minimum = 0;
                    chartArea.AxisX.Maximum = 1000;
                    chartArea.AxisY.Minimum = 0;
                    chartArea.AxisY.Maximum = 50;

                    chartArea.AxisX.Interval = 100;
                    chartArea.AxisY.Interval = 10;

                    Send_Process(Tx_Protocol, bSTX, DEMO, bOPT, bDATA, bSYNC, bETX);

                    grbox_Connect.Enabled = false;
                    cbox_Select.Enabled = false;
                    txt_Setpoint.Enabled = false;
                    txt_Kp.Enabled = false;
                    txt_Ki.Enabled = false;
                    txt_Kd.Enabled = false;
                    btn_Reset.Enabled = false;
                    Encoder_value = 0;
                    PlotChart(0, double.Parse(txt_Setpoint.Text), 0);
                    realtime = 1;
                    timControl.Enabled = true;
                }
            }
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (cbox_Select.Text == "Not Select" || txt_Setpoint.Text == "" || txt_Kp.Text == "" || txt_Ki.Text == "" || txt_Kd.Text == "")
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (checkDigit(txt_Setpoint.Text) == false || checkDigit(txt_Kp.Text) == false || checkDigit(txt_Ki.Text) == false || checkDigit(txt_Kd.Text) == false)
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Plot_Chart.Series[0].Points.Clear();
                Plot_Chart.Series[1].Points.Clear();

                var chartArea = Plot_Chart.ChartAreas[0];

                chartArea.AxisX.Minimum = 0;
                chartArea.AxisX.Maximum = 1000;
                chartArea.AxisY.Minimum = 0;
                chartArea.AxisY.Maximum = 50;

                chartArea.AxisX.Interval = 100;
                chartArea.AxisY.Interval = 5;

                Send_Process(Tx_Protocol, bSTX, DEMO, bOPT, bDATA, bSYNC, bETX);

                grbox_Connect.Enabled = false;
                cbox_Select.Enabled = false;
                txt_Setpoint.Enabled = false;
                txt_Kp.Enabled = false;
                txt_Ki.Enabled = false;
                txt_Kd.Enabled = false;
                btn_Reset.Enabled = false;
                btn_Start.Enabled = false;
                btn_Stop.Enabled = true;
                Encoder_value = 0;
                PlotChart(0, double.Parse(txt_Setpoint.Text), 0);
                realtime = 1;
                timControl.Enabled = true;
            }
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            Send_Process(Tx_Protocol, bSTX, STOP, bOPT, bDATA, bSYNC, bETX);
            timControl.Enabled = false;
            grbox_Connect.Enabled = true;
            cbox_Select.Enabled = true;
            txt_Setpoint.Enabled = true;
            txt_Kp.Enabled = true;
            txt_Ki.Enabled = true;
            txt_Kd.Enabled = true;
            btn_Reset.Enabled = true;
            btn_Start.Enabled = true;
            btn_Stop.Enabled = false;
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            cbox_Select.SelectedIndex = 2;
            txt_Setpoint.Text = "";
            txt_Kp.Text = "";
            txt_Ki.Text = "";
            txt_Kd.Text = "";
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            //txt_Received.Text = "";
            Plot_Chart.Series[0].Points.Clear();
            Plot_Chart.Series[1].Points.Clear();
        }

        private void timControl_Tick(object sender, EventArgs e)
        {
            time = (float)(timControl.Interval * realtime);
            if (time > int.Parse(txt_TStop.Text))
            {
                Send_Process(Tx_Protocol, bSTX, STOP, bOPT, bDATA, bSYNC, bETX);
                timControl.Enabled = false;
                grbox_Connect.Enabled = true;
                cbox_Select.Enabled = true;
                txt_Setpoint.Enabled = true;
                txt_Kp.Enabled = true;
                txt_Ki.Enabled = true;
                txt_Kd.Enabled = true;
                btn_Reset.Enabled = true;
                btn_Start.Enabled = true;
                btn_Stop.Enabled = false;
            }
            else
            {
                if (bSpeed == true)
                {
                    speed = (double)Encoder_value * 60.0f / (1920 * 0.05);
                    PlotChart(time, double.Parse(txt_Setpoint.Text), speed);
                }
                else if (bPosition == true)
                {
                    position = (double)Encoder_value * 360 / 1920;
                    PlotChart(time, double.Parse(txt_Setpoint.Text), position);
                }
                realtime += 1;
            }
        }

        private void Send_Process(Byte[] pBuff, Byte[] pSTX, Byte[] pCommand, Byte[] pOpt, Byte[] pData, Byte[] pSYNC, Byte[] pETX)
        {
            try
            {
                Array.Clear(pBuff, 0, pBuff.Length);
                pSTX.CopyTo(pBuff, 0);
                pCommand.CopyTo(pBuff, 1);
                pOpt.CopyTo(pBuff, 5);
                pData.CopyTo(pBuff, 8);
                pSYNC.CopyTo(pBuff, 16);
                pETX.CopyTo(pBuff, 17);
                serialPort1.Write(pBuff, 0, 18);
            }
            catch (Exception ex) { }
        }

        private bool checkDigit(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c) && c != '.')
                {
                    return false;
                }
            }
            return true;
        }

        private void ScrollToBottom(TextBox textBox)
        {
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
            textBox.HideSelection = false;
        }
    }
}