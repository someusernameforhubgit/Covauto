using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Auto;

namespace Covauto.Application.Services;

public class BaseService<TListItem, TItem>(AbstractRepository<TListItem, TItem> repository) : AbstractService<TListItem, TItem>(repository);