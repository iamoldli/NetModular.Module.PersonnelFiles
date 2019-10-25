using FluentValidation;
using NetModular.Lib.Utils.Core.Extensions;
using NetModular.Lib.Validation.FluentValidation;
using NetModular.Module.PersonnelFiles.Application.UserWorkHistoryService.ViewModels;

namespace NetModular.Module.PersonnelFiles.Web.Validators
{
    public class UserWorkHistoryUpdateValidator : AbstractValidator<UserWorkHistoryUpdateModel>
    {
        public UserWorkHistoryUpdateValidator()
        {
            RuleFor(x => x.ContactPhone).Phone().When(x => x.ContactPhone.NotNull()).WithMessage("请输入正确的手机号");
        }
    }
}
