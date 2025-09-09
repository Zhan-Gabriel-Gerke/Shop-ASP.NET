using Shop.Core.Domain;
using Shop.Data;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;

namespace Shop.ApplicationServices.Services
{
    public class SpaceShipsServices : ISpaceShipsServices
    {
        private readonly ShopContext _context;

        public SpaceShipsServices(ShopContext context)
        {
            _context = context;
        }

        public async Task<SpaceShip> Create(SpaceShipDto dto)
        {
            SpaceShip spaceship = new SpaceShip();

            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.TypeName = dto.TypeName;
            spaceship.BuiltDate = dto.BuiltDate;
            spaceship.Crew = dto.Crew;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.Passengers = dto.Passengers;
            spaceship.InnerVolume = dto.InnerVolume;
            spaceship.CreateAt = DateTime.Now;
            spaceship.ModefiedAt = DateTime.Now;

            await _context.SpaceShips.AddAsync(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }

        public async Task <SpaceShip> DetailAsync(Guid id)
        {
            var result = await _context.SpaceShips
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
    }
}
