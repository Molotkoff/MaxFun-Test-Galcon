using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molotkoff.Galcon
{
    public class Pool<T>
    {
        private Stack<T> items = new Stack<T>();

        private Func<T> generator;

        public Pool(Func<T> generator)
        {
            this.generator = generator;
        }

        public T Item
        {
            get => items.Count > 0 ? items.Pop() : generator();
            set => items.Push(value);
        }
    }
}