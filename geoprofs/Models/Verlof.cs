namespace geoprofs.Models
{

    public class Verlof
    {
        public int VerlofId { get; set; }
        public int VerlofReden { get; set; }
        public string VerlofOmschrijving { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BeginVerlof { get; set; }
        public DateTime EindVerlof { get; set; }
        public int VerlofResterend { get; set; }
        public string rol { get; set; }
        public int VerlofStatus { get; set; }
    }
}