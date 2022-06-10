using Microsoft.AspNetCore.Mvc;

//APi yra MVC subset'as

namespace AnagramSolverWebsite.Controllers
{

    [Route("api/{controller}/{action}")]
    public class ValuesController : ControllerBase
    {
        //objektas JSON formatu
        [HttpGet]
        public string TestAction()
        {
            return "test";
        }
    }
}
