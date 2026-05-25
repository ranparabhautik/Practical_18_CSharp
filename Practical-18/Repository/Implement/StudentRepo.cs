using Microsoft.EntityFrameworkCore;
using Practical_18.Models.Data;
using Practical_18.Models.Entities;
using Practical_18.Repository.Interface;

namespace Practical_18.Repository.Implement
{
    public class StudentRepo : GenericRepo<Student>, IStudentRepo
    {
        public StudentRepo(AppDbContext context) : base(context)
        {
        }

        public async Task<Student> GetByNumber(string number)
        {
            var existing = await _dbSet.FirstOrDefaultAsync(x=> x.Mobile == number);
            if (existing != null)
            {
                return existing; 
            }
            throw new Exception("Number Not found");
        }
    }
}
