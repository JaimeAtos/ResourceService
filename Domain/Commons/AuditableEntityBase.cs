namespace Domain.Commons;

public abstract class AuditableEntityBase<TKey, TUserKey> : EntityBase<TKey, TUserKey>
{
    public TUserKey? UserLastModify { get; set; }
    public DateTime? LastDateModified { get; set; }
}
