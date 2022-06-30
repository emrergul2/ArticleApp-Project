using System.Reflection;
using ArticleApp.Core.Repositories;
using ArticleApp.Core.Services;
using ArticleApp.Core.UnitOfWorks;
using ArticleApp.Repository.UnitOfWorks;
using ArticleApp.Service.Repositories;
using ArticleApp.Service.Services;
using Autofac;
using Module = Autofac.Module;

namespace ArticleApp.API.Modules
{
    public class RepositoryServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(GenericRepository<>));
            var serviceAssembly = Assembly.GetAssembly(typeof(GenericService<>));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}