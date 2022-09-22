using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ARHospitalProject.EntityFrameworkCore
{
    public static class ARHospitalProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ARHospitalProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ARHospitalProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
