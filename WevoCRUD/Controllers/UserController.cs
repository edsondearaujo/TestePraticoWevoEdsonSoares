using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WevoCRUD.Entities;
using WevoCRUD.Repositories;

namespace WevoCRUD.Controllers
{
    // Criação da API
    [Route("Api/v1/User")]
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
        //[Route("Api/v1/[controller]")]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _repository.GetUsers();
            return Ok(users);
        }

        // Método de acesso por Id
        [HttpGet("{id: length(24)}", Name = "GetUser")]
        //[Route("Api/v1/[controller]")]
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
        [HttpGet("Api/v1/User")]
        //[Route("Api/v1/[controller]")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<User>> GetUser([FromBody] User user)
        {
            if (user is null)
                return BadRequest("Usuário inválido");

            await _repository.CreatUser(user);

            return CreatedAtRoute("GetUser", new { id = user.Id }, user);
        }

        // Método para editar o usuário
        [HttpPut]
        //[Route("Api/v1/[controller]")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<User>> UpdateUser([FromBody] User user)
        {
            if (user is null)
                return BadRequest("Usuário inválido");

            return Ok(await _repository.UpdateUser(user));
        }

        //Método para deletar usuário
        [HttpDelete("{id: length(24)}", Name = "DeleteUser")]
        //[Route("Api/v1/[controller]")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]

        public async Task<ActionResult<User>> DeleteUserById(string id)
        {
            return Ok(await _repository.DeleteUser(id));
        }

    }
}