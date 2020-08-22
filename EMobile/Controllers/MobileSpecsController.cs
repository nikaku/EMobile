using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EMobile.BL;
using EMobile.BL.Dtos.MobileSpecDtos;
using EMobile.BL.Entities;
using EMobile.BL.Filters;
using EMobile.BL.Interfaces;
using EMobile.DB.MinioService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMobile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileSpecsController : ControllerBase
    {
        private readonly IMobileSpecService _mobileSpecService;
        private readonly IMapper _mapper;
        private readonly IMobileSpecValidation _validation;
        private readonly IMinioProvider _minioProvider;

        public MobileSpecsController(IMobileSpecService mobileSpecService, IMapper mapper, IMobileSpecValidation validation, IMinioProvider minioProvider)
        {
            _mobileSpecService = mobileSpecService;
            _mapper = mapper;
            _validation = validation;
            _minioProvider = minioProvider;
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var mobileSpec = _mobileSpecService.Get(id);        
            if (mobileSpec == null)
            {
                return NotFound();
            }
            var mobileSpecDto = _mapper.Map<MobileSpecGetDto>(mobileSpec);
            return Ok(mobileSpecDto);
        }
        [HttpGet]
        [HttpHead]
        public IActionResult GetAll([FromQuery]MobileSpecsFilter filter)
        {
            var mobileSpec = _mobileSpecService.FindAll(filter).ToList();
            var mobileSpecDto = _mapper.Map<IList<MobileSpecGetDto>>(mobileSpec);
            return Ok(mobileSpecDto);
        }

        [HttpPost]
        public IActionResult Create(MobileSpecCreateDto mobileSpecDto)
        {
            var validationResult = _validation.ValidateCreateModel(mobileSpecDto);
            var hash = Helper.ReturnUniqueValue(DateTime.Now, "");
            if (!validationResult.IsValid)
            {
                return UnprocessableEntity(validationResult.ErrorMessage);
            }
            var mobileSpec = _mapper.Map<MobileSpec>(mobileSpecDto);
            var imageUrl = Url.ActionLink("GetImage", "Helper", new { imagename = $"{hash}.png" });
            mobileSpec.ImageUrl = imageUrl;
            var res = _mobileSpecService.Add(mobileSpec);
            var bytes = Convert.FromBase64String(mobileSpecDto.Base64Image);
            MemoryStream fileStream = new MemoryStream(bytes);
            _minioProvider.UploadImage(hash, fileStream, "uploads", "png");
            return CreatedAtAction(nameof(Get), new { id = res.Id }, res.Id);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _mobileSpecService.Delete(id);
            return Accepted();
        }

    }
}