using AutoMapper;
using FlowMeter.Application.DTOs.User;
using FlowMeter.Application.Exceptions;
using FlowMeter.Application.RepositoriesInterfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace FlowMeter.Application.Services.Users
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersService> _logger;

        public UsersService(IUnitOfWork uow, IMapper mapper, ILogger<UsersService> logger)
        {
            _uow = uow;
            _mapper = mapper;
            _logger = logger;
        }

        public List<UserDto> GetUsers()
        {
            var usersWithDevices = _uow.Users.GetAllUsersWithDevicesAndLocalizations();
            var usersDto = _mapper.Map<List<UserDto>>(usersWithDevices);

            return usersDto;
        }

        public UserDto GetUser(int id)
        {
            var user = _uow.Users.Get(x => x.Id == id);

            if (user is null)
                throw new NotFoundException("User not found");

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public void UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var user = _uow.Users.Get(x => x.Id == id);

            if (user is null)
                throw new NotFoundException("User not found");

            _mapper.Map(updateUserDto, user);
            _uow.Users.Modify(user);
            _uow.Save();
        }

        public void DeleteUser(int id)
        {
            _logger.LogError($"User with id: {id} DELETE action invoked");

            var user = _uow.Users.Get(x => x.Id == id);

            if (user is null)
                throw new NotFoundException("User not found");

            _uow.Users.Remove(id);
            _uow.Save();
        }
    }
}
