using AutoMapper;
using FlowMeter.API.Models.User;
using FlowMeter.DataManipulation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowMeter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _uow.Users.GetAll();
            var usersDto = _mapper.Map<List<UserDto>>(users);

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _uow.Users.Get(x => x.Id == id);
            var userDto = _mapper.Map<UserDto>(user);

            return Ok(userDto);
        }
    }
}
