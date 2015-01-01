using System;

namespace scratchAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TestDescriptionAttribute : Attribute
    {
        public string Description { get; private set; }

        public TestDescriptionAttribute(string description)
        {
            Description = description ?? string.Empty;
        }
    }

    
    
}
