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
    }
}
