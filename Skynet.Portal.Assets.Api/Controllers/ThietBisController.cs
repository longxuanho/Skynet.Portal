﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skynet.Portal.Assets.Api.Helpers;
using Skynet.Portal.Assets.Api.Models;
using Skynet.Portal.Assets.Data.Entities;
using Skynet.Portal.Assets.Api.Services;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Skynet.Portal.Assets.Api.Controllers
{
    [Route("api/thietbis")]
    public class ThietBisController : Controller
    {
        private IThucLucRepository _thucLucRepository;
        private ILogger<ThietBisController> _logger;
        private IUrlHelper _urlHelper;

        public ThietBisController(IThucLucRepository thucLucRepository, ILogger<ThietBisController> logger, IUrlHelper urlHelper)
        {
            _thucLucRepository = thucLucRepository;
            _logger = logger;
            _urlHelper = urlHelper;
        }

        [HttpGet(Name = "GetThietBis")]
        public IActionResult GetThietBis(ThietBisResourceParameters thietBisResourceParameters)
        {
            var thietBisFromRepo = _thucLucRepository.GetThietBis(thietBisResourceParameters);

            var previousPageLink = thietBisFromRepo.HasPrevious
                ? CreateThietBisResourceUri(thietBisResourceParameters, ResourceUriType.PreviousPage)
                : null;

            var nextPageLink = thietBisFromRepo.HasNext
                ? CreateThietBisResourceUri(thietBisResourceParameters, ResourceUriType.NextPage)
                : null;

            var paginationMetadata = new
            {
                totalCount = thietBisFromRepo.TotalCount,
                pageSize = thietBisFromRepo.PageSize,
                currentPage = thietBisFromRepo.CurrentPage,
                totalPages = thietBisFromRepo.TotalPages,
                previousPageLink = previousPageLink,
                nextPageLink = nextPageLink
            };

            Response.Headers.Add("x_Pagination", JsonConvert.SerializeObject(paginationMetadata));

            var thietbis = Mapper.Map<IEnumerable<ThietBiDto>>(thietBisFromRepo);
            return Ok(thietbis);
        }

        private string CreateThietBisResourceUri(ThietBisResourceParameters thietBisResourceParameters, ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _urlHelper.Link("GetThietBis",
                        new
                        {
                            pageNumber = thietBisResourceParameters.PageNumber - 1,
                            pageSize = thietBisResourceParameters.PageSize
                        });
                case ResourceUriType.NextPage:
                    return _urlHelper.Link("GetThietBis",
                        new
                        {
                            pageNumber = thietBisResourceParameters.PageNumber + 1,
                            pageSize = thietBisResourceParameters.PageSize
                        });
                default:
                    return _urlHelper.Link("GetThietBis",
                        new
                        {
                            pageNumber = thietBisResourceParameters.PageNumber,
                            pageSize = thietBisResourceParameters.PageSize
                        });
            }
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
