using AutoMapper;
using FlowMeter.API.Helpers;
using FlowMeter.Application.DTOs.Device;
using FlowMeter.Application.DTOs.Localization;
using FlowMeter.Application.DTOs.Survey;
using FlowMeter.Application.DTOs.User;
using FlowMeter.Application.RepositoriesInterfaces;
using FlowMeter.Application.Services.Devices;
using FlowMeter.Application.Services.Surveys;
using FlowMeter.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlowMeter.Application.Services.Localizations;


namespace FlowMeter.API.Controllers
{

    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;
        private readonly IDevicesService _devicesService;
        private readonly ISurveysService _surveyService;
        private readonly ILocalizationsService _localizationService;

        public AuthController(IUnitOfWork uow, IMapper mapper, JwtService jwtService, IDevicesService devicesService,
            ISurveysService surveyService, ILocalizationsService localizationService)
        {
            _uow = uow;
            _mapper = mapper;
            _jwtService = jwtService;
            _devicesService = devicesService;
            _surveyService = surveyService;
            _localizationService = localizationService;
        }
        

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto dto)
        {
            var userDto = new UserDto()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Hash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            var user = _mapper.Map<User>(userDto);

            await _uow.Users.Add(user);
            await _uow.Save();

            return CreatedAtRoute("Get", new { id = userDto.Id }, userDto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _uow.Users.GetByEmail(dto.Email);

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
        public async Task<IActionResult> User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = await _uow.Users.GetById(userId);

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

        [HttpPost("user/create-survey")]
        public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyDto createSurvey)
        {
            var survey = await _surveyService.CreateSurvey(createSurvey);

            return Ok(survey);
        }

        [HttpPost("user/adddevice")]
        public async Task<IActionResult> AddDevice([FromBody] CreateDeviceDto createDevice)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var deviceDto = await _devicesService.CreateDevice(createDevice, userId);

            return CreatedAtRoute("Get", new { id = deviceDto.Id }, deviceDto);
        }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpGet("user/getdevices")]
        public async Task<IActionResult> GetDevices()

        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                var userId = int.Parse(token.Issuer);

                var devices = await _devicesService.GetDevices(userId);
                return Ok(devices);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }


        [HttpGet("user/getlocalizations")]
        public async Task<IActionResult> GetLocalizations()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                var userId = int.Parse(token.Issuer);

                var localizations = await _localizationService.GetLocalizations(userId);
                return Ok(localizations);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpPost("user/add-localization")]
        public async Task<IActionResult> CreateLocalization([FromBody] CreateLocalizationDto createLocalization)
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                var userId = int.Parse(token.Issuer);

                var localizationDto = await _localizationService.CreateLocalization(createLocalization, userId);
                return CreatedAtRoute("Get", new { id = localizationDto.Id }, localizationDto);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpGet("user/last-five-surveys")]
        public async Task<IActionResult> GetLastFiveSurveys()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                var userId = int.Parse(token.Issuer);

                var surveysDto = await _surveyService.GetLastFiveSurveys(userId);
                return Ok(surveysDto);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        //[HttpGet("user/survey/{id}")]
        //public IActionResult GetSurvey(int id)
        //{
        //    try
        //    {
        //        var jwt = Request.Cookies["jwt"];

        //        var token = _jwtService.Verify(jwt);

        //        var userId = int.Parse(token.Issuer);

        //        var survey = _uow.Surveys.GetSurveyWithIncludes(id);
        //        var surveyDto = _mapper.Map<SurveyDto>(survey);

        //        return Ok(surveyDto);
        //    }
        //    catch (Exception e)
        //    {
        //        return Unauthorized();
        //    }
        //}

        [HttpGet("user/surveys-no-measurements")]
        public async Task<IActionResult> GetAllSurveysWithoutMeasurements()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                var userId = int.Parse(token.Issuer);

                var surveysDto = await _surveyService.GetAllSurveysWithoutMeasurements(userId);

                return Ok(surveysDto);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

    }
}
