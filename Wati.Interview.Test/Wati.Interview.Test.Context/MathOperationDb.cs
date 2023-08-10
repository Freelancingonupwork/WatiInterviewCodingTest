using Microsoft.EntityFrameworkCore;
using Wati.Interview.Test.Model;

namespace Wati.Interview.Test.Context
{
    public class MathOperationDb: DbContext
    {
        public MathOperationDb(DbContextOptions<MathOperationDb> options) : base(options) { }

        public DbSet<Sum> tblSum { get; set; }
    }
}