using IntegralService146.Models;
using IntegralService146.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IntegralService146.Controllers
{
    [Route("api/integral")]
    [ApiController]
    public class IntegralControler : ControllerBase
    {
        private ICalculatorService _calculatorService;
        public IntegralControler(ICalculatorService calcServ)
        {
            _calculatorService = calcServ;
        }

        // POST api/integrals
        [EnableCors]
        [HttpPost]
        public ActionResult<IntegralOutputData> Post([FromBody] IntegralInputData inputData)
        {
            return _calculatorService.Calculate(inputData);
        }

        
    }
}
