using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Interrapidisimo.Microservices.Api.Student.Logic.Student.Logic;
using Microsoft.AspNetCore.Mvc;

namespace Interrapidisimo.Microservices.Api.Student.Controllers
{

    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IStudentService service;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
        public StudentsController(IStudentService service)
        {
            this.service = service;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Student student)
        { 
            return Ok(await this.service.CreateAsync(student)); 
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await this.service.GetByIdAsync(id);
            return student == null ? NotFound() : Ok(student);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await this.service.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Student student)
        {
            var studentData = await this.service.UpdateAsync(id, student);
            return Ok(studentData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/classmates")]
        public async Task<IActionResult> GetClassmates(int id)
        {
            var data = await this.service.GetClassmates(id);
            return Ok(data);
        }


    }
}
