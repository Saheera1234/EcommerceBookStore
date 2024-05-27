﻿using ECommerceBookStore.Domain.Dto;
using MediatR;

namespace ECommerceBookStore.Application.Command._User
{
    public class UserCommand : IRequest<UserDto>
    {
        public UserCommand(Operation operation, UserDto userDto = null, User2Dto user2Dto = null)
        {
            Operation = operation;
            UserDto = userDto;
            User2Dto = user2Dto;
        }

        public Operation Operation { get; set; }
        public UserDto UserDto { get; set; }
        public User2Dto User2Dto { get; set; }
    }
}
