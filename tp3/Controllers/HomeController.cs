using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using tp3.Models;
using System.Data.SQLite;

namespace tp3.Controllers
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
            /*SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=C:\\Users\\LENOVO\\Downloads\\2022 GL3 .NET Framework TP3 - SQLite database.db;");
            sQLiteConnection.Open();
            using (sQLiteConnection)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info",sQLiteConnection);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string first_name = (string)reader["first_name"];
                        string last_name = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];
                        Debug.WriteLine("id = {0}, first_name= {1}, last_name= {2}, email= {3},image = {4}, country= {5}", id, first_name, last_name, email,image, country);
                    }
                }
            }*/
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/Person/All")]
        public IActionResult allPerson()
        {
            PersonalInfo personalInfo = new PersonalInfo();
            List<Person> list = personalInfo.GetAllPerson();
            Debug.WriteLine("all persons entred");
            return View(list);
        }

        [Route("/Person/{id}")]
        public IActionResult person(int id)
        {
            PersonalInfo personalInfo = new PersonalInfo();
            Person person = personalInfo.getPerson(id);
            return View(person);
        }
        
        [HttpGet]
        public IActionResult search()
        {
            Debug.WriteLine("search 1 entred");
            ViewBag.notFound = false;
            return View();
        }

        [HttpPost]
        public IActionResult search(String firstName, String country)
        {
            Debug.WriteLine("search 2 entred");
            PersonalInfo personal_info = new PersonalInfo();
            List<Person> personal__info = personal_info.GetAllPerson();
            Debug.WriteLine(firstName);
            Debug.WriteLine(country);
            foreach (Person person in personal__info)
            {
                if (person.firstName == firstName && person.country == country)
                {
                    Debug.WriteLine("if entred");
                    return Redirect($"/Person/{person.id.ToString()}");
                }
            }
            ViewBag.notFound = true;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}