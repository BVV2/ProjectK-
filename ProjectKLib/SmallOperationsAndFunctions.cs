using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectKLib
{
    class SmallOperationsAndFunctions
    {
        public string NameSplitter(string inputName)
        {
          string[] names = inputName.Split(' ');
          if (names.Length > 2)
          Console.WriteLine("there is some problems in your name");
          return names[0];
        }
    }
}
