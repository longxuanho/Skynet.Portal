using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skynet.Portal.Assets.Api.Helpers;
using Skynet.Portal.Assets.Api.Models;
using Skynet.Portal.Assets.Data.Entities;
using Skynet.Portal.Assets.Data.Services;
using System;
using System.Collections.Generic;

namespace Skynet.Portal.Assets.Api.Controllers
{
    [Route("api/thietbis")]
    public class ThietBisController : Controller
    {
        private IThucLucRepository _thucLucRepository;
        private ILogger<ThietBisController> _logger;

        public ThietBisController(IThucLucRepository thucLucRepository, ILogger<ThietBisController> logger)
        {
            _thucLucRepository = thucLucRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetThietBis()
        {
            var thietBisFromRepo = _thucLucRepository.GetThietBis();
           
            var thietbis = Mapper.Map<IEnumerable<ThietBiDto>>(thietBisFromRepo);
            return Ok(thietbis);
        }

        [HttpGet("{id}", Name = "GetThietBi")]
        public IActionResult GetThietBi(Guid id)
        {
            var thietBiFromRepo = _thucLucRepository.GetThietBi(id);
            if (thietBiFromRepo == null)
            {
                return NotFound();
            }

            var thietbi = Mapper.Map<ThietBiDto>(thietBiFromRepo);
            return Ok(thietbi);
        }

        [HttpPost]
        public IActionResult CreateThietBi([FromBody] ThietBiForCreationDto thietbi)
        {
            if (thietbi == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var thietBiEntity = Mapper.Map<ThietBi>(thietbi);

            _thucLucRepository.AddThietBi(thietBiEntity);

            if (!_thucLucRepository.Save())
            {
                throw new Exception("Có lỗi khi thêm thiết bị mới.");
            }

            _logger.LogInformation(100, $"Thiết bị mã với Guid {thietBiEntity.Id} ({thietBiEntity.MaThietBi}) đã được thêm vào hệ thống.");

            var thietBiToReturn = Mapper.Map<ThietBiDto>(thietBiEntity);

            return CreatedAtRoute("GetThietBi", new { id = thietBiToReturn.Id }, thietBiToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteThietBi(Guid id)
        {
            var thietBiFromRepo = _thucLucRepository.GetThietBi(id);
            if (thietBiFromRepo == null)
            {
                return NotFound();
            }

            _thucLucRepository.DeleteThietBi(thietBiFromRepo);

            if (!_thucLucRepository.Save())
            {
                throw new Exception($"Có lỗi xảy ra khi xóa bỏ thiết bị với mã Guid {id}.");
            }

            _logger.LogInformation(100, $"Thiết bị mã với Guid {id} ({thietBiFromRepo.MaThietBi}) đã được gỡ bỏ khỏi hệ thống.");

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateThietBi(Guid id, [FromBody] ThietBiForUpdateDto thietbi)
        {
            if (thietbi == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var thietBiFromRepo = _thucLucRepository.GetThietBi(id);
            if (thietBiFromRepo == null)
            {
                return NotFound();
            }

            Mapper.Map(thietbi, thietBiFromRepo);

            _thucLucRepository.UpdateThietBi(thietBiFromRepo);

            if (!_thucLucRepository.Save())
            {
                throw new Exception($"Có lỗi xảy ra khi cập nhật thiết bị với mã Gui {id}.");
            }

            _logger.LogInformation(100, $"Thiết bị mã với Guid {thietBiFromRepo.Id} ({thietBiFromRepo.MaThietBi}) đã được cập nhật nội dung.");

            return NoContent();
        }

    }
}
