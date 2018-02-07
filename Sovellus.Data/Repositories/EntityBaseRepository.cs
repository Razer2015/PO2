using System;
using System.Collections.Generic;
using System.Text;

namespace Sovellus.Data.Repositories
{
    public abstract class EntityBaseRepository
    {
        protected SovellusContext _context;
        public EntityBaseRepository(SovellusContext sovellusContext) {
            _context = sovellusContext;
        }
    }
}
