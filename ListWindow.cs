using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Browser
{
    public class NodeWindow
    {
        public Win window;
        public NodeWindow next;
        public NodeWindow prev;

        public NodeWindow(Win val)
        {
            window = val;
            next = null;
            prev = null;
        }
    }
    public class ListWindow
    {
        public NodeWindow head;
        public NodeWindow tail;
        public NodeWindow currentWindow;
        public int size = 0;

        public ListWindow()
        {
            head = null;
            tail = null;
        }

        public void addTail(Win window)
        {
            NodeWindow newNode = new NodeWindow(window);
            currentWindow = newNode;
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
                NodeWindow temp = head;
                head = head.next;

                if (head != null)
                {
                    head.prev = null;
                }
                else
                {
                    tail = null;
                }

                currentWindow = head;
                size--;
            }
            else
            {
                Console.WriteLine("This ListWindow is empty.");
            }
        }

        public void deleteTail()
        {
            if (tail != null)
            {
                NodeWindow temp = tail;
                tail = tail.prev;

                if (tail != null)
                {
                    tail.next = null;
                }
                else
                {
                    head = null;
                }
                currentWindow = tail;
                size--;
            }
            else
            {
                Console.WriteLine("This ListWindow is empty.");
            }
        }

        public bool deleteCurrent()
        {
            if (head.next == null)
            {
                Console.WriteLine("You cannot delete the only existed Window !!!");
                Console.WriteLine();
                return false;
            }
            if (currentWindow == head)
            {
                currentWindow = currentWindow.next;
                deleteHead();
            }
            else if (currentWindow == tail)
            {
                currentWindow = currentWindow.prev;
                deleteTail();
            }
            else
            {
                NodeWindow temp = currentWindow;
                currentWindow = currentWindow.prev;
                currentWindow.next = temp.next;
                temp.next.prev = currentWindow;
                size--;
            }
            return true;
        }

        public void display()
        {
            NodeWindow current = head;
            while (current != null)
            {
                current.window.display();
                Console.WriteLine();
                current = current.next;
            }
            Console.WriteLine();
        }

        public bool moveNext()
        {
            if (currentWindow.next == null)
            {
                return false;
            }
            else
                currentWindow = currentWindow.next;
            return true;

        }
        public bool moveBack()
        {
            if (currentWindow.prev == null)
            {
                return false;
            }
            else
                currentWindow = currentWindow.prev;
            return true;
        }

        public int getCurrentIndex()
        {
            int i = 1;
            for (NodeWindow p = head; p != null; p = p.next)
            {
                if (p == currentWindow)
                {
                    return i;
                }
                i++;
            }
            return -1;
        }
    }
}
