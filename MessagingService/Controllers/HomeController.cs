using MessageService.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MessagingService.Controllers
{

    public class HomeController : Controller
    {
        private readonly IMessageRepository _MessageRepository;
        private readonly IUserRepository _UserRepository;

        public HomeController(IMessageRepository MessageRepository, IUserRepository UserRepository)
        {
            _MessageRepository = MessageRepository;
            _UserRepository = UserRepository;
        }

        [Route("Home")]
        [Route("Home/Index")]
        public IActionResult Index()
        {       
            //ViewData["Message"]  = _MessageRepository.CustomerMessages(customerID);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
