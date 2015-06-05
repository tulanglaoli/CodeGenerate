
namespace DTDManager
{
    public class DTDElement
    {
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

         


        private string[] _ElementValue;
        public string[] ElementValue
        {
            get
            {
                return _ElementValue;
            }
            set
            {
                _ElementValue = value;
            }
        }

        private string _TypeValue;
        public string TypeValue
        {
            get
            {
                return _TypeValue;
            }
            set
            {
                _TypeValue = value;
            }
        }

        public DTDElement(string name, string TypeValue, string[] ElementValue)
        {
            this._Name = name;
            this._TypeValue = TypeValue;
            this._ElementValue = ElementValue;
        }

        public DTDElement()
        {
 
        }

        public override string ToString()
        {
            string s="";
            foreach(string v in _ElementValue)
            {
                s =  string.Format("{0}[{1}]",s,v);
            }
            return string.Format(
@"===================================
DTDElement:
Name:
[{0}]
ElementValue:
{1}
TypeValue:
[{2}]
===================================",
_Name, s, _TypeValue);
        }
    }
}
