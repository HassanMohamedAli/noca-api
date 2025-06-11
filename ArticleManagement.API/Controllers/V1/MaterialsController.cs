 
using ArticleManagement.Application.Common;
using ArticleManagement.Application.DTOs;
using ArticleManagement.Application.Interfaces.Implementations;
using ArticleManagement.Application.Interfaces.Services;
using ArticleManagement.Domain.Entities;
using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ArticleManagement.API.Controllers.V1
{
    [ApiController]
    

    [Authorize(AuthenticationSchemes = "Bearer")]

    [Route("api/v1/[controller]")]

    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialsController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             
            var response = new ApiResponse<object>(null);

            try
            {
                var result = await _materialService.GetAllAsync();
                response.Success = true;
                response.Message = "Data Loaded successfully";
                response.Data = result;

               
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error while Loading Data: " + ex.Message;
                response.Data = null;

                
            }


            return Ok(response);



        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MaterialDto request)
        {
          
            var response = new ApiResponse<object>(null);
            request.CreatedBy = User.FindFirst(ClaimTypes.Email)?.Value;


            try
            {
                var id = await _materialService.CreateAsync(request);

                response.Success = true;
                response.Message = "Data Saved successfully";
                response.Data = id;

               
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error while Save Data: " + ex.Message;
                response.Data = null;

               
            }
            return Ok(response);

        }
    }
}