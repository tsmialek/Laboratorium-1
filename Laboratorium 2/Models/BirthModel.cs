namespace Laboratorium_2.Models
{
    public class BirthModel
    {
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }

        public bool IsValid()
        {
            return (BirthDate != null && Name != null) && BirthDate < DateTime.Now;
        }

        public int CalculateAge() => (DateTime.Now - BirthDate).Days / 365;

    }
}
