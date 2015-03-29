﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Granular.Collections
{
    public class ReadOnlyStack<T>
    {
        public bool IsEmpty { get; private set; }

        private IEnumerator<T> enumerator;

        public ReadOnlyStack(IEnumerable<T> source)
        {
            this.enumerator = source.GetEnumerator();

            MoveNext();
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new Granular.Exception("Stack is empty");
            }

            T current = enumerator.Current;

            MoveNext();

            return current;
        }

        public T Peek()
        {
            if (IsEmpty)
            {
                throw new Granular.Exception("Stack is empty");
            }

            return enumerator.Current;
        }

        private void MoveNext()
        {
            IsEmpty = !enumerator.MoveNext();
        }
    }
}
