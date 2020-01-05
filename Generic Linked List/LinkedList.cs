using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Author: Ing.Computer José Manuel Mc Langhlin Matienzo.
/// Email:  mclanghlin@gmail.com.
/// Study Center: University of Cienfuegos,Cuba.  
namespace Generic_Linked_List
{   
    /// <summary>
    /// Represents a simple LinkedList.
    /// </summary>
    /// <typeparam name="T">Specifies the element type of the linked list.</typeparam>
    public class LinkedList<T> : System.Collections.Generic.IEnumerable<T>, ICloneable where T : IComparable<T>, IEquatable<T>
    {
        private int size;
        private LinkedListNode head;

        /// <summary>
        /// Initializes a new instance of the LinkedList class that is empty
        /// </summary>
        public LinkedList()
        {
            this.size = 0;
            this.head = null;
        }

        /// <summary>
        /// Initializes a new instance of the LinkedList class that contains elements copied from the specified IEnumerable and has sufficient capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="list">The IEnumerable whose elements are copied to the new LinkedList.</param>    
        /// <exception cref="System.ArgumentNullException"></exception>
        public LinkedList(System.Collections.Generic.IEnumerable<T> list)
            : this()
        {
            if (list == null) { throw new ArgumentNullException(); }
            this.AddRange(list);
        }

        /// <summary>
        /// Gets the number of nodes actually contained in the LinkedList.
        /// </summary>
        public int Count
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// Gets the first node of the LinkedList.
        /// </summary>
        public LinkedListNode Firt
        {
            get { return head; }
        }

        /// <summary>
        /// Gets the last node of the LinkedList.
        /// </summary>
        public LinkedListNode Last
        {
            get { return this.getNode(this.size - 1); }
        }

        /// <summary>
        /// Gets ors Sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get.</param>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public T this[int index]
        {
            get
            {
                try
                {
                    return this.getNode(index).Data;
                }
                catch (IndexOutOfRangeException) { throw new InvalidOperationException(); }
            }
            set
            {
                try
                {
                    this.setNode(index, value);
                }
                catch (IndexOutOfRangeException) { throw new InvalidOperationException(); }
            }
        }

        /// <summary>
        /// Returns true if this list contains no elements. 
        /// </summary>
        /// <returns>Returns true if this list contains no elements.</returns>
        public bool IsEmpty()
        {
            return this.size == 0;
        }

        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which the new elements should be inserted.</param>
        /// <param name="collection">The collection whose elements should be inserted into the List. The collection itself cannot benull, but it can contain elements that arenull, if typeT is a reference type.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void InsertRange(int index, System.Collections.Generic.IEnumerable<T> collection)
        {
            if (this.IsIndexOutOfBounds(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (collection == null)
            {
                throw new ArgumentNullException();
            }
            T[] arr = collection.ToArray(); int count = index;
            foreach (var item in arr)
            {
                this.Add(count++, item);
            }
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire List.
        /// </summary>
        /// <param name="item">The object to locate in the List. The value can benull for reference types.</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire List, if found; otherwise, –1.</returns>
        public int IndexOf(T item)
        {
            int index = -1, counter = 0;
            if (!this.IsEmpty())
            {
                LinkedListNode current = this.head;
                while (current != null)
                {
                    if (current.Data.Equals(item))
                    {
                        index = counter;
                        break;
                    }
                    current = current.Next;
                    counter++;
                }
            }
            return index;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the range of elements in the List that extends from the specified index to the last element.
        /// </summary>
        /// <param name="item">The object to locate in the List. The value can benull for reference types.</param>
        /// <param name="index">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <returns>The zero-based index of the first occurrence of item within the range of elements in the List that extends fromindex to the last element, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int IndexOf(T item, int index)
        {
            if (this.IsIndexOutOfBounds(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            int tmp = -1, i = index;
            for (LinkedListNode current = getNode(index); current != null; current = current.Next, i++)
            {
                if (current.Data.CompareTo(item) == 0)
                    return tmp = i;
            }
            return tmp;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the range of elements in the Lists that starts at the specified index and contains the specified number of element.
        /// </summary>
        /// <param name="item">The object to locate in the List. The value can benull for reference types.</param>
        /// <param name="index">The zero-based starting index of the search. 0 (zero) is valid in an empty list.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The zero-based index of the first occurrence of item within the range of elements in the List that starts atindex and contains count number of elements, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int IndexOf(T item, int index, int count)
        {
            if (this.IsIndexOutOfBounds(index) || this.IsIndexOutOfBounds(count))
            {
                throw new ArgumentOutOfRangeException();
            }
            int tmp = -1, i = index;
            for (LinkedListNode current = getNode(index); current != null; current = current.Next, i++)
            {
                if (index <= count)
                {
                    if (current.Data.CompareTo(item) == 0)
                        return tmp = i;
                }
            }
            return tmp;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the last occurrence within the entire List.
        /// </summary>
        /// <param name="item">The object to locate in the List. The value can benull for reference types.</param>
        /// <returns>The zero-based index of the last occurrence of item within the entire the List, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public int LastIndexOf(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            int index = -1, counter = 0;
            if (!this.IsEmpty())
            {
                LinkedListNode current = this.head;
                while (current != null)
                {
                    if (current.Data.CompareTo(item) == 0)
                        index = counter;
                    current = current.Next;
                    counter++;
                }
            }
            return index;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the last occurrence within the range of elements in the LinkedList that extends from the first element to the specified index.
        /// </summary>
        /// <param name="item">The object to locate in the LinkedList. The value can benull for reference types.</param>
        /// <param name="index">The zero-based starting index of the backward search.</param>
        /// <returns>The zero-based index of the last occurrence of item within the range of elements in the List that extends from the first element toindex, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int LastIndexOf(T item, int index)
        {
            if (this.IsIndexOutOfBounds(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            int tmp = -1, i = 0;
            for (LinkedListNode current = this.head; current != null; current = current.Next, i++)
            {
                if (!(i > index))
                {
                    if (current.Data.Equals(item))
                        tmp = i;
                }
            }            
            return tmp;
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire List
        /// </summary>
        /// <param name="predicate">The Predicate delegate that defines the conditions of the element to search for</param>
        /// <returns>The first element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type T.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>        
        public T Find(System.Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException();
            }
            if (!this.IsEmpty())
            {
                for (LinkedListNode current = this.head; current != null; current = current.Next)
                {
                    if (predicate(current.Data))
                        return current.Data;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Retrieves all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="predicate">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>A List containing all the elements that match the conditions defined by the specified predicate, if found; otherwise, an empty List.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>   
        public LinkedList<T> FindAll(System.Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException();
            }
            LinkedList<T> list = null;
            if (!this.IsEmpty())
            {
                list = new LinkedList<T>();
                for (LinkedListNode current = this.head; current != null; current = current.Next)
                {
                    if (predicate(current.Data))
                        list.Add(current.Data);
                }
            }                         
            return list;
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the last occurrence within the entire List.
        /// </summary>
        /// <param name="predicate">The Predicate delegate that defines the conditions of the element to search for.</param>
        /// <returns>The last element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type T. </returns>
        /// <exception cref="System.ArgumentNullException"></exception>        
        public T FindLast(System.Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException();
            }
            T find = default(T);
            if (!this.IsEmpty())
            {
                for (LinkedListNode current = this.head; current != null; current = current.Next)
                {
                    if (predicate(current.Data))
                        find = current.Data;
                }
            }
            return find;
        }

        /// <summary>
        /// Finds the last node that contains the specified value.
        /// </summary>
        /// <param name="item">The value to locate in the LinkedList.</param>
        /// <returns>The last LinkedListNode that contains the specified value, if found; otherwise,null.</returns>
        public LinkedListNode FindLast(T item)
        {
            int counter = 0; LinkedListNode find = null;
            if (!this.IsEmpty())
            {
                LinkedListNode current = this.head;
                while (current != null)
                {
                    if (current.Data.Equals(item))
                    {
                        find = this.getNode(counter);
                    }
                    current = current.Next;
                    counter++;
                }
            }
            return find;
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the entire List.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the element to search for.</param>
        /// <returns>The zero-based index of the last occurrence of an element that matches the conditions defined by match, if found; otherwise, –1.</returns>
        public int FindLastIndex(System.Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException();
            }
            int index = -1, i = 0;
            if (!this.IsEmpty())
            {
                for (LinkedListNode current = this.head; current != null; current = current.Next, i++)
                {
                    if (predicate(current.Data))
                        index = i;
                }
            }
            return index;
        }

        /// <summary>
        /// Adds an object to the end of the LinkeList.
        /// </summary>
        /// <param name="item">The object to be added to the end of the List. The value can benull for reference types.</param>
        public void Add(T item)
        {
            LinkedListNode node = new LinkedListNode(item);
            if (head == null)
                this.head = node;
            else { this.Last.Next = node; }
            this.size++;
        }

        /// <summary>
        /// Adds an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void Add(int index, T item)
        {
            if (this.IsIndexOutOfBounds(index))
                throw new IndexOutOfRangeException();
            
            if (item == null)
                throw new ArgumentNullException();
            
            LinkedListNode node = new LinkedListNode(item);
            if (index == 0)
            {
                node.Next = this.head;
                this.head = node;
            }
            else
            {
                LinkedListNode previous = this.getNode(index - 1);
                node.Next = previous.Next;
                previous.Next = node;
            }
            this.size++;
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the List.
        /// </summary>
        /// <param name="item">The collection whose elements should be added to the end of the List.The collection itself cannot benull, but it can contain elements that arenull, if typeT is a reference type.
        /// </param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void AddRange(System.Collections.Generic.IEnumerable<T> item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            var array = item.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                this.Add(array[i]);
            }
        }

        /// <summary>
        /// Adds a new node containing the specified value at the start of the LinkedList.
        /// </summary>
        /// <param name="item">The value to add at the start of the LinkedList.</param>
        public void AddFirts(T item)
        {
            this.Add(0, item);
        }

        /// <summary>
        /// Searches the entire sorted List for an element using the default comparer and returns the zero-based index of the element.
        /// </summary>
        /// <param name="item">The object to locate. The value can be null for reference types.</param>
        /// <returns>The zero-based index of item in the sorted List, ifitem is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than item or, if there is no larger element, the bitwise complement of Count.</returns>
        public int BinarySearch(T item)
        {
            int begin = 0, end = this.Count - 1, mid = 0;
            bool found = false;

            while (!found && begin <= end)
            {
                mid = (begin + end) / 2;
                if (item.CompareTo(this[mid]) == 0) { found = true; }

                else if (item.CompareTo(this[mid]) < 0) { end = mid - 1; }

                else { begin = mid + 1; }
            }
            if (found) return mid;
            else return -1;
        }
        
        /// <summary>
        /// Removes all elements from the List.
        /// </summary>
        public void Clear()
        {            
            this.size = 0;
        }

        /// <summary>
        /// Determines whether a value is in the LinkedList.
        /// </summary>
        /// <param name="item">The value to locate in the LinkedList.The value can benull for reference types.</param>
        /// <returns>true if value is found in the LinkedList; otherwise,false.</returns>
        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        /// <summary>
        /// Creates a shallow copy of the LinkedList.
        /// </summary>
        /// <returns>A shallow copy of the LinkedList.</returns>
        public object Clone()
        {
            LinkedList<T> clone = new LinkedList<T>();
            
            for (LinkedListNode current = this.head; current != null; current = current.Next)
                clone.Add(current.Data);
            
            return clone;
        }

        /// <summary>
        /// Determines whether the LinkedList contains duplicate
        /// </summary>
        /// <returns>true if the LinkedList contains duplicate; otherwise,false.</returns>
        public bool ContainsDuplicate()
        {
            int index = 0;
            for (LinkedListNode i = this.getNode(index); i != null; i = i.Next, index++)
            {
                int tmp = index + 1;
                if (tmp < this.size)
                {
                    for (LinkedListNode j = this.getNode(tmp); j != null; j = j.Next, tmp++)
                    {
                        if (i.Data.Equals(j.Data))
                            return true;
                    }
                }
            }
            return false;
        }               

        /// <summary>
        /// Copies the entire List to a compatible one-dimensional array, starting at the beginning of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public void CopyTo(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (this.size > array.Length)
            {
                throw new ArgumentException();
            }
            int i = 0;
            for (LinkedListNode current = this.head; current != null; current = current.Next, i++)
            {
                array[i] = current.Data;
            }            
        }

        /// <summary>
        /// Removes the first occurrence of the specified value from the LinkedList.
        /// </summary>
        /// <param name="item">The value to remove from the LinkedList.</param>
        /// <returns>if the element containing value is successfully removed; otherwise, false. This method also returns false if value was not found in the original LinkedList</returns>
        public bool Remove(T item)
        {
            return this.RemoveAt(this.IndexOf(item));
        }

        /// <summary>
        /// Removes the element at the specified index of the LinkedList.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <returns>if the element containing value in index; is successfully removed; otherwise, false.</returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public bool RemoveAt(int index)
        {
            if (this.IsIndexOutOfBounds(index))
            {
                throw new IndexOutOfRangeException();
            }
            bool remove = false;
            if (!this.IsEmpty())
            {
                if (index == 0)
                {
                    this.head = this.head.Next;
                }
                else
                {
                    this.getNode(index - 1).Next = this.getNode(index).Next;
                }
                this.size--;
                remove = true;
            }
            return remove;
        }

        /// <summary>
        /// Removes a range of elements from the LinkedList.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range of elements to remove.</param>
        /// <param name="cant">The number of elements to remove.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public void RemoveRange(int index, int cant)
        {
            if (this.IsIndexOutOfBounds(index) || this.IsIndexOutOfBounds(cant))
            {
                throw new ArgumentOutOfRangeException();
            }
            int j = 0, i = index;
            for (LinkedListNode current = getNode(index); current != null; current = current.Next, i++, j++)
            {
                if (j < cant)
                    this.RemoveAt(index);
            }            
        }

        /// <summary>
        /// Removes the node at the start of the LinkedList.
        /// </summary>
        /// <exception cref="System.InvalidOperationException"></exception>
        public void RemoveFirst()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException();
            }
            this.RemoveAt(0);
        }

        /// <summary>
        /// Removes the node at the end of the LinkedList.
        /// </summary>
        /// <exception cref="System.InvalidOperationException"></exception>
        public void RemoveLast()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException();
            }
            this.RemoveAt(this.size - 1);
        }

        /// <summary>
        /// Reverses the order of the elements in the entire LinkedList.
        /// </summary>
        public void Reverse()
        {
            LinkedList<T> tmp = null;
            if (!this.IsEmpty())
            {
                tmp = new LinkedList<T>();
                for (int i = size - 1; i >= 0; i--)
                {
                    tmp.Add(this[i]);
                }
                this.head = tmp.head;
            }
        }

        /// <summary>
        /// Sorts the elements in the entire LinkedList using the default comparer.
        /// </summary>
        public void Sort()
        {
            T temp = default(T); int index = 0;
            for (LinkedListNode i = this.head; i != null; i = i.Next, index++)
            {
                int subIndex = 0;
                for (LinkedListNode j = this.head; j != null; j = j.Next, subIndex++)
                {
                    if (this[index].CompareTo(this[subIndex]) < 0)
                    {
                        temp = this[index];
                        this[index] = this[subIndex];
                        this[subIndex] = temp;
                    }
                }
            }
        }        

        /// <summary>
        /// Sorts the elements in the entire List using the specified System.Comparison.
        /// </summary>
        /// <param name="comparison">The System.Comparison to use when comparing elements</param>
        /// <exception cref=""></exception>
        public void Sort(Comparison<T> comparison) 
        {
            T temp = default(T);
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (comparison(this.getNode(i).Data, this.getNode(j).Data) < 0)
                    {
                        temp = this[i];
                        this[i] = this[j];
                        this[j] = temp;
                    }
                }
            }           
        }       

        /// <summary>
        ///   
        /// </summary>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        /// <returns>A LinkedList containing all the elements in the specified range</returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public LinkedList<T> SubList(int fromIndex, int toIndex)
        {
            LinkedList<T> tmp = null;
            if ((!this.IsIndexOutOfBounds(fromIndex)) && (!this.IsIndexOutOfBounds(toIndex)) && (!this.IsEmpty()))
            {
                tmp = new LinkedList<T>();
                int i = fromIndex, j = toIndex;
                for (LinkedListNode current = this.getNode(fromIndex); current.Next != null && (i <= toIndex); current = current.Next, i++)
                {
                    tmp.Add(current.Data);
                }
            }
            else { throw new IndexOutOfRangeException(); }
            return tmp;
        }

        /// <summary>
        /// Retrieves all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>A List containing all the elements that match the conditions defined by the specified predicate, if found; otherwise, an empty List.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public bool TrueForAll(System.Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException();
            }
            bool tmp = false;
            for (LinkedListNode current = this.head; current != null; current = current.Next)
            {
                if (predicate(current.Data))
                    tmp = true;
                else { return tmp = false; }
            }
            return tmp;
        }

        /// <summary>
        /// Performs the specified action on each element of the List.
        /// </summary>
        /// <param name="action">The Action delegate to perform on each element of the List.</param>
        public void ForEach(System.Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException();
            }
            for (LinkedListNode current = this.head; current != null; current = current.Next)
            {
                action(current.Data);
            }
        }

        /// <summary>
        /// Copies the elements of the List to a new array.
        /// </summary>
        /// <returns>An array containing copies of the elements of the LinkedList.</returns>
        public T[] ToArray()
        {
            T[] data = new T[this.size];
            LinkedListNode current = this.head;
            if (!this.IsEmpty())
            {
                int i = 0;
                data[i] = current.Data;
                while (current.Next != null)
                {
                    current = current.Next;
                    data[++i] = current.Data;
                }
            }
            return data;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            StringBuilder chain = null;
            if (!this.IsEmpty())
            {
                chain = new StringBuilder();
                for (LinkedListNode current = this.head; current != null; current = current.Next) 
                {
                    chain.Append(current.Data);
                }
            }
            return chain.ToString();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the LinkedList.
        /// </summary>
        /// <returns>An LinkedList Enumerator for the LinkedList</returns>
        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            Enumerator e = new Enumerator(this);
            return e;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            Enumerator e = new Enumerator(this);
            return e;
        }

        private LinkedListNode getNode(int i)
        {
            if (this.IsIndexOutOfBounds(i))
            {
                throw new IndexOutOfRangeException();
            }
            int counter = 0; LinkedListNode current = this.head;
            while (current != null && current.Next != null)
            {
                if (counter == i) { break; }
                else
                {
                    current = current.Next;
                    counter++;
                }
            }
            return current;
        }

        private bool IsIndexOutOfBounds(int index)
        {
            return index < 0 || index >= this.size;
        }

        private void setNode(int index, T item)
        {
            if (this.IsIndexOutOfBounds(index))
            {
                throw new ArgumentOutOfRangeException();
            }          
            LinkedListNode node = new LinkedListNode(item);
            if (index == 0)
            {
                node.Next = this.head.Next;
                this.head = node;
            }
            else
            {
                LinkedListNode current = this.getNode(index);
                LinkedListNode previous = this.getNode(index - 1);
                previous.Next = node;
                node.Next = current.Next;
            }
        }

        public class LinkedListNode
        {
            private T data;
            private LinkedListNode next;

            public LinkedListNode(T data)
            {
                this.data = data;
                next = null;
            }

            public T Data
            {
                get { return data; }
                set { data = value; }
            }

            public LinkedListNode Next
            {
                get { return next; }
                set { next = value; }
            }
        }

        internal class Enumerator : System.Collections.Generic.IEnumerator<T>
        {
            private LinkedList<T> list;
            private int position = -1;

            public Enumerator(LinkedList<T> list)
            {
                this.list = list;
            }

            public T Current
            {
                get
                {
                    try
                    {
                        return this.list[position];
                    }
                    catch (IndexOutOfRangeException) { throw new InvalidOperationException(); }
                }
            }

            public void Dispose() { }

            object System.Collections.IEnumerator.Current
            {
                get { return list[position]; }
            }

            public bool MoveNext()
            {
                position++;
                return (position < list.Count);
            }

            public void Reset()
            {
                position = -1;
            }
        }        
    }
}