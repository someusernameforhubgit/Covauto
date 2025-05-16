using Covauto.API.Controllers.interfaces;
using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Reservering;

namespace Covauto.API.Controllers;

public class ReserveringController(AbstractService<ReserveringListItem, ReserveringItem> service) : AbstractController<ReserveringListItem, ReserveringItem>(service);
