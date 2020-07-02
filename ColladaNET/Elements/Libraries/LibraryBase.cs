using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColladaNET.Elements
{

    public abstract class LibraryBase : LibraryItemBase
    { }
    public abstract class LibraryBase<T> : LibraryBase where T : LibraryItemBase
    {
        protected List<T> _items = new List<T>();

        [XmlIgnore()]
        public List<T> items
        { get { return this._items; } }

        public T this[int index]
        { get { return items[index]; } }
        public int Count
        { get { return items.Count; } }


        // constructors
        public LibraryBase()
        { }
        public LibraryBase(string id, string name)
        {
            this.id = id;
            this.name = name;
        }



        public T FindByID(string id)
        { return _items.Find((x) => x.id.Equals(id)); }
        public T FindByURL(string url)
        {
            url = url.TrimStart('#');
            return _items.Find((x) => x.id.Equals(url));
        }
        public T FindByName(string name)
        { return _items.Find((x) => x.name.Equals(name)); }





        // Enumerable/Enumerator implementation
        public class Enumerable : IEnumerable<T>
        {
            private LibraryBase<T> _library;

            private Enumerable(LibraryBase<T> library)
            { _library = library; }

            public static implicit operator Enumerable(LibraryBase<T> library)
            { return new Enumerable(library); }

            // Must implement GetEnumerator, which reta new StreamReaderEnumerator.
            public IEnumerator<T> GetEnumerator()
            { return new Enumerator(_library); }
            // Must also implement IEnumerable.GetEnumerator, but implement as a private method.
            private IEnumerator GetEnumerator1()
            { return this.GetEnumerator(); }
            IEnumerator IEnumerable.GetEnumerator()
            { return GetEnumerator(); }

        }
        public class Enumerator : IEnumerator<T>
        {
            private int _index = 0;
            private T _current;
            private LibraryBase<T> _library;

            public Enumerator(LibraryBase<T> library)
            { _library = library; }

            public T Current
            {
                get
                {
                    if (_library == null || _current == null)
                        throw new InvalidOperationException();
                    return _current;
                }
            }

            private object InnerCurrent
            { get { return this.Current; } }

            object IEnumerator.Current
            {
                get { return InnerCurrent; }
            }

            // Implement MoveNext and Reset, which are required by IEnumerator.
            public bool MoveNext()
            {
                if (_index == _library.Count)
                    return false;

                _current = _library[_index++];
                return true;
            }

            public void Reset()
            {
                _index = 0;
                _current = default(T);
            }

            public void Dispose()
            {
                _library = null;
            }

        }

    }

}