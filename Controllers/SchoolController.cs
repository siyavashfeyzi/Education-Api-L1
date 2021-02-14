using AutoMapper;
using Education_Api_L1.Data;
using Education_Api_L1.Dtos.SchoolDto;
using Education_Api_L1.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Education_Api_L1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly ISchoolRepo  _repository;
        private readonly IMapper _mapper;

        public SchoolController(ISchoolRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/[controller]
        [HttpGet]
        public ActionResult<IEnumerable<School>> GetAllSchools()
        {
            IEnumerable<School> SchoolItems = _repository.GetAllSchools();
            return Ok(_mapper.Map<IEnumerable<SchoolReadDto>>(SchoolItems));
        }

        //GET BY ID api/[controller/{id}
        [HttpGet("{id}", Name = "GetSchoolById")]
        public ActionResult<School> GetSchoolById(int id)
        {
            School SchoolItem = _repository.GetById(id);

            if (SchoolItem != null)
            {
                return Ok(_mapper.Map<SchoolReadDto>(SchoolItem));
            }

            return NotFound();
        }

        //POST api/[controller]
        [HttpPost]
        public ActionResult<SchoolReadDto> CreateSchool(SchoolCreateDto sch)
        {
            School SchoolModel = _mapper.Map<School>(sch);
            _repository.CreateSchool(SchoolModel);
            _repository.SaveChanges();

            SchoolReadDto _StudentReadDto = _mapper.Map<SchoolReadDto>(SchoolModel);
            return CreatedAtRoute(nameof(GetSchoolById), new { id = _StudentReadDto.Id }, _StudentReadDto);
        }

        //PUT api/[controller]/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSchool(int id, SchoolUpdateDto _SchoolUpdateDto)
        {
            School SchoolModel = _repository.GetById(id);
            if (SchoolModel == null)
            {
                return NotFound();
            }

            _mapper.Map(_SchoolUpdateDto, SchoolModel);
            _repository.UpdateSchool(SchoolModel);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/[controller]/{id}
        [HttpPatch("{id}")]
        public ActionResult ParticialSchoolUpdate(int id, JsonPatchDocument<SchoolUpdateDto> PatchDoc)
        {
            School SchoolModel = _repository.GetById(id);
            if (SchoolModel == null)
            {
                return NotFound();
            }

            SchoolUpdateDto _SchoolDtoPatch = _mapper.Map<SchoolUpdateDto>(SchoolModel);
            PatchDoc.ApplyTo(_SchoolDtoPatch, ModelState);

            if (!TryValidateModel(ModelState))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(_SchoolDtoPatch, SchoolModel);
            _repository.UpdateSchool(SchoolModel);
            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSchool(int id) 
        {
            School SchoolModel = _repository.GetById(id);
            if (SchoolModel == null)
            {
                return NotFound();
            }

            _repository.DeleteSchool(SchoolModel);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}
