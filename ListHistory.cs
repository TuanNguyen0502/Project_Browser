using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project_Browser
{
    public class NodeHistory
    {
        public string his;
        public DateTime date;
        public NodeHistory next;
        public NodeHistory prev;

        public NodeHistory(string s)
        {
            his = s;
            next = null;
            prev = null;
            this.date = DateTime.Now;
        }
        public NodeHistory(string url, int month, int day, int year, int hour, int minute, int second)
        {
            this.his = url;
            next = null;
            prev = null;
            this.date = new DateTime(year, month, day, hour, minute, second);
        }
    }
    public class ListHistory
    {
        public NodeHistory head;
        public NodeHistory tail;
        public NodeHistory currentHistory;
        public int size = 0;

        public ListHistory()
        {
            head = null;
            tail = null;
        }

        public void addTail(string url, int month, int day, int year, int hour, int minute, int second)
        {
            NodeHistory newNode = new NodeHistory(url, month, day, year, hour, minute, second);
            currentHistory = newNode;
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

        public void addTail(string his)
        {
            NodeHistory newNode = new NodeHistory(his);
            currentHistory = newNode;
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
                NodeHistory temp = head;
                head = head.next;

                if (head != null)
                {
                    head.prev = null;
                }
                else
                {
                    tail = null;
                }

                currentHistory = head;
                size--;
            }
            else
            {
                Console.WriteLine("This List History is empty.");
            }
        }

        public void deleteTail()
        {
            if (tail != null)
            {
                NodeHistory temp = tail;
                tail = tail.prev;

                if (tail != null)
                {
                    tail.next = null;
                }
                else
                {
                    head = null;
                }
                currentHistory = tail;
                size--;
            }
            else
            {
                Console.WriteLine("This List History is empty.");
            }
        }

        public void deleteHis(string his)
        {
            NodeHistory current = head;

            // Traverse the list to find the node with the specified key
            while (current != null && current.his != his)
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
                Console.WriteLine("Node with key {0} not found in the list.", his);
            }
        }

        public void display()
        {
            NodeHistory current = head;
            while (current != null)
            {
                Console.WriteLine("{0}", current.his);
                current = current.next;
            }
            Console.WriteLine();
        }
    }
}
