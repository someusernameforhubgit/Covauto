using Covauto.API.Controllers.interfaces;
using Covauto.Application.Interfaces;
using Covauto.Shared.DTO.Gebruiker;

namespace Covauto.API.Controllers;

public class GebruikerController(AbstractService<GebruikerListItem, GebruikerItem> service) : AbstractController<GebruikerListItem, GebruikerItem>(service);
