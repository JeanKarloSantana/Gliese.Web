using Gliese.DAL.SQL;
using Gliese.Entities;
using Gliese.Entities.DTO;
using Gliese.Interfaces.Generic;
using Gliese.Interfaces.Repository;
using Gliese.Persistance.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gliese.Persistance.Repository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public DeimosDbContext _context { get { return context; } }

        public PersonRepository(DeimosDbContext dbContext) : base(dbContext)
        {

        }

        public Person CreatePersonByRegisterDto(RegisterDTO dto) 
        {
            var person = new Person();

            person.FirstName = dto.FirstName;
            person.LastName = dto.LastName;
            person.DateCreated = DateTime.UtcNow;

            Add(person);

            return person;
        }
    }
}
