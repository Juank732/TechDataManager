using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontTechOil.Pages.Trabajos
{
    public class EditarTrabajoModel : PageModel
    {
        [BindProperty]
        public Trabajo Trabajo { get; set; } = new Trabajo();

        public async Task OnGetAsync(int codTrabajo)
        {
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                httpClient.BaseAddress = new Uri("http://localhost:5111/");
                Trabajo = await httpClient.GetFromJsonAsync<Trabajo>($"Trabajo/{codTrabajo}");
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                httpClient.BaseAddress = new Uri("http://localhost:5111/");
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"Trabajo/{Trabajo.codTrabajo}", Trabajo);

                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/Trabajos");
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
                HttpResponseMessage response = await httpClient.DeleteAsync($"Trabajo/{Trabajo.codTrabajo}");

                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/Trabajos");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}
