using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApi.Common.Auth;
using TravelApi.Common.OperationResult;
using TravelApi.Domain.Core.Entities;
using TravelApi.Domain.Interfaces;
using TravelApi.Infrastructure.Data.Implementation;
using TravelApi.Services.Interfaces.DTO.Storage;
using TravelApi.Services.Interfaces.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace TravelApi.Infrastructure.Business
{
    public class StorageService : IStorageService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IStorageRepository _storageRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IPersonFIleRepository _personFIleRepository;
        private readonly IDecodingJWT _decodingJWT;
        private readonly IMapper _mapper;
        public StorageService(IPersonRepository personRepository, IStorageRepository storageRepository, IDecodingJWT decodingJWT, IImageRepository imageRepository, IPersonFIleRepository personFIleRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _storageRepository = storageRepository;
            _decodingJWT = decodingJWT;
            _imageRepository = imageRepository;
            _personFIleRepository = personFIleRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<int>> CreateStorageAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            if (tokenS != null)
            {
                var personId = tokenS.Claims.FirstOrDefault(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
                if (personId is not null)
                {
                    var person = await _personRepository.GetByIdAsync(Int32.Parse(personId));
                    if (person != null)
                    {
                        var storage = new Storage();
                        storage.Persons.Add(person);
                        var result = await _storageRepository.UpdateStorageAsync(storage);
                        return new OperationResult<int>(result);
                    }
                }
            }
            return OperationResult<int>.Fail(OperationCode.Unauthorized, $"Пользователь не авторизован");
        }

        public Task<OperationResult> DeleteFileAsync(string token, string storageId, string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationResult<StorageFilesResponse>> GetAllFilesAsync(string token)
        {
            var personId = _decodingJWT.getJWTTokenClaim(token, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid");
            if (personId != null)
            {
                var person = await _personRepository.GetByIdAsync(Int32.Parse(personId));
                if (person is not null)
                {
                    var storage = await _storageRepository.GetByIdAsync(person.StorageId);
                    if (storage is not null)
                    {
                        var imagesResult = await _imageRepository.GetAllImagesByStorageIdAsync(person.StorageId);
                        var images = _mapper.Map<IEnumerable<ImageResponse>> (imagesResult);
                        var filesResult = await _personFIleRepository.GetAllFilesByStorageIdAsync(person.StorageId);
                        var files = _mapper.Map<IEnumerable<FileResponse>> (filesResult);
                        var result = new StorageFilesResponse();
                        foreach ( var image in images ) result.Images.Add(image);
                        foreach ( var file in files ) result.personFiles.Add(file);
                        return new OperationResult<StorageFilesResponse>(result);
                    }
                }
            }
            return OperationResult<StorageFilesResponse>.Fail(OperationCode.AlreadyExists, "Файлы не найдены");
        }

        public async Task<OperationResult<bool>> SaveFileAsync(IFormFileCollection files, string token)
        {
            var personId = _decodingJWT.getJWTTokenClaim(token, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid");
            if (personId != null)
            {
                if (files is not null)
                {
                    var person = await _personRepository.GetByIdAsync(Int32.Parse(personId));
                    if (person is not null)
                    {
                        var storage = await _storageRepository.GetByIdAsync(person.StorageId);
                        if (storage is not null)
                        {
                            foreach (var file in files)
                            {
                                if (file.ContentType == "image/jpeg" || file.ContentType == "image/png")
                                {
                                    var image = new Domain.Core.Entities.Image();
                                    image.Name = file.Name;
                                    using (var memory = new MemoryStream())
                                    {
                                        file.CopyTo(memory);
                                        image.Data = memory.ToArray();
                                    }
                                    image.Storage = storage;
                                    image.StorageId = storage.Id;
                                    await _imageRepository.CreateAsync(image);
                                }
                                else if(file.ContentType == "video/mp4")
                                {
                                    var stream = file.OpenReadStream();
                                    using var fileStream = File.Create($"D:\\studing\\C#\\TravelAPI\\TravelAPI\\{file.FileName}");
                                    stream.Seek(0, SeekOrigin.Begin);
                                    stream.CopyTo(fileStream);
                                    var personFile = new PersonFile
                                    {
                                        FileName = file.FileName,
                                        FilePath = $"D:\\studing\\C#\\TravelAPI\\TravelAPI\\{file.FileName}",
                                        FileType = file.ContentType,
                                        Storage = storage,
                                        StrorageId = storage.Id
                                    };
                                    await _personFIleRepository.CreateAsync(personFile);
                                }
                            }
                            return new OperationResult<bool>(true);
                        }
                    }
                }
                return OperationResult<bool>.Fail(OperationCode.AlreadyExists, $"Файлы не добавлены");
            }
            return OperationResult<bool>.Fail(OperationCode.EntityWasNotFound, $"Пользователя не существует.{personId}");
        }
    }
}
