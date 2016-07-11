using System;
using System.Collections.Generic;
using System.Linq;
using NewtonProject.Models;

namespace NewtonProject.Repository
{
    public class AtividadeRepository : IRepository<Atividade>
    {
        private NewtonProjectContext _context;
        
        public AtividadeRepository(NewtonProjectContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Adiciona nova atividade ao banco
        /// </summary>
        /// <param name="item">Atividade a ser adicionada</param>
        public Atividade Add(Atividade item)
        {
            this._context.Atividades.Add(item);
            this._context.SaveChanges();
            return this._context.Atividades.Last();
        }

        /// <summary>
        /// Retorna todas as atividades do banco.
        /// </summary>
        /// <returns>Todas as Atividades de todos os usuários</returns>
        public IEnumerable<Atividade> GetAll()
        {
            return this._context.Atividades.ToList();
        }

        /// <summary>
        /// Retorna Todas as Atividades por Usuário.
        /// </summary>
        /// <param name="id">Id de Usuário</param>
        /// <returns></returns>
        public IEnumerable<Atividade> GetAllById(int id)
        {
            try
            {
                return this._context.Pessoas.Single(p => p.Id == id).Atividades;
            }
            catch (InvalidOperationException exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Retorna uma atividade especifica
        /// </summary>
        /// <param name="id">Identificador da atividade</param>
        /// <returns></returns>
        public Atividade Find(int id)
        {
            try
            {
                return this._context.Atividades.Single(a => a.Id == id);
            }
            catch (InvalidOperationException exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Remove atividade especifica
        /// </summary>
        /// <param name="id">Identificador da atividade</param>
        /// <returns></returns>
        public Atividade Remove(int id)
        {
            try
            {
                var item = this._context.Atividades.Single(a => a.Id == id);
                this._context.Atividades.Remove(item);
                this._context.SaveChanges();
                return item;
            }
            catch (InvalidOperationException exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Atualiza atividade especifica
        /// </summary>
        /// <param name="item">Atividade a ser atualizada</param>
        public void Update(Atividade item)
        {
            this._context.Atividades.Update(item);
            this._context.SaveChanges();
        }
    }
}
