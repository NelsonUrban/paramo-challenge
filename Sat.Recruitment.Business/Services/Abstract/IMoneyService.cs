namespace Sat.Recruitment.Business.Services.Abstract
{
    public interface IMoneyService
    {
        decimal UserMoneyValidation(string userType, decimal money);
    }
}
