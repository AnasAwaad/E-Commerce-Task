using Microsoft.AspNetCore.Http;

namespace E_Commerce.Application.Interfaces.Services;
public interface ICloudinaryService
{
	Task<string> UploadFileAsync(IFormFile file, string folderName);
}