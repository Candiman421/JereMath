using System;

namespace JereMath.Library.JereMath
{
    public class TopBottom<V, T>
    {
        public T Top { get; set; }
        public V Bottom { get; set; }

        public TopBottom(T t, V v)
        {
            Top = t;
            Bottom = v;
        }
    }
}
