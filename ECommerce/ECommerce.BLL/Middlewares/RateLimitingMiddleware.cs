using Microsoft.AspNetCore.Http;

namespace ECommerce.BLL.Middlewares
{
    public class RateLimitingMiddleware
    {
        private readonly RequestDelegate _next;
        private static int Counter = 0;
        private static DateTime _LastRequstDate = DateTime.Now;

        public RateLimitingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Counter++;
            if (DateTime.Now.Subtract(_LastRequstDate).Seconds > 10)
            {
                Counter = 1;
                _LastRequstDate = DateTime.Now;
                await _next(context);
            }
            else
            {
                if (Counter > 5)
                {
                    _LastRequstDate = DateTime.Now;
                    await context.Response.WriteAsync("Rate Limit Exedded");
                }
                else
                {
                    _LastRequstDate = DateTime.Now;
                    await _next(context);
                }


            }

        }

    }
}
