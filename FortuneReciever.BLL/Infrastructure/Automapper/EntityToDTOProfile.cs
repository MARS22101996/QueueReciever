using AutoMapper;
using FortuneReceiver.DAL.Entities;
using FortuneReciever.BLL.Dto;

namespace FortuneReciever.BLL.Infrastructure.Automapper
{
   public class EntityToDtoProfile : Profile
   {
      public EntityToDtoProfile()
      {
         CreateMap<FortuneMessage, FortuneMessageDto>();
      }
   }
}