namespace JobSearch_Grupo7.Models
{
    public class Search
    {
        public string? descriptionWords { get; set; }
        public string? ubication { get; set; }
        public string? type { get; set; }
        public int salary { get; set; }
        public int experience { get; set; }

        public Search(string? descriptionWords, string? ubication, string? type, int salary, int experience)
        {
            this.descriptionWords = descriptionWords;
            this.ubication = ubication;
            this.type = type;
            this.salary = salary;
            this.experience = experience;
        }

        public Search()
        {
        }
    }
}
