using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practical_18.Models.DTOs;
using Practical_18.Models.Entities;
using Practical_18.Repository.Interface;

namespace Practical_18.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly IStudentRepo _repo;
        private readonly IMapper _mapper;
        public StudentAPIController(IStudentRepo repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _repo.GetAll();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _repo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateDTO studentVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = _mapper.Map<Student>(studentVM);
            await _repo.Create(student);
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentUpdateDTO dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }
            var student = _mapper.Map<Student>(dto);
            await _repo.Update(student);
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _repo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            await _repo.Delete(student);
            return Ok();
        }
    }
}
