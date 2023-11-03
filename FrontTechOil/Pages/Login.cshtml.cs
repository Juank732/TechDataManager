using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FrontTechOil.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public LoginModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string nombre { get; set; }
            public string contrasena { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5111/api/auth/login");
            request.Content = new StringContent(JsonConvert.SerializeObject(Input), Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                var token = responseObject["token"];

                HttpContext.Session.SetString("BearerToken", token);

                TempData["Token"] = token;
                TempData.Keep("Token");
                return LocalRedirect(Url.Content("/Index"));
            }
            else
            {
                ModelState.AddModelError("Error", "Verifique su nombre y/o contraseña.");
                return Page();
            }


        }
    }

}

