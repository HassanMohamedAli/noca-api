using ArticleManagement.Application.DTOs;
using ArticleManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using ArticleManagement.Application.Common;
using Microsoft.AspNetCore.Authorization;
using ArticleManagement.Application.Interfaces.Implementations;
using Azure.Core;
using Azure;
using System.Security.Claims;

namespace ArticleManagement.API.Controllers.V1
{

    [Authorize(AuthenticationSchemes = "Bearer")]

    [ApiController]


    [Route("api/v1/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var response = new ApiResponse<object>(null);

            try
            {
                var result = await _articleService.GetAllAsync();

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = new ApiResponse<object>(null);

            try
            {
                var result = await _articleService.GetByIdAsync(id);
                response.Success = true;
                response.Data = result;

              
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Data = null;

             }
            return Ok(response);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleDto request)
        {
            var response = new ApiResponse<object>(null);
            request.CreatedBy = User.FindFirst(ClaimTypes.Email)?.Value;



            try
            {
                var id = await _articleService.CreateAsync(request);
                response.Success = true;
                response.Message = "Data created successfully";
                response.Data = id;

                
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error while creating the Article: " + ex.Message;
                response.Data = null;

                
            }
            return Ok(response);
        }







        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ArticleDto request)
        {

            var response = new ApiResponse<object>(null);
            request.UpdatedBy = User.FindFirst(ClaimTypes.Email)?.Value;
            request.UpdatedOn = DateTime.UtcNow;

            try
            {

                await _articleService.UpdateAsync(request);
                response.Success = true;
                response.Message = "Article Updated successfully";
                response.Data = true;


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error while Updating the Article: " + ex.Message;
                response.Data = false;

            }
            return Ok(response);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] ArticleFilterDto filter)
        {
            var response = new ApiResponse<object>(null);

            try
            {
                var result = await _articleService.FilterArticlesAsync(filter);
                response.Success = true;
                response.Data = result;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error while searching  the Articles: " + ex.Message;
                response.Data = new  List<ArticleFilterDto>();
            }
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ApiResponse<object>(null);

            try
            {
                await _articleService.DeleteAsync(id);
                response.Success = true;
                response.Message = "Article Deleted successfully";
                response.Data = true;

               
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error while Deleting the Article: " + ex.Message;
                response.Data = false;

                
            }
            return Ok(response);
        }



    }
}