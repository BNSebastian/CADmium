using AutoMapper;
using domain.Materials;

namespace api.Mapper
{
    public class MaterialsProfile : Profile
    {
        public MaterialsProfile()
        {
            CreateMap<Concrete, ConcreteDTO>();
            CreateMap<ConcreteDTO, Concrete>();

            CreateMap<Steel, SteelDTO>();
            CreateMap<SteelDTO, Steel>();
        }
    }
}