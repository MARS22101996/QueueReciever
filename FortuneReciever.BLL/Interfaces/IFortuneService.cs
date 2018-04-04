using System.Collections.Generic;
using FortuneReciever.BLL.Models;

namespace FortuneReciever.BLL.Interfaces
{
   public interface IFortuneService
   {
      IEnumerable<FortuneMessage> GetFortuneMessages();
   }
}
