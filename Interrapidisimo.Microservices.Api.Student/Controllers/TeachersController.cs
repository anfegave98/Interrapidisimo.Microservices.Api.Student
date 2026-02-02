using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Interrapidisimo.Microservices.Api.Student.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/teachers")]
    public class TeachersController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ITeacherService service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public TeachersController(ITeacherService service)
        {
            this.service = service;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllAsync());
        }
    }

}
