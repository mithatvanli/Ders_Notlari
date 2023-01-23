using EntityLayer.concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules_FluentValidations
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Kategori Adı Alanı Boş Bırakılamaz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Açıklama Kısmı Boş Bırakılamaz");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen Bu Alana En Az 2 Karakter Giriniz");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("En Fazla 50 Karakter Girebilirsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Bu Alan Boş Geçilemez");
            RuleFor(x => x.WriterTitles).NotEmpty().WithMessage("Bu Alan Boş Geçilemez");
        }
    }
}
