using AutoMapper;
using persistence.Materials;

namespace api.Controllers.Materials
{
    public class ConcreteController : BaseMaterialController
    {
        private readonly IConcreteRepository _concreteRepository;
        private readonly IMapper _mapper;

        public ConcreteController(IConcreteRepository categoryRepository, IMapper mapper)
        {
            _concreteRepository = categoryRepository;
            _mapper = mapper;
        }
    }
}