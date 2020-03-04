using System.Linq;

namespace BoolStates
{
    public class ResellerRepository
    {
        private readonly Reseller[] _resellers = new Reseller[]
        {
            new Reseller{ Id = 1, IsActive = true, },
            new Reseller{ Id = 2, IsActive = false, },
            new Reseller{ Id = 3, IsActive = true, StartDateUtc = System.DateTime.UtcNow.AddDays(-1), EndDateUtc = System.DateTime.UtcNow.AddDays(1) },
        };

        public Reseller Find(int id)
        {
            return _resellers.FirstOrDefault(r => r.Id == id);
        }
    }
}
