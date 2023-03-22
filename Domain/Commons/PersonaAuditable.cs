namespace Domain.Commons;
public abstract class PersonaAuditable<TKey, TUserKey> : AuditableEntityBase<TKey, TUserKey>
{
    public string FullName { get; set; }
}
