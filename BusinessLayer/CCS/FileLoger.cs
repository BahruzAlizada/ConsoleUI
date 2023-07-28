using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CCS
{
    public class FileLoger : ILoger
    {
        public void Log()
        {
            Console.WriteLine("Folder loglama oldu");
        }
    }
}
