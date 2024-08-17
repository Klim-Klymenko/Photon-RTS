using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Data
{
    public sealed class Entity : MonoBehaviour, IEntity
    {
        private readonly Dictionary<Type, object> _scripts = new();

        public bool TryGetScript<T>(out T component)
        {
            Type type = typeof(T);

            if (_scripts.TryGetValue(type, out object script))
            {
                component = (T)script;
                return true;
            }
                
            component = default;
            return false;
        }

        public T GetScript<T>()
        {
            Type type = typeof(T);
            return (T)_scripts[type];
        }

        public void AddScript<T>(T script)
        {
            Type type = script.GetType();
            _scripts.Add(type, script);
        }

        public bool HasScript<T>()
        {
            Type type = typeof(T);
            return _scripts.TryGetValue(type, out object script);
        }
    }
}