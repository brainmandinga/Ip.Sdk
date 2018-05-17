﻿using System;

namespace Ip.Sdk.ErrorHandling.CustomExceptions
{
    public class TwoFactorValueException : Exception
    {
        public TwoFactorValueException()
            : base("Two Factor Destination Value Invalid") { }

        public TwoFactorValueException(string message)
            : base(message) { }
    }
}
