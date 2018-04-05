using AutoMapper;
using FortuneReciever.BLL.Dto;
using FortuneReciever.ViewModels;

namespace FortuneReciever.Infrastrucrure.Automapper
{
   public class ApiModelToDtoProfile : Profile
   {
      public ApiModelToDtoProfile()
      {
         CreateMap<FortuneMessageViewModel, FortuneMessageDto>();
      }
   }
}