using System;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Database;

namespace EntityFramework.Repository
{
	public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(TodoContext context)
            : base(context)
        {
        }
        
        public override async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await this.context.Jobs
                .ToListAsync();
        }

        /*
        public override async Task<Job> GetByIdAsync(string id)
        {
            return await this.context.Jobs;
                
        }*/
        
        public async Task<bool> PermanentDelete(string id)
        {
            var jobToDelete = await context.Jobs
                .FirstOrDefaultAsync(x => x.Id == id);

            if (jobToDelete != null)
            {
                this.context.Remove(jobToDelete);

                await this.context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
