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

        }

        void mc_OnpropertyChanged(object sender, EventArgs e)
        {
            MessageBox.Show("The property has been changed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //convert Bitconvert 基础类型转换，区别在于BitConvert是将基础类型转为byte数组

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
        //////////////////
    }
}
