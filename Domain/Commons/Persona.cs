namespace Domain.Commons;

public abstract class Persona<TKey, TUserKey> : EntityBase<TKey, TUserKey>
{
    public string FullName { get; set; }
}
