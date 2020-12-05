using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AMLLinesEDMXCodeFirst;
using LineStatusViewer.Models;

namespace LineStatusViewer.Data
{
    public class LineStatusDataService : ILineStatusDataService
    {
        Func<AMLLinesCF> _contextCreator;

        // TODO(crhodes)
        // Not sure how Unity resolves this constructor parameter.  In the example
        // using AutoFac, had to register in bootstrapper.  Need to research this.
        // It magically is working, however.  :)

        public LineStatusDataService(Func<AMLLinesCF> contextCreator)
        {
            // 13
            // 20
            // 27
            _contextCreator = contextCreator;
        }

        public IEnumerable<AML_LineStatus> GetAll()
        {
            using (var ctx = _contextCreator())
            {
                ctx.Database.Log = Console.WriteLine;

                return ctx.AML_LineStatus.AsNoTracking().ToList();
            }
        }

        public async Task<IEnumerable<AML_LineStatus>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                ctx.Database.Log = Console.WriteLine;

                // Await result so ctx doesn't get disposed before ToListAsync returns
                // 39
                return await ctx.AML_LineStatus.AsNoTracking().ToListAsync();

                //// Demonstrate UI remains responsive

                //var friends = await ctx.Friends.AsNoTracking().ToListAsync();

                //// See that can move window around
                //await Task.Delay(5000);

                //// And then friends show up.
                //return friends;
            }
        }

        public async Task<AML_LineStatus> GetByBuildItemAsync(BuildItem buildItem)
        {
            using (var ctx = _contextCreator())
            {
                ctx.Database.Log = Console.WriteLine;

                // Await result so ctx doesn't get disposed before ToListAsync returns
                // B4
                return await ctx.AML_LineStatus.AsNoTracking()
                    .SingleAsync(n => 
                        n.LineID == buildItem.LineId 
                        && n.StationNO == buildItem.StationNO
                        && n.BuildNo == buildItem.BuildNo);

                //// Demonstrate UI remains responsive

                //var friends = await ctx.Friends.AsNoTracking().ToListAsync();

                //// See that can move window around
                //await Task.Delay(5000);

                //// And then friends show up.
                //return friends;
            }
        }

        //public async Task<AML_LineStatus> GetByBuildItemAsync(string buildNo)
        //{
        //    using (var ctx = _contextCreator())
        //    {
        //        // Await result so ctx doesn't get disposed before ToListAsync returns

        //        return await ctx.AML_LineStatus.AsNoTracking().SingleAsync(f => f.BuildNo == buildNo);

        //        //// Demonstrate UI remains responsive

        //        //var friends = await ctx.Friends.AsNoTracking().ToListAsync();

        //        //// See that can move window around
        //        //await Task.Delay(5000);

        //        //// And then friends show up.
        //        //return friends;
        //    }
        //}

        public async Task SaveAsync(BuildItem buildItem, AML_LineStatus newLineStatus)
        {
            using (var ctx = _contextCreator())
            {
                // S2
                ctx.Database.Log = Console.WriteLine;

                var oldLineStatus = ctx.AML_LineStatus
                    .Where(n => 
                        n.LineID == buildItem.LineId 
                        && n.StationNO == buildItem.StationNO
                        && n.BuildNo == buildItem.BuildNo)
                    .Single();

                //foreach (AML_LineStatus item in oldLineStatus)
                //{
                //    Console.WriteLine($"LineID:{item.LineID} StationNO:{item.StationNO}");
                //}

                //foreach (AML_LineStatus item in oldLineStatus.Where(n => n.BuildNo == buildItem.BuildNo))
                //{
                //    Console.WriteLine($"LineID:{item.LineID} StationNO:{item.StationNO}");
                //}

                ctx.AML_LineStatus.Remove(oldLineStatus);
                ctx.Entry(oldLineStatus).State = EntityState.Deleted;
                // Need to Save the Delete before Attaching new below
                // Ok unless the Key items do not change, e.g. updating IPCStatus, AndonCall, or ReadStatus
                // for an existing BuildItem

                await ctx.SaveChangesAsync();
                // TODO(crhodes)
                // Need to delete existing row based on buildItem, then attach new

                ctx.AML_LineStatus.Attach(newLineStatus);
                ctx.Entry(newLineStatus).State = EntityState.Added;

                await ctx.SaveChangesAsync();
            }
        }

        //public IEnumerable<AML_LineStatus> GetAll()
        //{
        //    //// TODO(crhodes)
        //    //// Load data from real database.
        //    //// For now just return hard coded list.
        //    yield return new AML_LineStatus {
        //        LineID = 1,
        //        StationNO = "0012",
        //        BuildNo = "12345",
        //        EngineMoveDate = DateTime.Now,
        //        AndonCALL = 0, 
        //        IPCStatus = 0, 
        //        ReadStatus = 0 };
        //    yield return new AML_LineStatus {
        //        LineID = 1, 
        //        StationNO = "0014", 
        //        BuildNo = "23456", 
        //        EngineMoveDate = DateTime.Now, 
        //        AndonCALL = 0, 
        //        IPCStatus = 0, 
        //        ReadStatus = 1 };
        //    yield return new AML_LineStatus { LineID = 1, 
        //        StationNO = "0016", 
        //        BuildNo = "34567", 
        //        EngineMoveDate = DateTime.Now, 
        //        AndonCALL = 0, 
        //        IPCStatus = 0, 
        //        ReadStatus = 0 };
        //    yield return new AML_LineStatus {
        //        LineID = 2,
        //        StationNO = "0022",
        //        BuildNo = "45678",
        //        EngineMoveDate = DateTime.Now,
        //        AndonCALL = 1,
        //        IPCStatus = 0,
        //        ReadStatus = 0
        //    };
        //    yield return new AML_LineStatus {
        //        LineID = 2,
        //        StationNO = "0028",
        //        BuildNo = "56789",
        //        EngineMoveDate = DateTime.Now,
        //        AndonCALL = 0,
        //        IPCStatus = 0,
        //        ReadStatus = 0
        //    };
        //}
    }
}
