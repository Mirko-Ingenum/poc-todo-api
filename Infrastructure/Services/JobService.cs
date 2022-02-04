using System;
using Core.Repository;
using Core.Services;
using Model.Database;
using Model.DTO;
using AutoMapper;
using System.Threading.Tasks;


namespace Infrastructure.Services
{
	public class JobService : BaseService<JobDto, AddJobDto, Job, IJobRepository>, IJobService
	{
        public JobService(IJobRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public async Task<JobDto> GetAsync(string id)
        {
            var job = await this.repository.GetByIdAsync(id);

            return this._mapper.Map<JobDto>(job);
        }

        public async Task<JobDto> UpdateAsync(string id, UpdateJobDto jobDto)
        {
            var job = await this.repository.GetByIdAsync(id);

            this._mapper.Map<UpdateJobDto, Job>(jobDto, job);

            if (job != null)
            {
                job.Id = id;

                var jobUpdated = await this.repository.UpdateAsync(job);

                return this._mapper.Map<JobDto>(jobUpdated);
            }

            return null;
        }

    }
}
