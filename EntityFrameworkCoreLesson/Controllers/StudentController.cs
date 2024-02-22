using EntityFrameworkCoreLesson.Applications.StudentService;
using EntityFrameworkCoreLesson.DTOs;
using EntityFrameworkCoreLesson.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCoreLesson.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {


        private readonly IStudentService _StudentService;


        public StudentController(IStudentService StudentService)
        {
            _StudentService = StudentService;
        }

        [HttpPost]
        public async Task<string> CreateStudent(StudentDTO type)
        {
            try
            {
                var _type = new Student()
                {
                    FullName = type.FullName,
                    Age = type.Age,
                    Field = type.Field,
                    GroupNumber = type.GroupNumber,
                };
                return await _StudentService.CreateStudentAsync(_type);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentAsync()
        {
            try
            {
                var result = await _StudentService.GetAllStudentsAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            try
            {
                var result = await _StudentService.GetStudentByIdAsync(id);

                if (result is null)
                {
                    return NotFound("Data not found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudentAsync(int id, StudentDTO type)
        {
            try
            {
                var _type = new Student()
                {
                    FullName = type.FullName,
                    Age = type.Age,
                    Field = type.Field,
                    GroupNumber = type.GroupNumber
                };

                await _StudentService.UpdateStudentAsync(id, _type);

                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudentAsync(int id)
        {
            try
            {
                await _StudentService.DeleteStudentByIdAsync(id);

                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
