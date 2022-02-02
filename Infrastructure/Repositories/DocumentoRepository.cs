using Application.Interfaces.Repoitories;
using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class DocumentoRepository : GenericRepository<Documento>, IDocumentoRepository
    {
        public DocumentoRepository(ApplicationContext context) : base(context)
        {

        }
    }
}