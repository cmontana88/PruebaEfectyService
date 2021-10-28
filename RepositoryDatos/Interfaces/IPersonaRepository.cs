using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDatos.Interfaces
{
    public interface IPersonaRepository : IDisposable
    {
        IEnumerable<Persona> GetPersonas();
        Persona GetPersonaByID(int PersonaId);
        void InsertPersona(Persona Persona);
        void DeletePersona(int PersonaID);
        void UpdatePersona(Persona Persona);
        void Save();
    }
}
