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
        public void Adicionar_eEProduct(EProduct eEProduct)
        {
            try
            {
                swLNPersona.Adicionar_eEProduct(eEProduct);
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
