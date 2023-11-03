using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FrontTechOil.Pages.Servicios
{
    public class ServiciosModel : PageModel
    {
        public List<Servicio> ListaServicios { get; set; }

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await httpClient.GetAsync("http://localhost:5111/Servicio");

                if (response.IsSuccessStatusCode)
                {
                    ListaServicios = await response.Content.ReadFromJsonAsync<List<Servicio>>();

                }
                else
                {
                    ListaServicios = new List<Servicio>();
                }
            }
        }

        public async Task<IActionResult> OnPostAsync(Servicio Servicio)
        {
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var content = new StringContent(JsonConvert.SerializeObject(Servicio), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5111/Servicio", content);

                var getResponse = await httpClient.GetAsync("http://localhost:5111/Servicio");

                if (getResponse.IsSuccessStatusCode)
                {
                    ListaServicios = await getResponse.Content.ReadFromJsonAsync<List<Servicio>>();
                }
                else
                {
                    ListaServicios = new List<Servicio>();
                }

            }
            return RedirectToPage("/Servicios/Servicios");


        }
    }

}

public class Servicio
{
    public int? codServicio { get; set; }
    public string descr { get; set; }
    public bool estado { get; set; }
    public decimal valorHora { get; set; }

}