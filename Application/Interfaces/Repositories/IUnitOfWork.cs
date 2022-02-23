using System;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository Personas { get; }
        IDocumentoRepository Documentos { get; }
        IDocumentoTipoRepository DocumentoTipos { get; }
        Task<int> CompleteAsync();
    }
}
