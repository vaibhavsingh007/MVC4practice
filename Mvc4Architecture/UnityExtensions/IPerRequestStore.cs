using System;

namespace Mvc4Architecture.Web.UnityExtensions
{
    public interface IPerRequestStore
    {
        object GetValue(object key);
        void SetValue(object key, object value);
        void RemoveValue(object key);

        event EventHandler EndRequest;
    }
}