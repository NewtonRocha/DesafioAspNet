using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewtonProject.Models;
using NewtonProject.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NewtonProject.Controllers
{
    [Route("api/[controller]")]
    public class PerfilController : Controller
    {
        //Repositorio de perfis
        private IRepository<Perfil> Perfis { get; set; }

        public PerfilController(IRepository<Perfil> perfis)
        {
            this.Perfis = perfis;
        }

        // GET: api/perfil
        // Retorna todos os perfis
        [HttpGet]
        public IEnumerable<Perfil> GetAll()
        {
            return this.Perfis.GetAll();
        }

        // GET api/perfil/5
        // Retorna perfil especifico
        [HttpGet("{id}", Name = "GetPerfil")]
        public IActionResult GetById(int id)
        {
            var item = this.Perfis.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/perfil
        // Cria um Perfil
        [HttpPost]
        public IActionResult Create([FromBody]Perfil item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            item = this.Perfis.Add(item);
            return CreatedAtRoute("GetPerfil", new { Controller = "Perfil", id = item.Id }, item);
        }

        // PUT api/perfil/5
        // Atualiza um perfil
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Perfil item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var perfil = this.Perfis.Find(id);
            if (perfil == null)
            {
                return NotFound();
            }

            perfil.Nome = item.Nome;
            this.Perfis.Update(perfil);
            return new NoContentResult();
        }

        // DELETE api/perfil/5
        // Deleta um perfil
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.Perfis.Remove(id);
        }
    }
}
