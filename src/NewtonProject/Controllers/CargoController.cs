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
    public class CargoController : Controller
    {
        //Repositorio de cargos
        private IRepository<Cargo> Cargos { get; set; }

        public CargoController(IRepository<Cargo> cargos)
        {
            this.Cargos = cargos;
        }

        // GET: api/cargo
        //Retorna todos os cargos
        [HttpGet]
        public IEnumerable<Cargo> GetAll()
        {
            return this.Cargos.GetAll();
        }

        // GET api/cargo/5
        //Retorna o cargo especifico
        [HttpGet("{id}", Name = "GetCargo")]
        public IActionResult GetById(int id)
        {
            var item = this.Cargos.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // GET api/cargo/customer/5
        //Retorna os cargos de um cliente especifico
        [HttpGet("customer/{id}", Name = "GetCargoByCustomer")]
        public IActionResult GetByCustomerId(int id)
        {
            var item = this.Cargos.GetAllById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/cargo
        //Cria um novo cargo
        [HttpPost]
        public IActionResult Create([FromBody]Cargo item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            item = this.Cargos.Add(item);
            return CreatedAtRoute("GetCargo", new { Controller = "Cargo", id = item.Id }, item);
        }

        // PUT api/cargo/5
        // Atualiza um cargo
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Cargo item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var cargo = this.Cargos.Find(id);
            if (cargo == null)
            {
                return NotFound();
            }

            cargo.Descricao = item.Descricao;
            cargo.Nome = item.Nome;
            cargo.Cliente = item.Cliente;
            this.Cargos.Update(cargo);
            return new NoContentResult();
        }

        // DELETE api/cargo/5
        // Deleta um cargo
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.Cargos.Remove(id);
        }
    }
}
