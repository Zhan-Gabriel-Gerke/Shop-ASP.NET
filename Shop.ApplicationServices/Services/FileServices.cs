
using Shop.Core.Dto;
using Shop.Data;
using Microsoft.Extensions.Hosting;
using Shop.Core.Domain;
using Shop.Core.ServiceInterface;

namespace Shop.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly ShopContext _context;
        private readonly IHostEnvironment _webHost;

        public FileServices(ShopContext context, IHostEnvironment _webHost)
        {
            _context = context;
        }
        public void FilesToApi(SpaceShipDto dto, SpaceShip spaceShip)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\multipleFileUpload"))
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\multipleFileUpload");
                }
                
                foreach (var file in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_webHost.ContentRootPath, "mmultipleFileUpload");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.Name;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream); // или CopyToAsync для асинхронного сохранения

                        FileToApiDto path = new FileToApi
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            SpaceShipId = spaceShip.Id
                        };

                        _context.FileToApis.AddAsync(path);
                    }
                }
            }
        }
    }
}
