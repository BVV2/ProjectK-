using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectKLib;
namespace DebugConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string FName;
            string SName;
            string Tel;
            string Mail;
            Console.WriteLine("Enter First, Second names, Tel and E-mail ");
            FName = Console.ReadLine();
            SName = Console.ReadLine();
            Tel = Console.ReadLine();
            Mail = Console.ReadLine();
            ProjectKLib.SQLHandler SQL = new SQLHandler();
            SQL.NewClient(FName, SName, Tel, Mail);


        }
    }
}
