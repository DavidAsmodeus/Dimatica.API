using Dimatica.Application.Contract;
using Dimatica.Application.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Dimatica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DutyController : ControllerBase
    {
        private readonly IDutyApplicacion dutyApplicacion;

        public DutyController(IDutyApplicacion dutyApplicacion)
        {
            this.dutyApplicacion = dutyApplicacion;
        }

        /// <summary>
        /// obtiene listado de todos los duties disponibles
        /// </summary>
        /// <returns>duty</returns>
        [HttpGet]
        public ActionResult<IEnumerable<Duty>> Get()
        {
            return Ok(dutyApplicacion.GetDuties());
        }

        /// <summary>
        /// obtiene duty por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>listado de duties</returns>
        [HttpGet, Route("{id}")]
        public ActionResult<Duty> Get(string id)
        {
            var duty = dutyApplicacion.GetDutyById(id);

            if (duty != null)
            {
                return Ok(duty);
            }
            else
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Añade un duty nuevo
        /// </summary>
        /// <param name="duty"></param>
        /// <returns>duty</returns>
        [HttpPost]
        public ActionResult<Duty> Post(Duty duty)
        {
            duty.Id = ObjectId.GenerateNewId().ToString();
            return Ok(dutyApplicacion.AddDuty(duty));
        }

        /// <summary>
        /// Actualiza un duty existente
        /// </summary>
        /// <param name="duty"></param>
        /// <returns>duty</returns>
        [HttpPut]
        public ActionResult<Duty> Put(Duty duty)
        {
            return Ok(dutyApplicacion.UpdateDuty(duty));
        }

        /// <summary>
        /// elimina un duty existente por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete, Route("{id?}")]
        public IActionResult Delete(string id)
        {
            dutyApplicacion.DeleteDuty(id);
            return Ok();
        }
    }
}
