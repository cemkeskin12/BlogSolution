using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;
using FluentValidation;

namespace CKBlog.Service.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adı boş geçilemez!");
            RuleFor(x => x.Name).Length(3, 50).WithMessage("Kategori Adı 3 ile 50 karakter arasında olmalıdır!");
        }
    }
}
