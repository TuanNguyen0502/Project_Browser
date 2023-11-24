using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Project_Browser
{
    public class NodeBookmark
    {
        public string url;
        public int index;
        public NodeBookmark next;
        public NodeBookmark prev;

        public NodeBookmark(string val, int index)
        {
            url = val;
            next = null;
            prev = null;
            this.index = index;
        }
    }
    public class ListBookmark
    {
        public NodeBookmark head;
        public NodeBookmark tail;
        public NodeBookmark currentPage;
        public int size = 0;
        public int index = 0;

        public ListBookmark()
        {
            head = null;
            tail = null;
            currentPage = null;
        }
        public void addTail(string address)
        {
            if (address == "NULL")
                return;

            NodeBookmark newNode = new NodeBookmark(address, index++);
            currentPage = newNode;

            if (tail == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            size++;
        }

        public void deleteHead()
        {
            if (head != null)
            {
                NodeBookmark temp = head;
                head = head.next;

                if (head != null)
                {
                    head.prev = null;
                }
                else
                {
                    tail = null;
                }

                size--;
            }
            else
            {
                Console.WriteLine("This ListBookmark is empty.\n");
            }
        }

        public void deleteTail()
        {
            if (tail != null)
            {
                NodeBookmark temp = tail;
                tail = tail.prev;

                if (tail != null)
                {
                    tail.next = null;
                }
                else
                {
                    head = null;
                }
                size--;
            }
            else
            {
                Console.WriteLine("This ListBookmark is empty.\n");
            }
        }

        public void deleteCurrent()
        {
            if (head == null)
            {
                return;
            }
            if (currentPage == head)
            {
                currentPage = currentPage.next;
                deleteHead();
            }
            else if (currentPage == tail)
            {
                currentPage = currentPage.prev;
                deleteTail();
            }
            else
            {
                NodeBookmark temp = currentPage;
                currentPage = currentPage.prev;
                currentPage.next = temp.next;
                temp.next.prev = currentPage;
                size--;
            }
        }

        public void deleteBookmark(string data)
        {
            NodeBookmark current = head;

            // Traverse the list to find the node with the specified key
            while (current != null && current.url != data)
            {
                current = current.next;
            }

            // If the node with the key is found
            if (current != null)
            {
                // Adjust the pointers of the adjacent nodes
                if (current.prev != null)
                {
                    current.prev.next = current.next;
                }
                else
                {
                    head = current.next; // If the node to be deleted is the head
                }

                if (current.next != null)
                {
                    current.next.prev = current.prev;
                }

                // Clean up the deleted node
                current.prev = null;
                current.next = null;
            }
            else
            {
                Console.WriteLine("Node with key {0} not found in the list.", data);
            }
        }

        public void display()
        {
            NodeBookmark current = head;
            int i = 1;
            Console.WriteLine("Bookmark contains: \n");
            while (current != null)
            {
                Console.WriteLine("Page {0} : {1}\t", i, current.url);
                i++;
                current = current.next;
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public void moveNext()
        {
            if (currentPage.next == null)
            {
                return;
            }
            else
                currentPage = currentPage.next;
        }

        public void moveBack()
        {
            if (currentPage.prev == null)
            {
                return;
            }
            else
                currentPage = currentPage.prev;
        }

        public int getCurrentIndex()
        {
            int i = 1;
            for (NodeBookmark p = head; p != null; p = p.next)
            {
                if (p == currentPage)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }

        public bool isEmpty()
        {
            return head == null;
        }

        public int getIndex(string value)
        {
            NodeBookmark current = head;
            int index = 0;

            while (current != null)
            {
                if (current.url == value)
                {
                    return index;
                }
                current = current.next;
                index++;
            }
            return -1;
        }

        public string getDataAtIndex(int index)
        {
            if (index < 0 || index >= size || size == 0)
            {
                Console.WriteLine("Index is out of bounds or the list is empty.");
                return "Error";
            }

            NodeBookmark current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }

            return current.url;
        }

        public void deleteNode(int index)
        {
            if (index < 0 || index >= size || size == 0)
            {
                Console.WriteLine("Deletion at index {0} is not possible.", index);
                return;
            }

            NodeBookmark current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }

            if (current == currentPage)
            {
                deleteCurrent();
                return;
            }
            if (current == head)
            {
                head = current.next;
                if (head == null)
                {
                    head.prev = null;
                }
            }
            else if (current == tail)
            {
                tail = current.prev;
                tail.next = null;
            }
            else
            {
                current.prev.next = current.next;
                current.next.next = current.prev;
            }

            size--;
        }
    }
}
