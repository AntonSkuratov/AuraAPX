using AuraAPX.Application.Dtos.ParameterDtos;
using AuraAPX.Core.Entities;
using FluentValidation;

namespace AuraAPX.API.Infrastructure.Validation
{
	public class UserValidator : AbstractValidator<CreateUserDto>
	{
		public UserValidator()
		{
			RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Имя обязательно")
			.Length(2, 100).WithMessage("Имя должно содержать от 2 до 100 символов")
			.Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage("Имя может содержать только буквы");

			RuleFor(x => x.Surname)
			.NotEmpty().WithMessage("Фамилия обязательна")
			.Length(2, 100).WithMessage("Фамилия должна содержать от 2 до 100 символов")
			.Matches(@"^[a-zA-Zа-яА-Я]+$").WithMessage("Имя может содержать только буквы");

			RuleFor(x => x.Email)
			.EmailAddress().WithMessage("Некорректный формат Email");

			RuleFor(x => x.Login)
			.NotEmpty().WithMessage("Логин обязателен")
			.Length(4, 500).WithMessage("Логин должен содержать от 4 до 500 символов");

			RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Пароль обязателен")
			.Length(8, 500).WithMessage("Пароль должен содержать от 8 до 500 символов");			
		}
	}
}
