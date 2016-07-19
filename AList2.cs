using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORT_06
{
    public class AList2 : IList
    {
        int[] ar = new int[30];
        int start = 15;
        int end = 15;

        public AList2()
        {

        }
        public void Init(int[] ini)
        {
            if (ini == null)
            {
                ini = new int[0];
            }
            start = ar.Length / 2 - ini.Length / 2;
            for (int i = 0; i < ini.Length; i++)
            {
                ar[start + i] = ini[i];
            }
            end = start + ini.Length;
        }

        public void Clear()
        {
            start = end = ar.Length / 2;
        }

        public override String ToString()
        {
            String str = "";
            for (int i = start; i < end; i++)
            {
                if (i != end - 1)
                    str += ar[i] + ", ";
                else
                    str += ar[i];
            }
            return str;
        }
        public int[] ToArray()
        {
            int[] ret = new int[Size()];
            for (int i = start; i < end; i++)
            {
                ret[i - start] = ar[i];
            }
            return ret;
        }
        public void AddStart(int val)
        {
            ar[--start] = val;
        }
        public void AddEnd(int val)
        {
            ar[end++] = val;
        }
        public void AddPos(int pos, int val)
        {
            if ((pos > end - start) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            for (int i = end; i > start + pos; i--)
            {
                ar[i] = ar[i - 1];
            }
            end++;
            ar[start + pos] = val;
        }
        public int DelStart()
        {
            if (start == end)
            {
                throw new IndexOutOfRangeException();
            }
            start++;
            return ar[start - 1];
        }
        public int DelEnd()
        {
            if (start == end)
            {
                throw new IndexOutOfRangeException();
            }
            end--;
            return ar[end];
        }
        public int Size()
        {
            return end - start;
        }
        public int DelPos(int pos)
        {
            if (start == end)
            {
                throw new IndexOutOfRangeException();
            }
            if ((pos > end - start) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            int tmp = ar[pos + start];
            end--;
            for (int i = pos + start; i < end; i++)
            {
                ar[i] = ar[i + 1];
            }
            return tmp;
        }
        public int Min()
        {
            if (start == end)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = ar[start];
            for (int i = start+1; i < end; i++)
            {
                if (tmp > ar[i])
                    tmp = ar[i];
            }
            return tmp;
        }
        public int Max()
        {
            if (start == end)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = ar[start];
            for (int i = start+1; i < end; i++)
            {
                if (tmp < ar[i])
                    tmp = ar[i];
            }
            return tmp;
        }
        public int MinInd()
        {
            if (start == end)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = start;
            for (int i = start+1; i < end; i++)
            {
                if (ar[tmp] > ar[i])
                    tmp = i;
            }
            return tmp - start;
        }
        public int MaxInd()
        {
            if (start == end)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = start;
            for (int i = start+1; i < end; i++)
            {
                if (ar[tmp] < ar[i])
                    tmp = i;
            }
            return tmp - start;
        }
        public void Set(int pos, int val)
        {
            if ((pos >= end - start) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            ar[pos+start] = val;
        }
        public int Get(int pos)
        {
            if ((pos >= end - start) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            return ar[pos + start];
        }
        public void Reverse()
        {
            for (int i = start; i < start + (end - start) / 2; i++)
            {
                int tmp = ar[i];
                ar[i] = ar[end - i + start - 1];
                ar[end - i + start - 1] = tmp;
            }
        }
        public void HalfReverse()
        {
            for (int i = start; i < start + (end - start) / 2; i++)
            {
                int tmp = ar[i];
                ar[i] = ar[end - (end - start) / 2 + i - start];
                ar[end - (end - start) / 2 + i - start] = tmp;
            }
        }
        public void Sort()
        {
            for (int i = start+1; i < end; i++)
            {
                int j;
                int temp = ar[i];
                for (j = i - 1; j >= start; j--)
                {
                    if (ar[j] < temp)
                        break;
                    ar[j + 1] = ar[j];
                }
                ar[j + 1] = temp;
            }
        }
        public void AddPos(int pos, int[] ini)
        {
            if ((pos > end - start) || (pos < 0))
            {
                throw new ArgumentOutOfRangeException();
            }
            end = end + ini.Length;
            for (int i = end - 1; i >= start + pos + ini.Length; i--)
            {
                ar[i] = ar[i - ini.Length];
            }
            for (int i = start + pos; i < start + pos + ini.Length; i++)
            {
                ar[i] = ini[i - start - pos];
            }
        }
    }
}