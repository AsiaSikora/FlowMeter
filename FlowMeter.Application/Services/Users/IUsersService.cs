using FlowMeter.Application.DTOs.User;
using System.Collections.Generic;

namespace FlowMeter.Application.Services.Users
{
    public interface IUsersService
    {
        void DeleteUser(int id);
        UserDto GetUser(int id);
        List<UserDto> GetUsers();
        void UpdateUser(int id, UpdateUserDto updateUserDto);
    }
}