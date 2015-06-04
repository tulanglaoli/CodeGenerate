using System.Collections.Generic;

namespace DTDManager
{
    public class DTDBody
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

        private DTDElement _dtdelement;
        public DTDElement DTDelement
        {
            get
            {
                return _dtdelement;
            }
            set
            {
                _dtdelement = value;
            }
        }

        private List<DTDATTLISTItem> _DTDATTList;
        public List<DTDATTLISTItem> DTDAttList
        {
            get
            {
                return _DTDATTList;
            }
        }

        public DTDBody(string name,DTDElement dtdelement)
        {
            this._Name = name;
            this._dtdelement = dtdelement;
            this._DTDATTList = new List<DTDATTLISTItem>();
        }


        public DTDBody()
        {
            this._dtdelement = new DTDElement();
            this._DTDATTList = new List<DTDATTLISTItem>();
        }



        public void AddDTDAttList(DTDATTLISTItem DAL)
        {
            this._DTDATTList.Add(DAL);
        }
    }
}
