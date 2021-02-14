using AutoMapper;
using Education_Api_L1.Data;
using Education_Api_L1.Dtos.StudentDto;
using Education_Api_L1.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Education_Api_L1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _repository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/[controller]
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAllStudens()
        {
            IEnumerable<Student> StudentItem = _repository.GetAllStudents();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(StudentItem));
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        public ActionResult<Student> GetStudentById(int id)
        {
            Student StudentItem = _repository.GetById(id);

            if (StudentItem == null)
            {
                return Ok(_mapper.Map<StudentReadDto>(StudentItem));
            }

            return NotFound();
        }

        //POST api/[controller]
        [HttpPost]
        public ActionResult<StudentReadDto> CreateStudent(Student std) 
        {
            Student StudentModel = _mapper.Map<Student>(std);
            _repository.CreateStudent(StudentModel);
            _repository.SaveChanges();

            StudentReadDto _StudentReadDto = _mapper.Map<StudentReadDto>(StudentModel);
            return CreatedAtRoute(nameof(GetStudentById), new { id = _StudentReadDto.id }, _StudentReadDto);
        }


        //PUT
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentUpdateDto _StudentUpdateDto)
        {
            Student StudentModel = _repository.GetById(id);
            if (StudentModel == null)
            {
                return NotFound();
            }

            _mapper.Map(_StudentUpdateDto, StudentModel);
            _repository.UpdateStudent(StudentModel);
            _repository.SaveChanges();

            return NoContent();
        }

        //Patch
        [HttpPatch("{id}")]
        public ActionResult ParticialStudentUpdate(int id, JsonPatchDocument<StudentUpdateDto> PatchDoc)
        {
            Student StudentModelFromRepo = _repository.GetById(id);
            if (StudentModelFromRepo == null)
            {
                return NotFound();
            }

            StudentUpdateDto _StudentDtoPatch = _mapper.Map<StudentUpdateDto>(StudentModelFromRepo);
            PatchDoc.ApplyTo(_StudentDtoPatch, ModelState);

            if (!TryValidateModel(ModelState))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(_StudentDtoPatch, StudentModelFromRepo);
            _repository.UpdateStudent(StudentModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE 
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            Student StudentFromRepo = _repository.GetById(id);
            if (StudentFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteStudent(StudentFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
