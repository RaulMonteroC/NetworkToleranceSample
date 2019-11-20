using System;

namespace NetworkTolerance.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    sealed class UrlAttribute : Attribute
    {
        public string Url { get; }

        public UrlAttribute(string url)
        {
            Url = url;
        }
    }
}