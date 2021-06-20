using FluentValidation;
using ShopWebApi.Model.Dto;

namespace ShopWebApi.Infrastructure.Validation
{
    public class ReservRequestValidator : AbstractValidator<ReservRequest>
    {
        public ReservRequestValidator()
        {
            RuleFor(x => x.Quantity)
                  .InclusiveBetween(1,int.MaxValue)
                  .WithMessage("Минимальное количество товара для резерва единица");
        }
    }
}
