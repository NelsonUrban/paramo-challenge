using Sat.Recruitment.Custom.Constants;
using Sat.Recruitment.Business.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Business.Services.Concrete
{
    public class MoneyService : IMoneyService
    {
        private readonly Dictionary<string, decimal> keyValues = new Dictionary<string, decimal>();

        public MoneyService()
        {
            keyValues.Add(MoneyNormalType.NormalMoreThan100, Convert.ToDecimal(0.12));
            keyValues.Add(MoneyNormalType.NormalLessThan100, Convert.ToDecimal(0.8));
            keyValues.Add(UserType.SuperUser, Convert.ToDecimal(0.20));
            keyValues.Add(UserType.Premium, Convert.ToDecimal(2));
        }

        public decimal UserMoneyValidation(string userType, decimal money)
        {
            return userType switch
            {
                UserType.Normal => MoneyNormalCalculation(money),
                UserType.SuperUser => MoneyCalculation(money, keyValues.Where(x => x.Key == UserType.SuperUser).FirstOrDefault().Value),
                UserType.Premium => MoneyCalculation(money, keyValues.Where(x => x.Key == UserType.Premium).FirstOrDefault().Value),
                _ => 0,
            };
        }

        private decimal CalculateGif(decimal money, decimal percentage)
        {
            return money * percentage;
        }

        private decimal MoneyCalculation(decimal money, decimal percentage)
        {
            if (money < 100) return 0;

            var gif = CalculateGif(money, percentage);
            return money + gif;
        }
        private decimal MoneyNormalCalculation(decimal money)
        {
            if (money > 100)
            {
                var percentage = keyValues.Where(x => x.Key == MoneyNormalType.NormalMoreThan100).FirstOrDefault().Value;
                var gif = CalculateGif(money, percentage);
                return money + gif;
            }
            if (money < 100 && money > 10)
            {
                var percentage = keyValues.Where(x => x.Key == MoneyNormalType.NormalLessThan100).FirstOrDefault().Value;
                var gif = CalculateGif(money, percentage);
                return money + gif;
            }
            return 0;
        }
    }
}
