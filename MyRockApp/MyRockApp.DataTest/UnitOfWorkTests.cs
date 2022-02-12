using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRockApp.Data;
using MyRockApp.Data.Models;
using MyRockApp.Data.Repositories;
using System;

namespace MyRockApp.DataTest
{
    [TestClass]
    public class UnitOfWorkTests
    {
        private readonly Guid dbId = Guid.NewGuid();
        private MyRockAppDBContext _DbContext;
        private UnitOfWork _Sut;

        [TestInitialize]
        public void InitializeTest()
        {
            _DbContext = InMemoryContext(dbId.ToString());
            _Sut = new UnitOfWork(_DbContext);
        }

        [TestMethod]
        public void UnitOfWorkPropertiesTypesTest()
        {
            Assert.IsInstanceOfType(_Sut.ArtistRepository, typeof(GenericRepository<Artist>));
            Assert.IsInstanceOfType(_Sut.SongRepository, typeof(GenericRepository<Song>));
        }

        [TestCleanup]
        public void Cleanup()
        {
            _Sut.Dispose();
        }

        private static MyRockAppDBContext InMemoryContext(string connection)
        {
            var options = new DbContextOptionsBuilder<MyRockAppDBContext>()
                .UseInMemoryDatabase(connection)
                .EnableSensitiveDataLogging()
                .Options;
            var context = new MyRockAppDBContext(options);

            return context;
        }
    }
}
