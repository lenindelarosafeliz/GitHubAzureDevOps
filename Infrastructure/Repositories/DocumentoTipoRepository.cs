using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories
{
    public class DocumentoTipoRepository : GenericRepository<DocumentoTipo>, IDocumentoTipoRepository
    {
        public DocumentoTipoRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
