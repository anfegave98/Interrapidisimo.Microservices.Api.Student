using Interrapidisimo.Microservices.Api.Student.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interrapidisimo.Microservices.Api.Student.Abstractions
{
    public interface ISubjectService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<SubjectDto>> GetAllAsync();
    }
}
