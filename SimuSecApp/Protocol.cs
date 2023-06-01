using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuSecApp
{
    public class Protocol : IProtocol
    {
        public string PackByProtocol(string[] args, string type = "")
        {
            string fullString = "";

            if (type != "")
                fullString = type + ":::";

            foreach (var item in args)
            {
                fullString += item+ ":::";
            }

            fullString = fullString.Remove(fullString.Length - 3, 3);

            return fullString;

        }
        public string[] SplitByProtocol(string packedMsg)
        {
            string[] args = packedMsg.Split(':');

            string fullString = "";

            foreach (var item in args)
            {
                if (item != "")
                    fullString += item + " ";
            }
            fullString = fullString.Remove(fullString.Length - 1, 1);

            string[] toReturn = fullString.Split(' ');

            return toReturn;

        }

        public string PackCardHolderNameFormat(string cardHolderName)
        {
            return cardHolderName;
        }
        public string PackCardNumberFormat(string cardNumber)
        {
            return cardNumber;
        }
        public string PackCardExpirationDateFormat (string cardExpirationDateMonths,
                                                    string cardExpirationDateYears)
        {
            return cardExpirationDateMonths + "/" + cardExpirationDateYears;
        }
        public string PackCardCVVFormat (string cardCVV)
        {
            return cardCVV;
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
