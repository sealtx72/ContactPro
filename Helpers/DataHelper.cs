using ContactPro.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactPro.Helpers
{
    public static class DataHelper
    {
        public static async Task ManageDataAsync(IServiceProvider svcProvider)
        {
            //get an instance of the database context
            var dbcontextSvc = svcProvider.GetRequiredService<ApplicationDbContext>();
            //migration: this is equivalent to running "update-database" in the package manager console
            await dbcontextSvc.Database.MigrateAsync();
        }
    }
}
