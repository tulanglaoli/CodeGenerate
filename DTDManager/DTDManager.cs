using System.Collections;
using System.IO;
using System.Collections.Generic;


namespace DTDManager
{
    public class DTDDocment
    {
        private static DTDDocment _instance;

        public static DTDDocment Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DTDDocment(); 
                }
                return _instance;
            }
        }

        private string _Text;
        public string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
            }
        }

        private List<DTDBody> _Docment;
        public List<DTDBody> Docment
        {
            get
            {
                return _Docment;
            }
            set
            {
                _Docment = value;
            }
        }

        private string _File;
        public string File
        {
            get
            {
                return _File;
            }
            
        }

        public DTDDocment(string File)
        {
            _File = File;
        }

        public DTDDocment()
        {
        }

        public void Load(string file)
        {
            _File = file;
            using (StreamReader sr = new StreamReader(file))
            {
                Text = sr.ReadToEnd();
                sr.Close();
            }

            DTDParse parse = new DTDParse();
            parse.Source = Text;
            _Docment = parse.Parse();

        }

    }
   
}
