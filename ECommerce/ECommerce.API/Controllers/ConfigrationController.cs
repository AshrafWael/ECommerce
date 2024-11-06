using ECommerce.BLL.ConfigrationsOptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ConfigrationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IOptions<AttachmentOptions> _options;
        private readonly ILogger<ConfigrationController> _logger;

        public ConfigrationController(IConfiguration configuration
            ,IOptions<AttachmentOptions> options,
            ILogger<ConfigrationController> logger)
        {
            _configuration = configuration;
            _options = options;
            _logger = logger;
        }


        [HttpGet]
        [Route("Get")]
        public IActionResult GetConfig()
        {

            var config = new
            {
                AllowedHosts = _configuration["AllowedHosts"],
                DefaultLogLavel = _configuration["Logging:LogLevel:Default"],
                attachmentOptions = _options.Value
            };

            return Ok(config);


        }



    }
}
