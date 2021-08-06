using Academy.TestWeek4.Core.Models;
using Academy.TestWeek4.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.TestWeek4.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdineController : ControllerBase
    {
        private readonly IGestioneBL mainBL;

        public OrdineController(IGestioneBL mainBL)
        {
            this.mainBL = mainBL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = this.mainBL.FetchOrdini();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Ordine Id.");

            var ordine = this.mainBL.FetchOrdineById(id);

            if (ordine == null)
                return NotFound($"Ordine with Id = {id} is missing.");

            return Ok(ordine);
        }

        [HttpPost]
        public IActionResult Post(Ordine newOrdine)
        {
            if (newOrdine == null)
                return BadRequest("Invalid Ordine data.");

            if (!this.mainBL.CreateOrdine(newOrdine))
                return BadRequest("Cannot complete the operation");

            return CreatedAtAction(nameof(GetById), new { id = newOrdine.ID }, newOrdine);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Ordine updatedOrdine)
        {
            if (updatedOrdine == null)
                return BadRequest("Invalid Ordine data.");

            if (id != updatedOrdine.ID)
                return BadRequest("Ordine IDs don't match.");

            if (!this.mainBL.EditOrdine(updatedOrdine))
                return BadRequest("Cannot complete the operation");

            return Ok(updatedOrdine);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid ID");
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error executing operation.");
            }
        }
    }
}
