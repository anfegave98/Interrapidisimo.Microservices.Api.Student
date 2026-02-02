using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Interrapidisimo.Microservices.Api.Student.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IEnrollmentService service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public EnrollmentsController(IEnrollmentService service)
        {
            this.service = service;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Enroll(CreateEnrollmentDto dto)
        {
            await this.service.EnrollAsync(dto);
            return Ok("Inscripcion Satisfractoria");
        }
    }
}
