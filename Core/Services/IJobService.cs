using System;
using System.Threading.Tasks;
using Core.Repository;
using Model.Database;
using Model.DTO;

namespace Core.Services
{
	public interface IJobService : IBaseService<JobDto, AddJobDto, Job, IJobRepository>
	{
		Task<JobDto> GetAsync(string id);

		Task<JobDto> UpdateAsync(string id, UpdateJobDto newJob);
	}
}

