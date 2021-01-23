using System;

namespace Phones.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string INVALID_PHONE_NUMBER__EXCEPTION_MSG = "Invalid number!";
        public InvalidPhoneNumberException()
            : base(INVALID_PHONE_NUMBER__EXCEPTION_MSG)
        {

        }
    }
}
