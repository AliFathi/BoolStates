namespace BoolStates
{
    public struct ResellerActiveState
    {
        public static ResellerActiveState Active => new ResellerActiveState(State.Active);

        public static ResellerActiveState Disabled => new ResellerActiveState(State.Disabled);

        public static ResellerActiveState StartDateNotReached => new ResellerActiveState(State.StartDateNotReached);

        public static ResellerActiveState EndDatePassed => new ResellerActiveState(State.EndDatePassed);

        #region Helpers

        private readonly State _state;

        private ResellerActiveState(State state)
        {
            _state = state;
        }

        public static bool operator ==(ResellerActiveState a, ResellerActiveState b)
        {
            return a._state == b._state;
        }

        public static bool operator !=(ResellerActiveState a, ResellerActiveState b)
        {
            return a._state != b._state;
        }

        public static implicit operator bool(ResellerActiveState result)
        {
            return result._state == default;
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is ResellerActiveState result)
                return _state.Equals(result._state);

            return false;
        }

        public override int GetHashCode()
        {
            return _state.GetHashCode();
        }

        private enum State
        {
            Active,
            Disabled,
            StartDateNotReached,
            EndDatePassed,
        }

        #endregion
    }
}
