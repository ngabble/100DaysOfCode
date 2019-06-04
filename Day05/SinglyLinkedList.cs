using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC395_Module3
{
    class Program
    {
        static void Main(string[] args) // O(n^2)
        {
            // Instantiate a new linked list object and populate it with strings. Then print it to prove it works with strings. 
            SinglyLinkedList myList = new SinglyLinkedList();
            myList.Insert("Albert"); // O(n)
            myList.Insert("Albert"); // O(n)
            myList.Insert("Fred"); // O(n)
            myList.Insert("Bob"); // O(n)
            myList.Insert("Derrik"); // O(n)
            myList.Insert("Bob"); // O(n)
            myList.Insert("Chad"); // O(n)
            myList.Insert("Garth"); // O(n)
            myList.Insert("Fred"); // O(n)
            myList.Insert("Zelda"); // O(n)
            myList.Insert("Zelda"); // O(n)
            myList.AddLast("Albert"); // O(1)

            myList.PrintList(); // O(n)

            myList.RemoveDublicates(); // O(n^2)

            myList.PrintList(); // O(n)

            bool answer = myList.IsPalindrome(); //O(1)

            Console.WriteLine(); //O(1)
            Console.WriteLine($"Is the list a palindrome? {answer}"); //O(1)

            SinglyLinkedList myList2 = new SinglyLinkedList(); //O(1)
            myList2.AddFirst("Church"); //O(1)
            myList2.AddFirst("Monk"); //O(1)
            myList2.AddLast("Church"); //O(1)
            myList2.AddLast("Monk"); //O(1)

            myList2.PrintList(); //O(n)

            answer = myList2.IsPalindrome(); //O(n)

            Console.WriteLine(); //O(1)
            Console.WriteLine($"Is the list a palindrome? {answer}"); //O(1)

            Console.ReadLine(); // O(?)
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

                while (curr.next != null && curr.next.value != val) // O(n)
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
                while (curr.next != null && curr.next.value.CompareTo(val) < 0) // O(n)
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
            else if (first.next == null) // O(1)
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
        // First we check if the list is empty, assuming it's not we'll create two pointers and compare them iteratively, moving comparer through the remainder of the list
        // each time we move curr foreward once. If we find a duplicate we link the duplicate out and run the comparison again without moving the pointers.
        public void RemoveDublicates() // O(n^2)
        {
            if (IsEmpty()) // O(1)
            {
                Console.WriteLine("the list is empty!!!"); // O(1)
            }

            Node curr = first; // O(1)
            Node comparer = first; // O(1)

            while (curr != null && curr.next != null)  // O(n^2)
            {
                if (comparer == null) // O(1)
                {
                    curr = curr.next; // O(1)
                    comparer = curr; // O(1)
                }
                if (comparer != null && comparer.next != null && curr.value.CompareTo(comparer.next.value) == 0) // O(1)
                {
                    comparer.next = comparer.next.next; // O(1)
                    continue; // O(1)
                }
                if (comparer != null) // O(1)
                    comparer = comparer.next; // O(1)
            }
        }
        // This is the function we want to call to check for a palindrom. It creates two pointers and moves both to the last node in the list. 
        // It then starts a loop, putting one pointer to the node just before the other pointer while moving the head pointer forward and comparing them. 
        // The loop breaks if it finds two values that aren't equal and returns false. Otherwise it compares each element until the pointers meet in the middle.
        public bool IsPalindrome()  // O(n)
        {
            bool answer = true; // O(1)
            if (IsEmpty()) // O(1)
                Console.WriteLine("the list is empty!!!"); // O(1)

            Node head = first;  // O(1)
            Node comparer1 = first;  // O(1)
            
            
            while (comparer1.next != null)  // O(n)
                comparer1 = comparer1.next;  // O(1)

            Node comparer2 = comparer1; // O(1)

            while (head != comparer1 && head != comparer2 && head.next != comparer1 && head.next != comparer2) // O(n)
            {
                if (head.next != null && head.next != comparer1 && head.next != comparer2) // O(1)
                {
                    if (head.value.CompareTo(comparer1.value) != 0) // O(1)
                    {
                        answer = false; // O(1)
                        break; // O(1)
                    }
               
                    head = head.next; // O(1)
                    comparer2 = head; // O(1)
                    while (comparer2.next != comparer1)  // O(n)
                    {
                        comparer2 = comparer2.next;  // O(1)
                    }
                }
                if (head.next != null && head.next != comparer1 && head.next != comparer2) // O(1)
                {
                    if (head.value.CompareTo(comparer2.value) != 0) // O(1)
                    {
                        answer = false; // O(1)
                        break; // O(1)
                    }
                
                    head = head.next; // O(1)
                    comparer1 = head; // O(1)
                    while (comparer1.next != comparer2)  // O(n)
                    {
                        comparer1 = comparer1.next;  // O(1)
                    }
                }
            }
            return answer;  // O(1)
        }
        // A default constructor.
        public SinglyLinkedList() // O(1)
        {
            first = null; // O(1)
        }
    }
}
