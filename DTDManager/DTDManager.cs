using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTDManager
{
    public static class DTDManager
    {

        public static DTDBody FindBodybyName(List<DTDBody> db,string name)
        {
            foreach (DTDBody DB in db)
            {
                if (DB.Name == name)
                {
                    return DB;
                }
            }
            return null;
        }

        public static DTDATTLISTItem FindElementByName(DTDBody db, string name)
        {
            foreach (DTDATTLISTItem dat in db.DTDAttList)
            {
                if(dat.Name == name)
                {
                    return dat;
                }
            }
            return null;
        }

    }
}
