using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Models.Dogs;
using WebApi.Services;

using System.ComponentModel.DataAnnotations;


namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogsController : BaseController
    {
        private readonly IDogService _dogService;
        private readonly IMapper _mapper;

        public DogsController(
            IDogService dogService,
            IMapper mapper)
        {
            _dogService = dogService;
            _mapper = mapper;
        }
/*
        [HttpPost]
        public IActionResult AddDog([FromForm] DogRequest model)
        {
            return Ok();
        }
*/
        [Authorize(Role.Admin)]
        [HttpGet]
        public ActionResult<IEnumerable<DogResponse>> GetAll()
        {
            var dogs = _dogService.GetAll();
            return Ok(dogs);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public ActionResult<DogResponse> GetById(int id)
        {
            // users can get their own account and admins can get any account
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var account = _dogService.GetById(id);
            return Ok(account);
        }

        [Authorize(Role.Admin)]
        [HttpPost]
        public ActionResult<DogResponse> Create([FromForm]CreateRequest model)
        {
            var dog = _dogService.Create(model);
            return Ok(dog);
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public ActionResult<DogResponse> Update(int id, [FromForm] UpdateRequest model)
        {
            // users can update their own account and admins can update any account
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            // only admins can update role
            ////if (Account.Role != Role.Admin)
                /////model.Role = null;

            var dog = _dogService.Update(id, model);
            return Ok(dog);
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            // users can delete their own account and admins can delete any account
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            _dogService.Delete(id);
            return Ok(new { message = "Account deleted successfully" });
        }

        // helper methods

    }
}