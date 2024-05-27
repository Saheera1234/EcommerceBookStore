﻿using AutoMapper;
using ECommerceBookStore.Domain.Dto;
using ECommerceBookStore.Domain.Entity;
using ECommerceBookStore.Domain.Interface;
using MediatR;

namespace ECommerceBookStore.Application.Command._Book
{
    public class BookCommandHandler : IRequestHandler<BookCommand, BookDto>
    {
        private readonly IBaseRepository baseRepository;
        private readonly IMapper mapper;

        public BookCommandHandler(IBaseRepository baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<BookDto> Handle(BookCommand request, CancellationToken cancellationToken)
        {
            Book book;

            switch (request.Operation)
            {
                case Operation.Create:
                    book = new Book
                    {
                        Title = request.Book2Dto.Title,
                        AuthorId = request.Book2Dto.AuthorId,
                        Price = request.Book2Dto.Price,
                        Description = request.Book2Dto.Description
                    };
                    var createdBook = await baseRepository.CreateBookAsync(book);
                    return mapper.Map<BookDto>(createdBook);

                case Operation.Update:
                    var updateBook = new Book
                    {
                        Id = request.BookDto.Id,
                        Title = request.BookDto.Title,
                        AuthorId = request.BookDto.AuthorId,
                        Price = request.BookDto.Price,
                        Description = request.BookDto.Description
                    };

                    await baseRepository.UpdateBookAsync(request.BookDto.Id, updateBook);

                    return mapper.Map<BookDto>(updateBook);

                case Operation.Delete:

                    await baseRepository.DeleteBookAsync(request.BookDto.Id);
                    return null;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
