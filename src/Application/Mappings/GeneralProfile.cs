using Application.DTOs;
using Application.Features.Resources.Commands.CreateResourceCommand;
using Application.Features.ResourcesExtraSkills.CreateResourceExtraSkillsCommand;
using Application.Features.ResourcesSkills.Commands.CreateResourceSkillCommand;
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
        CreateMap<ResourceSkills, ResourceSkillsDto>();
        #endregion
        #region Commands
        CreateMap<CreateResourceCommand, Resource>();
        CreateMap<CreateResourceSkillsCommand, ResourceSkills>();
        CreateMap<CreateResourceExtraSkillsCommand, ResourceExtraSkills>();
        #endregion
    }
}
