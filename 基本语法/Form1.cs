using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNameSpace;

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
            // openfileDialogs
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本|*.txt|图片|*.jpg";
            ofd.Title = "OpenFileDialogTest";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
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
    }
}
