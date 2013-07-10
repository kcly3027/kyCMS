using System;
using System.Collections.Generic;
using System.Text;
using KyCMS.Common.SystemExtensions;

namespace KyCMS.Web.MVC.Mvc
{
    public class ControllerBuilder
    {
        private delegate IControllerFactory factoryThunk();
        private event factoryThunk FactoryThunk;
        public static ControllerBuilder Current { get; private set; }
        public HashSet<string> DefaultNamespaces { get; private set; }
        static ControllerBuilder()
        {
            Current = new ControllerBuilder();
        }
        public ControllerBuilder()
        {
            this.DefaultNamespaces = new HashSet<string>();
        }
        public IControllerFactory GetControllerFactory()
        {
            return FactoryThunk();
        }
        public void SetControllerFactory(IControllerFactory controllerFactory)
        {
            FactoryThunk += delegate()
            {
                return controllerFactory;
            };
        }
    }
}
