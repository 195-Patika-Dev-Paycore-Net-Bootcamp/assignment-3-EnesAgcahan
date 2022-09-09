using EnesAgcahan_Hafta3.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnesAgcahan_Hafta3
{
    
        public interface IMapperSession
        {
            //İnterface sınıfımızda kullanacağımızın servisin metodlarını tanımladık.
            void BeginTransaction();
            void Commit();
            void Rollback();
            void CloseTransaction();
            void Save(vehicle entity);
            void Update(vehicle entity);
            void Delete(vehicle entity);

            void Save(container entity);
            void Update(container entity);
            void Delete(container entity);

            IQueryable<vehicle> Vehicles { get; }
            IQueryable<container> Containers { get; }
            
            
       
    }
    
}
