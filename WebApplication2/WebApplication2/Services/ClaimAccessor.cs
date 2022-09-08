using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class ClaimAccessor
    {
        public readonly Settings _config;
        public readonly IHttpContextAccessor _accessor;
        public ClaimAccessor(IHttpContextAccessor accessor, IOptions<Settings> config) {
            _accessor = accessor;
            _config = config.Value;
        }
    }
}
