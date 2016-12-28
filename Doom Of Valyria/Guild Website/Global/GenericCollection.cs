using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using GuildWars2.API;

namespace GuildWebsite.Global
{
    public class GenericCollection<U, T> where T : class, new()
    {
        private readonly Dictionary<U, T> _collection;

        private readonly Func<U, T> _function;

        private object thisLock = new object();

        public GenericCollection(Func<U, T> function)
        {
            _collection = new Dictionary<U, T>();

            _function = function;
        }

        public T this[U id]
        {
            get
            {
                if (!_collection.ContainsKey(id))
                {
                    using (var api = new GuildWars2API())
                    {
                        var item = _function(id);

                        if (!_collection.ContainsKey(id))
                        {
                            lock (thisLock)
                            {
                                if (!_collection.ContainsKey(id))
                                {
                                    _collection[id] = item;
                                }
                            }
                        }
                    }
                }

                return _collection[id];
            }
        }
    }
}