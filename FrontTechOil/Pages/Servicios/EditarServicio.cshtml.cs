using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FrontTechOil.Pages.Servicios
{
    public class EditarServicioModel : PageModel
    {
        [BindProperty]
        public Servicio Servicio { get; set; } = new Servicio();

        public async Task OnGetAsync(int codServicio)
        {

            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                httpClient.BaseAddress = new Uri("http://localhost:5111/");
                Servicio = await httpClient.GetFromJsonAsync<Servicio>($"Servicio/{codServicio}");
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
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"Servicio/{Servicio.codServicio}", Servicio);

                if (response.IsSuccessStatusCode)
                {
                    // La actualización se realizó con éxito. Puedes redirigir a la página de Servicios u otra página de confirmación.
                    return Redirect("/Servicios");
                }
                else
                {
                    // Manejar errores si la actualización falla.
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
                HttpResponseMessage response = await httpClient.DeleteAsync($"Servicio/{Servicio.codServicio}");

                if (response.IsSuccessStatusCode)
                {
                    // La eliminación se realizó con éxito. Puedes redirigir a la página de Servicios u otra página de confirmación.
                    return Redirect("/Servicios");
                }
                else
                {
                    // Manejar errores si la eliminación falla.
                    return Page();
                }
            }
        }
    }
}
