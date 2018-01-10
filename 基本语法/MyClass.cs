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
        // 如果使用override，那么基类的方法必须是virtual的

        // 成员变量默认是private
        public string Name { get; };    // 控制属性只读
        string type;

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
    }
}
