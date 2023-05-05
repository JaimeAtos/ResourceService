using Application.Features.ResourcesExtraSkills.CreateResourceExtraSkillsCommand;
using Application.Features.ResourcesExtraSkills.DeleteResourceExtraSkillsCommand;
using Application.Features.ResourcesExtraSkills.UpdateResourceExtraSkillsCommand;
using Atos.Core.EventsDTO;

namespace Application.Extensions;

public static class CommandResourceExtraSkillExtensions
{
    public static ResourceExtraSkillCreated ToResourceExtraSkillCreated(this CreateResourceExtraSkillsCommand request, Guid id)
    {
        return new ResourceExtraSkillCreated
        {
            Id = id,
            Title = request.Title,
            ResourceId = request.ResourceId,
            ExperienceOverallTypeTag = request.ExperienceOverallTypeTag,
            BriefDescription = request.BriefDescription,
            Point = request.Point,
            IsApproved = request.IsApproved
        };
    }
	
    public static ResourceExtraSkillUpdated ToResourceExtraSkillUpdated(this UpdateResourceExtraSkillsCommand request)
    {
        return new ResourceExtraSkillUpdated
        {
            Id = request.Id,
            Title = request.Title,
            ResourceId = request.ResourceId,
            ExperienceOverallTypeTag = request.ExperienceOverallTypeTag,
            BriefDescription = request.BriefDescription,
            Point = request.Point,
            IsApproved = request.IsApproved
        };
    }
	
    public static ResourceExtraSkillDeleted ToResourceExtraSkillDeleted(this DeleteResourceExtraSkillsCommand request)
    {
        return new ResourceExtraSkillDeleted
        {
            Id = request.Id
        };
    }
}