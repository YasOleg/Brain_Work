using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace _111111111
{
    class Program
    {
        private static void Watcher_FileChanged()
        {
            Console.WriteLine("Enter Watcher_FileChanged");
            string content = File.ReadAllText("TxtWork.txt");
            if (content == "1")
            {
                File.WriteAllText("TxtWork.txt", "0");
                Thread.Sleep(10000);
            }
            else
            {
                Console.WriteLine("Content: {0}. ChangeTime: {1}", content, DateTime.Now);
            }
        }
        static void Main(string[] args)
        {
            FileWatcher FWatch = new FileWatcher();
            FWatch.Add_Txt();
            FWatch.FChange += Watcher_FileChanged;
            FWatch.Start("TxtWork.txt");
        }
            
    }
}

        
