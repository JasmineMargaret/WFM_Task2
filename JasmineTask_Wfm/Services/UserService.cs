using JasmineTask_Wfm.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using JasmineTask_Wfm.Helpers;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JasmineTask_Wfm.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly Jasmine_DBContext _context;
        public UserService(Jasmine_DBContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
       // private List<User> _users = new List<User>
       // {
       //     new User { Id = 1, UserName = "jasmine",Name = "jasmine",Password = "password", Role="Manager", Email="j@softura.com" },
       //     new User { Id = 2, UserName = "peter", Name = "peter", Password = "password", Role="WFM", Email="p@softura.com" }
       //};

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            //var user = _users.SingleOrDefault(x => x.UserName == model.Username && x.Password == model.Password);
            var user = GetAll().SingleOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            var query = _context.Users.ToList();
            return query;
        }
        //public async Task<IEnumerable<User>> GetAllDB()
        //{
        //    var result= await _context.Users.ToListAsync();
        //    return result;
        //} 

        public User GetById(int id)
        {
            //return _users.FirstOrDefault(x => x.Id == id);
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("This is my first Security key and hope this is enough to create jwt token");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
