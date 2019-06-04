using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC395_Module3
{
    class Program
    {
        static void Main(string[] args) // O(n)
        {
            // Instantiate a new linked list object and populate it with strings. Then print it to prove it works with strings. 
            SinglyLinkedList myList = new SinglyLinkedList();
            myList.Insert("Albert");
            myList.Insert("Fred");
            myList.Insert("Bob");
            myList.Insert("Derrik");
            myList.Insert("Chad");
            myList.Insert("Garth");
            myList.Insert("Zelda"); 

            myList.PrintList();

            Console.ReadLine();
        }
    }
    // A Node class with a single pointer.
    class Node // O(1)
    {
        public string value { get; set; } // O(1)
        public Node next; // O(1)

        public Node(string value) // O(1)
        {
            this.value = value; // O(1)
            this.next = null; // O(1)
        }
    }

    class SinglyLinkedList
    {
        public Node first; // O(1)

        public bool IsEmpty() // O(1)
        {
            return first == null; // O(1)
        }
        // Adds a Node to the end of the list by iterating to the last Node and linking in the new value. If it's an empty list call AddFirst(val).
        public void AddLast(string val) // O(n)
        {
            if (IsEmpty()) // O(1)
                AddFirst(val); // O(1)
            else
            {
                Node newNode = new Node(val); // O(1)

                Node current = first; // O(1)
                while (current.next != null) // O(n)
                {
                    current = current.next; // O(1)
                }
                current.next = newNode; // O(1)
            }
        }
        // Iterates through the list looking for the given value and links it out. 
        public void Delete(string val) // O(n)
        {
            if (IsEmpty()) // O(1)
                throw new Exception("you can't delete from an empty list"); // O(1)
            else if (val == first.value) // O(1)
                RemoveFirst(); // O(1)
            else
            {
                Node curr = first; // O(1)

                while (curr.next != null &&  curr.next.value != val) // O(n)
                    curr = curr.next; // O(1)
                if (curr.next == null) // O(1)
                    throw new Exception("we didn't find  the element in the list"); // O(1)
                else
                    curr.next = curr.next.next; // O(1)
            }
        }
        // Inserts a new node into the list, attempting to keep it sorted int the process. If empty AddFirst, otherwise iterate through and link in the new node at the appropriate point. 
        public void Insert(string val) // O(n)
        {
            if (IsEmpty() || first.value.CompareTo(val) >= 0) // O(1)
                AddFirst(val); // O(1)
            else
            {
                Node newNode = new Node(val); // O(1)
                Node curr = first; // O(1)
                while (curr.next!=null && curr.next.value.CompareTo(val) < 0) // O(n)
                    curr = curr.next; // O(1)

                newNode.next = curr.next; // O(1)
                curr.next = newNode; // O(1)
            }
        }
        // Move the First pointer to the second Node, allowing the garbage collector to destruct the first node.
        public void RemoveFirst() // O(1)
        {
            if (IsEmpty()) // O(1)
                throw new IndexOutOfRangeException("you can't remove first from an emtpy list"); // O(1)
            else
                first = first.next; // O(1)

        }
        // Iterate through the list looking for the second-to-last Node and set it's pointer to Null, allowing the garbage collector to destruct the last Node.
        public void RemoveLast() // O(n)
        {
            if (IsEmpty()) // O(1)
                throw new IndexOutOfRangeException("you can't remove last from an emtpy list"); // O(1)
            else if(first.next == null) // O(1)
            {
                first = null; // O(1)
            }
            else
            {
                Node current = first; // O(1)
                while (current.next.next != null) // O(n)
                    current = current.next; // O(1)
                current.next = null; // O(1) 
            }
        }
        // Create a new Node, setting it's pointer to first and then setting First to point to the new Node. 
        public void AddFirst(string value) // O(1)
        {
            Node newNode = new Node(value); // O(1)
            newNode.next = first; // O(1)
            first = newNode; // O(1)
        }
        // Move through the list, writing each Node's value to the Console. 
        public void PrintList() // O(n)
        {
            Console.WriteLine(); // O(1)
            Console.WriteLine(); // O(1)
            if (IsEmpty()) // O(1)
                Console.WriteLine("the list is empty!!!"); // O(1)
            else
            {
                Node current = first; // O(1)
                while (current != null) // O(n)
                {
                    Console.Write(current.value + "  "); // O(1)
                    current = current.next; // O(1)
                }
            }
        }
        // A default constructor.
        public SinglyLinkedList() // O(1)
        {
            first = null; // O(1)
        }
    }
}
