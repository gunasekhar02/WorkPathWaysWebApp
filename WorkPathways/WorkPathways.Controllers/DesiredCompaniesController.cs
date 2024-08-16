using Microsoft.AspNetCore.Mvc;
using WorkPathways.WorkPathways.Models;
using WorkPathways.WorkPathways.Services.Interfaces;
using WorkPathways.WorkPathways.Services.Services;



namespace WorkPathways.WorkPathways.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesiredCompaniesController:ControllerBase
    {
        private readonly IDesiredCompaniesService _desiredCompaniesService;

        public DesiredCompaniesController(DesiredCompaniesService desiredCompaniesService)
        {
            _desiredCompaniesService = desiredCompaniesService;
        }

/// <summary>
/// 
/// </summary>
/// <param name="desiredCompanies"></param>
/// <returns></returns>
        [HttpPost("AddDesiredCompanies")]
        public async Task<IActionResult> AddDesiredCompanies(List<DesiredCompaniesDto> desiredCompanies)
        {
            try
            {
                List<DesiredCompanies> companyList = new List<DesiredCompanies>();
                foreach (var company in desiredCompanies)
                {
                    DesiredCompanies companyObj = new DesiredCompanies
                    {
                        Id = Guid.NewGuid(),
                        UserId = company.UserId,
                        DesiredCompanyName=company.DesiredCompanyName,
                        DesiredRole=company.DesiredRole,
                    };
                    companyList.Add(companyObj);
                }
                var result = await _desiredCompaniesService.AddDesiredCompanies(companyList);
                var response = new ResponseStructure<List<DesiredCompanies>>
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = null
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ResponseStructure<DesiredCompanies>
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
        [HttpGet("GetDesiredCompaniesByUserId/{userId}")]
        public async Task<IActionResult> GetDesiredCompaniesByUserId(Guid userId)
        {
            try
            {
                var result = await _desiredCompaniesService.GetDesiredCompanyByUserId(userId);
                var response = new ResponseStructure<List<DesiredCompanies>>
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = null
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ResponseStructure<DesiredCompanies>
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
/// <param name="desiredCompany"></param>
/// <returns></returns>
        [HttpPost("UpdateDesiredComapny")]
        public async Task<IActionResult> UpdateDesiredComapny(DesiredCompanies desiredCompany)
        {
            try
            {
                var result = await _desiredCompaniesService.UpdateDesiredCompany(desiredCompany);
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
                var errorResponse = new ResponseStructure<DesiredCompanies>
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
        [HttpDelete("DeleteAllDesiredCompaniesByUserId/{userId}")]
        public async Task<IActionResult> DeleteAllExperiancesByUserId(Guid userId)
        {
            try
            {
                var result = await _desiredCompaniesService.DeleteDesiredCompanyByUserId(userId);
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
                var errorResponse = new ResponseStructure<DesiredCompanies>
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
