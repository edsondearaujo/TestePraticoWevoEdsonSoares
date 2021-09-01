using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WevoCRUD.Entities;
using WevoCRUD.Repositories;

namespace WevoCRUD.Controllers
{
    [Route("Api/v1/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        // Injeção de serviços do repository

        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        //  Definindo métodos assíncronos
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _repository.GetUsers();
            return Ok(users);
        }

        // Método de acesso por Id
        [HttpGet("{id: length(24)}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]

        public async Task<ActionResult<User>> GetUserById(string id)
        {
            var user = await _repository.GetUser(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // Método para criar usuário
        [HttpGet]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<User>> GetUser([FromBody] User user)
        {
            if (user is null)
                return BadRequest("Usuário inválido");

            await _repository.CreatUser(user);

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }


    }
}