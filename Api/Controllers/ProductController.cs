using ENTIDADES;
using LN;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController:ControllerBase
    {
        #region Atributos
        private LNProyectoApi lnProyectoApi;

        #endregion

        #region Constructor
        public ProductController()
        {
            lnProyectoApi = new LNProyectoApi();
        }
        #endregion

        #region Metodos Publicos

        [HttpPost]
        [Route("Insertar")]
        public dynamic InsertarProducto(EProduct eEProduct)
        {
            try
            {
                lnProyectoApi.Adicionar_EProducto(eEProduct);
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
