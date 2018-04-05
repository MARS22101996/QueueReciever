using AutoMapper;
using FortuneReciever.BLL.Infrastructure.Automapper;

namespace FortuneReciever.Infrastrucrure.Automapper
{
    public class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoToApiModelProfile>();
                cfg.AddProfile<ApiModelToDtoProfile>();

                ServiceAutoMapperConfiguration.Initialize(cfg);
            });

           var mapper = mapperConfiguration.CreateMapper();
           return mapper;
      }
    }
}