using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using BSalonWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BSalonWebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; private set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                var user = AuthenticateUser(Input.Login, Input.Password);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid login or password attempt.");
                    return Page();
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return LocalRedirect(Url.GetLocalUrl(returnUrl));
            }

            return Page();
        }

        private Admin AuthenticateUser(string login, string password)
        {
            if (string.Equals(login, "admin", StringComparison.OrdinalIgnoreCase) &&
                string.Equals(password, "root"))
            {
                return new Admin()
                {
                    Login = login,
                    Password = password
                };
            }
            else
            {
                return null;
            }
        }
    }

    public class InputModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }


}