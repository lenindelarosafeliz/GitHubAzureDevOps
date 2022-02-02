using Application.Interfaces.Repoitories;
using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        public PersonaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
