namespace Covauto.Application.Interfaces;

public abstract class AbstractUpdatableService<TListItem, TItem, TUpdatableItem>(AbstractUpdatableRepository<TListItem, TItem, TUpdatableItem> repository) : AbstractService<TListItem, TItem>(repository)
{
    public virtual Task<int> UpdateAsync(int id, TUpdatableItem item)
    {
        throw new NotImplementedException();
    }
}