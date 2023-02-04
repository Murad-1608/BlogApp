using Entity.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Helper
{
    public static class SystemIOOperations
    {
        public static string AddPhoto(IFormFile file, string folderName)
        {
            var extension = Path.GetExtension(file.FileName);
            var newImageName = file.FileName + Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Images/{folderName}/" + newImageName);

            using (var stream = new FileStream(location, FileMode.Create))
            {
                file.CopyTo(stream);
                return newImageName;
            }
        }

        public static void DeletePhoto(string Category,string Name)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/Images/{Category}/" + Name);

            if (System.IO.File.Exists(FolderPath))
            {
                System.IO.File.Delete(FolderPath);
            }
        }
    }
}
