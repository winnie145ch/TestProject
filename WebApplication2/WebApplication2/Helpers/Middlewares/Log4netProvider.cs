using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Helpers.Middlewares
{
        public class Log4netProvider : ILoggerProvider
        {
            private readonly FileInfo _fileInfo;

            public Log4netProvider(string log4netConfigFile)
            {
                _fileInfo = new FileInfo(log4netConfigFile);
            }

            public ILogger CreateLogger(string name)
            {
                return new Log4netLogger(name, _fileInfo);
            }

            public void Dispose()
            {
            }
        
    }
}
