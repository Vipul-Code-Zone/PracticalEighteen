using Microsoft.AspNetCore.Mvc;
using PracticalEighteen.Db.Interfaces;
using PracticalEighteen.Models.ViewModels;

namespace PracticalEighteen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        // GET: StudentController
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            IEnumerable<StudentModel> student = await _studentRepository.GetStudentsAsync();
            return Ok(student);
        }

        // GET: StudentController/Details/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            StudentModel student = await _studentRepository.GetStudentAsync(id);
            return Ok(student);
        }

        // POST: StudentController/Create
        [HttpPost]
        public async Task<IActionResult> CreateAync(StudentModel studentModel)
        {
            if (studentModel == null) return BadRequest(ModelState);
            if (ModelState.IsValid)
            {
                int studentId = await _studentRepository.AddStudentAsync(studentModel);
                return CreatedAtAction("Details", new { id = studentId }, studentModel);
            }
            return BadRequest(ModelState);
        }

        // GET: StudentController/Edit/id
        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync(int id, StudentModel studentModel)
        {
            if (studentModel == null) return BadRequest(ModelState);
            bool isUpdated = await _studentRepository.UpdateStudentAsync(id, studentModel);

            if (!isUpdated) return NotFound();
            return Ok(studentModel);
        }


        // GET: StudentController/Delete/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == 0) return BadRequest();
            bool isDeleted = await _studentRepository.DeleteStudentAsync(id);
            if (!isDeleted) return NotFound();
            return Ok();
        }
    }
}
