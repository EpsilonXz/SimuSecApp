using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuSecApp
{
    public class Protocol : IProtocol
    {
        public string PackUsernameFormat(string username)
        {
            return "TESTUSER:::" + username;
        }
        
        public string PackPasswordFormat(string password)
        {
            return "TESTPASS:::" + password;
        }

        

        public bool isVerified(string LoopBackValue)
        {
            
            if (LoopBackValue == "OK")
            {
                return true;
            }

            return false;
        }

        public string GetCurrentTimeAsString()
        {
            DateTime currentTime = DateTime.Now;
            return currentTime.ToString("dd/MM/yyyy");
        }
    }
}
