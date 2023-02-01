using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuSecApp
{
    public interface IProtocol
    {
        string PackUsernameFormat(string username);
        string PackPasswordFormat(string password);
    }
}
