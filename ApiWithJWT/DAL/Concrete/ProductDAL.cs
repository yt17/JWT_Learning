using CORE.EF;
using DAL.Abstracts;
using DAL.EF;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete
{
    public class ProductDAL: EFrepository<AppDbContext,Product>,IProductDAL
    {
    }
}
