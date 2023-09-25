using Microsoft.AspNetCore.Mvc;
using ENTIDADES;
using LN;

namespace Api.Controllers
{   
    [ApiController]
    [Route("Product")]
    public class PersonController : ControllerBase
    {
        #region Atributos
        private LNProyectoApi lnProyectoApi;
 
        #endregion  

        #region Constructor
        public PersonController()
        {
            lnProyectoApi = new LNProyectoApi();
        }
        #endregion

        #region Metodos Publicos

        [HttpPost]
        [Route("Insert")]
        public dynamic InsertarPersona(EProduct eEProduct)
        {
            try
            {
                lnProyectoApi.Adicionar_eEProduct(eEProduct);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest("Error al Insertar" + ex.Message);
            }

        }
        #endregion
    }
}
