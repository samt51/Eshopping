using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EShopping.UI.Models;
using EShoopping_Business.Abstrack;
using EShopping_Entity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using EShopping.UI.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Identity.UI.Services;
using EShopping.UI.Extension;

namespace EShopping.UI.Controllers
{
    [AutoValidateAntiforgeryToken]
       
    public class AccountController: Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _emailSender;
        private IKartService _kartService;
      

        public AccountController(IKartService kartService ,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender)
        {
           
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
            _kartService = kartService;
        }
        public IActionResult Register()
        {
            return View(new RegisterModels());
        }
        [HttpPost]
        public async Task< IActionResult> Register(RegisterModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Hesabınız Oluştu",
                    Message = "Hesabınız Güvenli Bir Şekilde Oluştur",
                    Css = "warning"

                });
            
             



                return RedirectToAction("Login");
            }
            ModelState.AddModelError("FullName", "İsminizi kurallara bağlı yazınız");
            ModelState.AddModelError("UserName", "Kullanıcı Adınızı doğru belirtiniz");
            ModelState.AddModelError("Password", "Şifrenizde bir büyük, bir küçük ve en az bir rakam bulundurunuz!!");
            
            ModelState.AddModelError("Email", "Email adresinizi doğru yazdığınızdan emin olun");
            
            return View(model);
        }

        public IActionResult Login(string ReturnUrl=null)
        {
            return View(new LoginModel()
            {

                ReturnUrl=ReturnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)

        {

            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Bu email ile daha önce hesap oluşturulmamış");
                return View(login);

            }


            var result = await _signInManager.PasswordSignInAsync(user, login.Password,true, false);
            if (result.Succeeded)
            {
                _kartService.initiliazCart(user.Id);
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Oturum Açıldı",
                    Message = "Hesabınız Açıldı",
                    Css = "success"

                });
                
                return Redirect(login.ReturnUrl ?? "~/");
            }
            ModelState.AddModelError("", "Email veya Şifreniz Yanlıştır");
            return View(login);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            TempData.Put("message", new ResultMessage()
            {
                Title="Oturum Kapatıldı",
                Message="Hesabınız Güvenli Bir Şekilde Kapatılmıştır",
                Css= "warning" 

            });

            return Redirect("~/");
        }

        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if (userId == null || token == null)
            {
                TempData["message"] = "Geçersiz Token";
                return View();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData["message"] = "Hesabınız Onaylandı";
                    return View();
                }
              
            }
            TempData["message"] = "Hesabınız Onaylanmadı";

            return View();
           
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> ForgotPassword(string mail)
        {
            if (string.IsNullOrEmpty(mail))
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Şifre Yenileme",
                    Message = "Bilgileriniz Hatalı",
                    Css = "warning"

                });

                return View();
            }
            var user = await _userManager.FindByEmailAsync(mail);
            if (user == null)
            {
                TempData.Put("message", new ResultMessage()
                {
                    Title = "Şifre Yenileme",
                    Message = "Eposta adresi ile kullanıcı bulunamadı",
                    Css = "danger"

                });
                return View();
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var callbackUrl = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = code
            });

            // send email
            await _emailSender.SendEmailAsync(mail, "Reset Password", $"Parolanızı yenilemek için linke <a href='http://localhost:55354{callbackUrl}'>tıklayınız.</a>");


            TempData.Put("message", new ResultMessage()
            {
                Title = "Şifre Yenileme",
                Message = "Parola yenilemek için hesabınıza mail gönderildi ",
                Css = "warning"

            });

            return RedirectToAction("Login", "Account");
        }
        public IActionResult ResetPassword(string token)
        {
            if (token == null)
            {
                return RedirectToAction("Product", "List");
            }
            var model = new ResetPasswordModel { Token = token };
            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return RedirectToAction("Product", "List");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Account", "Login");
                
            }
            return View(model);
        }
    }
}
