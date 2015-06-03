

namespace DTDManager
{

    /// <summary>
    /// DTD of DTDATTLISTItem
    /// </summary>
    public class DTDATTLISTItem 
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

         


        private string[] _TypeValue;
        public string[] TypeValue
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

        private string _DefaultValue;
        public string DefaultValue
        {
            get
            {
                return _DefaultValue;
            }
            set
            {
                _DefaultValue = value;
            }
        }

        public DTDATTLISTItem(string name, string DefaultValue, string[] TypeValue)
        {
            this._Name = name;
            this._DefaultValue = DefaultValue;
            this._TypeValue = TypeValue;
        }

        public DTDATTLISTItem()
        {

        }
        
    }
}
