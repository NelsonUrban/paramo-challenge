using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Business.Message
{
    public readonly struct UserMessage
    {
        public static readonly string Duplicated = "The user is duplicated";      
        public static readonly string Created = "User Created";
    }
}
