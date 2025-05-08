using backend.Data;
using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;

        public LoginController(ApplicationDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username);

            Console.WriteLine($"Gelen kullanıcı adı: {request.Username}");
            Console.WriteLine($"Gelen şifre: {request.Password}");

            if (user == null){
                Console.WriteLine("Kullanıcı bulunamadı!");
                return Unauthorized("Geçersiz kullanıcı adı.");
            }
            
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.Password);

            if (!isPasswordValid){
                Console.WriteLine("Şifre geçersiz!");
                return Unauthorized("Geçersiz şifre.");
            }
            var token = _jwtService.GenerateToken(user);
            Console.WriteLine("Oluşturulan token: " + token);


            return Ok(new { token });
        }

    }
}
