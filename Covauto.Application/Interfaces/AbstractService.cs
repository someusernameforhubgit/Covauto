namespace Covauto.Application.Interfaces;

public abstract class AbstractService<TListItem, TItem, TMakeItem, TUpdateItem>(AbstractRepository<TListItem, TItem, TMakeItem, TUpdateItem> repository)
{
    protected readonly AbstractRepository<TListItem,TItem, TMakeItem, TUpdateItem> Repository = repository;
    public virtual async Task<IEnumerable<TListItem>> GetAllAsync()
    {
        return await Repository.GetAllAsync();
    }

    public virtual async Task<TItem> GetByIDAsync(int id)
    {
        return await Repository.GetByIDAsync(id);
    }

    public virtual async Task<IEnumerable<TListItem>> SearchAsync(string query)
    {
        return await Repository.SearchAsync(query);
    }
    
    public virtual async Task<int> AddAsync(TMakeItem item)
    {
        return await Repository.AddAsync(item);
    }
    
    public virtual Task<int> UpdateAsync(int id, TUpdateItem item)
    {
        throw new NotImplementedException();
    }
    
    public virtual async Task DeleteAsync(int id)
    {
        await Repository.DeleteAsync(id);
    }
}