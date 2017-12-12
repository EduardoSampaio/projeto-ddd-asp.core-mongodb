using System;
using System.Text.RegularExpressions;

namespace Controle.Imobilizado.Infra.Crosscutting.AssertionConcern
{
    public class AssertionConcern
    {
        public static void AssertArgumentEquals(object object1, object object2, string message)
            => AssertArgumentEquals<DomainException>(object1, object2, message);

        public static void AssertArgumentFalse(bool boolValue, string message)
            => AssertArgumentFalse<DomainException>(boolValue, message);

        public static void AssertArgumentLength(string stringValue, int maximum, string message)
            => AssertArgumentLength<DomainException>(stringValue, maximum, message);

        public static void AssertArgumentLength(string stringValue, int minimum, int maximum, string message)
            => AssertArgumentLength<DomainException>(stringValue, minimum, maximum, message);

        public static void AssertArgumentMatches(string pattern, string stringValue, string message)
            => AssertArgumentMatches<DomainException>(pattern, stringValue, message);

        public static void AssertArgumentNotEmpty(string stringValue, string message)
            => AssertArgumentNotEmpty<DomainException>(stringValue, message);

        public static void AssertArgumentNotEquals(object object1, object object2, string message)
            => AssertArgumentNotEquals<DomainException>(object1, object2, message);

        public static void AssertArgumentNotNull(object object1, string message)
            => AssertArgumentNotNull<DomainException>(object1, message);

        public static void AssertArgumentRange(double value, double minimum, double maximum, string message)
            => AssertArgumentRange<DomainException>(value, minimum, maximum, message);

        public static void AssertArgumentRange(float value, float minimum, float maximum, string message)
            => AssertArgumentRange<DomainException>(value, minimum, maximum, message);

        public static void AssertArgumentRange(int value, int minimum, int maximum, string message)
            => AssertArgumentRange<DomainException>(value, minimum, maximum, message);

        public static void AssertArgumentRange(long value, long minimum, long maximum, string message)
            => AssertArgumentRange<DomainException>(value, minimum, maximum, message);

        public static void AssertArgumentTrue(bool boolValue, string message)
            => AssertArgumentTrue<DomainException>(boolValue, message);

        public static void AssertStateFalse(bool boolValue, string message)
            => AssertStateFalse<DomainException>(boolValue, message);

        public static void AssertStateTrue(bool boolValue, string message)
            => AssertStateTrue<DomainException>(boolValue, message);

        public static void AssertArgumentEnumRange<TEnum>(TEnum value, string message)
            => AssertArgumentEnumRange<DomainException, TEnum>(value, message);

        public static void AssertArgumentEquals<TException>(object object1, object object2, string message)
            where TException : Exception
        {
            if (!object1.Equals(object2))
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertArgumentFalse<TException>(bool boolValue, string message) where TException : Exception
        {
            if (boolValue)
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertArgumentLength<TException>(string stringValue, int maximum, string message)
            where TException : Exception
        {
            var length = stringValue.Trim().Length;
            if (length > maximum)
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertArgumentLength<TException>(string stringValue, int minimum, int maximum, string message)
            where TException : Exception
        {
            if (string.IsNullOrEmpty(stringValue))
                stringValue = string.Empty;

            var length = stringValue.Trim().Length;
            if (length < minimum || length > maximum)
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertArgumentMatches<TException>(string pattern, string stringValue, string message)
            where TException : Exception
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(stringValue))
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertArgumentNotEmpty<TException>(string stringValue, string message)
            where TException : Exception
        {
            if (stringValue == null || stringValue.Trim().Length == 0)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }

        public static void AssertArgumentNotEquals<TException>(object object1, object object2, string message)
            where TException : Exception
        {
            if (object1.Equals(object2))
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertArgumentNotNull<TException>(object object1, string message)
            where TException : Exception
        {
            if (object1 == null)
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertArgumentRange<TException>(double value, double minimum, double maximum, string message)
            where TException : Exception
        {
            if (value < minimum || value > maximum)
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertArgumentRange<TException>(float value, float minimum, float maximum, string message)
            where TException : Exception
        {
            if (value < minimum || value > maximum)
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertArgumentRange<TException>(int value, int minimum, int maximum, string message)
            where TException : Exception
        {
            if (value < minimum || value > maximum)
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertArgumentRange<TException>(long value, long minimum, long maximum, string message)
            where TException : Exception
        {
            if (value < minimum || value > maximum)
                throw new InvalidOperationException(message);
            throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertArgumentTrue<TException>(bool boolValue, string message) where TException : Exception
        {
            if (!boolValue)
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertStateFalse<TException>(bool boolValue, string message) where TException : Exception
        {
            if (boolValue)
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertStateTrue<TException>(bool boolValue, string message) where TException : Exception
        {
            if (!boolValue)
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        public static void AssertArgumentEnumRange<TException, TEnum>(TEnum value, string message)
            where TException : Exception
        {
            if (!Enum.IsDefined(typeof(TEnum), value))
                throw (TException)Activator.CreateInstance(typeof(TException), message);
        }
    }
}