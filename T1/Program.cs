using System;

namespace T1
{
    class Node {
        public int iData;
        public Node next;
        public Node(int id) {
            this.iData = id; }
    }
    class LinkList { 
        private Node first;
        public LinkList() {  first = null; }
        public Node find(int key) { 
            Node current = first;
            while (current != null && current.iData != key)
                current = current.next;
            return current; }
        public void displayList() { 
            for (Node current = first; current != null; current = current.next)
                System.Console.WriteLine(current.iData);
        }

        public void insertFirst(int key)
        {
            if (first == null)
            {
                first = new Node(key);
            }
            else
            {
                Node n = new Node(key);
                n.next = first;
                first = n;
            }
        }

        public Node delete(int key)
        {
            var current_node = first;
            while (current_node != null)
            {
                if (first.iData == key)
                    first = first.next;
                else
                {
                    if (current_node.next != null &&
                        current_node.next.iData == key)
                    {
                        current_node.next = current_node.next.next;
                        return first;
                    }
                    current_node = current_node.next;
                }
            }
            return null;
        }
        
    }
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LinkList theList = new LinkList(); 
            theList.insertFirst(22); 
            theList.insertFirst(44); 
            theList.insertFirst(66); 
            Node d = theList.delete(44); 
            d = theList.delete(88);
            theList.displayList();
        }
    }
}
