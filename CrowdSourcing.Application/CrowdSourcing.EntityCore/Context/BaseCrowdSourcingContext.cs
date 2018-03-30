using System.Data.Entity;
using System.Threading.Tasks;

namespace CrowdSourcing.EntityCore.Context
{
    public abstract class BaseCrowdSourcingContext : DbContext
    {
        protected BaseCrowdSourcingContext(string connection) : base(connection)
        {

        }

        public override async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }   
}
