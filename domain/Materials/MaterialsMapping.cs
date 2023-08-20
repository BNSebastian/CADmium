using AutoMapper;

namespace domain.Materials
{
    public class MaterialsMapping : Profile
    {
        public MaterialsMapping()
        {
            CreateMap<Concrete, ConcreteDTO>();
            CreateMap<ConcreteDTO, Concrete>();

            CreateMap<Steel, SteelDTO>();
            CreateMap<SteelDTO, Steel>();
        }
    }
}