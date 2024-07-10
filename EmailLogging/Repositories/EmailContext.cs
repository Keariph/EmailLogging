using EmailLogging.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailLogging.Repositories
{
    /// <summary>
    /// Connects with database
    /// </summary>
    public class EmailContext : DbContext
    {
        /// <summary>
        /// Create a new connect to the database
        /// </summary>
        /// <param name="options">The options for the connection to the database</param>
        public EmailContext(DbContextOptions<EmailContext> options) : base(options)
        {
        }

        public DbSet<Email> Emails => Set<Email>();
    }
}
