using EMobile.BL;
using Microsoft.Extensions.Options;
using Minio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EMobile.DB.MinioService
{
    public class MinioProvider : IMinioProvider
    {
        private readonly AppSettings _appSettings;
        public MinioClient _minioClient { get; set; }
        public MinioProvider(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _minioClient = new MinioClient($"{_appSettings.MinioServerIp}:{_appSettings.MinioServerPort}", _appSettings.MinioAccesKey, _appSettings.MinioSecetKey);
        }

        public void UploadImage(string hash, MemoryStream fileStream, string bucketName, string format)
        {
            _minioClient.PutObjectAsync(bucketName, $"{hash}.{format}", fileStream, fileStream.Length);

        }

        public async Task<byte[]> GetImageAsync(string imageName, string bucket)
        {
            var streamX = new MemoryStream();
            await _minioClient.GetObjectAsync(bucket, imageName,
                                     (stream) =>
                                     {
                                         stream.CopyTo(streamX);
                                     });

            return streamX.ToArray();
        }

        
    }
}
