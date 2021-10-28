using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDatos.Interfaces
{
    public interface ITipoDocumentoRepository : IDisposable
    {
        IEnumerable<TipoDocumento> GetTipoDocumentos();
        TipoDocumento GetTipoDocumentoByID(int TipoDocumentoId);
        void InsertTipoDocumento(TipoDocumento TipoDocumento);
        void DeleteTipoDocumento(int TipoDocumentoID);
        void UpdateTipoDocumento(TipoDocumento TipoDocumento);
        void Save();
    }
}
