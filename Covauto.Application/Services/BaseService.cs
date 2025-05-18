using Covauto.Application.Interfaces;

namespace Covauto.Application.Services;

public class BaseService<TListItem, TItem, TMakeItem, TUpdateItem>(AbstractRepository<TListItem, TItem, TMakeItem, TUpdateItem> repository) : AbstractService<TListItem, TItem, TMakeItem, TUpdateItem>(repository);