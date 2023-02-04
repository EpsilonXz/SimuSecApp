using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuSecApp
{
    public class Protocol : IProtocol
    {
        private string TestIndicator = "TEST:::";
        public string PackUsernameFormat(string username)
        {
            return TestIndicator + username;
        }
        
        public string PackPasswordFormat(string password)
        {
            return TestIndicator + password;
        }
        public string PackCardHolderNameFormat(string cardHolderName)
        {
            return TestIndicator + cardHolderName;
        }
        public string PackCardNumberFormat(string cardNumber)
        {
            return TestIndicator + cardNumber;
        }
        public string PackCardExpirationDateFormat (string cardExpirationDateMonths,
                                                    string cardExpirationDateYears)
        {
            return TestIndicator + cardExpirationDateMonths + "/" + cardExpirationDateYears;
        }
        public string PackCardCVVFormat (string cardCVV)
        {
            return TestIndicator + cardCVV;
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
