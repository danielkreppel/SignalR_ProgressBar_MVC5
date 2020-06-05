using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SignalR_ProgressBar_MVC5.Service
{
    public class ProcessService
    {
        public async Task<bool> SimulateSomeProcess(Action<int> notifyProgressAction)
        {
            int i = 0;
            while (++i <= 100)
            {
                await Task.Delay(200)
                    .ContinueWith((t) => {
                        if (!t.IsFaulted)
                        {
                            notifyProgressAction(i);
                        }
                    });
            }

            return true;
        }
    }
}