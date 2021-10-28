using Datos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaEfectyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private TipoDocumentoRepository tipoDocumentoRepository;
        private readonly IConfiguration _configuration;

        public TipoDocumentoController(IConfiguration configuration)
        {
            _configuration = configuration;
            tipoDocumentoRepository = new TipoDocumentoRepository(_configuration.GetConnectionString("ConexionModel"));
        }

        [HttpGet()]
        public ActionResult Get()
        {
            List<TipoDocumento> tipoDocumentos;
            try
            {
                tipoDocumentos = tipoDocumentoRepository.GetTipoDocumentos().ToList();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(tipoDocumentos);
        }
    }
}
