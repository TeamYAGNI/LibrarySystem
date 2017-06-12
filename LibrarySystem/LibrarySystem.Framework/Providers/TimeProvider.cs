using System;
using Bytes2you.Validation;

namespace LibrarySystem.Framework.Providers
{
    public abstract class TimeProvider
    {
        private static TimeProvider current;

        static TimeProvider()
        {
            TimeProvider.current =
                new DefaultTimeProvider();
        }

        public static TimeProvider Current
        {
            get
            {
                return TimeProvider.current;
            }

            set
            {
                Guard.WhenArgument(value, "Current").IsNull().Throw();

                TimeProvider.current = value;
            }
        }
        public abstract DateTime Now { get; }

        public abstract DateTime Today { get; }

        public static void ResetToDefault()
        {
            TimeProvider.current =
                new DefaultTimeProvider();
        }
    }
}
