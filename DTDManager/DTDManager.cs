using System.Collections;
using System.IO;



namespace DTDManager
{
    public class DTDManager
    {
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

        private ArrayList _Elements;
        public ArrayList Elements
        {
            get
            {
                return _Elements;
            }
            set
            {
                _Elements = value;
            }
        }

        public DTDBody this[string name]
        {
            get
            {
                for (int i = 0; i < Elements.Count; i++)
                {
                    if (((DTDBody)Elements[i]).Name.Equals(name))
                        return (DTDBody)Elements[i];
                }

                return null;
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

        public DTDManager(string File)
        {
            _File = File;
        }

        public void Load(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                Text = sr.ReadToEnd();
                sr.Close();
            }

            DTDParse parse = new DTDParse();
            parse.Source = Text;
            Elements = parse.Parse();

        }

    }
   
}
