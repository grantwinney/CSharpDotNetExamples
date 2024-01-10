using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace TimeAbstraction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeAbstractionController : ControllerBase
    {
        readonly IBusinessOperations3 _busOpLogic3;
        readonly IBusinessOperations _busOpLogic4;

        public TimeAbstractionController(IBusinessOperations3 busOpLogic3, IBusinessOperations busOpLogic4)
        {
            _busOpLogic3 = busOpLogic3;
            _busOpLogic4 = busOpLogic4;
        }

        [SwaggerOperation(
            Summary = "Endpoint that uses a custom IDateTime interface",
            Description = "This endpoint hits the last method in BusinessOperationsLegacy, which uses a custom interface for DI.")]
        [HttpGet("v1/IsBusinessOpen")]
        public bool GetBusinessOpen3()
        {
            return _busOpLogic3.IsOpenHours();
        }


        [SwaggerOperation(
            Summary = "Endpoint that uses the new TimeProvider class",
            Description = "This endpoint hits the method in BusinessOperations, which uses the new TimeProvider abstract class.")]
        [HttpGet("v2/IsBusinessOpen")]
        public bool GetBusinessOpen4()
        {
            return _busOpLogic4.IsOpenHours();
        }
    }
}