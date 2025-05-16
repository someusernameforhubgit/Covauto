using Covauto.API.Controllers.interfaces;
using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Auto;

namespace Covauto.API.Controllers;

public class AutoController(AbstractService<AutoListItem, AutoItem> service) : AbstractController<AutoListItem, AutoItem>(service);