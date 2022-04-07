using FlowMeter.Application.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlowMeter.Application.Services.Users
{
    public interface IUsersService
    {
        Task DeleteUser(int id);
        Task<UserDto> GetUser(int id);
        Task<IReadOnlyCollection<UserDto>> GetUsers();
        Task UpdateUser(int id, UpdateUserDto updateUserDto);
    }
}