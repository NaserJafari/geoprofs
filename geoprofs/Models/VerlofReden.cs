using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

public class VerlofReden 
{
    
    public List<SelectListItem> VerlofRedenList { get; set; }

    public void OnGet()
    {
        
        VerlofRedenList = new List<SelectListItem>
        {
            new SelectListItem { Value = "Sick", Text = "Sick" },
            new SelectListItem { Value = "Vacation", Text = "Vacation" },
            
        };

   }
}