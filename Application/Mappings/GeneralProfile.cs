using Application.DTOs;
using Application.Features.Resources.Commands.CreateResourceCommand;
using Application.Features.ResourcesExtraSkills.CreateResourceExtraSkillsCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        #region DTOs
        CreateMap<Resource, ResourceDto>();
        CreateMap<ResourceExtraSkills, ResourceExtraSkillsDto>();
        #endregion
        #region Commands
        CreateMap<CreateResourceCommand, Resource>();
        CreateMap<CreateResourceExtraSkillsCommand, ResourceExtraSkills>();
        #endregion
    }
}
