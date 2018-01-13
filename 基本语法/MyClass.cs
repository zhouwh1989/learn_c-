using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNameSpace
{
    class MyClass
    {
        // 继承的时候可以使用base访问基类

        // override 关键字是new
        // 如果使用override，那么基类的方法必须是virtual, abstract或者override的

        // 成员变量默认是private
        public string Name { get; private set; }    // 控制属性只读
        string type;

        // indexers
        public string[] testString = {"one", "two", "three"};
        public string this[int index]
        {
            get { return testString[index]; }
            set { testString[index] = value;}
        }

        public MyClass()
        {
            MessageBox.Show(Name);
        }

        public MyClass(string name)
        {
            Name = name;
            MessageBox.Show(name);
        }

        public string GetName()
        {
            return Name;
        }

        public static void showMsg(string msg)
        {
            MessageBox.Show("I have message: " + msg);
        }

        public virtual void showMsg()
        {
            MessageBox.Show("I am just a messageBox");
        }

        //delegates 使用相同的参数同时调用多个接口
        delegate int MyDeleGate(string s);
        public void showDelegateMsgs()
        {
            MyDeleGate md = new MyDeleGate(showDelegateMsg1);
            md += showDelegateMsg2;
            md("test");
        }
        public int showDelegateMsg1(string s)
        {
            MessageBox.Show(s + ": I am in showDelegateMsg1");
            return 1;
        }
        public int showDelegateMsg2(string s)
        {
            MessageBox.Show(s + ": I am in showDelegateMsg2");
            return 2;
        }

        // event
        public event EventHandler OnPropertyChanged;
        public string eventname = "";
        public string eventName
        {
            get { return eventname; }
            set 
            { 
                eventname = value;
                OnPropertyChanged(this, new EventArgs());
            }
        }
    }

    class MySecondClass : MyClass, MyInterface
    {
        public string s = "test";

        public override void showMsg()
        {
            MessageBox.Show("I am just a messageBox in MySecondClass");
        }

        public void MyVoid()
        {
            base.showMsg();
            MessageBox.Show("MyVoid Interface in MySecondClass");
        }
    }

    interface MyInterface
    {
        void MyVoid();
    }

    //partial 两个相同的类，其中各自有一部分定义，最终组合成一个完整的
    partial class partialTestClass
    {
        public string name = "Vanora";
        public int age = 30;
    }

    // abstract
    // abstract类不能被实例化
    // abstract类可以被继承，有abstract方法时，类也必须是abstract
    // abstract方法不可以有具体实现
}
