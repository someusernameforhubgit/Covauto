using Covauto.Shared.DTO.Adres;

namespace Covauto.Application.Interfaces;

public interface IAdresRepository
{
    void VoegToe(AdresListItem request);
}