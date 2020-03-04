using static System.Console;

namespace BoolStates
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var repo = new ResellerRepository();
            var clock = new SystemClock();
            var validator = new ResellerValidator(repo, clock);

            WriteLine(ResellerActiveState.EndDatePassed == ResellerActiveState.EndDatePassed);
            WriteLine(ResellerActiveState.EndDatePassed != ResellerActiveState.EndDatePassed);
            WriteLine(ResellerActiveState.EndDatePassed == ResellerActiveState.Active);
            WriteLine(ResellerActiveState.EndDatePassed != ResellerActiveState.Active);

            if (validator.ResellerIsActive(resellerId: 3))
                validator.ValidateResellerIsActive(resellerId: 2);
        }
    }
}
