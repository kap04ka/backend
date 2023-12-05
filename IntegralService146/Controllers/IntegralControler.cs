using IntegralService146.Models;
using IntegralService146.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IntegralService146.Controllers
{
    [Route("api/integral")]
    [ApiController]
    public class IntegralControler : ControllerBase
    {
        private readonly ILogger<IntegralControler> _logger;
        private ICalculatorService _calculatorService;
        public IntegralControler(ILogger<IntegralControler> logger, ICalculatorService calcServ)
        {
            _calculatorService = calcServ;
            _logger = logger;
        }

        // POST api/integrals
        [EnableCors]
        [HttpPost]
        public ActionResult<IntegralOutputData> Post([FromBody] IntegralInputData inputData)
        {
            _logger.LogInformation("Запрос к api/integrals");
            return _calculatorService.Calculate(inputData);
        }

        
    }
}
