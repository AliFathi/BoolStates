namespace BoolStates
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Throws a <see cref="System.ArgumentNullException"/>.
        /// </summary>
        /// <param name="arg">arg to check</param>
        /// <param name="paramName"></param>
        public static void CheckArgumentIsNull(this object arg, string paramName)
        {
            if (arg == null)
                throw new System.ArgumentNullException(paramName);
        }

        /// <summary>
        /// Throws a <see cref="System.ArgumentNullException"/> with supplied message.
        /// </summary>
        /// <param name="arg">arg to check</param>
        /// <param name="paramName"></param>
        /// <param name="message"></param>
        public static void CheckArgumentIsNull(this object arg, string paramName, string message)
        {
            if (arg == null)
                throw new System.ArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Throws a <see cref="System.NullReferenceException"/> with supplied message.
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <param name="message">Exception message</param>
        public static void CheckReferenceIsNull(this object obj, string message)
        {
            if (obj == null)
                throw new System.NullReferenceException(message);
        }
    }
}
