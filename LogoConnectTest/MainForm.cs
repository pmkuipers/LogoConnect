using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogoConnect;

namespace LogoConnectTest
{
    public partial class MainForm : Form
    {
        LogoConnector Logo = new LogoConnector(LogoType.Logo8FS4);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Setup connection parameters
            Logo.SetConnectionParams("192.168.0.10", 0x0300, 0x0200);
            // Attempt connection
            try
            {
                Logo.Connect();
            }
            catch (LogoConnect.LogoCommunicationException x)
            {
                // On communication error, show the message in a messagebox
                MessageBox.Show(x.Message, "Communication error");
            }

        }
        

        private void btReadNq1_Click(object sender, EventArgs e)
        {
            try
            {
                bool nq1 = Logo.ReadVBit(1, 0);
                textBox1.Text = "NQ1 read as: " + nq1.ToString() + "\r\n" + textBox1.Text;
            }
            catch (LogoConnect.LogoCommunicationException x)
            {
                // On communication error, show the message in a messagebox
                MessageBox.Show(x.Message, "Communication error");
            }
        }

        private void btSetNi1True_Click(object sender, EventArgs e)
        {
            try
            {
                Logo.WriteVBit(0, 0, true);
                textBox1.Text = "NI1 set to: True\r\n" + textBox1.Text; 
            }
            catch (LogoConnect.LogoCommunicationException x)
            {
                // On communication error, show the message in a messagebox
                MessageBox.Show(x.Message, "Communication error");
            }
        }

        private void btSetNi1False_Click(object sender, EventArgs e)
        {
            try
            {
                Logo.WriteVBit(0, 0, false);
                textBox1.Text = "NI1 set to: False\r\n" + textBox1.Text;
            }
            catch (LogoConnect.LogoCommunicationException x)
            {
                // On communication error, show the message in a messagebox
                MessageBox.Show(x.Message, "Communication error");
            }
        }

        private void btReadNAq1_Click(object sender, EventArgs e)
        {
            try
            {
                ushort naq1 = Logo.ReadVWord(12);
                textBox1.Text = "NAQ1 read as: " + naq1.ToString() + "\r\n" + textBox1.Text;
            }
            catch (LogoConnect.LogoCommunicationException x)
            {
                // On communication error, show the message in a messagebox
                MessageBox.Show(x.Message, "Communication error");
            }
        }

        private void btSetNAi1Dec_Click(object sender, EventArgs e)
        {
            try
            {
                // Read NAI1
                ushort nai1 = Logo.ReadVWord(10);
                // Decrement
                nai1-= 10; 
                // Write new value
                Logo.WriteVWord(10, nai1);

                textBox1.Text = "NAI1 decreased to : " + nai1.ToString() + "\r\n" + textBox1.Text;
            }
            catch (LogoConnect.LogoCommunicationException x)
            {
                // On communication error, show the message in a messagebox
                MessageBox.Show(x.Message, "Communication error");
            }
        }

        private void btSetNAi1Inc_Click(object sender, EventArgs e)
        {
            try
            {
                // Read NAI1
                ushort nai1 = Logo.ReadVWord(10);
                // Increment
                nai1+= 10;
                // Write new value
                Logo.WriteVWord(10, nai1);

                textBox1.Text = "NAI1 increased to : " + nai1.ToString() + "\r\n" + textBox1.Text;
            }
            catch (LogoConnect.LogoCommunicationException x)
            {
                // On communication error, show the message in a messagebox
                MessageBox.Show(x.Message, "Communication error");
            }
        }
    }
}
