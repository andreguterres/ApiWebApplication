using AutoMapper;
using WebApi.Dto;
using WebApi.Entities;

namespace WebApi.Mappings
{
    public class EntitiesToDtoMapping: Profile
    {
        public EntitiesToDtoMapping()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Logradouro, LogradouroDto>().ReverseMap();

        }
    }
}
