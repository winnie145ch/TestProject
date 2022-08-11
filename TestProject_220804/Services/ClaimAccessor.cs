using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject_220804.Models;

namespace TestProject_220804.Services
{
    public class ClaimAccessor
    {
        public readonly appsettings _config;
        public readonly IHttpContextAccessor _accessor;
        public ClaimAccessor(IHttpContextAccessor accessor,IOptions<appsettings> config)
        {
            _accessor = accessor;
            _config = config.Value;
        }
    }
}
