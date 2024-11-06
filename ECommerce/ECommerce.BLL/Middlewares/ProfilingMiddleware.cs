using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BLL.Middlewares
{
    public class ProfilingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ProfilingMiddleware> _logger;

        public ProfilingMiddleware(RequestDelegate next,
                                   ILogger<ProfilingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
      /// <summary>
        //All information About Request and Response (Http Context)
        // test program Preformance and Speed Of Requst using Stop Watch
      /// 
      /// </summary>
      /// <param name="context"></param>
      /// <returns> Task </returns>
        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await _next(context);
            stopwatch.Stop();
         _logger.LogInformation($"Requst {context.Request.Path} " +
                                $"Toke {stopwatch.ElapsedMilliseconds}");
        }



    }
}
