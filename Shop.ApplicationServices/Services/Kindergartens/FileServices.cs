using Microsoft.Extensions.Hosting;
using Shop.Core.Domain.Kindergarten;
using Shop.Core.Dto.Kindergarten;
using Shop.Core.ServiceInterface.Kindergarten;
using Shop.Data.Kindergarten;

namespace Shop.ApplicationServices.Services.Kindergarten
{
    public class FileServices : IFileServices
    {
        private readonly KindergartenContext _context;
        private readonly IHostEnvironment _webHost;

        public FileServices(KindergartenContext context, IHostEnvironment _webHost)
        {
            _context = context;
        }
        public void FilesToApi(KindergartenDto dto, Shop.Core.Domain.Kindergartens.Kindergarten kindergarten)
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

                        FileToApiKindergarten path = new FileToApiKindergarten
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            KindergartenId = kindergarten.Id
                        };

                        _context.FileToApis.AddAsync(path);
                    }
                }
            }
        }
    }
}
