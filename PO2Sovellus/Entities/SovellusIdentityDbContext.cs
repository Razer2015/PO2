using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PO2Sovellus.Entities
{
    public class SovellusIdentityDbContext : IdentityDbContext<User>
    {
        public SovellusIdentityDbContext(DbContextOptions<SovellusIdentityDbContext> options)
            :base (options) {

        }
    }
}
