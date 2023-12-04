using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Users.Controllers;

[ApiController]
public class UserController : ControllerBase
{

    private readonly IConfiguration _config;

    public UserController(IConfiguration config)
    {
            _config = config;
    }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUserModel()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            IEnumerable<UserModel> users = await SelectAllUsers(connection);
            return Ok(users);
        }
    


    [HttpGet("{Id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var user = await connection.QueryFirstAsync<UserModel>("select * from Users where id = @Id",
                    new { Id = Id });
            return Ok(user);
        }

    [HttpPost]
        public async Task<ActionResult<List<UserModel>>> CreateUser(User user)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into Users (name, age, email, password) values (@Name, @Age, @Email, @Password)", user);
            return Ok(await SelectAllUsers(connection));
        }

    [HttpDelete("/{id}")]
    public IActionResult delete([FromRoute] int id)
    {
        var User = User.Users.FirstOrDefault(x => x.id == id);
        if (User == null){
            return Notfound();
        }

        return ok(User);

    }

    [HttpPut("/{id}")]
    public IActionResult update([FromRoute] int id,[FromBody] User user)
    {
        var UserU = User.Users.FirstOrDefault(x => x.id == id);
        
    }

}