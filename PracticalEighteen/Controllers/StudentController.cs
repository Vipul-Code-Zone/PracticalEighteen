using Microsoft.AspNetCore.Mvc;
using PracticalEighteen.Models.ViewModels;
using System.Net;

namespace PracticalEighteen.Controllers
{
    public class StudentController : Controller
    {
        private readonly HttpClient _httpClient;
        public StudentController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("studentApi");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _httpClient.GetFromJsonAsync<IEnumerable<StudentModel>>("Student");
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            StudentModel? student = await _httpClient.GetFromJsonAsync<StudentModel>($"Student/{id}");
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentModel studentModel)
        {
            var result = await _httpClient.PostAsJsonAsync("Student", studentModel);
            if (result.StatusCode == HttpStatusCode.Created)
            {
                return RedirectToAction("Index", "Student");

            }
            ModelState.AddModelError("", "Data can't added Try again!");
            return View(studentModel);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            StudentModel? student = await _httpClient.GetFromJsonAsync<StudentModel>($"Student/{id}");
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentModel model)
        {

            var result = await _httpClient.PutAsJsonAsync($"Student/{model.Id}", model);

            if (result.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            StudentModel? student = await _httpClient.GetFromJsonAsync<StudentModel>($"Student/{id}");
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, StudentModel model)
        {
            var result = await _httpClient.DeleteAsync($"Student/{id}");

            if (result.StatusCode == HttpStatusCode.NotFound)
            {
                ModelState.AddModelError("", "Model is not found or already deleted!");
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

    }
}
