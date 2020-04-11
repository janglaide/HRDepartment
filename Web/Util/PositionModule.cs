using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Util
{
    public class PositionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPositionService>().To<PositionService>();
        }
    }
}