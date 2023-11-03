using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontTechOil.Pages
{
    public class EditarUsuarioModel : PageModel
    {
        [BindProperty]
        public Usuario Usuario { get; set; } = new Usuario();

        public async Task OnGet(int codUsuario)
        {
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                httpClient.BaseAddress = new Uri("http://localhost:5111/");
                Usuario = await httpClient.GetFromJsonAsync<Usuario>($"Usuario/{codUsuario}");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var prueba = Usuario;
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                httpClient.BaseAddress = new Uri("http://localhost:5111/");
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"Usuario/{Usuario.codUsuario}", Usuario);

                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/Usuarios");
                }
                else
                {
                    return Page();
                }
            }
        }
        public async Task<IActionResult> OnPostDelete()
        {
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                httpClient.BaseAddress = new Uri("http://localhost:5111/");
                HttpResponseMessage response = await httpClient.DeleteAsync($"Usuario/{Usuario.codUsuario}");

                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/Usuarios");
                }
                else
                {
                    return Page();
                }
            }
        }



    }



}

