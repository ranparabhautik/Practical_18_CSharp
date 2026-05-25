using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Practical_18.Models.DTOs;
using Practical_18.Models.Entities;
using Practical_18.Repository.Interface;

namespace Practical_18.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepo _repo;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepo repo,IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;   
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _repo.GetAll();
            return View(students);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var student = await _repo.GetById(id);
            return View(student);   
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var student = await _repo.GetById(id);
            if (student == null)
            {
                return NotFound();
            }
            var vm = _mapper.Map<StudentUpdateDTO>(student);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StudentUpdateDTO student)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<Student>(student);
                await _repo.Update(entity);
                return RedirectToAction("Index");
            }

            return View(student);
        }


        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateDTO student)
        {
            if (ModelState.IsValid)
            {
                var entity = _mapper.Map<Student>(student);
                await _repo.Create(entity);
                return RedirectToAction("Index");
            }

            return View(student);
        }



        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _repo.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            await _repo.Delete(student);

            return RedirectToAction("Index");
        }

    }
}
