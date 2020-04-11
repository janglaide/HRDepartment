using BLL;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;

using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web.Util;

namespace Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule departmentModule = new DepartmentModule();
            NinjectModule employeeModule = new EmployeeModule();
            NinjectModule emplTP = new EmployeeToProjectModule();
            NinjectModule positionModule = new PositionModule();
            NinjectModule projectModule = new ProjectModule();
            NinjectModule serviceModule = new ServiceModule("Context");
            var kernel = new StandardKernel(departmentModule, employeeModule, emplTP,
                positionModule, projectModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            
        }
    }
}
