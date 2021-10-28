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
    public class PersonaRepository : IPersonaRepository, IDisposable
    {
        private Model context;

        public PersonaRepository(string conexion)
        {
            this.context = new Model(conexion);
        }

        public IEnumerable<Persona> GetPersonas()
        {
            return context.Persona.ToList();
        }

        public Persona GetPersonaByID(int id)
        {
            return context.Persona.Find(id);
        }

        public void InsertPersona(Persona Persona)
        {
            context.Persona.Add(Persona);
        }

        public void DeletePersona(int PersonaID)
        {
            Persona Persona = context.Persona.Find(PersonaID);
            context.Persona.Remove(Persona);
        }

        public void UpdatePersona(Persona Persona)
        {
            context.Entry(Persona).State = EntityState.Modified;
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
