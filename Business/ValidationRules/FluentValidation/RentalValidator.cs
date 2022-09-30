using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(c => c.RentDate).Must(IfCheckCurrentDate).WithMessage("Kiralama Tarihi Şimdiki Tarihten Küçük Olamaz");
            RuleFor(c => c).Must(IfCheckCurrentDate2).WithMessage("Geri Dönüş Tarihi Kiralama Tarihinden Küçük Olamaz");
        }

        private bool IfCheckCurrentDate(DateTime rentDate)
        {
            var result = rentDate >= DateTime.Now;
            return result;
        }

        private bool IfCheckCurrentDate2(Rental rental)
        {
            var result = rental.ReturnDate >= rental.RentDate;
            return result;
        }
    }
}
