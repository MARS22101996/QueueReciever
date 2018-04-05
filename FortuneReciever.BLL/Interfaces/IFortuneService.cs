using System.Collections.Generic;
using FortuneReceiver.DAL.Entities;
using FortuneReciever.BLL.Dto;

namespace FortuneReciever.BLL.Interfaces
{
   public interface IFortuneService
   {
      IEnumerable<FortuneMessageDto> GetFortuneMessages();
   }
}
