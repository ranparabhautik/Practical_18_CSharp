using Practical_18.Models.Entities;

namespace Practical_18.Repository.Interface
{
    public interface IStudentRepo:IGenericRepo<Student>
    {
        Task<Student> GetByNumber(string email);
    }
}
