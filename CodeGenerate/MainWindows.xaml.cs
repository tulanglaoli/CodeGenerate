using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CodeGenerate.ViewModel;
using DTDManager;
using DotNet.Tools;
using System.Xml;

namespace CodeGenerate
{
    /// <summary>
    /// MainWindows.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindows : Window
    {
        MyXMLManager mxm;
        public MainWindows(string filePath,string filename,string DTDfile)
        {
            InitializeComponent();
            if (filePath.Trim().Last<char>() == '\\')
            {
                mxm = new MyXMLManager(filePath + filename + "Operator.xml");
               
            }
            else 
            {
                mxm = new MyXMLManager(filePath + "\\" + filename + "Operator.xml");
            }

            DTDDocment.Instance.Load(DTDfile);
            StringBuilder sb = new StringBuilder();
           
            foreach(XmlNode xn in mxm.Xmldoc.ChildNodes)
            {
                sb.AppendLine(xn.OuterXml);
            }
            File1_Text.Text = sb.ToString() ;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlNode xn = mxm.readnode(@"//Dataset");
            var win = new ElementWindow { DataContext = new ViewModelMain(DTDManager.DTDManager.FindBodybyName(DTDDocment.Instance.Docment, "Dataset"), xn) };
            win.Show();
        }

        private void File1_Text_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Label_Postion.Content = File1_Text.Text[File1_Text.SelectionStart];
        }

      
    }
}
