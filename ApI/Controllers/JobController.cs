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

[Route("jobs")]
[ApiController]
public class JobController : ControllerBase
{
    private readonly IJobService jobService;

    public JobController(IJobService jobService)
    {
        this.jobService = jobService;
    }

    [HttpGet]
    public async Task<ActionResult<Response<IEnumerable<JobDto>>>> Get()
    {
        var jobs = await this.jobService.GetAllAsync();

        if (jobs.IsNullOrEmpty())
        {
            //retourner liste vide
            return this.NotFound(new Response<IEnumerable<JobDto>>(new ErrorResult()
            {
                Code = ErrorCode.ITEMS_NOT_FOUND,
                Description = ErrorDescription.ITEMS_NOT_FOUND
            }));
        }

        return this.Ok(new Response<IEnumerable<JobDto>>(jobs));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Response<JobDto>>> Get(string id)
    {
        var job = await this.jobService.GetAsync(id);

        if (job == null)
        {
            return this.NotFound(new Response<JobDto>(new ErrorResult()
            {
                Code = ErrorCode.ITEM_NOT_FOUND,
                Description = ErrorDescription.ITEM_NOT_FOUND
            }));
        }

        return this.Ok(new Response<JobDto>(job));
    }

    [HttpPost]
    public async Task<ActionResult<Response<JobDto>>> Post(AddJobDto newJob)
    {
        if (newJob == null)
        {
            return this.ValidationProblem();
        }

        var createdJob = await this.jobService.CreateAsync(newJob);

        if (createdJob == null)
        {
            return this.UnprocessableEntity();
        }

        return this.Ok(new Response<JobDto>(createdJob));
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Response<JobDto>>> Put(string id, [FromBody] UpdateJobDto newJob)
    {
        if (newJob == null)
        {
            return this.ValidationProblem();
        }

        var address = await this.jobService.GetAsync(id);

        if (address == null)
        {
            return this.NotFound(new Response<JobDto>(new ErrorResult()
            {
                Code = ErrorCode.ITEM_NOT_FOUND,
                Description = ErrorDescription.ITEM_NOT_FOUND
            }));
        }

        var updatedJob = await this.jobService.UpdateAsync(id, newJob);

        if (updatedJob == null)
        {
            return this.UnprocessableEntity();
        }

        return this.Ok(new Response<JobDto>(updatedJob));
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var job = await this.jobService.GetAsync(id);

        if (job == null)
        {
            return this.NotFound(new Response<JobDto>(new ErrorResult()
            {
                Code = ErrorCode.ITEM_NOT_FOUND,
                Description = ErrorDescription.ITEM_NOT_FOUND
            }));
        }

        var isDeleted = await this.jobService.DeleteAsync(job.Id);

        return isDeleted ? this.Ok(isDeleted) : this.UnprocessableEntity() as IActionResult;
    }
}

