using System.Collections.Generic;
using AutoMapper;
using PerreraTeam.Domain.Models;
using PerreraTeam.ViewModels;

namespace PerreraTeam.Services.AutoMapper
{
    public class PruebaMapper
    {
        
        protected IMapper _mapper;

        public PruebaMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<PerrosViewModel> AutoMapperDemo()
        {
            var question = new List<Perros>();
            return _mapper.Map<IEnumerable<Perros>, IEnumerable<PerrosViewModel>>(question);
        }


    }
}