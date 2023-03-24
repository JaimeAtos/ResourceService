using Application.DTOs;
using Application.Features.Resources.Commands.CreateResourceCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        #region DTOs
        CreateMap<Resource, ResourceDto>();
        #endregion
        #region Commands
        CreateMap<CreateResourceCommand, Resource>();
        #endregion
    }
}
