using Minio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EMobile.DB.MinioService
{
    public interface IMinioProvider
    {
        MinioClient _minioClient { get; set; }
        void UploadImage(string hash, MemoryStream fileStream, string bucketName, string format);
        Task<byte[]> GetImageAsync(string imageName, string bucket);
    }
}
