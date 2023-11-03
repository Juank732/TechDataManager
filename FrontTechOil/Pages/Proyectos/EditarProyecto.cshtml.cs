using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontTechOil.Pages.Proyectos
{
    public class EditarProyectoModel : PageModel
    {
        [BindProperty]
        public Proyecto Proyecto { get; set; } = new Proyecto();

        public async Task OnGetAsync(int codProyecto)
        {

            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                httpClient.BaseAddress = new Uri("http://localhost:5111/");
                Proyecto = await httpClient.GetFromJsonAsync<Proyecto>($"Proyecto/{codProyecto}");
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
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"Proyecto/{Proyecto.codProyecto}", Proyecto);

                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/Proyectos");
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
                HttpResponseMessage response = await httpClient.DeleteAsync($"Proyecto/{Proyecto.codProyecto}");

                if (response.IsSuccessStatusCode)
                {
                    return Redirect("/Proyectos");
                }
                else
                {
                    return Page();
                }
            }
        }
    }
}
