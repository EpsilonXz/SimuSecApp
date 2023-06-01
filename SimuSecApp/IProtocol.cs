using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuSecApp
{
    public interface IProtocol
    {
        bool isVerified (string LoopBackValue);
        string GetCurrentTimeAsString ();
        string PackCardHolderNameFormat (string cardHolderName);
        string PackCardNumberFormat (string cardNumber);
        string PackCardExpirationDateFormat (string cardExpirationDateMonths,
                                            string cardExpirationDateYears);
        string PackCardCVVFormat (string cardCVV);
    }
}
