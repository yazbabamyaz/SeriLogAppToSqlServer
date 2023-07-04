using LogAppGiris.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogAppGiris.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogger<LogsController> _logger;
        private readonly IMathService _mathService;

        public LogsController(ILogger<LogsController> logger, IMathService mathService)
        {
            _logger = logger;
            _mathService = mathService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                decimal result = _mathService.Divide(10, 0);
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogWarning(ex, "2 sayı bölünürken bir hata meydana geldi.");

            }
            return Ok();
            
        }
    }
}
