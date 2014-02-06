using System;
using System.Collections.Generic;

namespace Shuttle.Core.Infrastructure
{
    public class ReusableObjectPool<TReusableObject>
        where TReusableObject : class
    {
        private static readonly object padlock = new object();
        private readonly Dictionary<Type, List<TReusableObject>> pool = new Dictionary<Type, List<TReusableObject>>();
        private readonly Func<Type, TReusableObject> createObject;

        public ReusableObjectPool()
        {
        }

        public ReusableObjectPool(Func<Type, TReusableObject> createObject)
        {
            this.createObject = createObject;
        }

        public TReusableObject Get(Type key)
        {
            Guard.AgainstNull(key, "key");

            lock (padlock)
            {
                if (!pool.ContainsKey(key))
                {
                    pool.Add(key, new List<TReusableObject>());
                }

                if (pool.Count > 0)
                {
                    var reusableObjects = pool[key];

                    if (reusableObjects.Count > 0)
                    {
                        var reusableObject = reusableObjects[0];

                        reusableObjects.RemoveAt(0);

                        return reusableObject;
                    }
                }

                return createObject == null ? null : createObject(key);
            }
        }

        public void Release(TReusableObject instance)
        {
            lock (padlock)
            {
                if (!pool.ContainsKey(instance.GetType()))
                {
                    pool.Add(instance.GetType(), new List<TReusableObject>());
                }

                pool[instance.GetType()].Add(instance);
            }
        }
    }
}