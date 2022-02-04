
using System;
using AutoMapper;
using Core.Repository;
using Core.Services;
using Model.Database;
using Model.DTO;

namespace Infrastructure.Services
{
	public class BoardService : BaseService<BoardDto, AddBoardDto, Board, IBoardRepository>, IBoardService
    {
        public BoardService(IBoardRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public async Task<BoardDto> GetAsync(string id)
        {
            var board = await this.repository.GetByIdAsync(id);

            return this._mapper.Map<BoardDto>(board);
        }

        public async Task<BoardDto> UpdateAsync(string id, UpdateBoardDto boardDto)
        {
            var board = await this.repository.GetByIdAsync(id);

            this._mapper.Map<UpdateBoardDto, Board>(boardDto, board);

            if (board != null)
            {
                board.Id = id;

                var boardUpdated = await this.repository.UpdateAsync(board);

                return this._mapper.Map<BoardDto>(boardUpdated);
            }

            return null;
        }

    }
}
