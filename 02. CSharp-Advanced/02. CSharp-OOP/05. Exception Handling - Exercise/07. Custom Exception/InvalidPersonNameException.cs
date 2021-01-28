using System;

namespace _07._Custom_Exception
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException()
        {

        }
        public InvalidPersonNameException(string username, string msg)
            : base(msg)
        {
            Username = username;
        }

        public string Username { get; set; }
    }
}
