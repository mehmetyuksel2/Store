using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using Entities.Dtos;

namespace StoreApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;//
        private readonly SignInManager<IdentityUser> _signInManager;//giriş yapıldıktan sonra kullanılır

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {

            return View(new LoginModels()
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModels model)
        {//Login sayfasından gelen kullanıcının bilgileri buraya gelir
            if(ModelState.IsValid)//valid oldu ise
            {
                IdentityUser user = await _userManager.FindByNameAsync(model.Name);// kullanıcı filtrelenir
                if (user is not null)//eğer kullanıcı var ise
                {
                    await _signInManager.SignOutAsync();//başka yerde login ise çıkışı yapılır
                    if((await _signInManager.PasswordSignInAsync(user,model.Password,false,false)).Succeeded)
                    {
                        return Redirect(model?.ReturnUrl ?? "/");
                    }
                }
                ModelState.AddModelError("Error", "Invalid username or password.");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout([FromQuery(Name ="ReturnUrl")] string ReturnUrl="/")
        {//FromQuery ile endpoint içindeki returnurl var ise çeker ve ona yönlendirir. boş olma olasılığına karşılık
            //default değeri atadık.
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }
       
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {
            var user = new IdentityUser//kullanıcı ekleme
            {
                UserName = model.UserName,
                Email = model.Email 
            };

            var result = await _userManager
                .CreateAsync(user, model.Password);//kullanıcı eklendi
            if (result.Succeeded)//eğer kullanıcı başarıyla eklendiyse
            {
                var roleResult = await _userManager
                    .AddToRoleAsync(user, "User");//role değerinide ver
                if(roleResult.Succeeded)
                {
                    return RedirectToAction("Login", new { ReturnUrl = "/" });
                    //ReturnUrl yi actiona parametre olarak gönderiyoruz
                }
            }
            else
            {
                foreach(var err in result.Errors)//errorları ata
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View();
        }

        public IActionResult AccessDenied([FromQuery(Name ="ReturnUrl")]string returnUrl)
        {//authorized kullanıldığında gelen url deki parametrenin action nu ve view ını oluşturuyoruz
            return View();
        }
    }
}
