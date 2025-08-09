using Interfaces.Entities;

namespace Models.Entities
{
    public class Company : ICompany
    {
        public int Id { get ; set ; }
        public string Name { get; set; }
    }
}
