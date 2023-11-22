using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project_Browser
{
    public class NodeTab
    {
        public Tab tab;
        public int index;
        public NodeTab next;
        public NodeTab prev;

        public NodeTab(Tab val, int index)
        {
            this.tab = val;
            next = null;
            prev = null;
            this.index = index;
        }
    }
    public class Win
    {
        public NodeTab head;
        public NodeTab tail;
        public NodeTab currentTab;
        public int size = 0;
        public int index = 0;

        public Win()
        {
            head = null;
            tail = null;
        }

        public void addTail(Tab tab)
        {
            NodeTab newNode = new NodeTab(tab, index);
            index++;
            currentTab = newNode;
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
                NodeTab temp = head;
                head = head.next;

                if (head != null)
                {
                    head.prev = null;
                }
                else
                {
                    tail = null;
                }

                currentTab = head;
                size--;
            }
            else
            {
                Console.WriteLine("This Window is empty.");
            }
        }

        public void deleteTail()
        {
            if (tail != null)
            {
                NodeTab temp = tail;
                tail = tail.prev;

                if (tail != null)
                {
                    tail.next = null;
                }
                else
                {
                    head = null;
                }
                currentTab = tail;
                size--;
            }
            else
            {
                Console.WriteLine("This Window is empty.");
            }
        }

        public bool deleteCurrent()
        {
            if (head.next == null)
            {
                Console.WriteLine("You cannot delete the only existed Tab !!!");
                return false;
            }
            if (currentTab == head)
            {
                currentTab = currentTab.next;
                deleteHead();
            }
            else if (currentTab == tail)
            {
                currentTab = currentTab.prev;
                deleteTail();
            }
            else
            {
                NodeTab temp = currentTab;
                currentTab = currentTab.prev;
                currentTab.next = temp.next;
                temp.next.prev = currentTab;
                size--;
            }
            return true;
        }

        public void display()
        {
            NodeTab current = head;
            int i = 1;
            Console.WriteLine("This Window contains: ");
            while (current != null)
            {
                Console.WriteLine("Tab {0} : ", i);
                i++;
                current.tab.display();
                current = current.next;
            }
            Console.WriteLine();
        }

        public bool moveNext()
        {
            if (currentTab.next == null)
            {
                return false;
            }
            else
                currentTab = currentTab.next;
            return true;
        }
        
        public bool moveBack()
        {
            if (currentTab.prev == null)
                return false;
            else
                currentTab = currentTab.prev;
            return true;
        }

        public void changeCurrentTab(int index)
        {
            for (NodeTab p = head; p != null; p = p.next)
            {
                if (p.index == index)
                {
                    currentTab = p;
                    return;
                }
            }
        }

        public bool isEmpty()
        {
            return head == null;
        }

        public void deleteTab(int index)
        {
            NodeTab current = head;

            // Traverse the list to find the node with the specified key
            while (current != null && current.index != index)
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
                Console.WriteLine("Node with key {0} not found in the list.", index);
            }
        }
    }
}
