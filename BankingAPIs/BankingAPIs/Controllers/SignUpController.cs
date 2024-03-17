using BankingAPIs.Interface;
using BankingAPIs.ModelClass;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BankingAPIs.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[EnableCors()]
    public class SignUpController : ControllerBase
    {

        private readonly ISignUp _signup;

        public SignUpController(ISignUp signUp)
        {

            _signup = signUp;
        }

        [HttpPost]

        public IActionResult CreateNewAccount(SignUp signup)
        {
            try
            {
                return Ok(_signup.Create(signup, signup.Password, signup.ConfirmPassword));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }


    }
}
