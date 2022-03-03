using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL.dbo;

namespace WebApp.Pages.Parametro
{
    public class GridModel : PageModel
    {
        private readonly IParametroService parametroService;
        public GridModel(IParametroService parametroService)
        {
            this.parametroService = parametroService;
        }

        public IEnumerable<ParametroEntity> GridList { get; set; } = new List<ParametroEntity>();
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await parametroService.Get();
                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnGetEliminar(int id)
        {
            try
            {
                var result = await parametroService.Delete(new() 
                {
                    Id_Parametro = id
                }                
                );

                return Redirect("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
    }
}
