using System.Collections.Generic;
using Model.Database;
using Model.DTO;

namespace Api.App_Start;

public class MapperProfile : AutoMapper.Profile
{
    public MapperProfile()
    {
        this.CreateMap<Job, JobDto>()
                .ReverseMap();

        this.CreateMap<Job, AddJobDto>()
            .ForMember(x => x.DueDate, x => x.MapFrom(x => x.Date))
            .ReverseMap();

        this.CreateMap<Job, UpdateJobDto>()
            .ReverseMap();

        this.CreateMap<Board, BoardDto>()
            .ReverseMap();

        this.CreateMap<Board, AddBoardDto>()
            .ReverseMap();

        this.CreateMap<Board, UpdateBoardDto>()
            .ReverseMap();
    }
}

