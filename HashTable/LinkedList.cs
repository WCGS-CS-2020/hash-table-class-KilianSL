using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    /// <summary>
    /// Dynamic-Length Single Linked List Datastructure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> where T : IComparable //Simple linked list
    {

        //c in all instances is a temporary variable used to indicate the Currrent node that the method is processing
        /// <summary>
        /// Gets the number of items contained in the list.
        /// </summary>
        public int Count { get; set; }  //amount of nodes in the list
        private Node head;  //first node in the list

        /// <summary>
        /// Initializes a new empty instance of LinkedList.
        /// </summary>
        public LinkedList()   //default constructor 
        {
            head = new Node(default);  //head stores no data (default T) - merely the beginning of the list
            Count = 0;
        }

        /// <summary>
        /// Initializes a new instance of LinkedList that contains elements copied from the specified collection.
        /// </summary>
        /// <param name="collection">The collection who's elements are copied to the new list.</param>
        public LinkedList(IEnumerable<T> collection)
        {
            head = new Node(default);
            Count = 0;
            AddRange(collection);
        }
        private class Node  //Node in the list, stores data and a pointer to the next node. 
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data, Node next = null)
            {
                Data = data;
                Next = next;
            }
        }

        /// <summary>
        /// Adds an object to the end of the list.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            Node n = head;
            while (n.Next != null)  //iterates until the last node in the list is found
            {
                n = n.Next;
            }
            n.Next = new Node(item);
            Count += 1;
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the list.
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(IEnumerable<T> collection)  //adds a collection of items to the list
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Inserts an element into the list at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)  //inserts an item in the specified position in the list (index from 0)
        {
            if (index <= Count)
            {
                Node c = head;
                for (int i = 0; i < index; i++)
                {
                    c = c.Next;  //cycles to the node before the index to be replaced
                }
                c.Next = new Node(item, c.Next);  //inserts a new node between c and c.next
                Count += 1;
            }
            else
            {
                Console.WriteLine("Null pointer exception - Cannot insert beyond last node");
            }
        }

        /// <summary>
        /// Inserts the elements of a collection into the List at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="collection"></param>
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            if (index <= Count)
            {
                Node c = head;
                for (int i = 0; i < index; i++)
                {
                    c = c.Next;  //cycles to the node before the index to be replaced
                }
                foreach (var item in collection)
                {
                    c.Next = new Node(item, c.Next);  //inserts a new node between c and c.next
                    Count += 1;
                    c = c.Next;
                }
            }
            else
            {
                Console.WriteLine("Null pointer exception - Cannot insert beyond last node");
            }
        }

        /// <summary>
        /// Returns true if the list has no elements
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            if (head.Next == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes the element at the specified index of the list.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index < Count)
            {
                Node c = head;
                for (int i = 0; i < index; i++)  //iterates until the node before the node to be removed
                {
                    c = c.Next;
                }
                c.Next = c.Next.Next;  //removes the next node from the chain, changing the link to the node after it
                Count -= 1;
            }
            else
            {
                Console.WriteLine("Null Pointer Exception - No item at {0}", index);
            }
        }

        /// <summary>
        ///Removes the first occurrence of a specific object from the List.
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            Node c = head;
            for (int i = 0; i <= Count; i++)
            {
                if (c.Next.Data.Equals(item))
                {
                    c.Next = c.Next.Next;
                    Count -= 1;
                    break;
                }
                c = c.Next;
            }
        }

        /// <summary>
        /// Remove all occurrences of a specific object from the List.
        /// </summary>
        /// <param name="item"></param>
        public void RemoveAll(T item)
        {
            Node c = head;
            do
            {
                c = c.Next;
                if (c.Next.Data.Equals(item))
                {
                    c.Next = c.Next.Next;
                    Count -= 1;
                }

            } while (c.Next != null);

        }

        /// <summary>
        /// Removes a range of elements from the List.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void RemoveRange(int start, int end) //removes all items between the two specified indicies (inclusive)
        {
            getNodeAt(start - 1).Next = getNodeAt(end + 1);
        }

        /// <summary>
        /// Performs a bubble sort of the data in the list
        /// </summary>
        public void Sort()
        {
            int bound = Count - 1;

            bool done = false;
            int swapped;
            do
            {
                var c = head.Next;
                swapped = -1;
                for (int i = 0; i < bound; i++)
                {

                    if (c.Data.CompareTo(c.Next.Data) >= 0)
                    {
                        T temp = c.Data;
                        c.Data = c.Next.Data;
                        c.Next.Data = temp;
                        swapped = i;
                    }
                    c = c.Next;
                }
                if (swapped < 0)
                {
                    done = true;
                }
                else
                {
                    bound = swapped;
                }
            } while (!done);

        }

        /// <summary>
        /// Copies the elements of the List to a new array.
        /// </summary>
        /// <returns></returns>
        public T[] ToArray()
        {
            T[] arr = new T[Count];
            Node c = head.Next;
            for (int i = 0; i < Count; i++)
            {
                arr[i] = c.Data;
                c = c.Next;
            }
            return arr;
        }

        /// <summary>
        /// Removes all elements from the list.
        /// </summary>
        public void Clear()
        {
            head.Next = null;
        }

        /// <summary>
        /// Determines whether an element is in the list.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)  //checks if the list contains a specified item
        {
            Node c = head.Next;
            do
            {
                if (c.Data.Equals(item))
                {
                    return true;
                }
                c = c.Next;
            } while (c.Next != null);
            return false;
        }

        /// <summary>
        /// Gets the element at a specific index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetItemAt(int index)
        {
            Node c = head;
            for (int i = 0; i <= index; i++)
            {
                c = c.Next;
            }
            return c.Data;
        }

        private Node getNodeAt(int index) //returns the node at a specific index
        {
            Node c = head;
            for (int i = 0; i <= index; i++)
            {
                c = c.Next;
            }
            return c;
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the first occurrence within the entire List.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int IndexOf(T item)  //returns the 0-based index of the specified item (-1 if not found)
        {
            Node c = head;
            for (int i = 0; i <= Count; i++)
            {
                if (c.Data.Equals(item))
                {
                    return i - 1;
                }
                else
                {
                    c = c.Next;
                }
            }
            return -1;
        }

        /// <summary>
        /// Displays the list in the Console.
        /// </summary>
        public void DisplayList()
        {
            Node c = head.Next;
            while (c.Next != null)
            {
                Console.Write(c.Data + " ");
                c = c.Next;
            }
            Console.WriteLine(c.Data + " ");

        }
    }
}
