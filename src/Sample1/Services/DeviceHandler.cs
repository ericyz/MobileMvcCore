using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample1.Services
{
    public interface IDeviceHandler
    {
        bool IsMobileRequest(HttpRequest request);
    }

    public class SuperSmartDeviceHandler : IDeviceHandler
    {
        public bool IsMobileRequest(HttpRequest request) => request.Headers["User-Agent"].Any(t => t.ToUpper().Contains("MOBILE")) || request.Host.Value.StartsWith("m.");
    }
}
