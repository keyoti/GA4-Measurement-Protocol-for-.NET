using System;

namespace Keyoti.GA4
{
    public class MeasurementParameter
    {
        private readonly int MAXIMUM_NAME_LENGTH = 40;
        private readonly int MAXIMUM_VALUE_LENGTH = 100;

        public MeasurementParameter(string name, dynamic value)
        {
            if (name.Length > MAXIMUM_NAME_LENGTH)
            {
                throw new ApplicationException($"Parameter name {name} is too long, maximum length per GA4 protocol is {MAXIMUM_NAME_LENGTH}.");
            }
            if (value is string && value.Length > MAXIMUM_VALUE_LENGTH)
            {
                throw new ApplicationException($"Parameter value {value} is too long, maximum length per GA4 protocol is {MAXIMUM_VALUE_LENGTH}.");
            }
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public dynamic Value { get; }
    }
}