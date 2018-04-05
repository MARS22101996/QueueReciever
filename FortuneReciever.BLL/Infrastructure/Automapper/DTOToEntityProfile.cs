using AutoMapper;
using FortuneReceiver.DAL.Entities;
using FortuneReciever.BLL.Dto;

namespace FortuneReciever.BLL.Infrastructure.Automapper
{
   public class DtoToEntityProfile : Profile
   {
      public DtoToEntityProfile()
      {
         CreateMap<FortuneMessageDto, FortuneMessage>();
      }
   }
}