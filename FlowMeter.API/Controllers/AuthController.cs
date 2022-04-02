using System.Collections.Generic;
using AutoMapper;
using BCrypt.Net;
using FlowMeter.API.Models.Device;
using FlowMeter.API.Models.User;
using FlowMeter.DataManipulation;
using Microsoft.AspNetCore.Mvc;
using FlowMeter.Domain;
using FlowMeter.API.Helpers;
using Microsoft.AspNetCore.Http;
using System;

namespace FlowMeter.API.Controllers
{

    [Route("api")]
    [ApiController]
    public class AuthController: Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;

        public AuthController(IUnitOfWork uow, IMapper mapper, JwtService jwtService)
        {
            _uow = uow;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] CreateUserDto dto)
        {
            var userDto = new UserDto()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Hash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            var user = _mapper.Map<User>(userDto);

            _uow.Users.Add(user);
            _uow.Save();

            return CreatedAtRoute("Get", new { id = userDto.Id }, userDto);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _uow.Users.GetByEmail(dto.Email);

            if (user == null) return BadRequest(new { message = "Invalid Credentials" });

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Hash))
            {
                return BadRequest(new { message = "Invalid Credentials" });
            }

            var jwt = _jwtService.Generate(user.Id);

            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });


            return Ok(new
            {
                message = "success"
            });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _uow.Users.GetById(userId);

                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new 
            { 
                message = "success" 
            });
        }

        [HttpGet("user/surveys")]
        public IActionResult UserSurveys()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var surveys = _uow.Surveys.GetLastFiveSurveys(userId);

                return Ok(surveys);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpPost("user/adddevice")]
        public IActionResult AddDevice([FromBody] CreateDeviceDto createDevice, int userId)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int id = int.Parse(token.Issuer);

                var deviceDto = new DeviceDto()
                {
                    DeviceNumber = createDevice.DeviceNumber,
                    UserId = id
                };

                var device = _mapper.Map<Device>(deviceDto);

                _uow.Devices.Add(device);
                _uow.Save();

                return CreatedAtRoute("Get", new { id = deviceDto.Id }, deviceDto);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpGet("user/getdevices")]
        public IActionResult GetDevices(int userId)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                userId = int.Parse(token.Issuer);

                var devices = _uow.Devices.GetAllDevicesWithIncludes(userId);
                var devicesDto = _mapper.Map<List<DeviceDto>>(devices);
                return Ok(devicesDto);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

    }
}
