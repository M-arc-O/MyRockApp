using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyRockApp.Data;
using MyRockApp.Data.Models;
using MyRockApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyRockApp.DataTest
{
    [TestClass]
    public class GenericRepositoryTests
    {
        private readonly Guid dbId = Guid.NewGuid();
        private MyRockAppDBContext _DbContext;
        private GenericRepository<Artist> _Sut;

        private const int arrayLength = 10;

        [TestInitialize]
        public void InitializeTest()
        {
            CreateSut();
            LoadDataIntoDatabase();
        }

        [TestCleanup]
        public void CleanupTest()
        {
            _DbContext.Dispose();
        }

        [TestMethod]
        public void GetWithoutParametersTest()
        {
            CreateSut();

            var results = _Sut.Get().ToList();

            for (int i = 0; i < results.Count; i++)
            {
                Assert.AreEqual($"Name{i + 1}", results[i].Name);
            }
        }

        [TestMethod]
        public void GetWithSingleLevelIncludesTest()
        {
            CreateSut();

            var results = _Sut.Get(null, null, "Songs").ToList();

            for (int i = 0; i < results.Count; i++)
            {
                Assert.AreEqual(1, results[i].Songs.Count);
                Assert.AreEqual($"Name{i + 1}", results[i].Songs[0].Name);
            }
        }

        [TestMethod]
        public void GetWithSingleLevelIncludesAndOrderTest()
        {
            CreateSut();

            var results = _Sut.Get(null, x => x.OrderBy(e => e.Name), "Songs").ToList();
            var names = new List<string> { "Name1", "Name10", "Name2", "Name3", "Name4", "Name5", "Name6", "Name7", "Name8", "Name9" };

            for (int i = 0; i < results.Count; i++)
            {
                Assert.AreEqual(names[i], results[i].Name);
            }
        }

        [TestMethod]
        public void GetWithFilterTest()
        {
            var results = _Sut.Get(x => x.Name.Equals("Name1")).ToList();

            Assert.IsInstanceOfType(results, typeof(List<Artist>));
            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            for (int i = 1; i <= arrayLength; i++)
            {
                var result = _Sut.GetByID(i);

                Assert.IsInstanceOfType(result, typeof(Artist));
                Assert.AreEqual($"Name{i}", result.Name);
            }
        }

        [TestMethod]
        public async Task DeleteByIdDetachedTest()
        {
            var entity = _DbContext.Set<Artist>().Find(1);
            _DbContext.Entry(entity).State = EntityState.Detached;
            _DbContext.SaveChanges();

            _Sut.Delete(entity);
            _DbContext.SaveChanges();

            Assert.IsNull(_Sut.GetByID(1));
        }

        [TestMethod]
        public async Task DeleteByIdAttachedTest()
        {
            _Sut.Delete(2);
            _DbContext.SaveChanges();

            Assert.IsNull(_Sut.GetByID(2));
        }

        [TestMethod]
        public void UpdateTest()
        {
            var testName = "name";

            var artist = new Artist
            {
                ArtistId = 1,
                Name = testName
            };

            CreateSut();

            _Sut.Update(artist);
            _DbContext.SaveChanges();

            Assert.AreEqual(testName, _Sut.GetByID(1).Name);
        }

        private void CreateSut()
        {
            _DbContext = InMemoryContext(dbId.ToString());
            _Sut = new GenericRepository<Artist>(_DbContext);
        }

        private void LoadDataIntoDatabase()
        {
            for (int i = 1; i <= arrayLength; i++)
            {
                var artist = new Artist
                {
                    Name = $"Name{i}",
                    Songs = new List<Song>()
                };

                var song = new Song
                {
                    Name = $"Name{i}",
                    Album = $"Album{i}",
                    Bpm = i,
                    Duration = i,
                    Genre = $"Genre{i}",
                    Shortname = $"Shortname{i}",
                    SpotifyId = $"SpotifyId{i}",
                    Year = i,
                    Artist = artist
                };

                artist.Songs.Add(song);

                _Sut.Insert(artist);
            }

            _DbContext.SaveChanges();
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
