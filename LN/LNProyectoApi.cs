using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DAL;
namespace LN
{
    public class LNProyectoApi
    {
        #region Variables
        public SWLNPersona swLNPersona;
        #endregion

        #region Constructor
        public LNProyectoApi()
        {

            swLNPersona = new SWLNPersona();

        }
        #endregion

        #region Metodos Publicos
        public void Adicionar_EProducto(EProduct eEProduct)
        {
            try
            {
                swLNPersona.Adicionar_EProducto(eEProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
        public void Eliminar_Producto(int productId)
        {
            try
            {
                swLNPersona.Eliminar_Producto(productId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public void Actualizar_Producto(int productId, EProduct newProductData)
        {
            try
            {
                swLNPersona.Actualizar_Producto(productId, newProductData);
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
