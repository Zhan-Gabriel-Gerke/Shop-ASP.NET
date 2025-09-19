using Microsoft.EntityFrameworkCore;
using Shop.Core.ServiceInterface.SpaceShips;
using Shop.Core.Dto.Kindergarten;
using Shop.Core.Dto.SpaceShips;
using Shop.Data.SpaceShips;
using Shop.Data.Kindergarten;
using Shop.Core.Domain.SpaceShips;

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

        public async Task<SpaceShip> Delete(Guid id)
        {
            //you need to do that by yourself
            var spaceship = await _context.SpaceShips
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.SpaceShips.Remove(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }

        public async Task<SpaceShip> Update(SpaceShipDto dto)
        {
            SpaceShip domain = new();

            domain.Id = dto.Id;
            domain.Name = dto.Name;
            domain.TypeName = dto.TypeName;
            domain.BuiltDate = dto.BuiltDate;
            domain.Crew = dto.Crew;
            domain.EnginePower = dto.EnginePower;
            domain.Passengers = dto.Passengers;
            domain.InnerVolume = dto.InnerVolume;
            domain.CreateAt = dto.CreatedAt;
            domain.ModefiedAt = DateTime.Now;

            _context.SpaceShips.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
    }
}
