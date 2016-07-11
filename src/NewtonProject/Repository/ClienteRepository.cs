using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewtonProject.Models;

namespace NewtonProject.Repository
{
    public class ClienteRepository : IRepository<Cliente>
    {

        private NewtonProjectContext _context;

        public ClienteRepository(NewtonProjectContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Adiciona um novo cliente ao banco
        /// </summary>
        /// <param name="item">Cliente a ser adicionado</param>
        /// <returns></returns>
        public Cliente Add(Cliente item)
        {
            this._context.Clientes.Add(item);
            this._context.SaveChanges();
            return this._context.Clientes.Last();
        }

        /// <summary>
        /// Retorna todos os clientes do banco
        /// </summary>
        /// <returns>Todos os clientes</returns>
        public IEnumerable<Cliente> GetAll()
        {
            return this._context.Clientes.ToList();
        }
        
        /// <summary>
        /// Não implementado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Cliente> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna um cliente especifica
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns></returns>
        public Cliente Find(int id)
        {
            try
            {
                return this._context.Clientes.Single(c => c.Id == id);
            }
            catch (InvalidOperationException exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Remove cliente especifico
        /// </summary>
        /// <param name="id">Identificador do cliente</param>
        /// <returns></returns>
        public Cliente Remove(int id)
        {
            try
            {
                var item = this._context.Clientes.Single(c => c.Id == id);
                this._context.Clientes.Remove(item);
                this._context.SaveChanges();
                return item;
            }
            catch (InvalidOperationException exception)
            {
                return null;
            }
        }
        
        /// <summary>
        /// Atualiza cliente especifico
        /// </summary>
        /// <param name="item">Cliente a ser atualizado</param>
        public void Update(Cliente item)
        {
            this._context.Clientes.Update(item);
            this._context.SaveChanges();
        }
    }
}
