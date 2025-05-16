using Covauto.Domain.Entities;
using Covauto.Shared.DTO.Adres;

namespace Covauto.Application.Interfaces;

public interface IAdresRepository
{
    Adres VoegToe(CreateAdres request);
}