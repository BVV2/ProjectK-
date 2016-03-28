using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectKLib
{
    public class MainData
    {
        public Dictionary<int,bool> ClosingTables;
        public Dictionary<int, bool> OpenTables;

        public SQLHandler SQLHandler
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}
