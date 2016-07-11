using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewtonProject.Models;

namespace NewtonProject.Repository
{
    public class PerfilRepository : IRepository<Perfil>
    {

        private NewtonProjectContext _context;

        public PerfilRepository(NewtonProjectContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Adiciona novo perfil no banco.
        /// </summary>
        /// <param name="item">perfil a ser adicionado</param>
        /// <returns></returns>
        public Perfil Add(Perfil item)
        {
            this._context.Perfis.Add(item);
            this._context.SaveChanges();
            return this._context.Perfis.Last();
        }

        /// <summary>
        /// Retorna todos os perfis do banco.
        /// </summary>
        /// <returns>Todos os perfis</returns>
        public IEnumerable<Perfil> GetAll()
        {
            return this._context.Perfis.ToList();
        }

        /// <summary>
        /// não implementado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Perfil> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retorna um perfil especifico
        /// </summary>
        /// <param name="id">Identificador do perfil</param>
        /// <returns></returns>
        public Perfil Find(int id)
        {
            try
            {
                return this._context.Perfis.Single(p => p.Id == id);
            }
            catch (InvalidOperationException exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Remove perfil especifico
        /// </summary>
        /// <param name="id">Identificador do perfil</param>
        /// <returns></returns>
        public Perfil Remove(int id)
        {
            try
            {
                var item = this._context.Perfis.Single(p => p.Id == id);
                this._context.Perfis.Remove(item);
                this._context.SaveChanges();
                return item;
            }
            catch (InvalidOperationException exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Atualiza perfil especifico
        /// </summary>
        /// <param name="item">Perfil a ser atualizado</param>
        public void Update(Perfil item)
        {
            this._context.Perfis.Update(item);
            this._context.SaveChanges();
        }
    }
}
