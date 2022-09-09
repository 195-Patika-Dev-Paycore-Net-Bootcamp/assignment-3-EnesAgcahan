using EnesAgcahan_Hafta3.Model;

using NHibernate;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnesAgcahan_Hafta3.Context
{
    public class MapperSession : IMapperSession
    {
        //Mapper servis işlemleri ve arayüz implemantasyonu
        private readonly ISession session;
        private ITransaction transaction;

        public MapperSession(ISession session)
        {
            this.session = session;
        }

        public IQueryable<vehicle> Vehicles => session.Query<vehicle>();

        public IQueryable<container> Containers => session.Query<container>();
        


        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Save(vehicle entity)
        {
            session.Save(entity);
        }
        
        public void Update(vehicle entity)
        {
            session.Update(entity);
        }
        public void Delete(vehicle entity)
        {
            session.Delete(entity);
        }


        public void Save(container entity)
        {
            session.Save(entity);
        }

        public void Update(container entity)
        {
            session.Update(entity);
        }
        public void Delete(container entity)
        {
            session.Delete(entity);
        }

        
    }
}
