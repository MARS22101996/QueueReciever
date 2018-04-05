using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using FortuneReciever.BLL.Interfaces;
using FortuneReciever.ViewModels;

namespace FortuneReciever.Controllers
{
   public class FortuneController : Controller
   {
      private readonly IFortuneService _fortuneService;
      private readonly IMapper _mapper;

      public FortuneController(
         IFortuneService fortuneService,
         IMapper mapper)
      {
         _fortuneService = fortuneService;
         _mapper = mapper;
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

         var messageViewModel = _mapper.Map<IEnumerable<FortuneMessageViewModel>>(message);

         return View("Index", messageViewModel);
      }
   }
}