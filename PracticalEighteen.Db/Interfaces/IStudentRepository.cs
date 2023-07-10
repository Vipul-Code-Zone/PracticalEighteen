using PracticalEighteen.Models.ViewModels;

namespace PracticalEighteen.Db.Interfaces
{
    public interface IStudentRepository
    {
        /// <summary>
        /// It returns all the Students records
        /// </summary>
        /// <returns></returns>
        Task<List<StudentModel>> GetStudentsAsync();
        /// <summary>
        /// It return student based on user input
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<StudentModel> GetStudentAsync(int id);
        /// <summary>
        /// It Add Student into database based on user input
        /// </summary>
        /// <param name="student"></param>
        /// <returns>id which student has added</returns>
        Task<int> AddStudentAsync(StudentModel student);
        /// <summary>
        /// Its update the exist row based on user input
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentModel"></param>
        /// <returns>true id=f update else false</returns>
        Task<bool> UpdateStudentAsync(int id, StudentModel studentModel);
        /// <summary>
        /// It Delete the record based on user input 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true if record deleted else false</returns>
        Task<bool> DeleteStudentAsync(int id);
    }
}
