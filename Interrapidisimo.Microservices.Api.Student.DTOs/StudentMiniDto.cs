using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interrapidisimo.Microservices.Api.Student.DTOs
{
    /// <summary>
    ///  dto para representar información mínima de un estudiante.
    /// </summary>
    public class StudentMiniDto
    {
        /// <summary>
        /// id del estudiante.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nombre completo del estudiante.
        /// </summary>
        public string FullName { get; set; } = null!;
    }

}
