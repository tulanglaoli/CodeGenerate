using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using CodeGenerate.Model;
using CodeGenerate.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace CodeGenerate.ViewModel
{
    class ViewModelMain : ViewModelBase
    {

        public static ViewModelMain Instance;
        public ObservableCollection<DTDelemInterface> People { get; set; }

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

        object _SelectedPerson;
        public object SelectedPerson
        {
            get
            {
                return _SelectedPerson;
            }
            set
            {
                if (_SelectedPerson != value)
                {
                    _SelectedPerson = value;
                    RaisePropertyChanged("SelectedPerson");
                }
            }
        }

        string _XMLText;
        public string XMLText
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
                    RaisePropertyChanged("TextProperty1");
                }
            }
        }

        public RelayCommand AddUserCommand { get; set; }

        public ViewModelMain()
        {
            People = new ObservableCollection<DTDelemInterface>
            {
                new DTDelemInterface {ElementName="Tom",ElementName2="Tom",ElementName3= new string[]{"222","Tom","222"}},
                new DTDelemInterface {ElementName="Dick",ElementName2="Dick",ElementName3=new string[]{"222","Dick","222"}},
                new DTDelemInterface {ElementName="Harry",ElementName2="Harry",ElementName3=new string[]{"222","Harry","222"} },
            };

            XMLText = "Tysdsdsdsdsdsadasdsadpe here";

            AddUserCommand = new RelayCommand(AddUser);
            Instance = this;
        }

        void AddUser(object parameter)
        {
            if (parameter == null) return;
            People.Add(new DTDelemInterface { ElementName = "Tom", ElementName2 = parameter.ToString(), ElementName3 = new string[] { parameter.ToString(), parameter.ToString(), parameter.ToString() } });
        }
    }
}
