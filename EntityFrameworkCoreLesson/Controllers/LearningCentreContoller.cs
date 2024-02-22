using EntityFrameworkCoreLesson.Applications.LearningCentreService;
using EntityFrameworkCoreLesson.DTOs;
using EntityFrameworkCoreLesson.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCoreLesson.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LearningCentreContoller : ControllerBase
    {


        private readonly ILearningCentreService _LearningCentreService;
        public LearningCentreContoller(ILearningCentreService learningCentreService)
        {
            _LearningCentreService = learningCentreService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLearningCentre(LearningCentreDTO model)
        {
            try
            {
                var _model = new LearningCentre()
                {
                    StudentId = model.StudentId,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Teacher = model.Teacher,
                };
                await _LearningCentreService.CreateLearningCentreAsync(_model);

                return Ok("Created Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLearningCentreAsync()
        {
            try
            {
                var result = await _LearningCentreService.GetAllLearningCentreAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLearningcentreByIdAsync(int id)
        {
            try
            {
                var result = await _LearningCentreService.GetLearningCentreByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLearningCentreAsync(int id, LearningCentreDTO model)
        {
            try
            {
                var _model = new LearningCentre()
                {
                    StudentId = model.StudentId,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Teacher = model.Teacher,
                };

                await _LearningCentreService.UpdateLearningCentreAsync(id, _model);

                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePLearningCentreAsync(int id)
        {
            try
            {
                await _LearningCentreService.DeleteLearningCentreByIdAsync(id);

                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
