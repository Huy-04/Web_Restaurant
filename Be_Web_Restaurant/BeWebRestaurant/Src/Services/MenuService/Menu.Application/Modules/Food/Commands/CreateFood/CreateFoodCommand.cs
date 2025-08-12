using Domain.Core.Rule;
using Domain.Core.Rule.RuleFactory;
using MediatR;
using Menu.Application.DTOs.Requests.Food;
using Menu.Application.DTOs.Responses.Food;
using Menu.Domain.Common.Factories.Rules;

namespace Menu.Application.Modules.Food.Commands.CreateFood
{
    public sealed record CreateFoodCommand(CreateFoodRequest Request) : IRequest<FoodResponse>, IValidateRequest
    {
        public IEnumerable<IBusinessRule> GetRule()
        {
            yield return FoodRuleFactory.NameMaxLength(Request.FoodName);
            yield return FoodRuleFactory.NameNotEmpty(Request.FoodName);
            yield return DescriptionRuleFactory.DescriptionNotEmpty(Request.Description);
            yield return DescriptionRuleFactory.DescriptionMaxLength(Request.Description);
            yield return ImgRuleFactory.ImgNotEmpty(Request.Img);
            yield return ImgRuleFactory.ImgMaxLength(Request.Img);
            foreach (var price in Request.Prices)
            {
                yield return MoneyRuleFactory.CurrencyValidate(price.CurrencyEnum);
                yield return MoneyRuleFactory.AmountNotNegative(price.Amount);
            }
        }
    }
}