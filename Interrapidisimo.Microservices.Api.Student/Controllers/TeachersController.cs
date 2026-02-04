using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Interrapidisimo.Microservices.Api.Student.Controllers
{
    /// <summary>
    /// controller de los servicios de profesores
    /// </summary>
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        /// <summary>
        /// expone los servicios de profesores
        /// </summary>
        private readonly ITeacherLogic logic;
        /// <summary>
        /// constructor del controller
        /// </summary>
        /// <param name="service"></param>
        public TeachersController(ITeacherLogic logic)
        {
            this.logic = logic;
        }
        /// <summary>
        /// servicio para obtener todos los profesores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await logic.GetAllAsync());
        }
    }

}
