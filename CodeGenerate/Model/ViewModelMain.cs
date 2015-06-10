using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using CodeGenerate.Model;
using CodeGenerate.Helpers;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using DTDManager;
using System.Xml;

namespace CodeGenerate.ViewModel
{
    class ViewModelMain : ViewModelBase
    {

        public static ViewModelMain Instance;
        public ObservableCollection<DTDATTLISTItemModel> AttList { get; set; }

        /// <summary>
        /// SelectedItem is an object instead of a Person, only because we are allowing "CanUserAddRows=true" 
        /// NewItemPlaceHolder represents a new row, and this is not the same as Person class
        /// 
        /// Change 'object' to 'Person', and you will see the following:
        /// 
        /// System.Windows.Data Error: 23 : Cannot convert '{NewItemPlaceholder}' from type 'NamedObject' to type 'MvvmExample.Model.Person' for 'en-US' culture with default conversions; consider using Converter property of Binding. NotSupportedException:'System.NotSupportedException: TypeConverter cannot convert from MS.Internal.NamedObject.
        ///   at System.ComponentModel.TypeConverter.GetConvertFromException(Object value)
        ///   at System.ComponentModel.TypeConverter.ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, Object value)
        ///   at MS.Internal.Data.DefaultValueConverter.ConvertHelper(Object o, Type destinationType, DependencyObject targetElement, CultureInfo culture, Boolean isForward)'
        ///System.Windows.Data Error: 7 : ConvertBack cannot convert value '{NewItemPlaceholder}' (type 'NamedObject'). BindingExpression:Path=SelectedPerson; DataItem='ViewModelMain' (HashCode=47403907); target element is 'DataGrid' (Name=''); target property is 'SelectedItem' (type 'Object') NotSupportedException:'System.NotSupportedException: TypeConverter cannot convert from MS.Internal.NamedObject.
        ///   at MS.Internal.Data.DefaultValueConverter.ConvertHelper(Object o, Type destinationType, DependencyObject targetElement, CultureInfo culture, Boolean isForward)
        ///   at MS.Internal.Data.ObjectTargetConverter.ConvertBack(Object o, Type type, Object parameter, CultureInfo culture)
        ///   at System.Windows.Data.BindingExpression.ConvertBackHelper(IValueConverter converter, Object value, Type sourceType, Object parameter, CultureInfo culture)'
        /// </summary>



        XmlNode _XMLText;
        public XmlNode XMLText
        {
            get
            {
                return _XMLText;
            }
            set
            {
                if (_XMLText != value)
                {
                    _XMLText = value;
                    RaisePropertyChanged("XMLText");
                }
            }
        }

        public string Name
        {
            get;
            set;
        }

        

        public RelayCommand SaveCommand { get; set; }

        public ViewModelMain(DTDBody DTDbody,XmlNode xn)
        {
            XmlNode XN = xn.CloneNode(false);
            AttList = GetModelList(DTDbody, xn);
            _XMLText = XN;
            Name = DTDbody.Name;
            SaveCommand = new RelayCommand(Save);
            Instance = this;

        }

        void Save(object parameter)
        {
            if (parameter == null) return;
            this.CloseWindow();
        }

        public void AddControl(Grid ElementGrid)
        {
            while (AttList.Count > ElementGrid.RowDefinitions.Count - 1)//后面减掉一是因为外面已经有一个了
            {
                ElementGrid.RowDefinitions.Add(new RowDefinition());

                Label A = new Label();
                A.SetBinding(Label.ContentProperty, new Binding(string.Format("AttList[{0}].ATTItemName", ElementGrid.RowDefinitions.Count - 2)));
                A.SetValue(Grid.ColumnProperty, 0);
                A.SetValue(Grid.RowProperty, ElementGrid.RowDefinitions.Count - 1);
                ElementGrid.Children.Add(A);

                Label E = new Label();
                E.SetBinding(Label.ContentProperty, new Binding(string.Format("AttList[{0}].Type", ElementGrid.RowDefinitions.Count - 2)));
                E.SetValue(Grid.ColumnProperty, 1);
                E.SetValue(Grid.RowProperty, ElementGrid.RowDefinitions.Count - 1);
                ElementGrid.Children.Add(E);

                Label F = new Label();
                F.SetBinding(Label.ContentProperty, new Binding(string.Format("AttList[{0}].TypeAtt", ElementGrid.RowDefinitions.Count - 2)));
                F.SetValue(Grid.ColumnProperty, 2);
                F.SetValue(Grid.RowProperty, ElementGrid.RowDefinitions.Count - 1);
                ElementGrid.Children.Add(F);

                if (AttList[ElementGrid.RowDefinitions.Count - 2].Type == "ENUM")
                {
                    ComboBox C = new ComboBox();
                    C.SetBinding(ComboBox.SelectedItemProperty, new Binding(string.Format("AttList[{0}].CurrentValue", ElementGrid.RowDefinitions.Count - 2)));
                    C.SetValue(Grid.ColumnProperty, 3);
                    C.SetValue(Grid.RowProperty, ElementGrid.RowDefinitions.Count - 1);
                    foreach (string ViewModel in AttList[ElementGrid.RowDefinitions.Count - 2].TypeValue)
                    {
                        C.Items.Add(ViewModel);
                    }
                    ElementGrid.Children.Add(C);
                }
                else
                {
                    TextBox B = new TextBox();
                    B.SetBinding(TextBox.TextProperty, new Binding(string.Format("AttList[{0}].CurrentValue", ElementGrid.RowDefinitions.Count - 2)));
                    B.SetValue(Grid.ColumnProperty, 3);
                    B.SetValue(Grid.RowProperty, ElementGrid.RowDefinitions.Count - 1);
                    ElementGrid.Children.Add(B);
                }
                Label D = new Label();
                D.SetBinding(Label.ContentProperty, new Binding(string.Format("AttList[{0}].CurrentValue", ElementGrid.RowDefinitions.Count - 2)));
                D.SetValue(Grid.ColumnProperty, 4);
                D.SetValue(Grid.RowProperty, ElementGrid.RowDefinitions.Count - 1);
                ElementGrid.Children.Add(D);
            }
        }

        public ObservableCollection<DTDATTLISTItemModel> GetModelList(DTDBody DTDbody, XmlNode XN)
        {
            ObservableCollection<DTDATTLISTItemModel> o = new ObservableCollection<DTDATTLISTItemModel>();
            foreach (DTDATTLISTItem DT in DTDbody.DTDAttList)
            {
                o.Add(new DTDATTLISTItemModel(DT, XN));
            }
            return o;
        }
    }
}
