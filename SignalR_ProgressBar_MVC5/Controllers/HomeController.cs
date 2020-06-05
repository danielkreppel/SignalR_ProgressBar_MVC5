using Microsoft.AspNet.SignalR;
using SignalR_ProgressBar_MVC5.Service;
using SignalR_ProgressBar_MVC5.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SignalR_ProgressBar_MVC5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SimulateProcess(string signalRconnectionId)
        {
            ProcessService processService = new ProcessService();
            var context = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();
            Action<int> progressAction;
            
            progressAction = new Action<int>((progress) => context.Clients.Client(signalRconnectionId).NotifyProgress(progress));
            await processService.SimulateSomeProcess(progressAction);

            ViewBag.Finished = true;
            return View("Index");
        }
    }
}