using System;

namespace Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository Personas { get; }
        IDocumentoRepository Documentos { get; }
        IDocumentoTipoRepository DocumentoTipos { get; }
        int Complete();
    }
}
