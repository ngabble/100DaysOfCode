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
            // Instantiate a new linked list object and populate it with integers. Then print it to prove it works. 
            DoublyLinkedList myList = new DoublyLinkedList(); // O(1)
            myList.AddFirst(3); // O(1)
            myList.AddFirst(16); // O(1)
            myList.AddFirst(14); // O(1)
            myList.Insert(26); // O(1)
            myList.Insert(15); // O(1)
            myList.Insert(1); // O(1)
            myList.Insert(45); // O(1)
            myList.Insert(300); // O(1)

            myList.PrintList(); // O(n)

            myList.Delete(14); // O(1)
            myList.AddFirst(0); // O(1)
            myList.AddLast(3); // O(1)

            myList.PrintList(); // O(n)

            bool answer = myList.IsPalindrome(); // O(n)
            Console.WriteLine(); // O(1)
            Console.WriteLine($"Is the list a palindrome? {answer}"); // O(1)

            myList.printReverse(); // O(n)

            DoublyLinkedList myList2 = new DoublyLinkedList(); // O(1)
            myList2.AddFirst(1); // O(1)
            myList2.AddFirst(2); // O(1)
            myList2.AddFirst(4); // O(1)
            myList2.AddFirst(6); // O(1)
            myList2.AddLast(2); // O(1)
            myList2.AddLast(4); // O(1)
            myList2.AddLast(6); // O(1)

            myList2.PrintList(); // O(n)

            answer = myList2.IsPalindrome(); // O(n)
            Console.WriteLine(); // O(1)
            Console.WriteLine($"Is the list a palindrome? {answer}"); // O(1)

            Console.ReadLine(); // O(1)?
        }
    }
    // A Node class with a single pointer.
    class Node // O(1)
    {
        public int value { get; set; } // O(1)
        public Node next; // O(1)
        public Node prev; // O(1)

        public Node(int value) // O(1)
        {
            this.value = value; // O(1)
            this.next = null; // O(1)
            this.prev = null; // O(1)
        }
    }
    // Doubly Linked List Class.
    class DoublyLinkedList
    {
        public Node first; // O(1)
        public Node last; // O(1)

        public bool IsEmpty() // O(1)
        {
            return first == null; // O(1)
        }
        // Adds a Node to the end of the list by linking in the new value and setting last to the new Node. If it's an empty list call AddFirst(val).
        public void AddLast(int val) // O(1)
        {
            if (IsEmpty()) // O(1)
            {
                AddFirst(val); // O(1)
            }
            else
            {
                Node newNode = new Node(val); // O(1)

                last.next = newNode; // O(1)
                newNode.prev = last; // O(1)
                last = newNode; // O(1)
            }
        }
        // Iterates through the list looking for the given value and links it out. 
        public void Delete(int val) // O(n)
        {
            if (IsEmpty()) // O(1)
                throw new Exception("you can't delete from an empty list"); // O(1)
            else if (val == first.value) // O(1)
                RemoveFirst(); // O(1)
            else
            {
                Node curr = first; // O(1)
                Node curr2 = first; // O(1)

                while (curr.next != null && curr.next.value != val) // O(n)
                    curr = curr.next; // O(1)
                if (curr.next == null) // O(1)
                    throw new Exception("we didn't find the element in the list"); // O(1)
                else
                {
                    curr2 = curr.next.next; // O(1)
                    curr.next = curr2; // O(1)
                    curr2.prev = curr; // O(1)
                }
            }
        }
        // Inserts a new node into the list, attempting to keep it sorted int the process. If empty AddFirst, otherwise iterate through and link in the new node at the appropriate point. 
        public void Insert(int val) // O(n)
        {
            if (IsEmpty() || first.value > val) // O(1)
            {
                AddFirst(val); // O(1)
            }
            else
            {
                Node newNode = new Node(val); // O(1)
                Node curr = first; // O(1)

                while (curr.next != null && curr.next.value < val) // O(n)
                    curr = curr.next; // O(1)

                newNode.next = curr.next; // O(1)
                newNode.prev = curr; // O(1)
                curr.next = newNode; // O(1)

                if (newNode.next != null) // O(1)
                {
                    newNode.next.prev = newNode; // O(1)
                }
                if (newNode.next == null) // O(1)
                {
                    last = newNode; // O(1)
                }
            }
        }
        // Move the First pointer to the second Node and set the new first.prev to null, allowing the garbage collector to destruct the first node.
        public void RemoveFirst() // O(1)
        {
            if (IsEmpty()) // O(1)
                throw new IndexOutOfRangeException("you can't remove first from an emtpy list"); // O(1)
            else if (first == last)
            {
                first = null;
                last = null;
            }
            else
            {
                first = first.next; // O(1)
                first.prev = null; // O(1)
            }
        }
        // Set last to the Node before last and set that Node's next pointer to Null, allowing the garbage collector to destruct the last Node.
        public void RemoveLast() // O(1)
        {
            if (IsEmpty()) // O(1)
                throw new IndexOutOfRangeException("you can't remove last from an emtpy list"); // O(1)
            else if (first == last) // O(1)
            {
                first = null; // O(1)
                last = null; // O(1)
            }
            else
            {
                last = last.prev; // O(1)
                last.next = null; // O(1)
            }
        }
        // Create a new Node, setting it's pointer to first and then setting First to point to the new Node. 
        public void AddFirst(int value) // O(1)
        {
            Node newNode = new Node(value); // O(1)
            if (IsEmpty())
            {
                first = newNode;
                last = newNode;
            }
            else
            {
                first.prev = newNode; // O(1)
                newNode.next = first; // O(1)
                first = newNode; // O(1)
            }
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
        public void printReverse() // O(n)
        {
            Console.WriteLine(); // O(1)
            Console.WriteLine(); // O(1)
            if (IsEmpty()) // O(1)
                Console.WriteLine("the list is empty!!!"); // O(1)
            else
            {
                Node current = last; // O(1)
                while (current != null) // O(n)
                {
                    Console.Write(current.value + "  "); // O(1)
                    current = current.prev; // O(1)
                }
            }
        }
        // The function checks if the string is empty. If not, it creates two movable pointers, one at either end of the list. It compares them and
        // if they're equivalent it moves the pointers towards the center and compares them again. If it makes it to the 
        public bool IsPalindrome() // O(n)
        {
            if (IsEmpty()) // O(1)
                Console.WriteLine("the list is empty!!!"); // O(1)

            bool answer = true; // O(1)

            Node comparer1 = first; // O(1)
            Node comparer2 = last; // O(1)

            while (comparer1 != comparer2 && comparer1.prev != comparer2) // O(n)
            {
                if (comparer1.value != comparer2.value) // O(1)
                {
                    answer = false; // O(1)
                    break; // O(1)
                }
                comparer1 = comparer1.next; // O(1)
                comparer2 = comparer2.prev; // O(1)
            }
            return answer; // O(1)
        }
        // A default constructor.
        public DoublyLinkedList() // O(1)
        {
            first = null; // O(1)
            last = null; // O(1)
        }
    }
}

