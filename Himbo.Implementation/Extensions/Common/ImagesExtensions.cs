using AutoMapper;
using Himbo.Application.UseCases.DTO.Entities;
using Himbo.DataAccess;
using Himbo.Domain.Common;
using Himbo.Domain.Common.Interfaces;
using Himbo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Himbo.Implementation.Extensions.Common
{
    public static class ImagesExtensions
    {

        public static void AddImage(this IImage entity, string fileName, IMapper mapper)
        {
            var addImage = !string.IsNullOrEmpty(fileName);
            if(addImage)
            {
                var imageDto = CreateImageDto(fileName);
                var image = mapper.Map<Image>(imageDto);
                entity.Image = image;
            }
        }

        public static void AddImages(this IImages entity, List<string> fileNames, IMapper mapper)
        {
            var addImages = fileNames != null && fileNames.Any();
            if(addImages)
            {
                entity.Images.Clear();
                var imagesList = new List<Image>();
                fileNames.ForEach(fileName =>
                {
                    var imageDto = CreateImageDto(fileName);
                    var mappedImage = mapper.Map<Image>(imageDto);
                    imagesList.Add(mappedImage);
                });
                entity.Images = imagesList;
            }

        }

        #region Create ImageDto
        private static ImageDto CreateImageDto(string fileName)
        {
            return new ImageDto { Path = fileName };
        }
        #endregion
    }
}
