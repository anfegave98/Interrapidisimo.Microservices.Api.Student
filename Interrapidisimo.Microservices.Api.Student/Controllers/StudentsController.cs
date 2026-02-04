using Interrapidisimo.Microservices.Api.Student.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Interrapidisimo.Microservices.Api.Student.Controllers
{
    /// <summary>
    /// Controller de los servicios de estudiantes
    /// </summary>
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        /// <summary>
        /// expone los servicios de estudiantes
        /// </summary>
        private readonly IStudentLogic logic;
        /// <summary>
        /// constructor del controller
        /// </summary>
        /// <param name="service">servicios de estutiantes</param>
        public StudentsController(IStudentLogic logic)
        {
            this.logic = logic;
        }
        /// <summary>
        /// servicio para crear un estudiante
        /// </summary>
        /// <param name="student">Entidad estudiante</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Entities.Student student)
        { 
            return Ok(await this.logic.CreateAsync(student)); 
        }


        /// <summary>
        /// servicio para obtener todos los estudiantes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        { 
            return Ok(await this.logic.GetAllAsync()); 
        }

        /// <summary>
        /// servicio para obtener un estudiante por id
        /// </summary>
        /// <param name="id">id del estudiante</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await this.logic.GetByIdAsync(id);
            return student == null ? NotFound() : Ok(student);
        }

        /// <summary>
        /// servicio para eliminar un estudiante por id
        /// </summary>
        /// <param name="id">id del estudiante</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await this.logic.DeleteAsync(id);
            return ok ? NoContent() : NotFound();
        }

        /// <summary>
        /// servicio para actualizar un estudiante
        /// </summary>
        /// <param name="id">id del estudiante</param>
        /// <param name="student">informacion que se va a actualizar</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Entities.Student student)
        {
            var studentData = await this.logic.UpdateAsync(id, student);
            return Ok(studentData);
        }

        /// <summary>
        /// servicio para obtener los compañeros de clase de un estudiante
        /// </summary>
        /// <param name="id">id del estudiante</param>
        /// <returns></returns>
        [HttpGet("{id}/classmates")]
        public async Task<IActionResult> GetClassmates(int id)
        {
            var data = await this.logic.GetClassmates(id);
            return Ok(data);
        }


    }
}
