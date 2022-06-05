using System.Collections.Generic;
using System.Linq;
using TargetProject.Data;
using TargetProject.Interfaces.IRepository;
using TargetProject.Models;

namespace TargetProject.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(TargetContext context) :base(context)
        {
            _context = context;
        }
    }
}
