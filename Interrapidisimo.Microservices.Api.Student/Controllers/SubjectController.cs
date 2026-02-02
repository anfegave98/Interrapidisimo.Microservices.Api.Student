using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Interrapidisimo.Microservices.Api.Student.Controllers
{

    [ApiController]
    [Route("api/subjects")]
    public class SubjectsController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ISubjectService service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public SubjectsController(ISubjectService service)
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
            return Ok(await this.service.GetAllAsync());
        }
    }
}
