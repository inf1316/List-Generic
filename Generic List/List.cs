using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Author: Ing.Computer José Manuel Mc Langhlin Matienzo.
/// Email:  mclanghlin@gmail.com.
/// Study Center: University of Cienfuegos, Cuba.
/// Work : Roshka, Asunción, Paraguay  
namespace Generic_List_Sequential
{
    /// <summary>
    /// Represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort, and manipulate lists.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list</typeparam>
    public class List<T> : System.Collections.Generic.IList<T>, System.Collections.Generic.ICollection<T>
    {        
        private int size;
        private T[] list;

        /// <summary>
        /// Initializes a new instance of the List class that is empty and has the default initial capacity.
        /// </summary>
        public List() : this(0) { }

        /// <summary>
        /// Initializes a new instance of the List class that contains elements copied from the specified collection and has sufficient 
        /// capacity to accommodate the number of elements copied.
        /// </summary>
        /// <param name="list">The collection whose elements are copied to the new list.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public List(T[] list)
        {
            if (list == null) { throw new ArgumentNullException(); }
            this.list = list;
            this.size = list.Length;
        }

        /// <summary>
        /// Initializes a new instance of the List class that is empty and has the specified initial capacity.
        /// </summary>
        /// <param name="capacidad">The number of elements that the new list can initially store.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public List(int capacidad)
        {
            if (capacidad < 0) { throw new ArgumentException(); }
            this.list = new T[capacidad];
            this.size = 0;
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public T this[int index]
        {
            get
            {
                try
                {
                    return list[index];
                }
                catch (IndexOutOfRangeException) { throw new InvalidOperationException(); }
            }
            set
            {
                try
                {
                    list[index] = value;
                }
                catch (IndexOutOfRangeException) { throw new InvalidOperationException(); }
            }
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire List.
        /// </summary>
        /// <param name="item">The object to locate in the List. The value can benull for reference types.</param>
        /// <returns>The zero-based index of the first occurrence of item within the entire List, if found; otherwise, –1.</returns>
        public int IndexOf(T item)
        {
            int index = -1;
            for (int i = 0; i < this.size; i++)
            {
                if (item.Equals(this.list[i]))
                    return index = i;
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
            int tmp = -1;
            for (int i = index; i < this.size; i++)
            {
                if (item.Equals(this.list[i]))
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
            int tmp = -1;
            for (int i = index; i <= count; i++)
            {
                if (item.Equals(this.list[i]))
                    return tmp = i;
            }
            return tmp;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the last occurrence within the entire List.
        /// </summary>
        /// <param name="item">The object to locate in the List. The value can benull for reference types.</param>
        /// <returns>The zero-based index of the last occurrence of item within the entire the List, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int LastIndexOf(T item)
        {
            if (item == null)
                throw new ArgumentOutOfRangeException();
            return System.Array.LastIndexOf(this.list, item);
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the last occurrence within the range of elements in the List that extends from the first element to the specified index.
        /// </summary>
        /// <param name="item">The object to locate in the List. The value can benull for reference types.</param>
        /// <param name="index">The zero-based starting index of the backward search.</param>
        /// <returns>The zero-based index of the last occurrence of item within the range of elements in the List that extends from the first element toindex, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int LastIndexOf(T item, int index)
        {
            if (this.IsIndexOutOfBounds(index))
                throw new ArgumentOutOfRangeException();
            return System.Array.LastIndexOf(this.list, item, index);
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the last occurrence within the range of elements in the List that contains the specified number of elements and ends at the specified index.
        /// </summary>
        /// <param name="item">The object to locate in the List. The value can benull for reference types.</param>
        /// <param name="index">The zero-based starting index of the backward search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <returns>The zero-based index of the last occurrence of item within the range of elements in the List that containscount number of elements and ends at index, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int LastIndexOf(T item, int index, int count)
        {
            if (this.IsIndexOutOfBounds(index) || this.IsIndexOutOfBounds(count))
                throw new ArgumentOutOfRangeException();
            return System.Array.LastIndexOf(this.list, item, index, count);
        }

        /// <summary>
        /// Inserts an element into the List at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which item should be inserted.</param>
        /// <param name="item">The object to insert. The value can be null for reference types.</param>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public void Insert(int index, T item)
        {
            if (this.IsIndexOutOfBounds(index))
                throw new IndexOutOfRangeException();
            else if (this.Count == this.list.Length)
                this.IncreaseSize();
            System.Array.Copy(this.list, index, this.list, index + 1, this.size - index);
            this.list[index] = item;
            this.size++;
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
                throw new ArgumentOutOfRangeException();
            if (collection == null)
                throw new ArgumentNullException();
            T[] arr = collection.ToArray(); int count = index;
            foreach (var item in arr)
            {
                this.Insert(count++, item);
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the List.
        /// </summary>
        /// <param name="item">The object to remove from the List. The value can benull for reference types.</param>
        /// <returns>if item is successfully removed; otherwise, false. This method also returns false if item was not found in the List.</returns>
        public bool Remove(T item)
        {
            bool removed = false;
            int index = this.IndexOf(item);
            if (index != -1)
            {
                try
                {
                    this.RemoveAt(index);
                    removed = true;
                }
                catch { removed = false; }
            }
            return removed;
        }

        /// <summary>
        /// Removes the element at the specified index of the List.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public void RemoveAt(int index)
        {
            if (!(IsIndexOutOfBounds(index)))
            {
                for (int i = index; i < this.size - 1; i++)
                {
                    list[i] = list[i + 1];
                }
                this.size--;
            }
            else throw new IndexOutOfRangeException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void removeFirts()
        {
            this.RemoveAt(0);
        }

        /// <summary>
        /// 
        /// </summary>
        public void removeLast()
        {
            this.RemoveAt(this.size - 1);
        }

        /// <summary>
        /// Removes a range of elements from the List.
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
            for (int i = index; i < index + cant; i++)
            {
                if (i == index)
                {
                    this.RemoveAt(i);
                }
                else
                {
                    this.RemoveAt(i - 1);
                }
            }
        }

        /// <summary>
        /// Reverses the order of the elements in the entire List.
        /// </summary>
        public void Reverse()
        {
            System.Array.Reverse(this.list);
        }

        /// <summary>
        /// Reverses the order of the elements in the specified range.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range to reverse.</param>
        /// <param name="count">The number of elements in the range to reverse.</param>       
        public void Reverse(int index, int count)
        {
            System.Array.Reverse(this.list, index, count);
        }

        /// <summary>
        /// Adds an object to the end of the List.
        /// </summary>
        /// <param name="item">The object to be added to the end of the List. The value can benull for reference types.</param>
        public void Add(T item)
        {
            if (this.size == this.list.Length)            
                this.IncreaseSize();            
            this.list[size] = item;
            this.size++;
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the List.
        /// </summary>
        /// <param name="item">The collection whose elements should be added to the end of the List.The collection itself cannot benull, but it can contain elements that arenull, if typeT is a reference type.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void AddRange(System.Collections.Generic.IEnumerable<T> item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }
            T[] tmp = item.ToArray();
            if ((this.list.Length - this.size) < tmp.Length)
            {
                this.IncreaseSize(tmp.Length);
            }
            System.Array.Copy(tmp, 0, this.list, this.Count, tmp.Length);
            this.size += tmp.Length;
        }

        /// <summary>
        /// Searches the entire sorted List for an element using the default comparer and returns the zero-based index of the element.        
        /// </summary>
        /// <param name="item">The object to locate. The value can be null for reference types</param>
        /// <returns>The zero-based index of item in the sorted List, ifitem is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than item or, if there is no larger element, the bitwise complement of Count.</returns>
        public int BinarySearch(T item) 
        {
            try
            {
                return System.Array.BinarySearch(this.list, item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }            
        }

        /// <summary>
        /// Searches the entire sorted List for an element using the specified comparer and returns the zero-based index of the element.
        /// </summary>
        /// <param name="item">The object to locate. The value can be null for reference types.</param>
        /// <param name="comparer">The IComparer implementation to use when comparing elements.</param>
        /// <returns></returns>
        public int BinarySearch(T item, System.Collections.Generic.IComparer<T> comparer)
        {
            try
            {
                return System.Array.BinarySearch(this.list, item, comparer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// Searches a range of elements in the sorted List for an element using the specified comparer and returns the zero-based index of the element.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range to search.</param>
        /// <param name="count">The length of the range to search.</param>
        /// <param name="item">The object to locate. The value can be null for reference types.</param>
        /// <param name="comparer">The IComparer implementation to use when comparing elements, ornull to use the default comparer Comparer.Default.</param>
        /// <returns>The zero-based index of item in the sorted List, ifitem is found; otherwise, a negative number that is the bitwise complement of the index of the next element that is larger than item or, if there is no larger element, the bitwise complement of Count.</returns>
        public int BinarySearch(int index, int count, T item, System.Collections.Generic.IComparer<T> comparer)
        {
            try
            {
                return System.Array.BinarySearch(this.list, index, count, item, comparer);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// Removes all elements from the List.
        /// </summary>
        public void Clear()
        {
            this.size = 0;            
        }

        /// <summary>
        /// Determines whether an element is in the List.
        /// </summary>
        /// <param name="item">The object to locate in the List. The value can benull for reference types.</param>
        /// <returns>true if item is found in the List; otherwise,false.</returns>
        public bool Contains(T item)
        {
            return this.IndexOf(item) != -1;
        }

        /// <summary>
        /// Determines whether the List contains duplicate
        /// </summary>
        /// <returns>true if the List contains duplicate; otherwise,false.</returns>
        public bool ContainsDuplicate()
        {
            if (!this.IsEmpty())
            {
                for (int i = 0; i < this.size; i++)
                {
                    for (int j = i + 1; j < this.size; j++)
                    {
                        if (this.list[i] != null && this.list[j] != null)
                        {
                            if (this.list[i].Equals(this.list[j]))
                            {
                                return true;
                            }
                        }                        
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
            if (this.list.Length > array.Length)
            {
                throw new ArgumentException();
            }
            System.Array.Copy(this.list, 0, array, 0, this.size);
        }

        /// <summary>
        /// Copies the entire to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            if (arrayIndex > this.list.Length)
            {
                throw new ArgumentException();
            }            
            this.list.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Copies a range of elements from the List to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="index">The zero-based index in the source List at which copying begins.</param>
        /// <param name="array">The one-dimensional Array that is the destination of the elements copied from List. The Array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <param name="count">The number of elements to copy.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }
            System.Array.Copy(this.list, index, array, arrayIndex, count);
        }

        /// <summary>
        /// Gets the number of elements contained in the List.
        /// </summary>
        public int Count
        {
            get { return this.size; }            
        }

        /// <summary>
        /// Gets or sets the total number of elements the internal data structure can hold without resizing.
        /// </summary>
        public int Capacity
        {
            get { return this.list.Length; }
        }

        /// <summary>
        /// Creates a shallow copy of the List.
        /// </summary>
        /// <returns>A shallow copy of the List</returns>
        public object Clone()
        {
            List<T> clone = null;
            if (!this.IsEmpty())
            {
                clone = new List<T>();
                for (int i = 0; i < this.size; i++)
                {
                    clone.Add(list[i]);
                }
            }
            return clone;
        }

        /// <summary>
        /// Determines whether the List contains elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>if the List contains one or more elements that match the conditions defined by the specified predicate; otherwise,false.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public bool Exists(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException();
            }
            return System.Array.Exists(this.list, match);
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the first occurrence within the entire List.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the element to search for.</param>
        /// <returns>The first element that matches the conditions defined by the specified predicate, if found; otherwise, the default value for type T.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public T Find(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException();
            }
            return System.Array.Find(this.list, match);
        }

        /// <summary>
        /// Retrieves all the elements that match the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the elements to search for.</param>
        /// <returns>A List containing all the elements that match the conditions defined by the specified predicate, if found; otherwise, an empty List.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public List<T> FindAll(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException();
            }
            List<T> list = new List<T>();
            list.AddRange(System.Array.FindAll(this.list, match));
            return list;
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the List that extends from the specified index to the last element.
        /// </summary>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="match">The Predicate delegate that defines the conditions of the element to search for.</param>
        /// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found; otherwise, –1.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public int FindIndex(int startIndex, Predicate<T> match)
        {
            if (this.IsIndexOutOfBounds(startIndex))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (match == null)
            {
                throw new ArgumentNullException();
            }
            return System.Array.FindIndex(this.list, startIndex, match);
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the first occurrence within the range of elements in the List that starts at the specified index and contains the specified number of elements.
        /// </summary>
        /// <param name="startIndex">The zero-based starting index of the search.</param>
        /// <param name="count">The number of elements in the section to search.</param>
        /// <param name="match">The Predicate delegate that defines the conditions of the element to search for.</param>
        /// <returns>The zero-based index of the first occurrence of an element that matches the conditions defined by match, if found; otherwise, –1.</returns>
        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException();
            }
            if (this.IsIndexOutOfBounds(startIndex) || this.IsIndexOutOfBounds(count))
            {
                throw new ArgumentOutOfRangeException();
            }
            return System.Array.FindIndex(this.list, startIndex, count, match);
        }

        /// <summary>
        /// Searches for an element that matches the conditions defined by the specified predicate, and returns the zero-based index of the last occurrence within the entire List.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions of the element to search for.</param>
        /// <returns>The zero-based index of the last occurrence of an element that matches the conditions defined by match, if found; otherwise, –1.</returns>
        public int FindLastIndex(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException();
            }
            return System.Array.FindLastIndex(this.list, match);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
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
        /// Copies the elements of the List to a new array.
        /// </summary>
        /// <returns>An array containing copies of the elements of the List.</returns>
        public T[] ToArray()
        {
            T[] tmp = new T[this.size];
            System.Array.Copy(this.list, 0, tmp, 0, this.size);
            return tmp;
        }

        /// <summary>
        /// Sets the capacity to the actual number of elements in the List<T>, if that number is less than a threshold value.
        /// </summary>
        public void TrimExcess()
        {
            T[] tmp = this.ToArray();
            this.list = tmp;
            this.size = tmp.Length;
        }

        /// <summary>
        /// Sorts the elements in the entire List using the default comparer.
        /// </summary>
        public void Sort()
        {
            System.Array.Sort(this.list);
        }

        /// <summary>
        /// Sorts the elements in the entire List using the specified System.Comparison.
        /// </summary>        
        /// <param name="comparison">The System.Comparison to use when comparing elements.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public void Sort(Comparison<T> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException();
            }
            System.Array.Sort(this.list, comparison);
        }

        /// <summary>
        /// Sorts the elements in the entire List using the specified comparer.
        /// </summary>
        /// <param name="comparer">The IComparer implementation to use when comparing elements, ornull to use the default comparer Comparer.Default.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        public void Sort(System.Collections.Generic.IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new InvalidOperationException();
            }
            System.Array.Sort(this.list, comparer);
        }

        /// <summary>
        /// Sorts the elements in a range of elements in List using the specified comparer.
        /// </summary>
        /// <param name="index">The zero-based starting index of the range to sort.</param>
        /// <param name="count">The length of the range to sort.</param>
        /// <param name="comparer">The IComparer implementation to use when comparing elements, ornull to use the default comparer Comparer.Default.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        public void Sort(int index, int count, System.Collections.Generic.IComparer<T> comparer)
        {
            if (comparer == null)
            {
                throw new InvalidOperationException();
            }
            System.Array.Sort(this.list, index, count, comparer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        /// <returns></returns>
        public List<T> SubList(int fromIndex, int toIndex)
        {
            List<T> tmp = null;
            if ((!this.IsIndexOutOfBounds(fromIndex)) && (!this.IsIndexOutOfBounds(toIndex)) && (!this.IsEmpty()))
            {
                tmp = new List<T>();
                for (int i = fromIndex; i <= toIndex; i++)
                {
                    tmp.Add(this.list[i]);
                }
            }
            else { throw new IndexOutOfRangeException(); }
            return tmp;
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
                for (int i = 0; i < this.size; i++)
                {
                    chain.Append(this.list[i] + " ");
                }                
            }
            return chain.ToString();
        }

        /// <summary>
        /// Determines whether every element in the List matches the conditions defined by the specified predicate.
        /// </summary>
        /// <param name="match">The Predicate delegate that defines the conditions to check against the elements.</param>
        /// <returns>if every element in the List matches the conditions defined by the specified predicate; otherwise,false. If the list has no elements, the return value is true.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public bool TrueForAll(Predicate<T> match)
        {
            if (match == null)
            {
                throw new ArgumentNullException();
            }
            return System.Array.TrueForAll(this.list, match);
        }

        /// <summary>
        /// Performs the specified action on each element of the List.
        /// </summary>
        /// <param name="action">The Action delegate to perform on each element of the List.</param>
        public void ForEach(Action<T> action)
        {           
            if (action == null)
            {
                throw new ArgumentNullException();
            }
            System.Array.ForEach(this.list, action);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the List.
        /// </summary>
        /// <returns>A List.Enumerator for the List.</returns>
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

        private bool IsIndexOutOfBounds(int index)
        {
            return index < 0 || index >= this.size;
        }

        private void IncreaseSize()
        {
            T[] tmp = new T[this.size + 1];
            System.Array.Copy(this.list, 0, tmp, 0, this.size);
            this.list = tmp;
        }

        private void IncreaseSize(int size)
        {
            T[] tmp = new T[this.size + size];
            System.Array.Copy(this.list, 0, tmp, 0, this.size);
            this.list = tmp;
        }

        internal class Enumerator : System.Collections.Generic.IEnumerator<T>
        {
            private List<T> list;
            private int position;

            public Enumerator(List<T> list)
            {
                this.list = list;
                this.position = -1;
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
