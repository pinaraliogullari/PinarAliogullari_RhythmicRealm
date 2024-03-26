using FluentValidation;
using RhythmicRealm.Entity.Concrete;


namespace RhythmicRealm.Shared.ValidationRules_FluentValidation_
{
	public class ContactValidatior : AbstractValidator<Contact>
	{
		public ContactValidatior()
		{
			RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş bırakılmamalıdır.");
			RuleFor(x=>x.Subject).NotEmpty().WithMessage("Konu adı boş bırakılmamalıdır.");
			RuleFor(x=>x.UserName).NotEmpty().WithMessage("Kullanıcı Adı boş bırakılmamalıdır.");
			RuleFor(x=>x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
			RuleFor(x=>x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız.");
			RuleFor(x=>x.Subject).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girmeyiniz.");
		}
	}
}
