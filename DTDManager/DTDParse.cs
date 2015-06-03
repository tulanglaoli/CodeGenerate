using System.Collections;
using System.Text;



namespace DTDManager
{
    public class DTDParse
    {

        private string m_source;
        private int m_idx;

        public static bool IsWhiteSpace(char ch)
        {
            return ("\t\n\r ".IndexOf(ch) != -1);
        }

        public static int IsInkey(char ch,string key)
        {
            return key.IndexOf(ch);
        }

        public void EatWhiteSpace()
        {
            while (!Eof())
            {
                if (!IsWhiteSpace(GetCurrentChar()))
                    return;
                Advance();
            }
        }

        public void EatSpecialKey(string key)
        {
            while (!Eof())
            {
                if (!IsWhiteSpace(GetCurrentChar()) && IsInkey(GetCurrentChar(),key)!=-1)
                    return;
                Advance();
            }
        }


        public bool Eof()
        {
            return (m_idx >= m_source.Length);
        }


        public char GetCurrentChar()
        {
            return GetCurrentChar(0);
        }

        public char GetCurrentChar(int peek)
        {
            if ((m_idx + peek) < m_source.Length)
                return m_source[m_idx + peek];
            else
                return (char)0;
        }

        

        public char AdvanceCurrentChar()
        {
            return m_source[Advance()];
        }

        public int Advance()
        {
            return m_idx++;
        }

        public string Source
        {
            get
            {
                return m_source;
            }

            set
            {
                m_source = value;
            }
        }


        public string ParseWord(string key)
        {
            StringBuilder element = new StringBuilder();
            
            while (!Eof() && IsInkey(GetCurrentChar(), key) == -1)
            {
                element.Append(AdvanceCurrentChar());
            }
            EatSpecialKey(key);
            return element.ToString().Trim();
        }

        



        public string ParseAttributeName()
        {
            StringBuilder attribute = new StringBuilder();
            EatWhiteSpace();

            while (!Eof())
            {
                if (GetCurrentChar() == ':')
                {
                    Advance();
                    break;
                }
                attribute.Append(GetCurrentChar());
                Advance();
            }

            EatWhiteSpace();
            return attribute.ToString().Trim();
        }

        public string ParseAttributeValue()
        {
            StringBuilder attribute = new StringBuilder();
            EatWhiteSpace();
            while (!Eof())
            {
                if (GetCurrentChar() == ';')
                {
                    Advance();
                    break;
                }
                attribute.Append(GetCurrentChar());
                Advance();
            }

            EatWhiteSpace();
            return attribute.ToString().Trim();
        }

        public ArrayList Parse()
        {
            ArrayList elements = new ArrayList();

            while (!Eof())
            {
                
                //if (AdvanceCurrentChar() == '<' && AdvanceCurrentChar() == '!')
                //{
                //    DTDBody DB = new DTDBody();
                //    EatWhiteSpace();
                //    string type = ParseWord();
                //    if(type == "ELEMENT")
                //    {
                //        string Name = ParseWord();
                //        DB.Name = Name;
                //        if (IsListWord(AdvanceCurrentChar()))
                //        {
                //            string[] List = ParseWord().Split(new char[1]{'|'});
                //            if (IsListWord(AdvanceCurrentChar()))
                //            {
                //                DTDElement DE = new DTDElement(Name, AdvanceCurrentChar().ToString(), List);
                //                DB.DTDelement = DE;
                //            }
                //        }
                //    }
                //    if (IsEndWord(AdvanceCurrentChar()))
                //    {
                //        if (AdvanceCurrentChar() == '<' && AdvanceCurrentChar() == '!')
                //        {
                //            type = ParseWord();
                //            if (type == "ATTLIST")
                //            {
                //                string ItemName = ParseWord();


                //            }
                //        }
                //    }
                //}
                //else if (AdvanceCurrentChar() == '>')
                //{

                //}
            }
            return elements;
        }

        public DTDBody ParseInState(ref ParseState p)
        {
            DTDBody DB = new DTDBody();
            
            while (p != ParseState.End||p!= ParseState.error)
            {
                string error = "";
                switch (p)
                {
                    case ParseState.Start:
                        if (AdvanceCurrentChar() == '!')
                        {
                            p = ParseState.ElementOrATTList;
                            EatWhiteSpace();
                        }
                        break;
                    case ParseState.ElementOrATTList:
                        string t = ParseWord("\t\n\r ");
                        if (t == "ELEMENT")
                            p = ParseState.BodyName;
                        else if (t == "ATTLIST")
                            p = ParseState.BodyName2;
                        else
                        {
                            error = "该类型不属于ELEMENT也不属于ATTLIST!";
                            p = ParseState.error;
                        }
                        break;
                    case ParseState.BodyName:
                        t = ParseWord("\t\n\r ");
                        DB.Name = t;
                        DB.DTDelement.Name = t;
                        if (AdvanceCurrentChar() == '(')
                            p = ParseState.Islist;
                        else
                            p = ParseState.Nolist;
                        break;
                    case ParseState.Islist:
                        t = ParseWord(")");
                        string[] l = t.Split(new char[1]{'|'});
                        DB.DTDelement.ElementValue = l;
                        p = ParseState.Type;
                        break;
                    case ParseState.Nolist:
                        t = ParseWord("\t\n\r ");
                        break;
                    case ParseState.Type:
                        DB.DTDelement.TypeValue = ParseWord(">");
                        if (AdvanceCurrentChar() == '<' && AdvanceCurrentChar() == '!')
                            p = ParseState.Start;
                        break;
                    case ParseState.BodyName2:
                        break;
                    case ParseState.ItemName:
                        break;
                    case ParseState.TypeValue:
                        break;
                    case ParseState.DefaultValue:
                        break;
                    case ParseState.Isend:
                        break;
                    case ParseState.End:
                        break;
                    case ParseState.error:
                        break;
                }
            }
            return DB;
        }

        public enum ParseState
        {
            Start=1,
            ElementOrATTList,
            BodyName,
            Islist,
            Nolist,
            Type,
            BodyName2,
            ItemName,
            TypeValue,
            DefaultValue,
            Isend,
            End,
            error
        }
    }
}
