using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Identities.Jwt;
using Core.Utilities.Interceptor;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacDependencyResolversModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

            builder.RegisterType<GameManager>().As<IGameService>().SingleInstance();
            builder.RegisterType<EfGameDal>().As<IGameDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<RoleClaimManager>().As<IRoleClaimService>().SingleInstance();
            builder.RegisterType<EfRoleClaimDal>().As<IRoleClaimDal>().SingleInstance();

            builder.RegisterType<UserRoleClaimManager>().As<IUserRoleClaimService>().SingleInstance();
            builder.RegisterType<EfUserRoleClaimDal>().As<IUserRoleClaimDal>().SingleInstance();

            builder.RegisterType<GamerManager>().As<IGamerService>().SingleInstance();
            builder.RegisterType<EfGamerDal>().As<IGamerDal>().SingleInstance();

            builder.RegisterType<GameImageManager>().As<IGameImageService>().SingleInstance();
            builder.RegisterType<EfGameImageDal>().As<IGameImageDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtService>().As<ITokenService>().SingleInstance();
            builder.RegisterType<FileTool>().As<IFileTool>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new InterceptorSelector()
                })
                .SingleInstance();

        }
    }
}
