using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FrontTechOil.Pages
{
    public class UsuariosModel : PageModel
    {
        public List<Usuario> ListaUsuarios { get; set; }

        public async Task OnGetAsync()
        {
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                var response = await httpClient.GetAsync("http://localhost:5111/Usuario");

                if (response.IsSuccessStatusCode)
                {
                    ListaUsuarios = await response.Content.ReadFromJsonAsync<List<Usuario>>();
                }
                else
                {
                    ListaUsuarios = new List<Usuario>();
                }
            }
        }

        public async Task<IActionResult> OnPostAsync(Usuario usuario)
        {
            using (var httpClient = new HttpClient())
            {
                string token = HttpContext.Session.GetString("BearerToken");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5111/Usuario", content);

                var getResponse = await httpClient.GetAsync("http://localhost:5111/Usuario");

                if (getResponse.IsSuccessStatusCode)
                {
                    ListaUsuarios = await getResponse.Content.ReadFromJsonAsync<List<Usuario>>();
                }
                else
                {
                    ListaUsuarios = new List<Usuario>();
                }

            }
            return RedirectToPage("/Usuarios/usuarios");


        }

    }
}

public class Usuario
{
    public int codUsuario { get; set; }

    public string nombre { get; set; }

    public int dni { get; set; }

    public int tipo { get; set; }

    public string contrasena { get; set; }
}