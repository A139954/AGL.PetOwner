using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGL.PetOwner.Utilities
{
    public static class Logger
    {
        private static log4net.ILog Log { get; set; }

        static Logger()
        {
            Log = log4net.LogManager.GetLogger(typeof(Logger));
        }

        public static void Error(object msg)
        {
            Log.Error(msg);
        }
 
        public static void Info(object msg)
        {
            Log.Info(msg);
        }

        public static void HandleException(Exception ex)
        {
            Log.Error(ex.Message, ex);
        }
    }
}
