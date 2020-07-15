using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AccessData;
using Dapper;
using Npgsql;

namespace Bookish
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=ADennis400!;Database=bookish"))
            {
                connection.Open();
                var bookList = connection.Query<Book>("SELECT * FROM book;").ToList();
                var userList = connection.Query<Person>("SELECT * FROM person;").ToList();
                var copyList = connection.Query<Copy>("SELECT * FROM copy;").ToList();

                foreach (var book in bookList)
                {
                    Console.WriteLine(book.Title);
                }
            }
 
        }
    }
}