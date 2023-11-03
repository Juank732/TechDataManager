using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FrontTechOil.Pages.Proyectos
{
    public class ProyectosModel : PageModel
    {
        public List<Proyecto> ListaProyectos { get; set; }

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await httpClient.GetAsync("http://localhost:5111/Proyecto");

                if (response.IsSuccessStatusCode)
                {
                    ListaProyectos = await response.Content.ReadFromJsonAsync<List<Proyecto>>();
                }
                else
                {
                    ListaProyectos = new List<Proyecto>();
                }
            }
        }

        public async Task<IActionResult> OnPostAsync(Proyecto Proyecto)
        {
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var content = new StringContent(JsonConvert.SerializeObject(Proyecto), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5111/Proyecto", content);

                var getResponse = await httpClient.GetAsync("http://localhost:5111/Proyecto");

                if (getResponse.IsSuccessStatusCode)
                {
                    ListaProyectos = await getResponse.Content.ReadFromJsonAsync<List<Proyecto>>();
                }
                else
                {
                    ListaProyectos = new List<Proyecto>();
                }

            }
            return RedirectToPage("/Proyectos/proyectos");


        }
    }
}


public class Proyecto
{
    public int? codProyecto { get; set; }

    public string nombre { get; set; }

    public string direccion { get; set; }

    public int estado { get; set; }

}