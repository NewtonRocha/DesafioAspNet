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
    public class ClienteController : Controller
    {
        //Repositorio de clientes
        private IRepository<Cliente> Clientes { get; set; }

        public ClienteController(IRepository<Cliente> clientes)
        {
            this.Clientes = clientes;
        }

        // GET: api/cliente
        // Retorna todos os clientes
        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            return this.Clientes.GetAll();
        }

        // GET api/cliente/5
        // Retorna um cliente especifico
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult GetById(int id)
        {
            var item = this.Clientes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/cliente
        // Cria um novo cliente
        [HttpPost]
        public IActionResult Create([FromBody]Cliente item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            item = this.Clientes.Add(item);
            return CreatedAtRoute("GetCustomer", new { Controller = "Cliente", id = item.Id }, item);
        }

        // PUT api/cliente/5
        // Atualiza um cliente
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Cliente item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var cliente = this.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Name = item.Name;
            this.Clientes.Update(cliente);
            return new NoContentResult();
        }

        // DELETE api/cliente/5
        // Deleta um cliente
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.Clientes.Remove(id);
        }
    }
}
