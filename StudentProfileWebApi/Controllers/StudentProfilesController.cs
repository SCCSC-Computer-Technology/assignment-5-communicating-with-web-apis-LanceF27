using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentProfileWebApi.Models;

namespace StudentProfileWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentProfilesController : ControllerBase
    {
        private readonly StudentProfileContext _context;
        public List<StudentProfile> apiCache = new List<StudentProfile>
        {
            new StudentProfile{Id = 112, Name = "Charles", GPA = 4.0, StudentEmail = "test@Gmail.com", hashedPassword = "xxxxxxxxxxxxxxxxxxxxxxxxxx", isVerified = false, Major = "Computer Science", password = "password", PhoneNumber = "555-555-5555", StudentUserName = "cthompson29"},
            new StudentProfile{Id = 115, Name = "Mike", GPA = 2.0, StudentEmail = "test@Gmail.com", hashedPassword = "xxxxxxxxxxxxxxxxxxxxxxxxxx", isVerified = false, Major = "Programming", password = "password", PhoneNumber = "555-555-6666", StudentUserName = "user1"},
            new StudentProfile{Id = 116, Name = "John Elway", GPA = 3.0, StudentEmail = "test@Gmail.com", hashedPassword = "xxxxxxxxxxxxxxxxxxxxxxxxxx", isVerified = false, Major = "Networking", password = "password", PhoneNumber = "555-555-7777", StudentUserName = "user2"},
            new StudentProfile{Id = 117, Name = "Dennis Rodman", GPA = 2.9, StudentEmail = "test@Gmail.com", hashedPassword = "xxxxxxxxxxxxxxxxxxxxxxxxxx", isVerified = false, Major = "IT", password = "password", PhoneNumber = "555-555-8888", StudentUserName = "user3"},
            new StudentProfile{Id = 118, Name = "Billie Holiday", GPA = 3.3, StudentEmail = "test@Gmail.com", hashedPassword = "xxxxxxxxxxxxxxxxxxxxxxxxxx", isVerified = false, Major = "IT Tech", password = "password", PhoneNumber = "555-555-9999", StudentUserName = "user4"},
            new StudentProfile{Id = 119, Name = "JimboLambert", GPA = 4.1, StudentEmail = "test@Gmail.com", hashedPassword = "xxxxxxxxxxxxxxxxxxxxxxxxxx", isVerified = false, Major = "Comp Sci", password = "password", PhoneNumber = "555-555-2222", StudentUserName = "user5"}

        };


        public StudentProfilesController(StudentProfileContext context)
        {
            _context = context;

        }

        // GET: api/StudentProfiles
        [HttpGet]
        public ActionResult<IEnumerable<StudentProfile>> GetStudentProfiles()
        {
            return apiCache;

        }

        // GET: api/StudentProfiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentProfile>> GetStudentProfile(long id)
        {
            var studentProfile = apiCache.ToList<StudentProfile>().Find(x => x.Id == id);

            if (studentProfile == null)
            {
                return NotFound();
            }

            return studentProfile;
        }

        // PUT: api/StudentProfiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentProfile(long id, StudentProfile studentProfile)
        {
            if (id != studentProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentProfiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentProfile>> PostStudentProfile(StudentProfile studentProfile)
        {
            byte[] salt;
            var shahash = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            apiCache.Append(studentProfile);
            _context.StudentProfiles.Add(studentProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentProfile", new { id = studentProfile.Id }, studentProfile);
        }

        // DELETE: api/StudentProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentProfile(long id)
        {
            var studentProfile = await _context.StudentProfiles.FindAsync(id);
            if (studentProfile == null)
            {
                return NotFound();
            }
            apiCache.RemoveAll(x => x.Id == studentProfile.Id);
            _context.StudentProfiles.Remove(studentProfile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentProfileExists(long id)
        {
            return _context.StudentProfiles.Any(e => e.Id == id);
        }
    }
}
