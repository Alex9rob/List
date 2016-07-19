using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORT_06
{
    public class AListR : IList
    {
        int[] ar = new int[30];
        int start = 0;
        int end = 0;

        public AListR()
        {

        }
        public void Init(int[] ini)
        {
            if (ini == null)
            {
                ini = new int[0];
            }
            for (int i = 0; i < ini.Length; i++)
            {
                ar[i] = ini[i];
            }
            end = ini.Length;
        }

        public void Clear()
        {
            start = 0;
            end = 0;
        }

        public override String ToString()
        {
            String str = "";
            if (start < end)
            {
                for (int i = start; i < end; i++)
                {
                    if (i != end - 1)
                        str += ar[i] + ", ";
                    else
                        str += ar[i];
                }
            }
            else if (start > end)
            {
                if (end ==0)
                {
                    for (int i = start; i < ar.Length; i++)
                    {
                        if (i != ar.Length - 1)
                            str += ar[i] + ", ";
                        else
                            str += ar[i];
                    }
                }
                else
                {
                    for (int i = start; i < ar.Length; i++)
                    {
                        str += ar[i] + ", ";
                    }
                    for (int i = 0; i < end; i++)
                    {
                        if (i != end - 1)
                            str += ar[i] + ", ";
                        else
                            str += ar[i];
                    }
                }
            }
            return str;
        }

        public int[] ToArray()
        {
            int[] ret = new int[Size()];
            int S = Size();
            if (start <= end)
            {
                for (int i = start; i < end; i++)
                {
                    ret[i-start] = ar[i];
                }
            }
            else
            {
                for (int i = start; i < ar.Length; i++)
                {
                    ret[i - start] = ar[i];
                }
                for(int i = 0; i< end; i++)
                {
                    ret[ar.Length - start + i] = ar[i];
                }
            }

            return ret;
        }
        public void AddStart(int val)
        {
            if(start == 0)
            {
                start = ar.Length - 1;
            }
            else
            {
                start--;
            }
            ar[start] = val;
        }
        public void AddEnd(int val)///
        {
            ar[end++] = val;
        }
        
        public void AddPos(int pos, int val)
        {
            if(start<= end )
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
            else
            {
                if ((pos > end + ar.Length - start) || (pos < 0))
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (pos >= ar.Length - start)
                {
                    for (int i = end; i > pos - ar.Length+start; i--)
                    {
                        ar[i] = ar[i - 1];
                    }
                    end++;
                    ar[pos - ar.Length + start] = val;
                }
                else
                {
                    for (int i = start - 1; i < start + pos; i++)
                    {
                        ar[i] = ar[i + 1];
                    }
                    start--;
                    ar[start + pos] = val;
                }
            }
        }

        public int DelStart()
        {
            if (start == end)
            {
                throw new IndexOutOfRangeException();
            }
            if (start == ar.Length - 1)
            {
                start = 0;
                return ar[ar.Length - 1];
            }
            else
            {
                start++;
                return ar[start - 1];
            }
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
            if (start <= end)
                return end - start;
            else
                return ar.Length - start + end;
        }
        
        public int DelPos(int pos)
        {
            if (start == end)
            {
                throw new IndexOutOfRangeException();
            }
            if (start < end)
            {
                if (pos < 0||pos > end - start)
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
            else
            {
                if (pos < 0 || pos > end + ar.Length - start)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if(pos>=ar.Length - start)
                {
                    int tmp = ar[pos + start];
                    end--;
                    for (int i = pos + start; i < end; i++)
                    {
                        ar[i] = ar[i + 1];
                    }
                    return tmp;
                }
                else
                {
                    int tmp = ar[pos + start];
                    
                    for (int i = pos + start; i > start; i--)
                    {
                        ar[i] = ar[i - 1];
                    }
                    start++;
                    return tmp;
                }
            }
        }
        public int Min()
        {
            if (start == end)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = ar[start];
            if (start < end)
            {
                for (int i = start + 1; i < end; i++)
                {
                    if (tmp > ar[i])
                        tmp = ar[i];
                }
            }
            else
            {
                for (int i = start + 1; i < ar.Length; i++)
                {
                    if (tmp > ar[i])
                        tmp = ar[i];
                }
                for (int i = 0; i < end; i++)
                {
                    if (tmp > ar[i])
                        tmp = ar[i];
                }
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
            if (start < end)
            {
                for (int i = start + 1; i < end; i++)
                {
                    if (tmp < ar[i])
                        tmp = ar[i];
                }
            }
            else
            {
                for (int i = start + 1; i < ar.Length; i++)
                {
                    if (tmp < ar[i])
                        tmp = ar[i];
                }
                for (int i = 0; i < end; i++)
                {
                    if (tmp < ar[i])
                        tmp = ar[i];
                }
            }
            return tmp;
        }
        public int MinInd()
        {
            if (start == end)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = 0;
            if (start < end)
            {
                for (int i = start + 1; i < end; i++)
                {
                    if (ar[tmp] > ar[i])
                        tmp = i;
                }
                return tmp - start;
            }
            else
            {
                for (int i = start + 1; i < ar.Length; i++)
                {
                    if (ar[tmp] > ar[i])
                        tmp = i;
                }
                int tmp2 = 0;
                for (int i = 0; i < end; i++)
                {
                    if (ar[tmp2] > ar[i])
                        tmp2 = i;
                }
                if (ar[tmp] < ar[tmp2])
                    tmp = tmp - start;
                else
                    tmp = tmp2 - start + ar.Length;
                return tmp;
            }
            
        }
        public int MaxInd()
        {
            if (start == end)
            {
                throw new IndexOutOfRangeException();
            }
            int tmp = 0;
            if (start < end)
            {
                for (int i = start + 1; i < end; i++)
                {
                    if (ar[tmp] < ar[i])
                        tmp = i;
                }
                return tmp - start;
            }
            else
            {
                for (int i = start + 1; i < ar.Length; i++)
                {
                    if (ar[tmp] < ar[i])
                        tmp = i;
                }
                int tmp2 = 0;
                for (int i = 0; i < end; i++)
                {
                    if (ar[tmp2] < ar[i])
                        tmp2 = i;
                }
                if (ar[tmp] > ar[tmp2])
                    tmp = tmp - start;
                else
                    tmp = tmp2 - start + ar.Length;
                return tmp;
            }
        }
        public void Set(int pos, int val)
        {
            if (start <= end)
            {
                if (pos < 0 || pos >= end - start)
                {
                    throw new ArgumentOutOfRangeException();
                }
                ar[pos + start] = val;
            }
            else
            {
                if (pos>=ar.Length - start)
                {
                    if(pos>end+ar.Length - start)
                        throw new ArgumentOutOfRangeException();
                    ar[pos - ar.Length + start] = val;
                }
                else
                {
                    if (pos < 0)
                        throw new ArgumentOutOfRangeException();
                    ar[pos + start] = val;
                }
            }
        }
        public int Get(int pos)
        {
            if (start <= end)
            {
                if (pos < 0 || pos >= end - start)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return ar[pos + start];
            }
            else
            {
                if (pos >= ar.Length - start)
                {
                    if (pos > end + ar.Length - start)
                        throw new ArgumentOutOfRangeException();
                    return ar[pos - ar.Length + start];
                }
                else
                {
                    if (pos < 0)
                        throw new ArgumentOutOfRangeException();
                    return  ar[pos + start];
                }
            }
        }
        /// <summary>
        /// остановился здесь.
        /// </summary>
        public void Reverse()
        {
            if (start <= end)
            {
                for (int i = start; i < start + (end - start) / 2; i++)
                {
                    int tmp = ar[i];
                    ar[i] = ar[end - i + start - 1];
                    ar[end - i + start - 1] = tmp;
                }
            }
            else
            {
                if(ar.Length - start <= end)
                {
                    for(int i = 0; i< ar.Length - start; i++)
                    {
                        int tmp = ar[start + i];
                        ar[start + i] = ar[end - i - 1];
                        ar[end - i - 1] = tmp;
                    }
                    for (int i = 0; i < (end - (ar.Length - start))/2; i++)
                    {
                        int tmp = ar[i];
                        ar[i] = ar[end - (ar.Length - start) - i - 1];
                        ar[end - (ar.Length - start) - i - 1] = tmp;
                    }
                }
                else if(ar.Length - start > end)
                {
                    for (int i = 0; i < end; i++)
                    {
                        int tmp = ar[start + i];
                        ar[start + i] = ar[end - i - 1];
                        ar[end - i - 1] = tmp;
                    }
                    for (int i = 0; i < (ar.Length - start - end)/2; i++)
                    {
                        int tmp = ar[start + end + i];
                        ar[start + end + i] = ar[ar.Length - i - 1];
                        ar[ar.Length - i - 1] = tmp;
                    }
                }
            }
        }
        public void HalfReverse()
        {
            if (start <= end)
            {
                for (int i = start; i < start + (end - start) / 2; i++)
                {
                    int tmp = ar[i];
                    ar[i] = ar[end - (end - start) / 2 + i - start];
                    ar[end - (end - start) / 2 + i - start] = tmp;
                }
            }
            else
            {
                if (ar.Length - start <= end)
                {
                    for (int i = 0; i < ar.Length - start; i++)
                    {
                        int tmp = ar[start + i];
                        ar[start + i] = ar[end - (end + (ar.Length - start)) / 2 + i];
                        ar[end - (end + (ar.Length - start)) / 2 + i] = tmp;
                    }
                    for (int i = 0; i < (end - (ar.Length - start)) / 2; i++)
                    {
                        int tmp = ar[i];
                        ar[i] = ar[end - (end - (ar.Length - start)) / 2 + i];
                        ar[end - (end - (ar.Length - start)) / 2 + i] = tmp;
                    }
                }
                else if (ar.Length - start > end)
                {
                    for (int i = 0; i < end; i++)
                    {
                        int tmp = ar[start + i];
                        ar[start + i] = ar[ar.Length - (ar.Length - start - end) / 2 + i];
                        ar[ar.Length - (ar.Length - start - end) / 2 + i] = tmp;
                    }
                    for (int i = 0; i < (ar.Length - start - end) / 2; i++)
                    {
                        int tmp = ar[start + end + i];
                        ar[start + end + i] = ar[i];
                        ar[i] = tmp;
                    }
                }
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