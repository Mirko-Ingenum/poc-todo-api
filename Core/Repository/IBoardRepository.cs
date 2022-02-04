using System;
using Model.Database;

namespace Core.Repository
{
	public interface IBoardRepository : IBaseRepository<Board>
	{

		Task<bool> PermanentDelete(string id);
	}
}
