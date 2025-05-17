using Covauto.Application.Interfaces;

namespace Covauto.Application.Services;

public class BaseService<TListItem, TItem>(AbstractRepository<TListItem, TItem> repository) : AbstractService<TListItem, TItem>(repository);