using System;
using System.ComponentModel;
using System.Windows;

namespace CodeGenerate.Model
{
    public class DTDelemInterface : INotifyPropertyChanged
    {
        string _Elementname;
        public string ElementName
        {
            get
            {
                return _Elementname;
            }
            set
            {
                if (_Elementname != value)
                {
                    _Elementname = value;
                    RaisePropertyChanged("ElementName");
                }
            }
        }

        string _Elementname2;
        public string ElementName2
        {
            get
            {
                return _Elementname2;
            }
            set
            {
                if (_Elementname2 != value)
                {
                    _Elementname2 = value;
                    RaisePropertyChanged("ElementName2");
                }
            }
        }


        string[] _Elementname3;
        public string[] ElementName3
        {
            get
            {
                return _Elementname3;
            }
            set
            {
                if (_Elementname3 != value)
                {
                    _Elementname3 = value;
                    RaisePropertyChanged("ElementName3");
                }
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
