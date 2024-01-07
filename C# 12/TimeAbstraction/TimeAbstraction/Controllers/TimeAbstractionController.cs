using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("v1/IsBusinessOpen")]
        public bool GetBusinessOpen3()
        {
            return _busOpLogic3.IsOpenHours();
        }


        [HttpGet("v2/IsBusinessOpen")]
        public bool GetBusinessOpen4()
        {
            return _busOpLogic4.IsOpenHours();
        }
    }
}