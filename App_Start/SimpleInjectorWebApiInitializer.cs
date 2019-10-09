[assembly: WebActivator.PostApplicationStartMethod(typeof(MVCAngular.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace MVCAngular.App_Start
{
    using System.Web.Http;
  using MVCAngular.DI;
  using MVCAngular.Interfaces;
  using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
      container.Register<IAPI, API_Access>(Lifestyle.Scoped);
      container.Register<IDB, IDB_Access>(Lifestyle.Scoped);

      // For instance:
      // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
    }
    }
}
