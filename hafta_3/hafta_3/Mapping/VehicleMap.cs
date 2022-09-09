using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using EnesAgcahan_Hafta3.Model;

namespace EnesAgcahan_Hafta3.Mapping
{
    public class VehicleMap : ClassMapping<vehicle>
    {
        //Araç için mapping işlemleri
        public VehicleMap()
        {
            Id(x => x.id, x =>
            {
                x.Type(NHibernateUtil.Int64);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.vehiclename, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });
            Property(b => b.vehicleplate, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Table("vehicle");
        }
    }
}
