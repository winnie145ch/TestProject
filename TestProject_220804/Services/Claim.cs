using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject_220804.Models;

namespace TestProject_220804.Services
{
    public class Claim
    {
        public readonly appsettings _config;
        public Claim(IOptions<appsettings> config)
        {
            _config = config.Value;
        }
    }
}
