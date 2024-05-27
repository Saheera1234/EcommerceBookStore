﻿using ECommerceBookStore.Domain.Dto;
using MediatR;

namespace ECommerceBookStore.Application.Command._Order
{
    public class OrderCommand : IRequest<OrderDto>
    {
        public OrderCommand(Operation operation, OrderDto orderDto = null, Order2Dto order2Dto = null)
        {
            Operation = operation;
            OrderDto = orderDto;
            Order2Dto = order2Dto;
        }

        public Operation Operation { get; set; }
        public OrderDto OrderDto { get; set; }
        public Order2Dto Order2Dto { get; set; }

    }
}
