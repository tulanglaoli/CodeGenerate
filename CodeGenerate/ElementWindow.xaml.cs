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

namespace CodeGenerate
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class ElementWindow : Window
    {
        public ElementWindow()
        {
            
            InitializeComponent();
            //动态添加数据
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModelMain.Instance.AddControl(ElementGrid);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
