using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Mvc;
using WorkPathways.WorkPathways.Models;
using WorkPathways.WorkPathways.Services.Interfaces;
using WorkPathways.WorkPathways.Services.Services;

namespace WorkPathways.WorkPathways.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccomplishmentsController : ControllerBase
    {
        private readonly IAccomplishmentsService _accomplishmentService;

        public AccomplishmentsController(AccomplishmentsService accomplishmentsService)
        {
            _accomplishmentService = accomplishmentsService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accomplisments"></param>
        /// <returns></returns>
        [HttpPost("AddAcomplisments")]
        public async Task<IActionResult> AddAcomplisments(List<AccomplismentsDto> accomplisments)
        {
            try
            {
                List<Accomplisments> acccomplishMentsList = new List<Accomplisments>();
                foreach (var acc in accomplisments)
                {
                    Accomplisments accomObj = new Accomplisments
                    {
                        Id = Guid.NewGuid(),
                        UserId = acc.UserId,
                        Awards = acc.Awards,
                        AwardedFor = acc.AwardedFor,
                        InCompany = acc.InCompany

                    };
                    acccomplishMentsList.Add(accomObj);
                }
                var result = await _accomplishmentService.AddAccomplishments(acccomplishMentsList);
                var response = new ResponseStructure<List<Accomplisments>>
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = null
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ResponseStructure<List<Accomplisments>>
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
        [HttpGet("GetAccomplismentsByUserId/{userId}")]
        public async Task<IActionResult> GetAccomplismentsByUserId(Guid userId)
        {
            try
            {
                var result = await _accomplishmentService.GetAccomplishmentsByUserId(userId);
                var response = new ResponseStructure<List<Accomplisments>>
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = null
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ResponseStructure<Accomplisments>
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
  /// <param name="accomplisment"></param>
  /// <returns></returns>
        [HttpPost("UpdateAccomplisments")]
        public async Task<IActionResult> UpdateDesiredComapny(Accomplisments accomplisment)
        {
            try
            {
                var result = await _accomplishmentService.UpdateAccomplishment(accomplisment);
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
                var errorResponse = new ResponseStructure<Accomplisments>
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
        [HttpDelete("DeleteAllAccomplismentsByUserId/{userId}")]
        public async Task<IActionResult> DeleteAllAccomplismentsByUserId(Guid userId)
        {
            try
            {
                var result = await _accomplishmentService.DeleteAccomplishmnetsByUserId(userId);
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
                var errorResponse = new ResponseStructure<Accomplisments>
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
