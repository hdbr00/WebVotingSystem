using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using NETCore.MailKit.Core;
using ProyectoFinalPrograWeb.Models;

namespace ProyectoFinalPrograWeb.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IEmailService _EmailService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IEmailService emailService,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _EmailService = emailService;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Debe de digitar una cédula")]
            [RegularExpression("[0-9]+", ErrorMessage = "Solo números")]
            [Range(100000000, 999999999999, ErrorMessage = "Formato no válido")]
            [Display(Name = "Cédula")]
            
            public string Username { get; set; }

            [Required]
            [EmailAddress(ErrorMessage = "El correo electrónico ingresado no es válido.")]
            [Display(Name = "Correo electrónico")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "La contraseña debe ser de al menos {2} o de un máximo de {1} caracteres de longitud.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            bool primerRegistro = _userManager.Users.FirstOrDefault() == null;
            if (ModelState.IsValid)
            {
                var mismoCorreo = await _userManager.FindByEmailAsync(Input.Email);
                var mismaCedula = await _userManager.FindByNameAsync(Input.Username);

                if (mismoCorreo != null || mismaCedula != null)
                {
                    ModelState.AddModelError(string.Empty, "La cédula o el correo electrónico indicado se encuentra ligado a otra cuenta.");
                    return Page();
                }
                var user = new Usuario { UserName = Input.Username, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (primerRegistro && result.Succeeded)
                {
                    // Se crean los roles por defecto
                    List<String> rolesPorDefecto = new List<String>();
                    rolesPorDefecto.Add("Administrador");
                    rolesPorDefecto.Add("Votante");

                    foreach (String nombreRol in rolesPorDefecto)
                    {
                        IdentityRole rol = new IdentityRole(nombreRol);
                        await _roleManager.CreateAsync(rol);
                    }
                    await _userManager.AddToRoleAsync(user, "Administrador");
                }
                if (result.Succeeded)
                {
                    if (primerRegistro == false)
                    {
                        await _userManager.AddToRoleAsync(user, "Votante");
                    }
                    _logger.LogInformation("User created a new account with password.");
                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    // If account confirmation is required, we need to show the link if we don't have a real email sender
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("./RegisterConfirmation", new { Email = Input.Email });
                    }

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    string mensajeError = "";
                    switch (error.Code)
                    {
                        case "PasswordRequiresNonAlphanumeric":
                            mensajeError = "La contraseña debe contener al menos un caracter no alfanumérico.";
                            break;
                        case "PasswordRequiresLower":
                            mensajeError = "La contraseña debe contener al menos una letra minúscula ('a'-'z').";
                            break;
                        case "PasswordRequiresUpper":
                            mensajeError = "La contraseña debe contener al menos una letra mayúscula ('A'-'Z').";
                            break;
                    }
                    ModelState.AddModelError(string.Empty, mensajeError);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
