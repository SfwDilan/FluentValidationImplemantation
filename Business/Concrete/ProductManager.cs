using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);   //Bu kodu vererek ValidationTool'u çağırmış olduk.FluentValidation



            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}
