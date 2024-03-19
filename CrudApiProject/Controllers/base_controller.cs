using CrudApiProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CrudApiProject.Services;
namespace CrudApiProject.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class base_controller : ControllerBase
    {
        protected readonly base_service _baseService;

        public base_controller(base_service baseService)
        {
            _baseService = baseService;
        }
    }
}

