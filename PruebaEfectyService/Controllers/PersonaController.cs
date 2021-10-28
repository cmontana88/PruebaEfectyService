using Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace PruebaEfectyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PersonaController : ControllerBase
    {
        private PersonaRepository personaRepository;
        private readonly IConfiguration _configuration;

        public PersonaController(IConfiguration configuration)
        {
            _configuration = configuration;
            personaRepository = new PersonaRepository(_configuration.GetConnectionString("ConexionModel"));
        }
        
        [HttpPost]
        public ActionResult CrearPersona([FromBody] Persona persona)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    personaRepository.InsertPersona(persona);
                    personaRepository.Save();

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(persona);
        }

        [HttpGet()]
        public ActionResult Get()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                personas = personaRepository.GetPersonas().ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(personas);
        }
    }
}
