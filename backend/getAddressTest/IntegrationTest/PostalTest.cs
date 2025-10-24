using api.DBContext;
using api.Repositories;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

namespace getAddressTest.IntegrationTest
{
    [TestFixture]
    [Category("IntegrationTest")]
    public class PostalTest
    {
        private DataContext _context;
        private IPersonsRepository _personsRepository;

        [SetUp]
        public void Setup()
        {
            Env.TraversePath().Load();
            var connectionString = Environment.GetEnvironmentVariable(
                "ConnectionStrings__Default"
            )!;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    "Connection string is not set in environment variables."
                );
            }

            // Configure DbContext to use PostgresSQL
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseNpgsql(connectionString)
                .Options;

            // Create a new instance of the DataContext
            _context = new DataContext(options);
            // Ensure a clean database state before each test
            _context.Database.EnsureDeleted();
            // Apply migrations to the database
            _context.Database.Migrate();

            //Initialize the repository with the test context
            _personsRepository = new PersonsRepository(_context);
        }

        [Test]
        public async Task GetPostal_ReturnsSeededPostal()
        {
            var result = await _personsRepository.GetPostal();
            Assert.That(result.PostalCode, Does.Match(@"^\d{4}$")); // Postal code should be 4 digits
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
