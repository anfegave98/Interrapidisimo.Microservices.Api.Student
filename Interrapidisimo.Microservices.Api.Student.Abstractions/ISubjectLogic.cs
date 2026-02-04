using Interrapidisimo.Microservices.Api.Student.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interrapidisimo.Microservices.Api.Student.Abstractions
{
    /// <summary>
    /// interface para el servicio de materias
    /// </summary>
    public interface ISubjectLogic
    {
        /// <summary>
        /// servicio para obtener todas las materias
        /// </summary>
        /// <returns></returns>
        Task<List<SubjectDto>> GetAllAsync();
    }
}
