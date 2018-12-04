using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public sealed class Problems
    {
        private static Problems _instance = null;
        private static readonly object _lock = new object();

        Problems() { }

        public static Problems Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new Problems();

                    return _instance;
                }
            }
        }

        public void CalculateHourGlassSum()
        {
            int[][] arr = new int[6][];
            for (int arr_i = 0; arr_i < 6; arr_i++)
            {
                string[] arr_temp = Console.ReadLine().Split(' ');
                arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            }

            Console.WriteLine(CalculateHourGlassSum(arr));
            Console.ReadKey();
        }

        private int CalculateHourGlassSum(int[][] arr)
        {
            if (arr == null || arr.Count().Equals(0))
                return 0;

            int sum = 0;
            int maxColumns = 0;
            int maxRow = arr.Length - 2;

            List<int> all = new List<int>();

            for (int i = 0; i < maxRow; i++)
            {
                maxColumns = arr[i].Length - 2;

                for (int j = 0; j < maxColumns; j++)
                {
                    sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] +
                                      arr[i + 1][j + 1] +
                          arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];

                    all.Add(sum);
                }
            }

            return all.Max();
        }

        public void RotateArrayLeft()
        {
            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);
            int d = Convert.ToInt32(nd[1]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp));
            int[] result = RotateArrayLeft(a, d);

            Console.WriteLine(string.Join(" ", result));
            Console.ReadKey();
        }

        private int[] RotateArrayLeft(int[] a, int d)
        {
            if (a == null || a.Count().Equals(0))
                return null;

            int c = a.Count();

            if (d < 1 || d > c)
                return null;

            var first = a.Take(d).ToList();
            var last = a.Skip(d).Take(c - d).ToList();

            last.AddRange(first);

            return last.ToArray();
        }

        public void MakeAnagram()
        {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            int res = MakeAnagram(a, b);

            Console.WriteLine(res);
            Console.ReadKey();
        }

        private int MakeAnagram(string a, string b)
        {
            if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b))
                return 0;

            if (a.Equals(b))
                return 0;

            a = a.ToLower();
            b = b.ToLower();

            int charToRemove = 0;
            List<char> checkedChars = new List<char>();

            foreach (char item in a)
            {
                if (checkedChars.Any(f => f.Equals(item)))
                    continue;

                if (b.Any(f => f.Equals(item)))
                {
                    int aCount = a.Count(f => f.Equals(item));
                    int bCount = b.Count(f => f.Equals(item));

                    charToRemove += Math.Abs(aCount - bCount);

                    checkedChars.Add(item);
                }

                else
                    charToRemove++;
            }

            foreach (char item in b)
            {
                if (!a.Any(f => f.Equals(item)))
                    charToRemove++;
            }

            return charToRemove;
        }

        public void AdjacentChars()
        {
            int q = Convert.ToInt32(Console.ReadLine());

            for (int qItr = 0; qItr < q; qItr++)
            {
                string s = Console.ReadLine();

                int result = AdjacentChars(s);

                Console.WriteLine(result);
            }
        }

        private int AdjacentChars(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            int deletions = 0;
            List<char> ss = s.AsEnumerable().ToList();

            for (int i = ss.Count - 1; i > 0; i--)
            {
                if (ss[i].Equals(ss[i - 1]))
                {
                    ss.RemoveAt(i);
                    deletions++;
                }
            }

            return deletions;
        }

        public void IsValid()
        {
            string s = Console.ReadLine();

            string result = IsValid(s);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private string IsValid(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return "";

            int count = 0;
            int occurrence = 0;
            bool deleted = false;
            List<char> checkedChars = new List<char>();

            foreach (char item in s)
            {
                if (checkedChars.Any(f => f.Equals(item)))
                    continue;

                checkedChars.Add(item);
                occurrence = s.Count(c => c.Equals(item));

                if (count.Equals(0))
                    count = occurrence;

                else
                {
                    if (occurrence.Equals(count))
                        continue;

                    if (deleted)
                        return "NO";

                    if (occurrence.Equals(1))
                    {
                        deleted = true;
                        continue;
                    }

                    if (Math.Abs(occurrence - count) > 1)
                        return "NO";



                    deleted = true;
                }


            }

            return "YES";
        }

        public void CommonChild()
        {
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            int result = CommonChild(s1, s2);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private int CommonChild(string s1, string s2)
        {
            if (string.IsNullOrWhiteSpace(s1) || string.IsNullOrWhiteSpace(s2))
                return 0;

            if (!s1.Length.Equals(s2.Length))
                return 0;

            s1 = s1.ToUpper();
            s2 = s2.ToUpper();

            if (s1.Equals(s2))
                return s1.Length;

            foreach (var item in s1)
            {
                int index = s2.IndexOf(item);
                if (index.Equals(-1))
                    continue;


            }

            return 0;
        }

        public void SockMerchent()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
            ;
            int result = SockMerchent(n, ar);

            Console.WriteLine(result);
            Console.ReadLine();
        }

        private int SockMerchent(int n, int[] ar)
        {
            int pairs = 0;
            int color = 0;
            int index = 0;

            List<int> matched = new List<int>();

            for (int i = 0; i < n; i++)
            {
                color = ar[i];
                index = matched.IndexOf(color);

                if (index > -1)
                {
                    matched.RemoveAt(index);
                    pairs++;
                }
                else
                {
                    matched.Add(color);
                }
            }

            return pairs;
        }

        public void Braces()
        {
            int valuesCount = Convert.ToInt32(Console.ReadLine());

            string[] values = new string[valuesCount];

            for (int i = 0; i < valuesCount; i++)
            {
                string valuesItem = Console.ReadLine();
                values[i] = valuesItem;
            }

            string res = Braces(values[0]);

            Console.WriteLine(string.Join("\n", res));
            Console.ReadLine();
        }

        private string Braces(string values)
        {
            //if (values == null || values.Count().Equals(0))
            //    return null;

            int braket = 0;
            int curlyBracket = 0;
            int squareBracket = 0;

            bool missingBracket = false;


            List<char> matched = new List<char>();

            foreach (var c in values)
            {
                if (c.Equals('('))
                    braket++;
                else if (c.Equals(')'))
                {
                    if (braket > 0)
                    {
                        braket--;
                    }
                    else
                    {
                        missingBracket = false;
                    }
                }

                if (c.Equals('{'))
                    curlyBracket++;
                else if (c.Equals('}'))
                {
                    if (curlyBracket > 0)
                    {
                        curlyBracket--;
                    }
                    else
                    {
                        missingBracket = false;
                    }
                }

                if (c.Equals('['))
                    squareBracket++;
                else if (c.Equals(']'))
                {
                    if (squareBracket > 0)
                    {
                        squareBracket--;
                    }
                    else
                    {
                        missingBracket = false;
                    }
                }
            }

            return missingBracket || braket > 0 || curlyBracket > 0 || squareBracket > 0 ? "NO" : "YES";
        }

        public void GetOneBits(int n)
        {
            BitArray b = new BitArray(new int[] { n });
            bool[] bits = new bool[b.Count];
            b.CopyTo(bits, 0);

            Array.Reverse(bits);

            byte[] bitValues = bits.Select(bit => (byte)(bit ? 1 : 0)).ToArray();

            string s = string.Join("", bitValues).TrimStart('0');

            List<int> values = new List<int>();

            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Equals('1'))
                {
                    count++;
                    values.Add(i + 1);
                }
            }

            values.Insert(0, count);

            Console.ReadLine();
        }
    }
}
