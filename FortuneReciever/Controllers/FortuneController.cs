using System.Web.Mvc;
using FortuneReciever.BLL.Interfaces;

namespace FortuneReciever.Controllers
{
    public class FortuneController : Controller
    {
       private readonly IFortuneService _fortuneService;

       public FortuneController(IFortuneService fortuneService)
       {
          _fortuneService = fortuneService;
       }

       [HttpGet]
       public ActionResult Index()
       {
          return View();
       }

       [HttpGet]
       public ActionResult RecieveFortuneMessage()
       {
          var message = _fortuneService.GetFortuneMessages();

          return View("Index", message);
       }
   }
}