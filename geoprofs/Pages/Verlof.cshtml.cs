using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

public class VerlofModel : PageModel
{
    private readonly YourDbContext _dbContext;

    public VerlofModel(YourDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public string Reden { get; set; }
    public string Beschrijving { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public List<VerlofEntry> SubmittedEntries { get; set; }

    public void OnGet()
    {
        // Retrieve existing entries from the database and display them
        SubmittedEntries = _dbContext.VerlofEntries.ToList();
    }

    public IActionResult OnPost()
    {
        if (ModelState.IsValid)
        {
            // Create a new entry and save it to the database
            var newEntry = new VerlofEntry
            {
                Reden = Request.Form["Reden"],
                Beschrijving = Request.Form["Beschrijving"],
                StartDate = DateTime.Parse(Request.Form["StartDate"]),
                EndDate = DateTime.Parse(Request.Form["EndDate"]),
                StartTime = TimeSpan.Parse(Request.Form["StartTime"]),
                EndTime = TimeSpan.Parse(Request.Form["EndTime"])
            };

            _dbContext.VerlofEntries.Add(newEntry);
            _dbContext.SaveChanges();
        }

        // Retrieve all entries from the database and display them
        SubmittedEntries = _dbContext.VerlofEntries.ToList();

        return Page();
    }
}
