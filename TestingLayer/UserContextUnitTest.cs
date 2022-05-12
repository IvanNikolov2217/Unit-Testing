using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestingLayer
{
    public class UserContextUnitTest
    {
        private GamingDbContext dbContext;
        private UserContext userContext;
        DbContextOptionsBuilder builder;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {


        }

        [SetUp]
        public void Setup()
        {
            builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString());

            dbContext = new GamingDbContext(builder.Options);
            userContext = new UserContext(dbContext);
        }

        [Test]
        public void TestCreateGenre()
        {
            int usersBefore = userContext.ReadAll().Count();

            userContext.Create(new User("Ivan","Nikolov",17,"ivan221718","ne kazvam","ivan_nikolov2014@abv.bg"));

            int usersAfter = userContext.ReadAll().Count();

            Assert.IsTrue(usersBefore != usersAfter);
        }

        [Test]
        public void TestReadGenre()
        {
            userContext.Create(new User("Ivan", "Nikolov", 17, "ivan221718", "ne kazvam", "ivan_nikolov2014@abv.bg"));

            User user = userContext.Read(1);

            Assert.That(user != null, "There is no record with id 1!");
        }

        [Test]
        public void TestUpdateGenre()
        {
            userContext.Create(new User("Ivan", "Nikolov", 17, "ivan221718", "ne kazvam", "ivan_nikolov2014@abv.bg"));

            User user = userContext.Read(1);

            user.FirstName = "Petar";

            userContext.Update(user);

            User user1 = userContext.Read(1);

            Assert.IsTrue(user1.FirstName == "Petar", "User Update() does not change first name!");
        }

        [Test]
        public void TestDeleteGenre()
        {
            userContext.Create(new User("Empty user","",30,"","",""));

            int usersBeforeDeletion = userContext.ReadAll().Count();

            userContext.Delete(1);

            int usersAfterDeletion = userContext.ReadAll().Count();

            Assert.AreNotEqual(usersBeforeDeletion, usersAfterDeletion);
        }

    }
}