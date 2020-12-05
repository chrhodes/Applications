using System;

namespace PrismDemo.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RibbonPageAttribute : Attribute
    {
        public Type Type
        {
            get;
            private set;
        }

        public RibbonPageAttribute(Type ribbonPageType)
        {
            Type = ribbonPageType;
        }
    }
}
