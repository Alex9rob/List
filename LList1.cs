using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORT_06
{
    public class LList1 : IList
    {
        class Node
        {
            public int val;
            public Node next;
            public Node(int val)
            {
                this.val = val;
            }
        }
        Node root = null;
        public LList1()
        {
        }
        public void Init(int[] ini)
        {
            if (ini == null)
            {
                ini = new int[0];
            }
            root = null;
            for (int i = ini.Length - 1; i >= 0; i--)
            {
                AddStart(ini[i]);
            }
        }
        public void Clear()
        {
            root = null;
        }
        public override string ToString()
        {
            string str = "";
            Node tmp = root;
            while (tmp != null)
            {
                if (tmp.next != null)
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
            return str;
        }
        public void AddStart(int val)
        {
            Node p = new Node(val);
            p.next = root;
            root = p;
        }
        public void AddEnd(int val)         
        {
            if(root==null)
                AddStart(val);
            else
            {
                Node p = new Node(val);
                Node tmp = root;
                while (tmp.next != null)
                {
                    tmp = tmp.next;
                }
                tmp.next = p;
            }
        }
        public int[] ToArray()
        {
            int[] ret = new int[Size()];
            Node tmp = root;
            int i = 0;
            while (tmp != null)
            {
                ret[i++] = tmp.val;
                tmp = tmp.next;
            }
            return ret;
        }
        public int Size()
        {
            int ret = 0;
            Node tmp = root;
            while (tmp != null)
            {
                ret++;
                tmp = tmp.next;
            }
            return ret;
        }
        public void AddPos(int pos, int val)
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
                for (int i = 0; i < pos-1; i++)
                {
                    tmp = tmp.next;
                }
                p.next = tmp.next;
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
            return ret;
        }
        public int DelEnd()
        {
            if (root == null)
            {
                throw new IndexOutOfRangeException();
            }
            int ret = 0;
            if (root.next == null)
            {
                ret = root.val;
               // root = root.next;
                root = null;
            }
            else
            {
                Node tmp = root;

                while (tmp.next.next != null)
                {
                    tmp = tmp.next;
                }
                ret = tmp.next.val;
                tmp.next = null;        ////
            }
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
            }
            else
            {
                Node tmp = root;
                for (int i = 0; i < pos - 1; i++)
                {
                    tmp = tmp.next;
                }
                ret = tmp.next.val;
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
            while (tmp != null)
            {
                if (ret > tmp.val)
                    ret = tmp.val;
                tmp = tmp.next;
            }
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
            while (tmp != null)
            {
                if (ret < tmp.val)
                    ret = tmp.val;
                tmp = tmp.next;
            }
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
            int M = Min();
            while (tmp.val != M)
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
            int max = root.val;
            int i = 0;
            int M = Max();
            while (tmp.val != M)
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
            Node p = new Node(val);
            if (pos != 0)
            {
                Node tmp = root;
                for (int i = 0; i < pos-1; i++)
                {
                    tmp = tmp.next;
                }
                p.next = tmp.next.next;
                tmp.next = p;
            }
            else
            {
                p.next = root.next;
                root = p;
            }
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
                for (int i = 0; i < pos; i++)
                {
                    tmp = tmp.next;
                }
                ret = tmp.val;
            return ret;
        }

        public void Reverse()
        {
            Node root2 = null;
            int S = Size();
            for (int i = 0; i < S; i++)
            {
                Node tmp = root;
                root = root.next;
                tmp.next = root2;
                root2 = tmp;
            }
            root = root2;
        }
        public void HalfReverse()
        {
            int S = Size();
            if (S <= 1)
            {
                return;
            }
            Node p = null;
            Node tmp = root;
            Node tmp_root = root;
            for (int i = 0; i < S / 2 - 1; i++)
            {
                tmp = tmp.next;
            }
            root = tmp.next;
            tmp.next = p;
            p = tmp_root;
            if (S % 2 != 0)
            {
                tmp_root = root;
                root = root.next;
                tmp_root.next = p;
                p = tmp_root;
            }
            tmp = root;
            while (tmp.next != null)
            {
                tmp = tmp.next;
            }
            tmp.next = p;
        }
        public void Sort()
        {
            Node tmp;
            Node tmp2;
            for (tmp = root; tmp != null; tmp = tmp.next)
            {
                for (tmp2 = root; tmp2.next != null; tmp2 = tmp2.next)
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
            if (ini == null || ini.Length == 0)
                return;
            Node pStart = new Node(ini[0]);
            Node pEnd = pStart;
            for (int i = 1; i < ini.Length; i++)
            {
                Node tmp = new Node(ini[i]);
                pEnd.next = tmp;
                pEnd = tmp;
            }
            if (pos < 0 || pos > Size())
            {
                throw new ArgumentOutOfRangeException();
            }
            if (pos == 0)
            {
                pEnd.next = root;
                root = pStart;
            }
            else
            {
                Node t = root;
                for (int i = 0; i < pos - 1; i++)
                {
                    t = t.next;
                }
                pEnd.next = t.next;
                t.next = pStart;
            }
        }
    }
}