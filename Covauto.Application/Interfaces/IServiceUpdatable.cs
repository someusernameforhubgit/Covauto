namespace Covauto.Application.Interfaces;

public interface IServiceUpdatable<in TUpdatable>
{
    public Task UpdateAsync(int id, TUpdatable item);
}