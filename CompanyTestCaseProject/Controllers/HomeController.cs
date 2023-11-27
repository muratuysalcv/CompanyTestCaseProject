using CompanyTestCaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Linq;

namespace CompanyTestCaseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //main list of student list.
            var ogrenciListesi = new List<Ogrenci>();
            var rootFolder = Directory.GetCurrentDirectory();
            // read file contents by line.
            var lines = System.IO.File.ReadAllLines(rootFolder + "//ogrenciler.txt");
            for (var i = 0; i < lines.Length; i += 1)
            {
                var line = lines[i];
                var ad = line.Split(" ")[0];
                int no = 0;
                int vize = 0;
                int final = 0;
                try
                {
                    // convert text to numbers and throw exception if not numeric.
                    no = Convert.ToInt32(line.Split(" ")[1]);
                    vize = Convert.ToInt32(line.Split(" ")[2]);
                    final = Convert.ToInt32(line.Split(" ")[3]);
                }
                catch (Exception ex)
                {
                    // if not numeric value
                    ad += " ERROR : ogrenci no, vize veya final notu alanlarının sayısal değer olmalıdır.";
                }
                // set values to object and added to list.
                ogrenciListesi.Add(new Ogrenci(no, ad, vize, final));
            }

            // all calculated result text in a list.
            var notlar = ogrenciListesi.Select(x => x.OgrenciYazdir());

            // join with \n for line by viewing.
            var sonucMetni = string.Join("\n", notlar);

            // return result text.
            return Content(sonucMetni);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}