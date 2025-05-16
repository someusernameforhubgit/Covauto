using Covauto.API.Controllers.interfaces;
using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Rit;

namespace Covauto.API.Controllers;

public class RitController(AbstractService<RitListItem, RitItem> service) : AbstractController<RitListItem, RitItem>(service);