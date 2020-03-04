using System;

namespace BoolStates
{
    public class ResellerValidator
    {
        private readonly ResellerRepository _resellerRepository;
        private readonly SystemClock _clock;

        public ResellerValidator(
            ResellerRepository resellerRepository,
            SystemClock clock
        )
        {
            _resellerRepository = resellerRepository;
            _clock = clock;
        }

        public ResellerActiveState ResellerIsActive(int resellerId)
        {
            var reseller = _resellerRepository.Find(resellerId);
            reseller.CheckReferenceIsNull($"Reseller {resellerId} not found.");

            return ResellerIsActive(reseller);
        }

        public ResellerActiveState ResellerIsActive(Reseller reseller)
        {
            reseller.CheckArgumentIsNull(nameof(reseller));

            if (!reseller.IsActive)
                return ResellerActiveState.Disabled;

            if (reseller.StartDateUtc > _clock.UtcNow)
                return ResellerActiveState.StartDateNotReached;

            if (reseller.EndDateUtc <= _clock.UtcNow)
                return ResellerActiveState.EndDatePassed;

            return ResellerActiveState.Active;
        }

        public bool ValidateResellerIsActive(int resellerId)
        {
            var reseller = _resellerRepository.Find(resellerId);
            reseller.CheckReferenceIsNull($"Reseller {resellerId} not found.");

            return ValidateResellerIsActive(reseller);
        }

        public bool ValidateResellerIsActive(Reseller reseller)
        {
            reseller.CheckArgumentIsNull(nameof(reseller));
            var result = ResellerIsActive(reseller);

            if (result == ResellerActiveState.Disabled)
                throw new InvalidOperationException($"Reseller {reseller.Id} is not active.");

            if (result == ResellerActiveState.StartDateNotReached)
                throw new InvalidOperationException($"Reseller {reseller.Id} is not active. StartDate has not been reached.");

            if (result == ResellerActiveState.EndDatePassed)
                throw new InvalidOperationException($"Reseller {reseller.Id} is not active. EndDate has passed.");

            if (result != ResellerActiveState.Active)
                throw new InvalidOperationException($"Reseller {reseller.Id} is not active.");

            return true;
        }
    }
}
