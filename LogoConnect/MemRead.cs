using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;
using System.Windows.Forms;

namespace MemoryRead
{
  public class Mem_Read
    {
        S7Client client = new S7Client();

        public bool timer_value;
        public bool Read_timer(bool timer)
        {
            System.Windows.Forms.Timer Read_timer1 = new System.Windows.Forms.Timer();
            Read_timer1.Tick += new EventHandler(Read_timer_tick);
            Read_timer1.Interval = 1500;

            if (timer.Equals(true)) { Read_timer1.Start(); timer_value = true; }
            if (timer.Equals(false)) { Read_timer1.Stop(); timer_value = false; }

            return (bool)(timer) && (bool)(timer_value);


        }

        private void Open_socket()
        {
            client.SetConnectionParams("192.168.1.10", 0x0300, 0x0200);
            Setup_socket();
        }

        private void Setup_socket()
        {
            int Con_error = client.Connect();

            if (Con_error == 0) { client.Connect(); }
            if (Con_error > 0){ MessageBox.Show("Error opening socket"); }
        }

        private void Close_socket()
        { 
            client.Disconnect();
        }

        public int Read_out_VBmem()
        {
            //Comment Reads A DB prints out 196608

            byte[] DB_1 = new byte[1024];
            int DB_number = 1;
            int Read_size = 16;

            int result = client.DBGet(DB_number, DB_1, ref Read_size);

            return result;


            // Comment Reads a DB prints out 0 
            //S7MultiVar Reader = new S7MultiVar(client);

            //byte[] DB_1 = new byte[1024];
            //byte[] DB_2 = new byte[1024];
            //byte[] DB_3 = new byte[1024];

            //int DBNumber_1 = 1;
            //int DBNumber_2 = 1;
            //int DBNumber_3 = 1;

            //Reader.Add(S7Consts.S7AreaDB, S7Consts.S7WLByte, DBNumber_1, 0, 16, ref DB_1);
            //Reader.Add(S7Consts.S7AreaDB, S7Consts.S7WLByte, DBNumber_2, 0, 16, ref DB_2);
            //Reader.Add(S7Consts.S7WLByte, S7Consts.S7WLByte, DBNumber_3, 0, 16, ref DB_3);

            //int result = Reader.Read();

            //return result;

        }

        public void Read_timer_tick(object sender, EventArgs e)
        {
            if (timer_value.Equals(true))
            {
                Open_socket();
                Read_out_VBmem();
                Close_socket();
                
            }
            
        }



    }
}
