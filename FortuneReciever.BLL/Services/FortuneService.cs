using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using AutoMapper;
using FortuneReceiver.DAL.Entities;
using FortuneReceiver.DAL.Interfaces;
using FortuneReciever.BLL.Dto;
using FortuneReciever.BLL.Interfaces;
using Microsoft.ServiceBus.Messaging;

namespace FortuneReciever.BLL.Services
{
   public class FortuneService : IFortuneService
   {
      private readonly IQueueRepository _queueRepository;
      private readonly IMapper _mapper;

      public FortuneService(
         IQueueRepository queueRepository,
         IMapper mapper)
      {
         _queueRepository = queueRepository;
         _mapper = mapper;
      }

      public IEnumerable<FortuneMessageDto> GetFortuneMessages()
      {
         var recievedMessages = _queueRepository.Recieve();

         var recievedMessagesDto = _mapper.Map<IEnumerable<FortuneMessageDto>>(recievedMessages);

         return recievedMessagesDto;
      }
   }
}
