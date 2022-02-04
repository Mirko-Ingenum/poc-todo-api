using System;
using Core.Repository;
using Model.Database;
using Model.DTO;

namespace Core.Services
{
	public interface IBoardService : IBaseService<BoardDto, AddBoardDto, Board, IBoardRepository>
	{
		Task<BoardDto> GetAsync(string id);

		Task<BoardDto> UpdateAsync(string id, UpdateBoardDto newJob);
	}
}

