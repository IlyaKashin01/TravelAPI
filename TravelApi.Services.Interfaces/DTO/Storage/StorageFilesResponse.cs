using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Domain.Core.Entities;

namespace TravelApi.Services.Interfaces.DTO.Storage
{
    public class StorageFilesResponse
    {
        public List<ImageResponse> Images { get; set; } = new List<ImageResponse>();
        public List<FileResponse> personFiles { get; set; } = new List<FileResponse>();
    }

    public class ImageResponse
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public Byte[] Data { get; set; } = new Byte[0];
    }

    public class FileResponse
    {
        public int Id { get; set; } = 0;
        public string FileName { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
    }
}
