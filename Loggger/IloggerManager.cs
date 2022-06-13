using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggger
{
    public interface IloggerManager
    {
        public void LogDebug(string message);
        public void LogError(string message);
        public void LogInfo(string message);
        public void LogWarn(string message);
    }
}
