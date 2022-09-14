using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //FluentValidation packages added.
    //CrossCuttingConcerns ve ValidationRules Klasörleri ...
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A ile başlamalı.");
        }

        //RuleFor(p => p.ProductName).Must(StartWithA) : FluenValidation'da olmayan bir kuralı kendimiz yazarken-- Must --diye belirtip-- metot-- oluşturabiliriz.
        private bool StartWithA(string arg) //arg: RuleFor(p => p.ProductName).Must(StartWithA); =>buradaki productname'e karşılık gelir.
        {
            return arg.StartsWith("A");
        }
    }
}
