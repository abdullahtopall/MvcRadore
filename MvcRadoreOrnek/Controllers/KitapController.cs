using Microsoft.AspNetCore.Mvc;
using MvcRadoreOrnek.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MvcRadoreOrnek.Controllers
{
    public class KitapController : Controller
    {
        public async  Task<IActionResult> Index()
        {
            List<Kitap> kitapList = new List<Kitap>();
            //gideceğimiz adresi yazdık:
            using (var httpClient = new HttpClient())
            {
                using (var gelenYanit = await httpClient.GetAsync("https://localhost:7115/kitap/getall"))
                {
                    string gelenString = await gelenYanit.Content.ReadAsStringAsync();
                    kitapList = JsonConvert.DeserializeObject<List<Kitap>>(gelenString);
                }
            }
                return View(kitapList);
        }

        [HttpGet]
        public async Task<IActionResult> GetKitap(int id)
        {
            Kitap gelenKitapDetay = new Kitap();
            using (var httpClient = new HttpClient())
            {
                using (var gelenYanit = await httpClient.GetAsync("https://localhost:7115/api/Kitap/"+id))
                {
                    string gelenKitapDetayString = await gelenYanit.Content.ReadAsStringAsync();
                    gelenKitapDetay = JsonConvert.DeserializeObject<Kitap>(gelenKitapDetayString);
                }
            }
            return View(gelenKitapDetay);
        }

        public ViewResult addBook() => View();
        /* Üstteki ile aşağıda yazdığımız fonksiyon aynı fonksiyon
        public ViewResult addBook()
        {
            return View();
        }
        */
        [HttpPost]
        public async Task<IActionResult> addBook(Kitap kitap)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent serializeEdilecekFilm = new StringContent(JsonConvert.SerializeObject(kitap),
                        Encoding.UTF8,
                        "application/json");
                    using (var response = await httpClient.PostAsync("https://localhost:7115/kitap/add", serializeEdilecekFilm))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            //işlem başarılı mesajını göster
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            Kitap kitap = null;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (var gelenYanit = await httpClient.GetAsync($"https://localhost:7115/kitap/update/{id}"))
                    {
                        if (gelenYanit.StatusCode == HttpStatusCode.OK)
                        {
                            string gelenString = await gelenYanit.Content.ReadAsStringAsync();
                            kitap = JsonConvert.DeserializeObject<Kitap>(gelenString);
                        }
                        else
                        {
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return View(kitap);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Kitap kitap)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent serializeEdilecekKitap = new StringContent(JsonConvert.SerializeObject(kitap), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"https://localhost:7115/kitap/update/{kitap.Id}", serializeEdilecekKitap))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync($"https://localhost:7115/kitap/delete/{id}"))
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                        }
                        else
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return RedirectToAction("Index");
        }


    }
}
