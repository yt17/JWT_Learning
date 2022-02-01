using Autofac;
using BL.Abstracts;
using BL.Concrete;
using CORE.Jwt;
using DAL.Abstracts;
using DAL.Concrete;
using System;
using System.Collections.Generic;

using System.Text;

namespace BL.DependencyInjection
{
    public class AutofactBM:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductDAL>().As<IProductDAL>();
            builder.RegisterType<UserDAL>().As<IUserDAL>();
            builder.RegisterType<TokenHelper>().As<ITokenHelper>();
            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<OperationClaimsDAL>().As<IOperationClaims>();
            builder.RegisterType<UserOperationClaimsDAL>().As <IUserOperationClaims>();

        }

    }
}
