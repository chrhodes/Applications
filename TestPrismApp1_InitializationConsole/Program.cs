using System;
using System.Data.Entity;

using TestPrismApp1.Data;
using TestPrismApp1.Domain;

namespace TestPrismApp1_InitializationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Have EF skip DB state check.
            Database.SetInitializer(new NullDatabaseInitializer<TestPrismApp1DbContext>());

            using (var context = new TestPrismApp1DbContext())
            {
                context.Database.Log = Console.WriteLine;

                var mat1 = context.MaterialSet.Find(1);
                var mat2 = context.MaterialSet.Find(2);
                var mat3 = context.MaterialSet.Find(3);
                var mat4 = context.MaterialSet.Find(4);

                var serviceAddress1 = context.ServiceAddressSet.Find(1);
                var serviceAddress2 = context.ServiceAddressSet.Find(2);
                var serviceAddress3 = context.ServiceAddressSet.Find(3);

                //var serviceCall7 = context.ServiceCallset.Find(7);
                //var serviceCall8 = context.ServiceCallset.Find(8);

                var poolConditionReport1 = new PoolCondition();

                poolConditionReport1.ChlorineResidual = 2;
                poolConditionReport1.CyanuricAcidLevel = 35;
                poolConditionReport1.FreeChlorine = 1;
                poolConditionReport1.PHLevel = 7.4F;
                poolConditionReport1.Temperature = 87.3F;
                poolConditionReport1.TotalAlkalinity = 160;
                poolConditionReport1.Turbidity = 1;


                //var serviceCall = context.ServiceCallset.Add(
                //    new ServiceReport
                //    {
                //        ServiceAddress = serviceAddress1,
                //        ServiceDate = DateTime.Now,
                //        ServiceTime = new TimeSpan(1, 2, 3),
                //        PoolCondition = poolConditionReport1
                //    });

                var serviceCall = new ServiceCall
                {
                    ServiceAddress = serviceAddress1,
                    ServiceDate = DateTime.Now,
                    ServiceTime = new TimeSpan(1, 2, 3),
                    PoolCondition = poolConditionReport1
                };

                serviceCall.ServiceType.ChemicalCheck = true;

                // This alone doesn't seem to work as no MaterialUsed rows are created.

                // Doesn't matter if add ServiceReport first

                //context.ServiceCallset.Add(serviceCall);

                //serviceCall.MaterialsUsed.Add(
                //    new MaterialUsed
                //    {
                //        Material = mat1,
                //        Quantity = 3,
                //        ServiceReport = serviceCall
                //    });

                //serviceCall.MaterialsUsed.Add(
                //    new MaterialUsed
                //    {
                //        Material = mat2,
                //        Quantity = 4.9F,
                //        ServiceReport = serviceCall
                //    });

                var mu1 = new MaterialUsed
                {
                    //Id = 3,
                    Material = mat3,
                    Quantity = 3,
                    ServiceReport = serviceCall
                };

                var mu2 = new MaterialUsed
                {
                    //Id = 4,
                    Material = mat4,
                    Quantity = 4.9F,
                    ServiceReport = serviceCall
                };

                // This doesn't get rows added.

                serviceCall.MaterialsUsed.Add(mu1);
                serviceCall.MaterialsUsed.Add(mu2);

                // But if we tell the context about them directly it works
                // The EF6 course suggests otherwise.

                context.MaterialUsedSet.Add(mu1);
                context.MaterialUsedSet.Add(mu2);

                // Or here

                context.ServiceCallSet.Add(serviceCall);

                context.SaveChanges();
            }
        }
    }
}
