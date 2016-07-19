using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORT_06
{
    public class LListR : IList
    {
        class Node
        {
            public int val;
            public Node next;
            public Node prev;
            public Node(int val)
            {
                this.val = val;
            }
        }
        Node root; // = null;
                   // Node rear = null;

        public LListR()
        {
        }
        public void Init(int[] ini)
        {
            Clear();
            if (ini == null)
            {
                ini = new int[0];                           //?
               // root = null;
            }
              
            for (int i = ini.Length-1; i >=0; i--)          //с доски
            {
                AddStart(ini[i]);
            }
        }
        public void Clear() //      ?
        {
            root = null;
        }

        public override string ToString()           ///ok
        {
            string str = "";
            if (root == null)
                return str;
            Node tmp = root;
            do
            {
                if (tmp.next != root)
                {
                    str += tmp.val + ", ";
                    tmp = tmp.next;
                }
                else
                {
                    str += tmp.val;
                    tmp = tmp.next;
                }
            }
            while (tmp != root);
            return str;
        }

        public void AddStart(int val)           //// Ok;
        {
            if (root == null)
            {
                root = new Node(val);
                root.prev = root;
                root.next = root;
            }
            else
            {
                Node p = new Node(val);
                p.prev = root.prev;
                p.next = root;
                root.prev.next = p;
                root.prev = p;
                root = p;
            }
        }
        public void AddEnd(int val) //Ok
        {
            if (root == null)
            {
                root = new Node(val);
                root.prev = root;
                root.next = root;
            }
            else
            {
                Node p = new Node(val);
                p.prev = root.prev;
                p.next = root;
                root.prev.next = p;
                root.prev = p;
            }
        }
        public int[] ToArray()      ///ok
        {
            int[] ret = new int[Size()];
            Node tmp = root;
            int i = 0;
            do
            {
                ret[i++] = tmp.val;
                tmp = tmp.next;
            }
            while (tmp != root);
            return ret;
        }

        public int Size()
        {
            int ret = 0;
            Node tmp = root;
            do
            {
                ret++;
                tmp = tmp.next;
            }
            while (tmp != root);
            return ret;
        }

        public void AddPos(int pos, int val)        //вроде, Ok
        {
            if (pos < 0 || pos > Size())
            {
                throw new ArgumentOutOfRangeException();
            }
            if (pos == 0)
                AddStart(val);
            else
            {
                Node p = new Node(val);
                Node tmp = root;
                for (int i = 0; i < pos - 1; i++)
                {
                    tmp = tmp.next;
                }
                p.next = tmp.next;
                p.prev = tmp.next.prev;
                tmp.next.prev = p;
                tmp.next = p;
            }
        }

        public int DelStart()
        {
            if (root == null)
            {
                throw new IndexOutOfRangeException();
            }
            int ret = root.val;
            root = root.next;
            root.prev.prev.next = root;
            root.prev = root.prev.prev;
            return ret;
        }

        public int DelEnd()
        {
            if (root == null)
            {
                throw new IndexOutOfRangeException();
            }
            int ret = root.prev.val;

            root.prev.prev.next = root;
            root.prev = root.prev.prev;
            return ret;
        }

        public int DelPos(int pos)
        {
            if (root == null)
            {
                throw new IndexOutOfRangeException();
            }
            if ((pos < 0) || (pos > Size()))
            {
                throw new ArgumentOutOfRangeException();
            }

            int ret = 0;
            if (pos == 0)
            {
                ret = root.val;
                root = root.next;
                root.prev.prev.next = root;
                root.prev = root.prev.prev;
            }
            else
            {
                Node tmp = root;
                for (int i = 0; i < pos - 1; i++)
                {
                    tmp = tmp.next;
                }
                ret = tmp.next.val;
                tmp.next.next.prev = tmp;
                tmp.next = tmp.next.next;
            }
            return ret;
        }

        public int Min()
        {
            if (root == null)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = root;
            int ret = root.val;
            do
            {
                if (ret > tmp.val)
                    ret = tmp.val;
                tmp = tmp.next;
            }
            while (tmp != root);
            return ret;
        }

        public int Max()
        {
            if (root == null)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = root;
            int ret = root.val;
            do
            {
                if (ret < tmp.val)
                    ret = tmp.val;
                tmp = tmp.next;
            }
            while (tmp != root);
            return ret;
        }

        public int MinInd()
        {
            if (root == null)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = root;
            int min = root.val;
            int i = 0;
            int m = Min();
            while (tmp.val != m)
            {
                tmp = tmp.next;
                i++;
            }
            return i;
        }
        public int MaxInd()
        {
            if (root == null)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = root;
            int min = root.val;
            int i = 0;
            int m = Max();
            while (tmp.val != m)
            {
                tmp = tmp.next;
                i++;
            }
            return i;
        }

        public void Set(int pos, int val)
        {
            if ((pos < 0) || (pos > Size()))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (root == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            Node tmp = root;
            for (int i = 0; i < pos; i++)
            {
                tmp = tmp.next;
            }
            tmp.val = val;
        }

        public int Get(int pos)
        {
            if (root == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            if ((pos < 0) || (pos > Size()))
            {
                throw new ArgumentOutOfRangeException();
            }
            Node tmp = root;
            int ret = 0;
            if (pos == 0)
            {
                ret = root.val;
            }
            else
            {
                for (int i = 0; i < pos; i++)
                {
                    tmp = tmp.next;
                }
                ret = tmp.val;
            }
            return ret;
        }

        public void Reverse()
        {

            Node p = null;
            int S = Size();
            Node tmp2 = root.next;
            for (int i = 0; i < S; i++)
            {
                Node tmp = root;
                root = root.next;

                tmp.next = p;
                tmp2 = tmp;
                p = tmp;
            }
            root = p;
        }
        /*
        public void HalfReverse()
        {
            int S = Size();
            if (S <= 1)
            {
                return;
            }
            Node p = null;
            Node tmp = front;
            Node tmp_root = front;
            for (int i = 0; i < S / 2 - 1; i++)
            {
                tmp = tmp.next;
            }
            front = tmp.next;
            tmp.next = p;
            p = tmp_root;
            if (S % 2 != 0)
            {
                tmp_root = front;
                front = front.next;
                tmp_root.next = p;
                p = tmp_root;
            }
            rear.next = p;
        }
        public void Sort()
        {
            Node tmp;
            Node tmp2;
            for (tmp = front; tmp != null; tmp = tmp.next)
            {
                for (tmp2 = front; tmp2.next != null; tmp2 = tmp2.next)
                {
                    if (tmp.val < tmp2.val)
                    {
                        int buf = tmp.val;
                        tmp.val = tmp2.val;
                        tmp2.val = buf;
                    }
                }
            }
        }

        public void AddPos(int pos, int[] ini)
        {
            for (int i = 0; i < ini.Length; i++)
            {
                AddPos(pos + i, ini[i]);
            }
        }*/
    }
}