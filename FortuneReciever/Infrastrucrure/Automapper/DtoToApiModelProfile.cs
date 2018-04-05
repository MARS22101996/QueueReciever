using AutoMapper;
using FortuneReciever.BLL.Dto;
using FortuneReciever.ViewModels;

namespace FortuneReciever.Infrastrucrure.Automapper
{
   public class DtoToApiModelProfile : Profile
   {
      public DtoToApiModelProfile()
      {
         CreateMap<FortuneMessageDto, FortuneMessageViewModel>();
      }
   }
}