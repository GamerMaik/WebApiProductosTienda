using DAL;
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


        [HttpPost]
        [Route("Eliminar")]
        public dynamic Eliminar_Producto(int productId)
        {
            try
            {
                lnProyectoApi.Eliminar_Producto(productId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest("Error al Eliminar" + ex.Message);
            }

        }
        [HttpPost]
        [Route("Actualizar")]
        public void Actualizar_Producto(int productId, EProduct newProductData)
        {
            try
            {
                lnProyectoApi.Actualizar_Producto(productId, newProductData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        #endregion
    }
}
