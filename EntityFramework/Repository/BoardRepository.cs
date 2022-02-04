
using System;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Database;

namespace EntityFramework.Repository
{
	public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        public BoardRepository(TodoContext context)
            : base(context)
        {
        }

        public override async Task<IEnumerable<Board>> GetAllAsync()
        {
            return await this.context.Boards
                .Include(x => x.Jobs)
                .ToListAsync();
        }

       

        public async Task<bool> PermanentDelete(string id)
        {
            var boardToDelete = await context.Boards
                .FirstOrDefaultAsync(x => x.Id == id);

            if (boardToDelete != null)
            {
                this.context.Remove(boardToDelete);

                await this.context.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
