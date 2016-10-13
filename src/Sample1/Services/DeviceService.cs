using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample1.Services
{
    public interface IDeviceService
    {
        bool IsMobile { get; }
    }

    public class DeviceService : IDeviceService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IDeviceHandler _handler;

        public DeviceService(IHttpContextAccessor accessor, IDeviceHandler handler)
        {
            _accessor = accessor;
            _handler = handler;
        }

        public bool IsMobile => _handler.IsMobileRequest(_accessor.HttpContext.Request);
    }
}
