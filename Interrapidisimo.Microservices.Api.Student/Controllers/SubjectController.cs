using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Interrapidisimo.Microservices.Api.Student.Controllers
{
    /// <summary>
    /// Controller de los servicios de materias
    /// </summary>
    [ApiController]
    [Route("api/subjects")]
    public class SubjectsController : ControllerBase
    {
        /// <summary>
        /// expone los servicios de materias
        /// </summary>
        private readonly ISubjectLogic logic;
        /// <summary>
        /// constructor del controller
        /// </summary>
        /// <param name="service"></param>
        public SubjectsController(ISubjectLogic logic)
        {
            this.logic = logic;
        }


        /// <summary>
        /// servicio para obtener todas las materias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.logic.GetAllAsync());
        }
    }
}
