using Covauto.Domain.Data;

namespace Covauto.Application.Interfaces;

public abstract class AbstractUpdatableRepository<TListItem, TItem, TUpdatableItem>(CovautoContext context) : AbstractRepository<TListItem, TItem>(context)
{
    public virtual Task<int> UpdateAsync(int id, TUpdatableItem item)
    {
        throw new NotImplementedException();
    }
}