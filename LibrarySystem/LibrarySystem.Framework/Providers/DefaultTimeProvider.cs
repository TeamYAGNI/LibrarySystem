using System;

namespace LibrarySystem.Framework.Providers
{
    public class DefaultTimeProvider : TimeProvider
    {
        public override DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public override DateTime Today
        {
            get
            {
                return DateTime.Today;
            }
        }
    }
}