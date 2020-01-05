using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic_List_Sequential;

/// Author: Ing.Computer José Manuel Mc Langhlin Matienzo.
/// Email:  mclanghlin@gmail.com.
/// Study Center: University of Cienfuegos, Cuba.
/// Work : Roshka, Asuncion, Paraguay
namespace Program
{
    /// <summary>
    /// Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {            
            new TestListSequential().main();
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Test class
    /// </summary>
    public class TestListSequential
    {
        /// <summary>
        /// 
        /// </summary>
        private List<int> list;

        /// <summary>
        /// 
        /// </summary>
        public void main()
        {
            this.add(1);
            this.addRange(new int[] { 2, 3, 4, 5, 6 });
            this.binarySearch(1);
            this.capacity();

            this.clear();
            this.addRange(new int[] { 2, 3, 4, 5, 6 });
            this.clone();
            this.contains(1);

            this.containsDuplicate();
            this.copyTo(new int[15]);
            this.copyTo(new int[17], 1);
            this.count();

            this.find(delegate (int item) { return item < 3; });
            foreach (var item in this.findAll(delegate (int item) { return item > 3; })) ;
            this.findIndex(0, delegate (int item) { return item > 3; });
            this.findLastIndex(delegate (int item) { return item > 3; });

            this.forEach(delegate (int res) { Console.WriteLine("Test... success...."); });
            this.indexOf(1);
            this.insert(1, 3);
            this.insertRange(0, new int[] { 7, 8, 9, 10 });

            this.isEmpy();
            this.lastIndexOf(2);
            this.lastIndexOf(2, 0);
            this.remove(1);

            this.removeAt(1);
            this.removeFirst();
            this.removeLast();
            this.removeRange(0, 3);

            this.reverse();
            this.sort();
            this.subList(0, 3);
            this.toArray();
            this.toString();
        }

        /// <summary>
        /// 
        /// </summary>
        public TestListSequential()
        {
            this.list = new List<int>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public TestListSequential(int[] item)
        {
            this.list = new List<int>(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public TestListSequential(int capacity)
        {
            this.list = new List<int>(capacity);
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="item"></param>
        private void add(int item)
        {
            try
            {
                list.Add(item);
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... add(int item)");
            }
            Console.WriteLine("Test.... success... add(int item)");
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="item"></param>
        private void addRange(int[] item)
        {
            try
            {
                list.AddRange(item);
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... addRange(int[] item)");
            }
            Console.WriteLine("Test.... success... addRange(int[] item)");
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="item"></param>
        private int binarySearch(int item)
        {
            try
            {
                var res = this.list.BinarySearch(item);
                Console.WriteLine("Test.... success... binarySearch(int item)");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... binarySearch(int item)");
            }

        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="item"></param>
        private void clear()
        {
            try
            {
                this.list.Clear();
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... clear()");
            }
            Console.WriteLine("Test.... success... clear()");
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="item"></param>
        private object clone()
        {
            try
            {
                var res = this.list.Clone();
                Console.WriteLine("Test.... success... clone()");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... clone()");
            }
        }

        /// <summary>
        ///  test method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool contains(int item)
        {
            try
            {
                var res = this.list.Contains(item);
                Console.WriteLine("Test.... success... contains(int item)");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... contains(int item)");
            }
        }

        /// <summary>
        ///  test method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool containsDuplicate()
        {
            try
            {
                var res = this.list.ContainsDuplicate();
                Console.WriteLine("Test.... success... containsDuplicate()");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... containsDuplicate()");
            }
        }

        /// <summary>
        ///  test method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private void copyTo(int[] item)
        {
            try
            {
                this.list.CopyTo(item);
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... copyTo(int[] item)");
            }
            Console.WriteLine("Test.... success... copyTo(int[] item)");
        }

        /// <summary>
        ///  test method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private void copyTo(int[] item, int arrayIndex)
        {
            try
            {
                this.list.CopyTo(item, arrayIndex);
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... copyTo(int[] item, int arrayIndex)");
            }
            Console.WriteLine("Test.... success... copyTo(int[] item, int arrayIndex)");
        }

        /// <summary>
        ///  test method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private void copyTo(int index, int[] item, int arrayIndex, int count)
        {
            try
            {
                this.list.CopyTo(index, item, arrayIndex, count);
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... copyTo(int index, int[] item, int arrayIndex, int count)");
            }
            Console.WriteLine("Test.... success... copyTo(int index, int[] item, int arrayIndex, int count)");
        }

        /// <summary>
        ///  test method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private int count()
        {
            try
            {
                var res = this.list.Count;
                Console.WriteLine("Test.... success... count()");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... count()");
            }
        }

        /// <summary>
        ///  test method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private int capacity()
        {
            try
            {
                var res = this.list.Capacity;
                Console.WriteLine("Test.... success... capacity()");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... capacity()");
            }
        }

        /// <summary>
        ///  test method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private void exist(Predicate<int> predicate)
        {
            try
            {
                this.list.Exists(predicate);
                Console.WriteLine("Test.... success... exist(Predicate<int> predicate)");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... exist(Predicate<int> predicate)");
            }
        }

        /// <summary>
        ///  test method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private void find(Predicate<int> predicate)
        {
            try
            {
                var res = this.list.Find(predicate);
                Console.WriteLine("Test.... success... find(Predicate<int> predicate)");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... find(Predicate<int> predicate)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private List<int> findAll(Predicate<int> predicate)
        {
            try
            {
                var res = this.list.FindAll(predicate);
                Console.WriteLine("Test.... success... findAll(Predicate<int> predicate)");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... findAll(Predicate<int> predicate)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="start"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private int findIndex(int start, Predicate<int> predicate)
        {
            try
            {
                var res = this.list.FindIndex(start, predicate);
                Console.WriteLine("Test.... success... findIndex(int start, Predicate<int> predicate)");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... findIndex(int start, Predicate<int> predicate)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private int findIndex(int start, int count, Predicate<int> predicate)
        {
            try
            {
                var res = this.list.FindIndex(start, count, predicate);
                Console.WriteLine("Test.... success... findIndex(int start, int count, Predicate<int> predicate)");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed...");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private int findLastIndex(Predicate<int> predicate)
        {
            try
            {
                var res = this.list.FindLastIndex(predicate);
                Console.WriteLine("Test.... success... findLastIndex(Predicate<int> predicate)");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... findLastIndex(Predicate<int> predicate)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="action"></param>
        private void forEach(Action<int> action)
        {
            try
            {
                this.list.ForEach(action);
                Console.WriteLine("Test.... success... forEach(Action<int> action)");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... forEach(Action<int> action)");
            }
        }

        /// <summary>
        /// test method
        /// </summary> 
        /// <param name="item"></param>
        /// <returns></returns>
        private int indexOf(int item)
        {
            try
            {
                var res = this.list.IndexOf(item);
                Console.WriteLine("Test.... success... indexOf(int item) ");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... indexOf(int item)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private int indexOf(int item, int index)
        {
            try
            {
                var res = this.list.IndexOf(item, index);
                Console.WriteLine("Test.... success... indexOf(int item, int index)");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... indexOf(int item, int index)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        private void insert(int index, int item)
        {
            try
            {
                this.list.Insert(index, item);
                Console.WriteLine("Test.... success... insert(int index, int item)");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... insert(int index, int item)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        private void insertRange(int index, int[] item)
        {
            try
            {
                this.list.InsertRange(0, item);
                Console.WriteLine("Test.... success... insertRange(int index, int[] item)");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... insertRange(int index, int[] item)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <returns></returns>
        private bool isEmpy()
        {
            try
            {
                var res = this.list.IsEmpty();
                Console.WriteLine("Test.... success... isEmpy()");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... isEmpy()");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private int lastIndexOf(int item)
        {
            try
            {
                var res = this.list.LastIndexOf(item);
                Console.WriteLine("Test.... success... lastIndexOf(int item)");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... lastIndexOf(int item)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private int lastIndexOf(int item, int index)
        {
            try
            {
                var res = this.list.LastIndexOf(item, index);
                Console.WriteLine("Test.... success... lastIndexOf(int item, int index)");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... lastIndexOf(int item, int index)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private int lastIndexOf(int item, int index, int count)
        {
            try
            {
                var res = this.list.LastIndexOf(item, index, count);
                Console.WriteLine("Test.... success... lastIndexOf(int item, int index, int count)");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... lastIndexOf(int item, int index, int count)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool remove(int item)
        {
            try
            {
                var res = this.list.Remove(item);
                Console.WriteLine("Test.... success... remove(int item)");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... remove(int item)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="index"></param>
        private void removeAt(int index)
        {
            try
            {
                this.list.RemoveAt(index);
                Console.WriteLine("Test.... success... removeAt(int index)");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... removeAt(int index)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="index"></param>
        /// <param name="cant"></param>
        private void removeRange(int index, int cant)
        {
            try
            {
                this.list.RemoveRange(index, cant);
                Console.WriteLine("Test.... success... removeRange(int index, int cant)");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... removeRange(int index, int cant)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        private void removeFirst()
        {
            try
            {
                this.list.removeFirts();
                Console.WriteLine("Test.... success... removeFirst()");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... removeFirst()");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        private void removeLast()
        {
            try
            {
                this.list.removeLast();
                Console.WriteLine("Test.... success... removeLast()");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed...");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        private void reverse()
        {
            try
            {
                this.list.Reverse();
                Console.WriteLine("Test.... success... reverse()");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed...");
            }

        }

        /// <summary>
        /// test method
        /// </summary>
        private void sort()
        {
            try
            {
                this.list.Sort();
                Console.WriteLine("Test.... success... sort()");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... sort()");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="comparison"></param>
        private void sort(Comparison<int> comparison)
        {
            try
            {
                this.sort(comparison);
                Console.WriteLine("Test.... success... sort(Comparison<int> comparison)");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... sort(Comparison<int> comparison)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="fromIndex"></param>
        /// <param name="toIndex"></param>
        private void subList(int fromIndex, int toIndex)
        {
            try
            {
                this.list.SubList(fromIndex, toIndex);
                Console.WriteLine("Test.... success... subList(int fromIndex, int toIndex)");
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... subList(int fromIndex, int toIndex)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        private bool trueForAll(Predicate<int> predicate)
        {
            try
            {
                var res = this.list.TrueForAll(predicate);
                Console.WriteLine("Test.... success... trueForAll(Predicate<int> predicate)");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... trueForAll(Predicate<int> predicate)");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <returns></returns>
        private int[] toArray()
        {
            try
            {
                var res = this.list.ToArray();
                Console.WriteLine("Test.... success... toArray()");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... toArray()");
            }
        }

        /// <summary>
        /// test method
        /// </summary>
        /// <returns></returns>
        private String toString()
        {
            try
            {
                var res = this.list.ToString();
                Console.WriteLine("Test.... success... toString()");
                return res;
            }
            catch (Exception)
            {
                throw new Exception("Test.... failed... toString()");
            }
        }
    }
}
