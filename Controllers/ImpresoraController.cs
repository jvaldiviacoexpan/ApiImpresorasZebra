using ApiImpresorasZebra.Models;
using ApiImpresorasZebra.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiImpresorasZebra.Controllers
{
    [Route("zebra")]
    [ApiController]
    public class ImpresoraController : ControllerBase
    {
        [Route("estado-impresora")]
        [HttpPost]
        public ActionResult<AnyModels.WsStatus> EstadoImpresora([FromBody] AnyModels.Impresora imp)
        {
            return ImpresoraServices.EstadoImpresora(imp);
        }
    }
}
