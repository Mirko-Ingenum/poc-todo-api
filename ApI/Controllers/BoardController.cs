using System.Collections.Generic;
using System.Threading.Tasks;

using Core.Services;
using Model.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Results;
using Core.Constants;
using Core.Extension;

namespace Api.Controllers;

[Route("boards")]
[ApiController]
public class BoardController : ControllerBase
{
    private readonly IBoardService boardService;

    public BoardController(IBoardService boardService)
    {
        this.boardService = boardService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<IEnumerable<BoardDto>>>> Get()
    {
        var boards = await this.boardService.GetAllAsync();

        if (boards.IsNullOrEmpty())
        {
            //retourner liste vide
            return this.NotFound(new Response<IEnumerable<BoardDto>>(new ErrorResult()
            {
                Code = ErrorCode.ITEMS_NOT_FOUND,
                Description = ErrorDescription.ITEMS_NOT_FOUND
            }));
        }

        return this.Ok(new Response<IEnumerable<BoardDto>>(boards));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Response<BoardDto>>> Get(string id)
    {
        var board = await this.boardService.GetAsync(id);

        if (board == null)
        {
            return this.NotFound(new Response<BoardDto>(new ErrorResult()
            {
                Code = ErrorCode.ITEM_NOT_FOUND,
                Description = ErrorDescription.ITEM_NOT_FOUND
            }));
        }

        return this.Ok(new Response<BoardDto>(board));
    }

    [HttpPost]
    public async Task<ActionResult<Response<BoardDto>>> Post(AddBoardDto newBoard)
    {
        if (newBoard == null)
        {
            return this.ValidationProblem();
        }

        var createdBoard= await this.boardService.CreateAsync(newBoard);

        if (createdBoard == null)
        {
            return this.UnprocessableEntity();
        }

        return this.Ok(new Response<BoardDto>(createdBoard));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Response<BoardDto>>> Put(string id, [FromBody] UpdateBoardDto newBoard)
    {
        if (newBoard == null)
        {
            return this.ValidationProblem();
        }

        var board = await this.boardService.GetAsync(id);

        if (board == null)
        {
            return this.NotFound(new Response<BoardDto>(new ErrorResult()
            {
                Code = ErrorCode.ITEM_NOT_FOUND,
                Description = ErrorDescription.ITEM_NOT_FOUND
            }));
        }

        var updatedBoard = await this.boardService.UpdateAsync(id, newBoard);

        if (updatedBoard == null)
        {
            return this.UnprocessableEntity();
        }

        return this.Ok(new Response<BoardDto>(updatedBoard));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var board = await this.boardService.GetAsync(id);

        if (board == null)
        {
            return this.NotFound(new Response<JobDto>(new ErrorResult()
            {
                Code = ErrorCode.ITEM_NOT_FOUND,
                Description = ErrorDescription.ITEM_NOT_FOUND
            }));
        }

        var isDeleted = await this.boardService.DeleteAsync(board.Id);

        return isDeleted ? this.Ok(isDeleted) : this.UnprocessableEntity() as IActionResult;
    }
}

