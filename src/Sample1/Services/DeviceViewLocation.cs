using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample1.Services
{
    public class DeviceViewLocation : IViewLocationExpander
    {
        private readonly IDeviceHandler _device;

        public DeviceViewLocation(IDeviceHandler device)
        {
            _device = device;
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            List<string> mobileLocations = new List<string>();
            if (context.Values.ContainsKey("IsMobile"))
            {
                mobileLocations = viewLocations.Select(t => t.Replace("{0}", "{0}.m")).ToList();
            }

            mobileLocations.AddRange(viewLocations);
            return mobileLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            if (_device.IsMobileRequest(context.ActionContext.HttpContext.Request))
            {
                context.Values["IsMobile"] = "mobile";
            }
        }
    }
}
