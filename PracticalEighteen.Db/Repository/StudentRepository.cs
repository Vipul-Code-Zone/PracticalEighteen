using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracticalEighteen.Db.DatabaseContext;
using PracticalEighteen.Db.Interfaces;
using PracticalEighteen.Models.Models;
using PracticalEighteen.Models.ViewModels;

namespace PracticalEighteen.Db.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _studentDbContext;
        private readonly IMapper _mapper;

        public StudentRepository(StudentDbContext studentDbContext, IMapper mapper)
        {
            _studentDbContext = studentDbContext;
            _mapper = mapper;
        }
        public async Task<int> AddStudentAsync(StudentModel student)
        {
            var result = _mapper.Map<Student>(student);
            await _studentDbContext.Students.AddAsync(result);
            await _studentDbContext.SaveChangesAsync();
            int id = await _studentDbContext.Students.MaxAsync(id => id.Id);
            return id;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var result = await _studentDbContext.Students.Where(stud => stud.Id == id).FirstOrDefaultAsync();
            if (result != null)
            {
                _studentDbContext.Students.Remove(result);
                await _studentDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<StudentModel> GetStudentAsync(int id)
        {
            var result = await _studentDbContext.Students.FirstOrDefaultAsync(stud => stud.Id == id);
            StudentModel student = _mapper.Map<StudentModel>(result);
            return student;
        }

        public async Task<List<StudentModel>> GetStudentsAsync()
        {
            var result = await _studentDbContext.Students.ToListAsync();
            var students = _mapper.Map<IEnumerable<StudentModel>>(result);
            return (List<StudentModel>)students;
        }

        public async Task<bool> UpdateStudentAsync(int id, StudentModel studentModel)
        {
            var student = _mapper.Map<Student>(studentModel);
            var result = await _studentDbContext.Students.FirstOrDefaultAsync(stud => stud.Id == id);
            if (result != null)
            {
                result.Name = student.Name;
                result.Email = student.Email;
                result.DOB = student.DOB;
                result.Age = student.Age;
                result.Address = student.Address;
                await _studentDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
