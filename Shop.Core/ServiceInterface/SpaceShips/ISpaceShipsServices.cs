using Shop.Core.Domain.SpaceShips;
using Shop.Core.Dto.SpaceShips;
namespace Shop.Core.ServiceInterface.SpaceShips
{
    public interface ISpaceShipsServices
    {
        Task<SpaceShip> Create(SpaceShipDto dto);
        Task<SpaceShip> DetailAsync(Guid id);
        Task<SpaceShip> Delete(Guid id);
        Task<SpaceShip> Update(SpaceShipDto dto);
    }
}