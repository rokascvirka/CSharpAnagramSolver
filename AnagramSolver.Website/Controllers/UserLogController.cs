using Contracts;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace AnagramSolver.Website.Controllers
{
    [Route("controller/UserLog/")]
    public class UserLogController : Controller
    {
        private readonly IWordRepository _repository;
        public UserLogController(IWordRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult UserLog()
        {
           var logList =  _repository.GetUserLogInfo();

            return View(logList);
        }
    }
}
