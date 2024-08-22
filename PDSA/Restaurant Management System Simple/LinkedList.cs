using Mysqlx.Crud;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System_Simple
{


    public class LinkedList<T>
    {
        // Private head of the list
        private Node<T> head;

        // Public property to access the head node
        public Node<T> Head
        {
            get { return head; }
        }

        public LinkedList()
        {
            head = null;
        }

        // Add a node at the end
        public void AddLast(T data)
        {
            Node<T> newNode = new Node<T>(data);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node<T> current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        // Remove a node by value
        public void Remove(T data)
        {
            if (head == null) return;

            if (head.Data.Equals(data))
            {
                head = head.Next;
                return;
            }

            Node<T> current = head;
            while (current.Next != null && !current.Next.Data.Equals(data))
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
            }
        }

        // Find the first node that matches the condition
        public Node<T> Find(Func<T, bool> predicate)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (predicate(current.Data))
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        // Get all items as a list
        public List<T> ToList()
        {
            List<T> items = new List<T>();
            Node<T> current = head;
            while (current != null)
            {
                items.Add(current.Data);
                current = current.Next;
            }
            return items;
        }

        // Count the number of nodes
        public int Count()
        {
            int count = 0;
            Node<T> current = head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }
    }

}

