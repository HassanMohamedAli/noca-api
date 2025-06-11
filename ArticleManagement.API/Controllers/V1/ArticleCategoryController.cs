 
using ArticleManagement.Application.Common;
using ArticleManagement.Application.DTOs;
using ArticleManagement.Application.Interfaces.Implementations;
using ArticleManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ArticleManagement.API.Controllers.V1
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]

    [Route("api/v1/[controller]")]

    public class ArticleCategoryController : ControllerBase
    {
        private readonly IArticleCategoryService _articleCategoryService;

        public ArticleCategoryController(IArticleCategoryService materialService)
        {
            _articleCategoryService = materialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = new ApiResponse<object>(null);

            try
            {
                var result = await _articleCategoryService.GetAllAsync();
                response.Success = true;
                response.Message = "Data Loaded successfully";
                response.Data = result;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error while Loading Data: " + ex.Message;
                response.Data = null;

                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleCategoryDto request)
        {

            var response = new ApiResponse<object>(null);
            request.CreatedBy = User.FindFirst(ClaimTypes.Email)?.Value;

            try
            {
                var id = await _articleCategoryService.CreateAsync(request);
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