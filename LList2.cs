using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORT_06
{
    public class LList2 : IList
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
        Node front = null;
        Node rear = null;

        public LList2()
        {
        }
        public void Init(int[] ini)
        {
            Clear();
            if (ini == null)
            {
                ini = new int[0];
            }
            front = null;
            rear = null;
            for (int i = 0 ; i < ini.Length; i++)
            {
                AddEnd(ini[i]);
            }
        }
        public void Clear()
        {
            front = null;
            rear = null;
        }
        
        public override string ToString()
        {
            string str = "";
            Node tmp = front;
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
            if (front == null)
            {
                front = p;
                rear = p;
            }
            else
            {
                p.next = front;
                front.prev = p;
                front = p;
            }
        }
        public void AddEnd(int val)
        {
            Node p = new Node(val);
            if (front == null)
            {
                front = p;
                rear = p;
            }
            else
            {
                p.prev = rear;
                rear.next = p;
                rear = p;
            }
        }
/*
        public int[] ToArray()
        {
            int[] ret = new int[Size()];
            Node tmp = front;
            int i = 0;
            while (tmp != null)
            {
                ret[i++] = tmp.val;
                tmp = tmp.next;
            }
            return ret;
        }
*/
        
                public int[] ToArray()
                {
                    int[] ret = new int[Size()];
                    Node tmp = rear;
                    int i = 0;
                    int s = Size();
                    while (tmp != null)
                    {

                        ret[s - i - 1] = tmp.val;
                        i++;
                        tmp = tmp.prev;
                    }
                    return ret;
                }
        
        public int Size()
        {
            int ret = 0;
            Node tmp = front;
            while (tmp != null)
            {
                ret++;
                tmp = tmp.next;
            }
            return ret;
        }
        
        public void AddPos(int pos, int val)
        {
            if (pos < 0||pos > Size())
            {
                throw new ArgumentOutOfRangeException();
            }
            if (pos == 0)
                AddStart(val);
            else
            {
                Node p = new Node(val);
                Node tmp = front;
                for (int i = 0; i < pos - 1; i++)
                {
                    tmp = tmp.next;
                }
                p.next = tmp.next;
                p.prev = tmp.next.prev;
                
                           //?
                tmp.next.prev = p;
                tmp.next = p;
            }
        }

        public int DelStart()
        {
            if (front == null)
            {
                throw new IndexOutOfRangeException();
            }
            int ret = front.val;
            if (front.next == null)
            {
                front = null;
                rear = null;
            }
            else
            {
                if (front.next == null)
                {
                    front = null;
                }
                else
                {
                    front = front.next;
                    front.prev = null;
                }
            }
            return ret;
        }
        
        public int DelEnd()
        {
            if (front == null)
            {
                throw new IndexOutOfRangeException();
            }
            int ret = rear.val;
            if (rear.prev == null)
            {
                front = null;
                rear = null;
            }
            else
            {
                rear = rear.prev;
                rear.next = null;
            }
            return ret;
        }
        
        public int DelPos(int pos)
        {
            if (front == null)
            {
                throw new IndexOutOfRangeException();
            }
            if ((pos < 0)||(pos> Size()))
            {
                throw new ArgumentOutOfRangeException();
            }
            int ret = 0;
            if (front.next == null)
            {
                ret = front.val;
                front = null;
                rear = null;
            }
            else
            {
                if (pos == 0)
                {
                    ret = front.val;
                    front.next.prev = null;
                    front = front.next;

                }
                else if (pos == Size() - 1)
                {
                    ret = rear.val;
                    rear.prev.next = null;
                    rear = rear.prev;
                }
                else
                {
                    Node tmp = front;
                    for (int i = 0; i < pos - 1; i++)
                    {
                        tmp = tmp.next;
                    }
                    ret = tmp.next.val;
                    tmp.next = tmp.next.next;
                    tmp.next.prev = tmp;
                }
            }
            
            return ret;
        }
        
        public int Min()
        {
            if (front == null)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = front;
            int ret = front.val;
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
            if (front == null)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = front;
            int ret = front.val;
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
            if (front == null)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = front;
            int min = front.val;
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
            if (front == null)
            {
                throw new IndexOutOfRangeException();
            }
            Node tmp = front;
            int max = front.val;
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
            if (front == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            Node tmp = front;
            for (int i = 0; i < pos; i++)
            {
                tmp = tmp.next;
            }
            tmp.val = val;
        }
        
        public int Get(int pos)
        {
            if (front == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            if ((pos < 0) || (pos > Size()))
            {
                throw new ArgumentOutOfRangeException();
            }
            Node tmp = front;
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

            //   Node p = null;
            ////   Node r = null;
            //   int S = Size();
            //   for (int i = 0; i < S; i++)
            //   {
            //       Node tmp = front;
            //      // Node tmp2 = rear;
            //       front = front.next;
            //       tmp.next = p;
            //       p = tmp;
            //   }
            //   front = p;

            Node p = null;
            Node tmp = front;
            Node r = rear;
            front = front.next;
            tmp.next = p;
            tmp.prev = r;
            p = tmp;
            r = tmp;
            int S = Size();
            for (int i = 1; i < S; i++)
            {
                tmp = front;
                front = front.next;
                tmp.next = p;
                tmp.prev = p.prev;
                p.prev = tmp;
                p = tmp;
            }



        }

        public void HalfReverse()
        {
            int S = Size();
            if (S <= 1)
            {
                return;
            }
            Node p = null;
           // Node r = null;
            Node tmp = front;
            Node tmp_front = front;
            Node tmp_rear = rear;
            for (int i = 0; i < S / 2 - 1; i++)
            {
                tmp = tmp.next;
            }
            front = tmp.next;
            tmp.next = p;
            tmp_rear = tmp;
            p = tmp_front;
            if (S % 2 != 0)
            {
                tmp_front = front;
                front = front.next;
                tmp_front.next = p;
                p = tmp_front;
            }
            rear.next = p;
            rear = tmp_rear;
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
            if(front == null)
            {
                Init(ini);
            }
            else
            {
                for (int i = 0; i < ini.Length; i++)
                {
                    AddPos(pos + i, ini[i]);
                }
            }

        }
    }
}
