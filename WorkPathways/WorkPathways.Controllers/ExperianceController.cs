using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WorkPathways.WorkPathways.Models;
using WorkPathways.WorkPathways.Services.Interfaces;
using WorkPathways.WorkPathways.Services.Services;

namespace WorkPathways.WorkPathways.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperianceController: ControllerBase
    {
        private readonly IExperianceService _experianceService;
        public ExperianceController(ExperianceService experianceService)
        {
            _experianceService = experianceService;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("AddExperiance")]
        public async Task<IActionResult> AddExperiance(List<AddExperianceDto> experiance)
        {
            try
            {
                List<Experiance> expList = new List<Experiance>();
                foreach (var exp in experiance)
                {
                    Experiance experinaceObj = new Experiance
                    {
                        Id = Guid.NewGuid(),
                        UserId = exp.UserId,
                        CompanyName = exp.CompanyName,
                        ProfessionalExperience = exp.ProfessionalExperience,
                        Role = exp.Role
                    };
                    expList.Add(experinaceObj);
                }
                var result = await _experianceService.AddExperiance(expList);
                var response = new ResponseStructure<List<Experiance>>
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = null
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ResponseStructure<Experiance>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("GetExperianceByUserId/{userId}")]
        public async Task<IActionResult> GetExperianceByUserId(Guid userId)
        {
            try
            {
                var result= await _experianceService.GetExperianceByUserId(userId);
                var response = new ResponseStructure<List<Experiance>>
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = null
                };
                return Ok(response);
            }
            catch (Exception ex) {
                var errorResponse = new ResponseStructure<Experiance>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="experiances"></param>
        /// <returns></returns>
        [HttpPost("UpdateExperiance")]
        public async Task<IActionResult> UpdateExperiance(Experiance experiance)
        {
            try
            {
                var result = await _experianceService.UpdateExperiance(experiance);
                var response = new ResponseStructure<string>
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = null
                };
                return Ok(response);
            }
            catch (Exception ex) {
                var errorResponse = new ResponseStructure<Experiance>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("DeleteAllExperiancesByUserId/{userId}")]
        public async Task<IActionResult> DeleteAllExperiancesByUserId(Guid userId)
        {
            try
            {
                var result = await _experianceService.DeleteExperianceByUserId(userId);
                var response = new ResponseStructure<string>
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = null
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ResponseStructure<Experiance>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = ex.Message
                };
                return StatusCode(500, errorResponse);
            }
        }

    }
}
