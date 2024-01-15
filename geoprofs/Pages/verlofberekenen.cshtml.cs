using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace geoprofs.Pages
{
    public class verlofberekenenModel : PageModel
    {
        [BindProperty]
        public int UrenPerWeek { get; set; }

        public int WettelijkeVakantieUren { get; private set; }

        public void OnPost()
        {
            // Code die wordt uitgevoerd wanneer het formulier wordt ingediend
            // Bereken wettelijk aantal vakantie-uren (4 keer het aantal gewerkte uren per week)
            WettelijkeVakantieUren = UrenPerWeek * 4;
        }

        public int BerekenAantalVakantieDagen()
        {
            // Aannemen dat een fulltime werkweek 40 uur is
            int fulltimeUrenPerWeek = 40;

            // Aannemen dat een standaard werkdag 8 uur is
            int standaardUrenPerDag = 8;

            // Bereken het aantal vakantiedagen op basis van het aantal gewerkte uren per week
            int aantalVakantieDagen = WettelijkeVakantieUren / standaardUrenPerDag;

            return aantalVakantieDagen;
        }
    }
}
