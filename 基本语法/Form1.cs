using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNameSpace;
// 文件操作
using System.IO;
//
using System.Diagnostics;
using System.Threading;
//net
using System.Net;
//media
using System.Media;


namespace winFormProj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient wb = new WebClient();
            textBox4.Text = wb.DownloadString("https://raw.githubusercontent.com/zhouwh1989/learn_c-/master/%E5%9F%BA%E6%9C%AC%E8%AF%AD%E6%B3%95/Form1.cs");
        }

        void mc_OnpropertyChanged(object sender, EventArgs e)
        {
            MessageBox.Show("The property has been changed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd1 = new OpenFileDialog();
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                //File.class
                //Path class

                ///////process class
                //Process.Start("notepad.exe");
                //MessageBox.Show(Process.GetCurrentProcess().ProcessName);
                //Process.GetCurrentProcess().Kill();

                Process[] ps = Process.GetProcesses();
                foreach (Process p in ps)
                {
                    if (!p.Responding)
                    {
                        p.Kill();
                    }
                }

                Process.GetProcessesByName("chrome");
                
            }

            // folderBrowserDialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyDocuments;
            fbd.Description = "My fbd test";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //Directory class
                //只获取目录下的文件
                string [] files = Directory.GetFiles(fbd.SelectedPath.ToString());
                // 获取目录
                string[] dirs = Directory.GetDirectories(fbd.SelectedPath.ToString());
                //获取盘符
                string[] drives = Directory.GetLogicalDrives();

                //创建
                Directory.CreateDirectory(fbd.SelectedPath + "\\test");
                //Directory.Move();   //mv

                MessageBox.Show(fbd.SelectedPath.ToString());
            }

            //substring
            string subTest = "vanora aery    ";
            string s = subTest.Substring(0, 6);
            // indexof
            int i = subTest.IndexOf(" ");
            //Trim
            s = subTest.Trim();
            //remove
            s = subTest.Remove(6);
            //replace
            s = subTest.Replace("a", "_");
            //Split
            string []ss = s.Split('_');
            //ToCharArray 转换为Unicode数组
            char []cc = "周ssda".ToCharArray();

            //math
            string nu = Math.Pow(2, 3).ToString();

            //random
            Random r = new Random();
            r.Next();
            r.Next(0, 100);
            
            //生成随机字符串
            char[] letters = "0123456789abcdefghijkASDFGHJKL-_=+".ToCharArray();
            //利用random生成随机数作为下标，获取随机字符串

            //convert Bitconvert 基础类型转换，区别在于BitConvert是将基础类型转为byte数组或者相反的转换

            // is as casting
            // is 关键字用于判断是否属于某种类型
            // as/casting 做类型转换
            // example
            //object myObject = "stringTest";
            //if (myObject is string) MessageBox.Show(myObject as string);

            // openfileDialogs
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本|*.txt|图片|*.jpg";
            ofd.Title = "OpenFileDialogTest";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                
                StreamReader sr = new StreamReader(File.OpenRead(ofd.FileName));
                char c = (char)sr.Peek();   //获取一个字符，但是不改变文件偏移
                char c1 = (char)sr.Read();  // 读取一个字符，文件偏移+1
                char c2 = (char)sr.Read();

                //// streamreader
                //textBox1.Text = sr.ReadToEnd(); // 二进制方式读取整个文件
                textBox1.Text = sr.BaseStream.ReadByte().ToString();    // 读取十六进制字节，转成ASCII码
                byte [] buffer = new byte[5];
                sr.BaseStream.Position = 2; // 指定offset
                sr.BaseStream.Read(buffer, 0, 5);   // 读取指定长度的流
                foreach (byte b in buffer)
                {
                    textBox1.Text += b.ToString("X") + " ";
                }
                sr.Dispose();
                MessageBox.Show(ofd.FileName);
            }

            ///// class
            MyClass mc = new MyClass("Vanoa");
            //delegates
            mc.showDelegateMsgs();
            //event
            mc.OnPropertyChanged += new EventHandler(mc_OnpropertyChanged);
            mc.eventName = "eventTest";
            //indexers
            MessageBox.Show(mc[1]);
            mc[1] = "none";
            MessageBox.Show(mc[1]);

            MessageBox.Show("My name is " + mc.GetName());
            // static access
            MyClass.showMsg("I love you");
            //mc.Name = "hello";    //set属性是private的
            MessageBox.Show("Now My name is " + mc.Name);

            MySecondClass mc2 = new MySecondClass();
            mc2.MyVoid();

            ///// try catch
            //try
            //{
            //    string[] test = new string[4];
            //    MessageBox.Show(test[6]);
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
           

            //////CheckBox
            //if (checkBox1.Checked == false)
            //{
            //    MessageBox.Show("未勾选");
            //    //checkBox1.Enabled = false;
            //}
            //else if (checkBox1.Checked == true)
            //{
            //    MessageBox.Show("勾选");
            //}

            ////// TextBox
            //textBox1.MaxLength = 2;
            //textBox1.Text = "The Button Clicked";

            ////修改属性
            //button1.Text = "vanora";
            //button1.Enabled = false;
            //button1.Height = 90;
            
            //// onject
            //object Myobject = true;
            //MessageBox.Show(Myobject.ToString());
            //MessageBox.Show("Hello", "MyItem");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            MessageBox.Show("Hello, for leave");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        ///////////// streamWriter
        string path;
        private void button2_Click(object sender, EventArgs e)
        {
            // openfileDialog
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本|*.txt|图片|*.jpg";
            ofd.Title = "OpenFileDialogTest";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                path = ofd.FileName;
                button3.Enabled = true;
            }
            ofd.Dispose();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            /// streamwriter
            //StreamWriter sw =Q new StreamWriter(File.Create(path));
            //sw.WriteLine("I am a new line");
            //sw.Flush();
            ////sw.Write(textBox2.Text);
            //sw.BaseStream.Position = 0x2B;
            //sw.BaseStream.WriteByte(0xff);
            //sw.Dispose();


            ////BinaryReader
            //BinaryReader br = new BinaryReader(File.OpenRead(path));
            ////textBox2.Text = br.ReadChar().ToString();
            
            //// binaryReader的ReadInt16优先读取文件偏移高的字节,可以认为是小端模式
            //textBox2.Text = "";

            ////textBox2.Text += br.ReadInt16().ToString("x");
            ////textBox2.Text += "|";

            //byte [] buffer = br.ReadBytes(2);
            //foreach (byte b in buffer)
            //{
            //    textBox2.Text += b.ToString("x");
            //    textBox2.Text += " ";
            //}
            //textBox2.Text += BitConverter.ToInt16(buffer, 0).ToString("x"); // BitConverter.toInt16也是按小端读取
            //br.Dispose();

            BinaryWriter bw = new BinaryWriter(File.Create(path));
            short myShort = 1;
            byte[] buffer = BitConverter.GetBytes(myShort);
            bw.Write(buffer);
            //bw.BaseStream.WriteByte(0x12);
            bw.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                
                string path = sfd.FileName;
                BinaryWriter bw = new BinaryWriter(File.Create(path));
                byte [] buffer= new byte[5];
                for(int i=0; i<5; i++)
                {
                    textBox2.Text += ((byte)i).ToString("x");
                    textBox2.Text += " ";
                    buffer[i] = (byte)i;
                }
                bw.BaseStream.Write(buffer, 0, 5);
                //bw.Write("SaveFileDialog Test.");
                bw.Dispose();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        Thread t;
        Thread t1;
        string mmm;
        private void button5_Click(object sender, EventArgs e)
        {
            t = new Thread(MyFreeze);
            t.Start();

            object[] parm = { "name", 20};
            t1 = new Thread(write);
            t1.Start(parm);

            while (t1.IsAlive) ;
            textBox3.Text = mmm;
        }

        // 这里的参数只能是object
        void write(object array)
        {
            object[] o = array as object[];
            for (int i = 0; i < Convert.ToInt32(o[1]); i++)
            {
                mmm += o[0].ToString() + ": " + i + "\r\n";
            }
        }

        void MyFreeze()
        {
            for (; ; ) ;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(t!=null && t.IsAlive)
                t.Abort();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                WebClient wb = new WebClient();
                wb.DownloadFileAsync(new Uri("https://github.com/zhouwh1989/learn_c-/blob/master/README.md"), sfd.FileName);

                wb.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wb_DownloadStringCompleted);
                wb.DownloadFileCompleted += new AsyncCompletedEventHandler(wb_DownloadFileCompleted);
                wb.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wb_DownloadProgressChanged);
            }
        }

        void wb_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("Download progress changed! " + e.ProgressPercentage.ToString());
        }

        void wb_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("Download File success!");
        }

        void wb_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("downloadString success!");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(2018,1,23,2,23,32);
            MessageBox.Show(dt.ToString());
            DateTime dt1 = DateTime.Now;
            MessageBox.Show(dt1.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdl = new OpenFileDialog();
            if (fdl.ShowDialog() == DialogResult.OK)
            {
                //Image img = Image.FromFile(fdl.FileName);
                //pictureBox1.Image = img;
                //pictureBox1.ImageLocation = fdl.FileName;
                pictureBox1.ImageLocation = "https://www.google.com.hk/logos/doodles/2018/virginia-woolfs-136th-birthday-5857012284915712.6-l.png";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ColorDialog cdl = new ColorDialog();
            cdl.AnyColor = true;
            cdl.SolidColorOnly = true;
            cdl.ShowHelp = true;
            cdl.FullOpen = true;
            cdl.AllowFullOpen = false;
            cdl.HelpRequest += new EventHandler(cdl_HelpRequest);
            if (cdl.ShowDialog() == DialogResult.OK)
            {
                button9.BackColor = cdl.Color;
                //KnownColor
                Color c = cdl.Color;
                if (c.IsNamedColor)
                    MessageBox.Show(c.Name);
            }
        }

        void cdl_HelpRequest(object sender, EventArgs e)
        {
            MessageBox.Show("help pressed!!");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = true;
            fd.ShowHelp = true;
            fd.HelpRequest += new EventHandler(fd_HelpRequest);
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox5.Font = fd.Font;
            }
        }

        void fd_HelpRequest(object sender, EventArgs e)
        {
            MessageBox.Show("font help pressed!!");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox6.Text += DateTime.Now.ToString() + Environment.NewLine;
            textBox6.SelectionStart = textBox6.Text.Length;
            textBox6.ScrollToCaret();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            if (opd.ShowDialog() == DialogResult.OK)
            {
                // play wav file
                SoundPlayer sp = new SoundPlayer(opd.FileName);
                sp.Play();
            }

            //SystemSounds
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
            //f.ShowDialog();       //不可再操作之前的窗体
            f.FormTestshow();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.IsMdiContainer = true;
            f.Show();

            Form f1 = new Form2();
            f1.MdiParent = f;
            f1.Show();

            Form f2 = new Form2();
            f2.MdiParent = f;
            f2.Show();

            f.LayoutMdi(MdiLayout.TileVertical);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "2222")
            {
                MessageBox.Show("you guessed...");
            }
            comboBox1.Items[0] = "atom";
            comboBox1.Items.Add("steve");
            MessageBox.Show(comboBox1.Items.Count.ToString());
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //if (progressBar1.Value >= 100)
            //{
            //    progressBar1.Value = 0;
            //}
            //progressBar1.Value += 10;

            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 100;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            progressBar1.Style = ProgressBarStyle.Blocks;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(textBox7.Text);
            lvi.SubItems.Add(textBox8.Text);
            lvi.SubItems.Add(textBox9.Text);
            listView1.Items.Add(lvi);
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // 不管是选中了哪一行，只显示第一行的
            if (listView1.SelectedItems.Count != 0)
            {
                MessageBox.Show(listView1.SelectedItems[0].SubItems[0].Text);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvit in listView1.SelectedItems)
                {
                    MessageBox.Show(lvit.SubItems[0].Text);
                }
                
            }
        }

        private void 删除选中行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lvit in listView1.SelectedItems)
                {
                    lvit.Remove();
                }

            }
        }

        private void 删除所有行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvit in listView1.Items)
            {
                if(lvit.Checked)
                    lvit.Remove();
            }
        }

        //////////////////
    }
}
