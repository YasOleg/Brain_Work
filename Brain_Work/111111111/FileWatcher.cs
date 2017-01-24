using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace _111111111
{

    class FileWatcher
    {
        public delegate void FWatchDelegate();
        public event FWatchDelegate FChange = null;

        public static string path = "TxtWork.txt";

        public void Add_Txt()
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            else
            {                
                File.SetLastWriteTime(path, new DateTime(1985, 4, 3));
            }
        }

        public void EventDetectFchanges(object state)
        {
            if (FChange != null)
            {
                FChange.Invoke();
            }
         }

        public void Start(string path)
        {
            DateTime dtCreated = new DateTime(1985, 4, 3);
            DateTime dtDetectNow;
            while (true)
            {
                dtDetectNow = File.GetLastWriteTime(path);
                if (dtDetectNow != dtCreated)
                {
                    ThreadPool.QueueUserWorkItem(EventDetectFchanges);
                    dtCreated = dtDetectNow;
                }
            }
        }
    }

}
