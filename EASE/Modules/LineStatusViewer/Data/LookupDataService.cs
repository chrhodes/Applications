using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using AMLLinesEDMXCodeFirst;
using LineStatusViewer.Models;

namespace LineStatusViewer.Data
{
    public class LookupDataService : ILookupBuildsService
    {
        Func<AMLLinesCF> _contextCreator;

        public LookupDataService(Func<AMLLinesCF> contextCreator)
        {
            // 18
            // 24
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<BuildItem>> GetBuildsAsync()
        {
            using (var ctx = _contextCreator())
            {
                ctx.Database.Log = Console.WriteLine;

                // Await result so ctx doesn't get disposed before ToListAsync returns
                // 36
                //return await ctx.AML_LineStatus.AsNoTracking()
                return await ctx.AML_LineStatus
                    .Select(f =>
                    new BuildItem
                    {
                        LineId = f.LineID,
                        StationNO = f.StationNO,
                        BuildNo = f.BuildNo

                    })
                    .ToListAsync();


                //return await ctx.AML_LineStatus.AsNoTracking().ToListAsync();

                //// Demonstrate UI remains responsive

                //var friends = await ctx.Friends.AsNoTracking().ToListAsync();

                //// See that can move window around
                //await Task.Delay(5000);

                //// And then friends show up.
                //return friends;
            }
        }
    }
}
