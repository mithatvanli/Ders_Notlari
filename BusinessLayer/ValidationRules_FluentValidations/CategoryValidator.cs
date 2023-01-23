using EntityLayer.concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_FluentValidations
{
    public class CategoryValidator:AbstractValidator<Category>// t değeri olarak üzerinde çalıştığımız sınıfı göderdik
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Alanı Boş Bırakılamaz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Kısmı Boş Bırakılamaz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen Bu Alana En Az 3 Karakter Giriniz");
            RuleFor(x => x.CategoryDescription).MaximumLength(500).WithMessage("En Fazla 500 Karakter Girebilirsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklam Alanı Boş Geçilemez");
        }
    }
}
