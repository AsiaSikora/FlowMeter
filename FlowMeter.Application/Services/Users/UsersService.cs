using AutoMapper;
using FlowMeter.Application.DTOs.User;
using FlowMeter.Application.Exceptions;
using FlowMeter.Application.RepositoriesInterfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IReadOnlyCollection<UserDto>> GetUsers()
        {
            var usersWithDevices = await _uow.Users.GetAllUsersWithDevicesAndLocalizations();
            var usersDto = _mapper.Map<List<UserDto>>(usersWithDevices);

            return usersDto;
        }

        public async Task<UserDto> GetUser(int id)
        {
            var user = await _uow.Users.Get(x => x.Id == id);

            if (user is null)
                throw new NotFoundException("User not found");

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var user = await _uow.Users.Get(x => x.Id == id);

            if (user is null)
                throw new NotFoundException("User not found");

            _mapper.Map(updateUserDto, user);
            await _uow.Users.Modify(user);
            await _uow.Save();
        }

        public async Task DeleteUser(int id)
        {
            _logger.LogError($"User with id: {id} DELETE action invoked");

            var user = await _uow.Users.Get(x => x.Id == id);

            if (user is null)
                throw new NotFoundException("User not found");

            await _uow.Users.Remove(id);
            await _uow.Save();
        }
    }
}
