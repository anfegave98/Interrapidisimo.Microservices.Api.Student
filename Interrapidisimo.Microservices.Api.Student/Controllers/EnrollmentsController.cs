using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Interrapidisimo.Microservices.Api.Student.Controllers
{
    /// <summary>
    /// Controller de los servicios de inscripciones de materias
    /// </summary>
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        /// <summary>
        /// Expone los servicios de inscripciones
        /// </summary>
        private readonly IEnrollmentLogic logic;
        /// <summary>
        /// Constructor del controller
        /// </summary>
        /// <param name="logic"></param>
        public EnrollmentsController(IEnrollmentLogic logic)
        {
            this.logic = logic;
        }
        /// <summary>
        /// Servicio para inscribir un estudiante en una materia
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Enroll(CreateEnrollmentDto dto)
        {
            await this.logic.EnrollAsync(dto);
            return Ok("Inscripcion Satisfractoria");
        }
    }
}
