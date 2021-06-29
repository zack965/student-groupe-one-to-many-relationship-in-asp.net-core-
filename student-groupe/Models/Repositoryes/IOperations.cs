using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_groupe.Models.Repositoryes
{
    public interface IOperations<TEntity>
    {
        IList<TEntity> List();
        TEntity Find(int id);
        void Add(TEntity entity);
        void Update(int id,TEntity entity);
        void Delete(int id);
        List<TEntity> Search(string term);
        //List<TEntity> ListSearchById(int id);
        IList<TEntity> ListSearch(int id);
    }
}
