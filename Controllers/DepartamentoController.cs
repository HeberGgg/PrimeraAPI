using PruebaApi.Models;
using PruebaApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PruebaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly DepartamentoContext context;

        public DepartamentoController(DepartamentoContext contexto)
        {
            context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentoItems()
        {
            return await context.Departamento.ToListAsync();
        }

        //Peticiones tipo get a api/Departamento
        //[HttpGet]
        //public IEnumerable<Departamento> GetDepartamentoItems() 
        //{
        //    return  context.Departamento.ToList();
        //}

        //Peticion tipo get id: un colo registro api/Departamento/4
        //[HttpGet("{id}")]
        //public ActionResult<Departamento> GetDepartamentoItem(int id)
        //{
        //    var DepartamentoItem = context.Departamento.Find(id);

        //    if(DepartamentoItem == null)
        //    {
        //        return NotFound();
        //    }

        //   return DepartamentoItem; 
        //}

        //Peticion tipo get id: un colo registro api/Departamento/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamentoItem(int id)
        {
            var DepartamentoItem = await context.Departamento.FindAsync(id);

            if(DepartamentoItem == null)
            {
                return NotFound();
            }

           return DepartamentoItem; 
        }


        //Peticion tipo post: api/Departamento 
        //[HttpPost]
        //public ActionResult<Departamento> PostDepartamentoItems(Departamento item) 
        //{
        //    context.Departamento.Add(item);
        //    context.SaveChanges();

        //    return CreatedAtAction(nameof(GetDepartamentoItem), new { id = item.ID_Persona}, item);
        //}

        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamentoItems(Departamento item) 
        {
            context.Departamento.Add(item);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartamentoItem), new { id = item.ID_Persona}, item);
        }


        //Peticion de tipo PUT: api/Departamento
        //[HttpPut("{id}")]
        //public IActionResult PutDepartamentoItem(int id, Departamento item)
        //{
        //    if(id != item.ID_Persona)
        //   {
        //        return BadRequest();
        //    }
        
        //    context.Entry(item).State = EntityState.Modified;
        //    context.SaveChanges();
        //    return NoContent(); 
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamentoItem(int id, Departamento item)
        {
            if(id != item.ID_Persona)
           {
                return BadRequest();
            }
        
            context.Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent(); 
        }        


      
    }
}