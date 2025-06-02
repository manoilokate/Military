using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PersonalRecords.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
       public IActionResult Profile() => View();
        
    }
}
