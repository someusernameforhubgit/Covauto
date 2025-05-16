namespace Covauto.Application.Interfaces;

public interface IRepositoryUpdatable<in TUpdatable>
{
    public Task UpdateAsync(int id, TUpdatable item);
}