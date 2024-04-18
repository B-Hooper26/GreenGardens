using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GreenGardens.Data;
using GreenGardens.Model;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace GreenGardens.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context; // Database context for accessing the database

    [BindProperty]
    public string Email { get; set; } // Email bound to the form input

    [BindProperty]
    public string Password { get; set; } // Password bound to the form input

    // Constructor injecting the database context
        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) // Check if the model state is valid
            {
                return Page(); // Return to the page if validation fails
            }

            var user = _context.customer.FirstOrDefault(u => u.email == Email);

            // Implement password verification logic here
            if (user != null && VerifyPassword(Password, user.password))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.f_name),
                    new Claim(ClaimTypes.Email, user.email),
                    // Add more claims as needed
                    new Claim(ClaimTypes.Role, user.Admin ? "Admin" : "User") // Add admin role to claims
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                if(user.Admin == true)
                {
                    return RedirectToPage("Products"); //Redirects admin to the admin page
                }
                else
                {
                    return RedirectToPage("Shop"); // Redirect customers to the shop if successfull
                }

            }

            return Page(); // Or provide a user-friendly error message
        }

        private bool VerifyPassword(string providedPassword, string storedHash)
        {
            // Implement password verification logic here
            return true; // Placeholder
        }
    }
}
