using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FrontTechOil.Pages.Trabajos
{
    public class TrabajosModel : PageModel
    {
        public List<Trabajo> ListaTrabajos { get; set; }

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                var response = await httpClient.GetAsync("http://localhost:5111/Trabajo");

                if (response.IsSuccessStatusCode)
                {
                    ListaTrabajos = await response.Content.ReadFromJsonAsync<List<Trabajo>>();
                }
                else
                {
                    ListaTrabajos = new List<Trabajo>();
                }
            }
        }

        public async Task<IActionResult> OnPostAsync(Trabajo Trabajo)
        {
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var content = new StringContent(JsonConvert.SerializeObject(Trabajo), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5111/Trabajo", content);

                var getResponse = await httpClient.GetAsync("http://localhost:5111/Trabajo");

                if (getResponse.IsSuccessStatusCode)
                {
                    ListaTrabajos = await getResponse.Content.ReadFromJsonAsync<List<Trabajo>>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error al crear el registro verifique los campos ingresados");
                }

            }
            return RedirectToPage("/Trabajos/trabajos");


        }
    }
}

public class Trabajo
{
    public int codTrabajo { get; set; }

    public DateTime fecha { get; set; }

    public int cantHoras { get; set; }

    public decimal valorHora { get; set; }

    public decimal costo { get; set; }

    public int? codProyecto { get; set; }

    public int? codServicio { get; set; }

}