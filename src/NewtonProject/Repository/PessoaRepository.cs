using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewtonProject.Models;

namespace NewtonProject.Repository
{
    public class PessoaRepository : IRepository<Pessoa>
    {

        private NewtonProjectContext _context;

        public PessoaRepository(NewtonProjectContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Adiciona uma pessoa ao banco
        /// </summary>
        /// <param name="item">Pessoa a ser adicionada</param>
        /// <returns></returns>
        public Pessoa Add(Pessoa item)
        {
            var atividades = new List<Atividade>();
            foreach (var atividade in item.Atividades.ToList())
            {
                atividades.Add(this._context.Atividades.SingleOrDefault(a => a.Id == atividade.Id));
            }
            item.Atividades = atividades;
            item.Cargo = this._context.Cargos.SingleOrDefault(c => c.Id == item.Cargo.Id);
            item.Cliente = this._context.Clientes.SingleOrDefault(c => c.Id == item.Cliente.Id);
            item.Perfil = this._context.Perfis.SingleOrDefault(p => p.Id == item.Perfil.Id);
            this._context.Pessoas.Add(item);
            this._context.SaveChanges();
            return this._context.Pessoas.Last();
        }

        /// <summary>
        /// Retorna todas as pessoas do banco.
        /// </summary>
        /// <returns>Todas as pessoas</returns>
        public IEnumerable<Pessoa> GetAll()
        {
            return this._context.Pessoas.Include(p => p.Atividades)
                .Include(p => p.Cargo)
                .Include(p => p.Cliente)
                .Include(p => p.Perfil)
                .ToList();
        }

        /// <summary>
        /// Retorna todas as pessoas por cliente.
        /// </summary>
        /// <param name="id">Id de cliente</param>
        /// <returns></returns>
        public IEnumerable<Pessoa> GetAllById(int id)
        {
            try
            {
                return this._context.Pessoas.Include(p => p.Atividades)
                .Include(p => p.Cargo)
                .Include(p => p.Cliente)
                .Include(p => p.Perfil)
                .Where(p => p.Cliente.Id == id);
            }
            catch (InvalidOperationException exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retorna uma pessoa especifica
        /// </summary>
        /// <param name="id">Identificador de pessoa</param>
        /// <returns></returns>
        public Pessoa Find(int id)
        {
            try
            {
                return this._context.Pessoas.Include(p => p.Atividades)
                .Include(p => p.Cargo)
                .Include(p => p.Cliente)
                .Include(p => p.Perfil)
                .Single(p => p.Id == id);
            }
            catch (InvalidOperationException exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Remove pessoa especifica.
        /// </summary>
        /// <param name="id">Identificador de pessoa</param>
        /// <returns></returns>
        public Pessoa Remove(int id)
        {
            try
            {
                var item = this._context.Pessoas.Single(p => p.Id == id);
                this._context.Pessoas.Remove(item);
                this._context.SaveChanges();
                return item;
            }
            catch (InvalidOperationException exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Atualiza pessoa especifica
        /// </summary>
        /// <param name="item">Pessoa a ser atualizada</param>
        public void Update(Pessoa item)
        {
            var atividades = new List<Atividade>();
            foreach (var atividade in item.Atividades.ToList())
            {
                var realAtividade = this._context.Atividades.SingleOrDefault(a => a.Id == atividade.Id);
                atividades.Add(realAtividade);
            }
            item.Atividades = atividades;
            item.Cargo = this._context.Cargos.SingleOrDefault(c => c.Id == item.Cargo.Id);
            item.Cliente = this._context.Clientes.SingleOrDefault(c => c.Id == item.Cliente.Id);
            item.Perfil = this._context.Perfis.SingleOrDefault(p => p.Id == item.Perfil.Id);
            this._context.Pessoas.Update(item);
            this._context.SaveChanges();
        }
    }
}
