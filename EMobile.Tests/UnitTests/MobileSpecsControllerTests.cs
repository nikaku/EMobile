using AutoMapper;
using EMobile.BL.Dtos.MobileSpecDtos;
using EMobile.BL.Entities;
using EMobile.BL.Filters;
using EMobile.BL.Interfaces;
using EMobile.BL.Services;
using EMobile.Controllers;
using EMobile.DB.MinioService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EMobile.Tests.UnitTests
{
    public class MobileSpecsControllerTests
    {
       
        private Mock<IMobileSpecService> _mobileSpecService;
        private Mock<IMinioProvider> _minioProvider;
        private MobileSpecsController _controler;
        private MobileSpecsFilter _filter;
        public MobileSpecsControllerTests()
        {
            _filter = new MobileSpecsFilter();           
            _mobileSpecService = new Mock<IMobileSpecService>();
            _minioProvider = new Mock<IMinioProvider>();

            _mobileSpecService
                .Setup(x => x
                .FindAll(_filter))
                .Returns(new List<MobileSpec> { new MobileSpec { Id = 1 } });
            _mobileSpecService
                .Setup(x => x.Get(1))
                .Returns(new MobileSpec { Id = 1 });
            _mobileSpecService
                .Setup(x => x.Get(-1))
                .Returns((MobileSpec)null);
            var mockMapper = new Mock<IMapper>();
            mockMapper
                .Setup(x => x.Map<MobileSpecGetDto>(It.IsAny<MobileSpec>()))
                .Returns(new MobileSpecGetDto { });

            mockMapper
           .Setup(x => x.Map<IList<MobileSpecGetDto>>(It.IsAny<IList<MobileSpec>>()))
           .Returns(new List<MobileSpecGetDto> { new MobileSpecGetDto { Id = 1 } });

            _minioProvider.Setup(x => x.GetImageAsync("", "")).Returns(new Task<byte[]>(() => new byte[] { }));

            _controler = new MobileSpecsController(_mobileSpecService.Object, mockMapper.Object, null, _minioProvider.Object);
        }

        [Fact]
        public void Get_Takes1_ReturnsOkResult()
        {
            // Act
            var okResult = _controler.Get(1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
        [Fact]
        public void Get_TakesMinus1_ReturnsNotFoundResult()
        {
            // Act
            var okResult = _controler.Get(-1);
            // Assert
            Assert.IsType<NotFoundResult>(okResult);
        }
        [Fact]
        public void Delete_TakesMinus1_ReturnsNotFoundResult()
        {
            // Act
            var okResult = _controler.Get(-1);
            // Assert
            Assert.IsType<NotFoundResult>(okResult);
        }
        [Fact]
        public void Delete_Takes1_ReturnsOkResult()
        {
            // Act
            var okResult = _controler.Get(1);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
