using ChatApp_UI.Commons.Constants;
using ChatApp_UI.Models.WebApiPayloads.Implementation.AuthWebApis.RequestBody;
using ChatApp_UI.ViewModels.Auths;
using ChatApp_UI.WebApis.Implementation.Auths;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LoginWebApi _loginWebApi;

        public IndexModel(LoginWebApi loginWebApi)
        {
            _loginWebApi = loginWebApi;
        }

        [BindProperty]
        public LoginViewModel LoginInfo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var cookies = Request.Cookies;

            if (cookies != null && cookies.Count > 0)
            {
                Request.Cookies.ToList().ForEach(x =>
                {
                    Console.WriteLine($"{x.Key} : {x.Value}");
                });
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var loginRequestBody = new LoginRequestBody
            {
                Username = LoginInfo.Username,
                Password = LoginInfo.Password,
                RememberMe = LoginInfo.RememberMe,
            };

            var result = await _loginWebApi.SendRequestAsync(loginRequestBody);

            if (result.IsSuccess)
            {
                var cookieLifeSpan = TimeSpan.FromDays(1);

                if (loginRequestBody.RememberMe)
                {
                    cookieLifeSpan = TimeSpan.FromDays(7);
                }

                var cookieOptions = new CookieOptions
                {
                    MaxAge = cookieLifeSpan,
                    Expires = DateTime.Now.Add(cookieLifeSpan)
                };

                Response.Cookies.Append(CookieNames.AccessToken, result.Body.AccessToken, cookieOptions);
                Response.Cookies.Append(CookieNames.RefreshToken, result.Body.RefreshToken, cookieOptions);
            }

            return Page();
        }
    }
}