using System.Collections.Generic;

namespace Sat.Recruitment.Business.Models
{
    public class ResultModel
    {
        public bool IsSuccess { get; set; } = true;
        public string Errors { get; set; } = Message.UserMessage.Created;
    }
}
