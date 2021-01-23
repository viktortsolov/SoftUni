using System.Linq;

using Phones.Exceptions;
using Phones.Interfaces;

namespace Phones.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public Smartphone()
        {

        }

        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidURLException();
            }

            return $"Browsing: {url}!";
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberException();
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
