﻿

namespace Domain.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 250;
        private Book(Guid id, string title, string description, double price)
        {
            Id = id; Title = title; Description = description; Price = price;
        }
        public Guid Id { get; }
        public string Title { get; } 
        public string Description { get; } 
        public double Price { get; }

        public static (Book Book, string Error) Create(Guid id, string title, string description, double price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = "Titile cant be empty or longer then 250 symbols";
            }

            var book = new Book(id, title, description, price);

            return (book, error);
        }
    }
}
