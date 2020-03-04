using System;

namespace BoolStates
{
    public class Reseller
    {
        public int Id { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }
        public bool IsActive { get; set; }
    }
}
