using EventPlan1.Models.DTO;
using EventPlan1.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EventPlan1.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;
        public UserAuthenticationController(IUserAuthenticationService authService)
        {
            this.authService = authService;
        }
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            model.Role = "user";
            var result = await authService.RegisterAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction("Event", "EventList");
            
            //var result = await authService.RegisterAsync(model);
            //return Ok(result.Message);
        }
        //public async Task<IActionResult> Reg()
        //{
        //    var model = new RegistrationModel
        //    {

        //        Name = "Admin",
        //        Username = "Admin",
        //        Email = "admin@gmail.com",
        //        Password = "Admin@123",
        //        PasswordConfirm = "Admin@123",

        //    };
        //    model.Role = "Admin";
        //    var result = await authService.RegisterAsync(model);
        //    return Ok(result);
        //}

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
                return RedirectToAction("Event", "EventList");
            else
            {
                TempData["msg"] = "Invalid Username or Password";
                return RedirectToAction(nameof(Login));
            }
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }

    }
}