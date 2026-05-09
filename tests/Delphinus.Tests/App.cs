using Delphinus.Builders.Query.Filters;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Delphinus.Tests
{
    internal class App
    {
        [SuppressMessage(
            "Security",
            "S2325:Methods and properties that don't access instance data should be static",
            Justification = "Connection string is used only for local development/testing environment. No sensitive production credentials are exposed.")]
        public async Task RunAsync()
        {
            // ----------------- SELECT DATA -----------------

            bool? isActive = true;
            DateTime? startDate = new DateTime(1980, 1, 1, 0, 0, 0, DateTimeKind.Unspecified);
            DateTime? endDate = new DateTime(1999, 12, 31, 0, 0, 0, DateTimeKind.Unspecified);
            int[] levels = RandomNumberGenerator.GetInt32(1, 8) == 1
                ? new int[] { 3, 5, 7 }
                : (int[])null;

            var builder = WhereBuilder.Create();
            var where = builder
                .AndIf(isActive.HasValue, "c.IsActive = @IsActive")
                .AndIf(startDate.HasValue, "c.BirthDate >= @StartDate")
                .AndIf(endDate.HasValue, "c.BirthDate <= @EndDate")
                .AndIf(levels != null && levels.Length > 0, "c.Level IN (@Levels)")
                .Build();
            Console.WriteLine(where);

            levels = new int[] { 3, 5, 7 };
            where = builder
                .Clear()
                .Where("1 = 1")
                .AndOrGroupIf(
                    new[]
                    {
                        isActive.HasValue,
                        levels != null,
                        levels.Length > 0
                    },
                    "(c.IsActive IS NULL OR c.IsActive = @IsActive)",
                    "c.Level IN (@Levels)")
                .OrAndGroupIf(
                    new[]
                    {
                        startDate.HasValue,
                        endDate.HasValue
                    },
                    "c.BirthDate >= @StartDate",
                    "c.BirthDate <= @EndDate")
                .Build();

            var sql = $@"
                SELECT
                    c.Id,
                    c.Name,
                    c.BirthDate,
                    c.Level,
                    c.Salary,
                    c.IsActive
                FROM Customer c
                {where}
                ORDER BY
                    c.Name;";

            Console.WriteLine(sql);
            Console.ReadKey();
        }
    }
}
