using Application.Features.Resources.Commands.CreateResourceCommand;
using Application.Features.Resources.Commands.DeleteResourceCommand;
using Application.Features.Resources.Commands.UpdateResourceCommand;
using Atos.Core.EventsDTO;

namespace Application.Extensions;

public static class CommandResourceExtensions
{
    public static ResourceCreated ToResourceCreated(this CreateResourceCommand request, Guid id)
    {
        return new ResourceCreated
        {
            Id = id,
            ResourceName = request.ResourceName,
            ResumeUrl = request.ResumeUrl,
            WorkEmail = request.WorkEmail,
            PersonalEmail = request.PersonalEmail,
            Phone = request.Phone,
            CurrentStateId = request.CurrentStateId, 
            CurrentStateDescription = request.CurrentStateDescription,
            CurrentPositionId = request.CurrentPositionId,
            CurrentPositionDescription = request.CurrentPositionDescription,
            LocationId = request.LocationId,
            LocationDescription = request.LocationDescription,
            NessieID = request.NessieID,
            CurrentClientId = request.CurrentClientId,
            CurrentClientName = request.CurrentClientName,
            IsNational = request.IsNational,
            Gcm = request.Gcm
        };
    }
	
    public static ResourceUpdated ToResourceUpdated(this UpdateResourceCommand request)
    {
        return new ResourceUpdated
        {
            Id = request.Id,
            ResourceName = request.ResourceName,
            ResumeUrl = request.ResumeUrl,
            WorkEmail = request.WorkEmail,
            PersonalEmail = request.PersonalEmail,
            Phone = request.Phone,
            CurrentStateId = request.CurrentStateId, 
            CurrentStateDescription = request.CurrentStateDescription,
            CurrentPositionId = request.CurrentPositionId,
            CurrentPositionDescription = request.CurrentPositionDescription,
            LocationId = request.LocationId,
            LocationDescription = request.LocationDescription,
            NessieID = request.NessieID,
            CurrentClientId = request.CurrentClientId,
            CurrentClientName = request.CurrentClientName,
            IsNational = request.IsNational,
            Gcm = request.Gcm
        };
    }
	
    public static ResourceDeleted ToResourceDeleted(this DeleteResourceCommand request)
    {
        return new ResourceDeleted
        {
            Id = request.Id
        };
    }
}