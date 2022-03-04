using BL.Abstracts;
using BL.ValidationRules.Concrete;
using CORE.Aspects.Autofac.Validation;
using CORE.CrossCuttingConcerns;
using DAL.Abstracts;
using Entities;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BL.Concrete
{
    public class ProductService : IProductService
    {
        private IProductDAL productDal;
        public ProductService(IProductDAL productDal)
        {
            this.productDal = productDal;
        }
        

        [ValidationAspect(typeof(ProductValidator))]
        public bool AddProduct(ProductDTO product)
        {
            //ValidationTool.Validate(new ProductValidator(), product);
            //ProductValidator asd = new ProductValidator();
            
            Product asd = new Product()
            {
                ID = product.ID,
                Name = product.Name
            };
            this.productDal.Insert(asd);
            return true;
        }

        public List<Product> GetList()  
        {
            return productDal.GetList(null);
        }
    }
}
