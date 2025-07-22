using Domain.Core.Rule;
using MediatR;
using Menu.Application.DTOs.Requests.Food;
using Menu.Application.DTOs.Responses.Food;
using Menu.Domain.Common.Factories.Rules;

namespace Menu.Application.Modules.Foods.Commands.CreateFood
{
    public sealed record CreateFoodCommand(CreateFoodRequest Request) : IRequest<FoodResponse>, IValidateRequest
    {
        public IEnumerable<IBusinessRule> GetRule()
        {
            yield return FoodRuleFactory.NameMaxLength(Request.FoodName);
            yield return FoodRuleFactory.NameNotEmpty(Request.FoodName);
            yield return FoodRuleFactory.DescriptionNotEmpty(Request.Description);
            yield return FoodRuleFactory.DescriptionMaxLength(Request.Description);
            yield return FoodRuleFactory.ImgNotEmpty(Request.Img);
            yield return FoodRuleFactory.ImgMaxLength(Request.Img);
        }
    }
}