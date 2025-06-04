using Covauto.Domain.Data;

namespace Covauto.Application.Interfaces;

public abstract class AbstractRepository<TListItem, TItem, TMakeItem, TUpdateItem>(CovautoContext context)
{
    protected readonly CovautoContext Ctx = context;

    public virtual Task<IEnumerable<TListItem>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public virtual Task<TItem> GetByIDAsync(int id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<IEnumerable<TListItem>> SearchAsync(string query)
    {
        throw new NotImplementedException();
    }
    
    public virtual Task<int> AddAsync(TMakeItem item)
    {
        throw new NotImplementedException();
    }
    
    public virtual Task UpdateAsync(int id, TUpdateItem item)
    {
        throw new NotImplementedException();
    }
    
    public virtual Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
