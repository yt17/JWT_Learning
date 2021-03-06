using Entities;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstracts
{
    public interface IProductService
    {
        List<Product> GetList();

        bool AddProduct(ProductDTO product);

    }
}
