using Microsoft.AspNetCore.Mvc;

namespace LOMI.WebApi.Controllers
{
    [ApiController]
    [Route("api/logs")]
    public class LogsController : ControllerBase
    {
        private readonly ILogger<LogsController> _logger;

        public LogsController(ILogger<LogsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Get([FromBody] LogModel logModel)
        {
            _logger.Log(logModel.LogLevel, logModel.Message, logModel.Args);
            return Ok();
        }

        [HttpPost("information")]
        public IActionResult Information()
        {
            _logger.LogInformation("Information log.");
            return Ok();
        }

        [HttpPost("warning")]
        public IActionResult Warning()
        {
            _logger.LogWarning("Warning log.");
            return Ok();
        }

        [HttpPost("critical")]
        public IActionResult Critical()
        {
            _logger.LogCritical("Critical log.");
            return Ok();
        }

        [HttpPost("error")]
        public IActionResult Error()
        {
            _logger.LogError("Error log.");
            return Ok();
        }

        [HttpPost("debug")]
        public IActionResult Debug()
        {
            _logger.LogDebug("Debug log.");
            return Ok();
        }

        public class LogModel
        {
            public LogLevel LogLevel { get; set; }
            public string? Message { get; set; }
            public object?[] Args { get; set; } = new object?[] { };
        }
    }
}
