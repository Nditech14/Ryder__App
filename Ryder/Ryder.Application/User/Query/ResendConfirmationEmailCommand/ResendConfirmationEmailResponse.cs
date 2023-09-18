using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Application.User.Query.ResendConfirmationEmail
{
    public class ResendConfirmationEmailResponse
    {
        public bool IsSuccess { get; set; } // Indicates whether the email was successfully resent
        public string Message { get; set; } // Any additional message about the operation
    }
}
