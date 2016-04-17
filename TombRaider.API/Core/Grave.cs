namespace TombRaider.API.Core
{
    public class Grave
    {
        public Grave()
        {
            Location = new Coordinates();
        }
        public string DateBirth { get; set; }
        public string DateBurial { get; set; }
        public string DateDeath { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Field { get; set; }
        public int? Id { get; set; }
        public int? CementaryId { get; set; }
        public int? Place { get; set; }
        public int? Quarter { get; set; }
        public int? Row { get; set; }
        public int? Size { get; set; }
        public Coordinates Location { get; set; }
    }
}