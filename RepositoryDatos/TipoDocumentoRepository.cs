using Datos;
using Microsoft.EntityFrameworkCore;
using RepositoryDatos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDatos
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository, IDisposable
    {
        private Model context;

        public TipoDocumentoRepository(string conexion)
        {
            this.context = new Model(conexion);
        }

        public IEnumerable<TipoDocumento> GetTipoDocumentos()
        {
            return context.TipoDocumento.ToList();
        }

        public TipoDocumento GetTipoDocumentoByID(int id)
        {
            return context.TipoDocumento.Find(id);
        }

        public void InsertTipoDocumento(TipoDocumento TipoDocumento)
        {
            context.TipoDocumento.Add(TipoDocumento);
        }

        public void DeleteTipoDocumento(int TipoDocumentoID)
        {
            TipoDocumento TipoDocumento = context.TipoDocumento.Find(TipoDocumentoID);
            context.TipoDocumento.Remove(TipoDocumento);
        }

        public void UpdateTipoDocumento(TipoDocumento TipoDocumento)
        {
            context.Entry(TipoDocumento).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
