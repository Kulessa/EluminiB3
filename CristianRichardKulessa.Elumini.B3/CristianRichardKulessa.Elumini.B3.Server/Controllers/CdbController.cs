using CristianRichardKulessa.Elumini.B3.Server.Models;
using CristianRichardKulessa.Elumini.B3.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace CristianRichardKulessa.Elumini.B3.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CdbController : ControllerBase
    {
        private readonly ILogger<CdbController> logger;
        private readonly ICdbService service;

        public CdbController(ILogger<CdbController> logger, ICdbService service)
        {
            this.logger = logger;
            this.service = service;
        }
        [HttpGet(Name = "GetCalculoCdb")]
        public IActionResult Get([FromQuery] CdbRequestModel model)
        {
            logger.LogInformation("Iniciando método GetCalculoCdb");
            if (!ModelState.IsValid)
            {
                List<string> erros = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                logger.LogWarning("Finalizando método GetCalculoCdb com erros");
                return BadRequest(new { Erros = erros });
            }
            CdbResponseModel response = service.Calcular(model);
            logger.LogInformation("Finalizando método GetCalculoCdb com sucesso!");
            return Ok(response);
        }
    }
}
