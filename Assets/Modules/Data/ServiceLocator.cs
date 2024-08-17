using System;
using System.Collections.Generic;

namespace Common.Data
{
    public sealed class ServiceLocator
    {
        private readonly Dictionary<Type, object> _data = new();
        
        public void AddData<T>(T data)
        {
            Type type = typeof(T);
            _data.Add(type, data);
        }
        
        public void AddData(Type type, object data) 
        {
            _data.Add(type, data);
        }
        
        public T GetData<T>()
        {
            Type type = typeof(T);
            return (T) _data[type];
        }
        
        public void RemoveData<T>()
        {
            Type type = typeof(T);
            _data.Remove(type);
        }
    }
}