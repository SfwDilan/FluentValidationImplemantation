using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    //Tool'lar genellikle static yapılır.Tek bir instance oluşturulur sürekli new'lenme ihtiyacı olmasın.
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}





/*
 * ProductManager'de aşağıda yazılan bu kodun yukarıdaki hali =>Refactor edilmiş koddur. :
 
var context = new ValidationContext<Product>(product);
            ProductValidator productValidator = new ProductValidator();
            var result = productValidator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            } 
 
 */
