using DAL;
using DAL.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServiceModule : NinjectModule
    {
        private string connectionStr;
        public ServiceModule(string s)
        {
            connectionStr = s;
        }
        public override void Load()
        {
            Bind<IDataManager>().To<DataManager>().WithConstructorArgument(connectionStr);
            
        }
    }
}
