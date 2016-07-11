using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewtonProject.Models;

namespace NewtonProject.Repository
{
    public class CargoRepository : IRepository<Cargo>
    {

        private NewtonProjectContext _context;

        public CargoRepository(NewtonProjectContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Adiciona novo cargo ao banco
        /// </summary>
        /// <param name="item">Cargo a ser adicionado</param>
        /// <returns></returns>
        public Cargo Add(Cargo item)
        {
            item.Cliente = this._context.Clientes.SingleOrDefault(c => c.Id == item.Cliente.Id);
            this._context.Cargos.Add(item);
            this._context.SaveChanges();
            return this._context.Cargos.Last();
        }

        /// <summary>
        /// Retorna todos os cargos do banco
        /// </summary>
        /// <returns>Todos os cargos no banco</returns>
        public IEnumerable<Cargo> GetAll()
        {
            return this._context.Cargos.Include(c => c.Cliente).ToList();
        }

        /// <summary>
        /// Retorna todas os cargos de um Cliente.
        /// </summary>
        /// <param name="id">Id do cliente</param>
        /// <returns></returns>
        public IEnumerable<Cargo> GetAllById(int id)
        {
            try
            {
                return this._context.Cargos.Include(c => c.Cliente).Where(c => c.Cliente.Id == id).ToList();
            }
            catch (InvalidOperationException exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retorna um cargo especifica.
        /// </summary>
        /// <param name="id">Identificador do cargo</param>
        /// <returns></returns>
        public Cargo Find(int id)
        {
            try
            {
                return this._context.Cargos.Include(c => c.Cliente).Single(c => c.Id == id);
            }
            catch (InvalidOperationException exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Remove cargo especifico
        /// </summary>
        /// <param name="id">Identificador do cargo</param>
        /// <returns></returns>
        public Cargo Remove(int id)
        {
            try
            {
                var item = this._context.Cargos.Single(c => c.Id == id);
                this._context.Cargos.Remove(item);
                this._context.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Atualiza cargo especifico
        /// </summary>
        /// <param name="item">Cargo a ser atualizado</param>
        public void Update(Cargo item)
        {
            item.Cliente = this._context.Clientes.SingleOrDefault(c => c.Id == item.Cliente.Id);
            this._context.Cargos.Update(item);
            this._context.SaveChanges();
        }
    }
}

