using System.Collections.Generic;
using FortuneReceiver.DAL.Entities;

namespace FortuneReceiver.DAL.Interfaces
{
   public interface IQueueRepository
   {
      IEnumerable<FortuneMessage> Recieve();
   }
}
