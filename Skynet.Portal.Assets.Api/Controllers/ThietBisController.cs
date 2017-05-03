using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Skynet.Portal.Assets.Api.Models;
using Skynet.Portal.Assets.Data.Services;
using System;
using System.Collections.Generic;

namespace Skynet.Portal.Assets.Api.Controllers
{
    [Route("api/thietbis")]
    public class ThietBisController : Controller
    {
        private IThucLucRepository _thucLucRepository;

        public ThietBisController(IThucLucRepository thucLucRepository)
        {
            _thucLucRepository = thucLucRepository;
        }

        [HttpGet]
        public IActionResult GetThietBis()
        {
            var thietBisFromRepo = _thucLucRepository.GetThietBis();
           
            var thietbis = Mapper.Map<IEnumerable<ThietBiDto>>(thietBisFromRepo);
            return Ok(thietbis);
        }

        [HttpGet("{id}")]
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

    }
}
