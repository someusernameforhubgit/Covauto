using Covauto.Domain.Data;

namespace Covauto.Application.Interfaces;

public abstract class AbstractRepository<TListItem, TItem>(CovautoContext context)
{
    protected readonly CovautoContext Ctx = context;
    public abstract Task<IEnumerable<TListItem>> GetAllAsync();
    public abstract Task<TItem> GetByIDAsync(int id);

    public virtual Task<IEnumerable<TListItem>> SearchAsync(string query)
    {
        throw new NotImplementedException();
    }
    
    public virtual Task<int> AddAsync(TItem item)
    {
        throw new NotImplementedException();
    }
    
    public virtual Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
