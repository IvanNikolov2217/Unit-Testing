using BusinessLayer;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace TestingLayer
{
    public class GameContextUnitTest
    {
        private GamingDbContext dbContext;
        private GameContext gameContext;
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
            gameContext = new GameContext(dbContext);
        }

        [Test]
        public void TestCreateGame()
        {
            int gamesBefore = gameContext.ReadAll().Count();

            gameContext.Create(new Game("God of war"));

            int gamesAfter = gameContext.ReadAll().Count();

            Assert.IsTrue(gamesBefore != gamesAfter);
        }

        [Test]
        public void TestReadGame()
        {
            gameContext.Create(new Game("God of war"));

            Game game = gameContext.Read(1);

            Assert.That(game != null, "There is no record with id 1!");
        }

        [Test]
        public void TestUpdateGame()
        {
            gameContext.Create(new Game("God of war"));

            Game game = gameContext.Read(1);

            game.Name = "God of war 2";

            gameContext.Update(game);

            Game game1 = gameContext.Read(1);

            Assert.IsTrue(game1.Name == "God of war 2", "Game Update() does not change name!");
        }

        [Test]
        public void TestDeleteGame()
        {
            gameContext.Create(new Game("Delete game"));

            int gamesBeforeDeletion = gameContext.ReadAll().Count();

            gameContext.Delete(1);

            int gamesAfterDeletion = gameContext.ReadAll().Count();

            Assert.AreNotEqual(gamesBeforeDeletion, gamesAfterDeletion);
        }

    }
}