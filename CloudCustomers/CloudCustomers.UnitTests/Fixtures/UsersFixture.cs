using CloudCustomers.API.Models;
using System.Collections.Generic;

namespace CloudCustomers.UnitTests.Fixtures;

public static class UsersFixture
{
    public static List<User> GetTestUsers() =>

               new()
               {
                   new User 
                   {
                       Id = 1,
                       Name = "Teste1",
                       Address = new Address()
                       {
                           Street = "Arboredo",
                           City = "Suzano",
                           ZipCode = "123456"
                       },
                       Email = "angel@angel.com"
                   },
                   new User
                   {
                       Id = 1,
                       Name = "Teste2",
                       Address = new Address()
                       {
                           Street = "Arboredo",
                           City = "Suzano",
                           ZipCode = "123456"
                       },
                       Email = "angel@angel.com"
                   },
                   new User
                   {
                       Id = 1,
                       Name = "Teste3",
                       Address = new Address()
                       {
                           Street = "Arboredo",
                           City = "Suzano",
                           ZipCode = "123456"
                       },
                       Email = "angel@angel.com"
                   }

               };
}
