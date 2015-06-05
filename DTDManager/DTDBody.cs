using System.Collections.Generic;
using System.Text;
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

        public override string ToString()
        {
            

            return string.Format(
@"*********************************
DTDBody:
Name:
[{0}]
DTDelement:
{1}
DTDAttList:
{2}
***********************************",
_Name, _dtdelement.ToString(), ATTListToString());
        }

        string ATTListToString()
        {
            StringBuilder SB = new StringBuilder();
            foreach (DTDATTLISTItem dt in _DTDATTList)
            {
                SB.Append(string.Format("\n{0}", dt.ToString()));
            }
            return SB.ToString();
        }

    }


}
