using Microsoft.AspNetCore.Mvc;
using WorkPathways.WorkPathways.Services;
using WorkPathways.WorkPathways.Models;
using Amazon.Runtime.Internal;
using MongoDB.Bson;

namespace WorkPathways.WorkPathways.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkPathwayController : ControllerBase
    {
        private readonly IWorkPathwayService _workPathwayService;
        public WorkPathwayController(WorkPathwayService workPathwayService) { 
            _workPathwayService = workPathwayService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            try
            {
                var result =  await _workPathwayService.CreateUser(user);
                var response = new ResponseStructure<User>
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = null
                };

                return Ok(response);
            }
            catch (Exception ex) {
                var errorResponse = new ResponseStructure<User>
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
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("EditUser")]
        public async Task<IActionResult> EditUser(User user) {
            try
            {
                var result = await _workPathwayService.UpdateUser(user);
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
                var errorResponse = new ResponseStructure<string>
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
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("getUserByUserId/{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId) {
            try
            {
                var result = await _workPathwayService.GetUserById(userId);
                var response = new ResponseStructure<User>
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = null
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ResponseStructure<User>
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
        /// <param name="firstName"></param>
        /// <returns></returns>
        [HttpGet("getUserByFirstName/{firstName}")]
        public async Task<IActionResult> GetUserByFirstName(string firstName) {
            try
            {
                var result = await _workPathwayService.GetUserByFirstName(firstName);
                var response = new ResponseStructure<User>
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = null
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ResponseStructure<User>
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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUserByUserId/{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId) {
            try
            {
                var result =await _workPathwayService.DeleteUser(userId);
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
                var errorResponse = new ResponseStructure<string>
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
        /// <returns></returns>
        /// 
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var result = await _workPathwayService.GetAllUsers();
                var response = new ResponseStructure<List<User>>
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = null
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var errorResponse = new ResponseStructure<User>
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
