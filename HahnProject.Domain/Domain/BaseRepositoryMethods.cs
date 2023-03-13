using BB.SmsQuiz.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HahnProject.Domain.Domain
{
    public interface BaseRepositoryMethods<T> where T : EntityBase
    {
        T FindById(long id);

        List<T> FindAll();
        
        void Insert(T item);

        void Update(T item);

        void Delete(long id);
    }
}
