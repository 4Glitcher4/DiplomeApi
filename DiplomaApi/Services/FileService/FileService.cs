﻿
namespace DiplomaApi.Services
{
    public class FileService : IFileService
    {
        private readonly IUserService _userService;

        public FileService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> SaveFile(byte[] pcapBytes)
        {
            try
            {
                var filePath = $"/Pcap/{_userService.GetClaimValue(ClaimType.UserId)}.pcap";
                //var filePath = $"/Pcap/FILEUPLOAD.pcap";
                await File.WriteAllBytesAsync(filePath, pcapBytes);

                return filePath;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
