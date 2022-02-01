using BL.Abstracts;
using DAL.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
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
        public List<Product> GetList()
        {
            return productDal.GetList(null);
        }
    }
}
