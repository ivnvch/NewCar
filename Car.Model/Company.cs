
namespace Car.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<CarC>? Cars { get; set; }
        
    }
}
