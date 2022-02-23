using Application.Interfaces.Repositories;
using Infrastructure.Contexts;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IPersonaRepository Personas { get; }
        public IDocumentoRepository Documentos { get; }
        public IDocumentoTipoRepository DocumentoTipos { get; }

        public UnitOfWork(ApplicationContext context, 
                          IPersonaRepository personas,
                          IDocumentoRepository documentos,
                          IDocumentoTipoRepository documentoTipos)
        {
            _context = context;
            Personas = personas;
            Documentos = documentos;
            DocumentoTipos = documentoTipos;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
