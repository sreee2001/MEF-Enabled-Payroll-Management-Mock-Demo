using Interfaces.Entities;

namespace Models.Entities
{
    public class State : IState
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
