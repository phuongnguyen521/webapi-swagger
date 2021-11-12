using System;
using System.Collections.Generic;
using System.Linq;
using MySQLReverseEngineering.Objects;

namespace MySQLReverseEngineering
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-scaffold-example.html
            using var context = new se1510Context();
            context.SaveChanges();
            IEnumerable<Student> list = context.Students.ToList();
            if (list is not null)
            {
                foreach (var temp in list)
                {
                    Console.WriteLine($"{temp.IdStudent} - {temp.StudentName} - {temp.Major}");
                }
            } else
            {
                Console.WriteLine("List is null");
            }
        }
    }
}
