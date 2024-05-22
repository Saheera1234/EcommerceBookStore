﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBookStore.Domain.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int LoginId { get; set; }

        [ForeignKey("LoginId")]

        public User? User { get; set; }

        public DateTime Date { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book? Book { get; set; }

        public string? Quantity { get; set; }
        public long TotalPrice { get; set; }

    }
}
