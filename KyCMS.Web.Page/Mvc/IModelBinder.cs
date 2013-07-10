using System;
using System.Collections.Generic;
using System.Text;

namespace KyCMS.Web.MVC.Mvc
{
    public interface IModelBinder
    {
        object BindModel(ControllerContext context, string modelName, Type modelType);
    }
}
