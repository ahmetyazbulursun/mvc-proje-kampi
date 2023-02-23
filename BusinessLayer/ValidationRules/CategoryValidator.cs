using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklamayı boş geçemezsiniz!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En az 3 karakter giriniz!");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("En fazla 2 karakter girilebilir!");

        }
    }
}
