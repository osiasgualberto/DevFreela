using DevFreela.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //POST api/Users
        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            return Ok();
        }


        [HttpPost("{id}/Skills")]
        public IActionResult PostSkills(UserSkillsInputModel model)
        {
            return NoContent();
        }




        [HttpPut("{id}/profile-picture")]
        public IActionResult PostProfilePicture(IFormFile file)
        {
            var description = $"File: {file.FileName},Size: {file.Length}";

            //processar a imagem
            return Ok(description);
        }

    }
}
