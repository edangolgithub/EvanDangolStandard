using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EvanDangol.Validation
{
    class EvanValidation
    {
    }
    public class MailManager
    {
        public bool IsValidAddress(string emailAddress)
        {
            Regex regex = new Regex(@"^[\w0-9._%+-]+@[\w0-9.-]+\.[\w]{2,6}$");
            return regex.IsMatch(emailAddress);
        }
    }
}
