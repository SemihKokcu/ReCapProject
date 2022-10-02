﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.Name).NotEmpty();
            RuleFor(c=>c.Name).MinimumLength(2).WithMessage("en az iki olmalıdır");
            RuleFor(c=>c.ModelYear).NotEmpty();
            RuleFor(c=>c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.Description).MinimumLength(2);
            //RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(1000).When(p => p.BrandId == 2);
            //RuleFor(c => c.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı.");

        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
