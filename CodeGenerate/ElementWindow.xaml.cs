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
            while (ViewModelMain.Instance.People.Count > ElementGrid.RowDefinitions.Count-1)//后面减掉一是因为外面已经有一个了
            {
                ElementGrid.RowDefinitions.Add(new RowDefinition());
                Label A = new Label();
                A.SetBinding(Label.ContentProperty, new Binding(string.Format("People[{0}].ElementName2", ElementGrid.RowDefinitions.Count - 2)));
                A.SetValue(Grid.ColumnProperty, 1);
                A.SetValue(Grid.RowProperty, ElementGrid.RowDefinitions.Count-1);
                ElementGrid.Children.Add(A);

                TextBox B = new TextBox();
                B.SetBinding(TextBox.TextProperty, new Binding(string.Format("People[{0}].ElementName2", ElementGrid.RowDefinitions.Count - 2)));
                B.SetValue(Grid.ColumnProperty, 2);
                B.SetValue(Grid.RowProperty, ElementGrid.RowDefinitions.Count-1);
                ElementGrid.Children.Add(B);

                ComboBox C = new ComboBox();
                C.SetBinding(ComboBox.SelectedItemProperty, new Binding(string.Format("People[{0}].ElementName", ElementGrid.RowDefinitions.Count - 2)));
                C.SetValue(Grid.ColumnProperty, 3);
                C.SetValue(Grid.RowProperty, ElementGrid.RowDefinitions.Count-1);
                foreach (string ViewModel in ViewModelMain.Instance.People[ElementGrid.RowDefinitions.Count - 2].ElementName3)
                {
                    C.Items.Add(ViewModel);
                }
                ElementGrid.Children.Add(C);
            }
        }
    }
}
