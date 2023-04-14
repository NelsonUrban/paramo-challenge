
using Newtonsoft.Json;
using Sat.Recruitment.Business.Models;

namespace Sat.Recruitment.Business.Dtos
{
    public class UserReponseDto : ResultModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UserType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public decimal Money { get; set; }
    }
}
