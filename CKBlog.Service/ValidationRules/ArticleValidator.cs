using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CKBlog.Entity.DbObjects;
using FluentValidation;

namespace CKBlog.Service.ValidationRules
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez!");
            RuleFor(x => x.Title).Length(3, 50).WithMessage("Minimum 3, Maximum 50 karakter aralığında olmalıdır!");

            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik alanı boş geçilemez!");
            RuleFor(x => x.Content).MinimumLength(25).WithMessage("Minimum 25 karakter olmalı!");

            //RuleFor(x => x.Thumbnail).NotEmpty().WithMessage("Thumbnail Boş Geçilemez!");
            RuleFor(x => x.Thumbnail).MaximumLength(350).WithMessage("Fotoğraf ismi çok uzun!");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori Boş Geçilemez");


        }
    }
}
