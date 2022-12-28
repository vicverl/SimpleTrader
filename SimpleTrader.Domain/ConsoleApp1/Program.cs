// See https://aka.ms/new-console-template for more information

using SimpleTrader.Domain.Models;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;

var userService = new GenericDataService<User>(new SimpleTraderDbContextFactory());
userService.Create(new User {Username = "Victor", Email = "asda@.com", Password = "asdasd"}).Wait();
