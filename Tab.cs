using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Project_Browser
{
    public class NodePage
    {
        public string url;
        public NodePage next;
        public NodePage prev;

        public NodePage(string val)
        {
            url = val;
            next = null;
            prev = null;
        }
    }
    public class Tab
    {
        public NodePage head;
        public NodePage tail;
        public NodePage currentPage;
        public int size = 0;

        public Tab()
        {
            head = null;
            tail = null;
            currentPage = null;
        }

        public void AddNewPage(string address)
        {
            // Xoá các page phía sau current
            while (currentPage != tail)
            {
                deleteTail();
            }

            // Thêm page mới vào tail
            addTail(address);
        }

        public void addTail(string address)
        {
            NodePage newNode = new NodePage(address);
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
                NodePage temp = head;
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
                Console.WriteLine("This TAB is empty.");
            }
        }

        public void deleteTail()
        {
            if (tail != null)
            {
                NodePage temp = tail;
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
                Console.WriteLine("This TAB is empty.");
            }
        }

        public bool deleteCurrent()
        {
            if (head == null)
            {
                Console.WriteLine("There isn't any Page to delete.");
                Console.WriteLine();
                return false;
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
                NodePage temp = currentPage;
                currentPage = currentPage.prev;
                currentPage.next = temp.next;
                temp.next.prev = currentPage;
                size--;
            }
            return true;
        }

        public void display()
        {
            NodePage current = head;
            int i = 1;
            Console.WriteLine("This Tab contains: ");
            while (current != null)
            {
                Console.WriteLine("Page {0} : {1}\t", i, current.url);
                i++;
                current = current.next;
            }
            Console.WriteLine();
        }

        public bool moveNext()
        {
            if (currentPage.next == null)
            {
                return false;
            }
            else
                currentPage = currentPage.next;
            return true;
        }
        public bool moveBack()
        {
            if (currentPage.prev == null)
            {
                return false;
            }
            else
                currentPage = currentPage.prev;
            return true;
        }

        public int getCurrentIndex()
        {
            int i = 1;
            for (NodePage p = head; p != null; p = p.next)
            {
                if (p == currentPage)
                {
                    return i;
                }
                i++;
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

            NodePage current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }

            return current.url;
        }

        public bool isEmpty()
        {
            return head == null;
        }
    }
}
