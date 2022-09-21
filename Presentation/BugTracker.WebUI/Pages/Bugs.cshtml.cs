using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.Entities.DTO;
using BugTracker.WebUI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BugTracker.WebUI.Pages
{
    public class BugsModel : PageModel
    {
        readonly IHttpClientHelper _client;
        public BugsModel(IHttpClientHelper client)
        {
            _client = client;
        }
        public IEnumerable<BugDTO> bugs { get; set; }

        public async Task OnGetAsync()
        {
            bugs = await _client.GetBugList();
        }
    }
}
