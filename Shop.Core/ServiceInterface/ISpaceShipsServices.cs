using Shop.Core.Domain;
using Shop.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface ISpaceShipsServices
    {
        Task<SpaceShip> Create(SpaceShipDto dto);
        Task<SpaceShip> DetailAsync(Guid id);
        Task<SpaceShip> Delete(Guid id);
    }
}