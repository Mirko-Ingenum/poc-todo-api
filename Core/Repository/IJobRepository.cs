using System;
using Model.Database;
using Model.DTO;

namespace Core.Repository
{
	public interface IJobRepository : IBaseRepository<Job>
	{
		/* Task<AddJobDto> Create(Job newJob); */


		Task<bool> PermanentDelete(string id); 
	}
}

