using System;
using System.ComponentModel;
using System.Windows;
using DTDManager;
using System.Xml;
using CodeGenerate.ViewModel;

namespace CodeGenerate.Model
{
    public class DTDATTLISTItemModel : INotifyPropertyChanged
    {
        DTDATTLISTItem DT;
        XmlNode xn;
        string _ATTItemName;
        public string ATTItemName
        {
            get
            {
                return _ATTItemName;
            }
            set
            {
                if (_ATTItemName != value)
                {
                    _ATTItemName = value;
                    RaisePropertyChanged("ATTItemName");
                }
            }
        }

        string _Type;
        public string Type
        {
            get
            {
                return _Type;
            }
            set
            {
                if (_Type != value)
                {
                    _Type = value;
                    RaisePropertyChanged("Type");
                }
            }
        }

        string _TypeAtt;
        public string TypeAtt
        {
            get
            {
                return _TypeAtt;
            }
            set
            {
                if (_TypeAtt != value)
                {
                    _TypeAtt = value;
                    RaisePropertyChanged("TypeAtt");
                }
            }
        }

        string[] _TypeValue;
        public string[] TypeValue
        {
            get
            {
                return _TypeValue;
            }
            set
            {
                if (_TypeValue != value)
                {
                    _TypeValue = value;
                    RaisePropertyChanged("TypeValue");
                }
            }
        }

        string _CurrentValue;
        public string CurrentValue
        {
            get
            {
                return _CurrentValue;
            }
            set
            {
                if (_CurrentValue != value)
                {
                    _CurrentValue = value;
                    if (xn.Attributes[_ATTItemName] != null)
                        xn.Attributes[_ATTItemName].InnerXml = _CurrentValue;
                    else
                    {
                        xn.Attributes.Append(xn.OwnerDocument.CreateAttribute(_ATTItemName)).InnerXml = _CurrentValue;
                    }
                    //注意！！！此处用了外界的东西
                    ViewModelMain.Instance.XMLText = xn.CloneNode(false);
                    RaisePropertyChanged("CurrentValue");
                }
            }
        }

        public DTDATTLISTItemModel(DTDATTLISTItem dt, XmlNode XN)
        {
            this.DT = dt;
            this.xn = XN;
            _ATTItemName=DT.Name;
            if (dt.TypeValue.Length == 1)
            {
                _Type = dt.TypeValue[0];
            }
            else
            {
                _Type = "ENUM";
                _TypeValue = dt.TypeValue;
            }
            TypeAtt = dt.DefaultValue;
            if (dt.DefaultValue != "#REQUIRED" && dt.DefaultValue != "#IMPLIED")
            {
                _CurrentValue = TypeAtt;
            }
            else
            {
                if (XN.Attributes[_ATTItemName] != null)
                    _CurrentValue = XN.Attributes[_ATTItemName].InnerXml;
            }
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;


    }
}
