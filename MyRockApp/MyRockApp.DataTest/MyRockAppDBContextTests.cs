using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRockApp.Data;
using MyRockApp.Data.Models;

namespace MyRockApp.DataTest
{

    [TestClass]
    public class MyRockAppDBContextTests
    {
        private MyRockAppDBContext _Sut;

        [TestInitialize]
        public void InitializeTest()
        {
            _Sut = new MyRockAppDBContext(new DbContextOptions<MyRockAppDBContext>());
        }

        [TestMethod]
        public void DbContextPropertiesTypesTest()
        {
            Assert.IsInstanceOfType(_Sut.Artists, typeof(DbSet<Artist>));
            Assert.IsInstanceOfType(_Sut.Songs, typeof(DbSet<Song>));
        }
    }
}
