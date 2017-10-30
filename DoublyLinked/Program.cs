using System;

namespace DoublyLinked
{
    class Program
    {
        static void Main(string[] args)
        {
            var llist = new LinkedList<object>();
            llist.Add('o');
            llist.Add('n');
            llist.Add('u');
            llist.Add('r');

            Console.WriteLine("---traverse---");
            llist.Traverse();

            Console.WriteLine("---reverse traverse---");
            llist.ReverseTraverse();


            Console.ReadLine();
        }
    }


    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T data)
        {
            this.Data = data;
            this.Next = null;
            this.Previous = null;
        }
    }

    public class LinkedList<T>
    {
        private Node<T> Head;

        public LinkedList()
        {
            this.Head = null;
        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (this.Head == null)
            {
                this.Head = node;
            }
            else
            {
                Node<T> tmp = this.Head;

                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }

                node.Previous = tmp;
                tmp.Next = node;
            }
        }

        public void Remove(T data)
        {
            Node<T> tmp = this.Head;

            while (tmp != null)
            {
                if (tmp.Data.Equals(data))
                {
                    Remove_Inner(tmp);
                    break;
                }

                tmp = tmp.Next;
            }
        }

        public void Traverse()
        {
            Node<T> tmp = this.Head;

            while (tmp != null)
            {
                Console.WriteLine(tmp.Data);
                tmp = tmp.Next;
            }
        }

        public void ReverseTraverse()
        {
            Node<T> tmp = this.Head;

            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }

            while (tmp != null)
            {
                Console.WriteLine(tmp.Data);

                tmp = tmp.Previous;
            }
        }

        public int IndexOf(T data)
        {
            int index = -1;
            bool isHit = false;
            Node<T> tmp = this.Head;

            while (tmp != null)
            {
                ++index;

                if (tmp.Data.Equals(data))
                {
                    return index;
                }

                tmp = tmp.Next;
            }

            return isHit ? index : -1;
        }

        public int LastIndexOf(T data)
        {
            int index = -1;
            int tmp_index = -1;
            bool isHit = false;

            Node<T> tmp = this.Head;

            while (tmp != null)
            {
                ++index;

                if (tmp.Data.Equals(data))
                {
                    tmp_index = index;
                    isHit = true;
                }

                tmp = tmp.Next;
            }

            return isHit ? tmp_index : -1;
        }

        private void Remove_Inner(Node<T> tmp)
        {
            Node<T> tmpPrev = tmp.Previous;
            Node<T> tmpNext = tmp.Next;

            if (tmpPrev != null)
            {
                tmpPrev.Next = tmpNext;
            }
            else
            {
                this.Head = tmp.Next;
            }
        }
    }

}
