using Inova.Farm.SistemaInterfaceWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inova.Farm.SistemaInterfaceWeb.Repository
{
    public class GenericRepository<TEntity>
                where TEntity : class

    {
        public InovaFarmDB contexto;

        public GenericRepository()
        {
            this.contexto = new InovaFarmDB();
        }

        public void Adicionar(TEntity objeto)
        {
            contexto.Set<TEntity>().Add(objeto);
            contexto.SaveChanges();
        }

        public void Excluir(int id)
        {
            contexto.Set<TEntity>().Remove(contexto.Set<TEntity>().Find(id));
            contexto.SaveChanges();
        }

        public TEntity EncontrarPorID(int id)
        {
            return contexto.Set<TEntity>().Find(id);

        }

        public IList<TEntity> EncontrarTodos()
        {
            return contexto.Set<TEntity>().ToList();
        }

    }
}