using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSalonWebApp.Pages.Components.ShowMore
{
    public class ShowMoreViewComponent : ViewComponent
    {
        public ShowMoreViewComponent() { }

        public IViewComponentResult Invoke()
        {
            var str = "CheckComponent";
            return View(model: str);
        }
    }
}
