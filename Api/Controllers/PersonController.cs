using Microsoft.AspNetCore.Mvc;
using ENTIDADES;
using LN;

namespace Api.Controllers
{   
    [ApiController]
    [Route("Persona")]
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

        #endregion
    }
}
