// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

namespace Program
{
    //Question 4 Resource
    public class FakeLinkedList
    {
        public string Value { get; set; }
        public FakeLinkedList Next { get; set; }

        public FakeLinkedList(string v)
        {
            Value = v;
            Next = null;
        }

        public FakeLinkedList(string v, FakeLinkedList n)
        {
            Value = v;
            Next = n;
        }
    }

    public class Midterm
    {
        //Question 1
        public static int FindMissingOfArr(int[] arr, int n)
        {
            int total = 0;
            for(int i = 1; i <= n; i++)
            {
                total += i;
            }
            
            return total - arr.Sum();
        }

        //Question 2
        public static int[] GetSumToTarget(int[] arr, int target)
        {           
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > target)
                {
                    continue;
                }
                for(int j = i +  1; j < arr.Length; j++)
                {
                    if(arr[j] + arr[i] == target)
                    {
                        return [i, j];
                    }
                }
            }

            //failed case
            return [-1, -1];
        }

        //Question 3
        public static string[] GenerateAllPermutationsOfString(string str)
        {
            List<string> outputList = new List<string>();
            Queue<char> insanity = new Queue<char>();
            foreach(char c in str) 
            {
                char[] secondLayerChars = str.Where(character => character != c).ToArray();
                foreach (char c2 in secondLayerChars)
                {
                    insanity.Enqueue(c);
                    insanity.Enqueue(c2);
                    foreach(char c3 in secondLayerChars.Where(character => character != c2).ToArray())
                    {
                        insanity.Enqueue(c3);
                    }                    
                    outputList.Add(String.Join("", insanity.ToArray()));
                    insanity.Clear();
                }
            }

            
            return outputList.ToArray();
        }

        //Question 4
        public static bool CheckLinkedListLoop(FakeLinkedList startNode)
        {
            if (startNode == null)
            {
                return false;
            }

            FakeLinkedList slowNode = startNode;
            FakeLinkedList fastNode = startNode;            

            while(fastNode.Next != null)
            {
                fastNode = fastNode.Next.Next;

                if (fastNode == null)
                    return false;

                if(slowNode == fastNode)
                {
                    return true;
                }

                slowNode = slowNode.Next;
            }

            return false;
        }

        //Question 5
        public static bool IsBracketStringValid(string str)
        {
            Dictionary<char, char> bracketDictionairy = new Dictionary<char, char>();
            bracketDictionairy.Add('{', '}');
            bracketDictionairy.Add('(', ')');
            bracketDictionairy.Add('[', ']');

            Stack<char> bracketStack = new Stack<char>();

            foreach(char c in str)
            {
                if(bracketDictionairy.ContainsKey(c))
                {
                    bracketStack.Push(c);
                }

                if(c == bracketDictionairy[bracketStack.First()])
                {
                    bracketStack.Pop(); 
                }
            }

            return bracketStack.Count == 0;
        }

        public static void Main(string[] args)
        {

            Console.WriteLine("----QUESTION 1----");
            int[] q1Arr_1 = { 5, 4, 1, 2 };
            int[] q1Arr_2 = { 9,5,3,2,6,1,7,8,10 };
            int[] q1Arr_3 = { 2,3,1,5 };
            int[] q1Arr_4 = { 1,2,3,4,5 };

            Console.WriteLine(FindMissingOfArr(q1Arr_1, 5));
            Console.WriteLine(FindMissingOfArr(q1Arr_2, 10));
            Console.WriteLine(FindMissingOfArr(q1Arr_3, 5));
            Console.WriteLine(FindMissingOfArr(q1Arr_4, 6));

            Console.WriteLine("----QUESTION 2----");

            int[] q2Arr_1 = { 1, 5, 2, 7 };
            int[] q2Arr_2 = { 20, 1, 5, 2, 11 };
            int[] q2Arr_3 = { 3, 2, 4 };

            Console.WriteLine(String.Join(" ", GetSumToTarget(q2Arr_1, 8)));
            Console.WriteLine(String.Join(" ", GetSumToTarget(q2Arr_2, 3)));
            Console.WriteLine(String.Join(" ", GetSumToTarget(q2Arr_3, 6)));


            Console.WriteLine("----QUESTION 3----");

            string q3Str_1 = "ABC";
            string q3Str_2 = "AB";


            string[] q3Test_1 = GenerateAllPermutationsOfString(q3Str_1);
            string[] q3Test_2 = GenerateAllPermutationsOfString(q3Str_2);

            foreach(string str in q3Test_1)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();


            foreach (string str in q3Test_2)
            {
                Console.Write(str + " ");
            }
            Console.WriteLine();


            Console.WriteLine("----QUESTION 4----");

            FakeLinkedList q4Node_1 = new FakeLinkedList("A");
            FakeLinkedList q4Node_2 = new FakeLinkedList("B");
            FakeLinkedList q4Node_3 = new FakeLinkedList("C");
            q4Node_1.Next = q4Node_2;
            q4Node_2.Next = q4Node_3;
            q4Node_3.Next = q4Node_1;

            Console.WriteLine(CheckLinkedListLoop(q4Node_1));

            FakeLinkedList q4Node_4 = new FakeLinkedList("1");
            FakeLinkedList q4Node_5 = new FakeLinkedList("2");
            FakeLinkedList q4Node_6 = new FakeLinkedList("3");
            q4Node_4.Next = q4Node_5;
            q4Node_5.Next = q4Node_6;            

            Console.WriteLine(CheckLinkedListLoop(q4Node_4));

            FakeLinkedList q4Node_7 = new FakeLinkedList("1");
            FakeLinkedList q4Node_8 = new FakeLinkedList("2");
            FakeLinkedList q4Node_9 = new FakeLinkedList("3");
            q4Node_7.Next = q4Node_8;
            q4Node_8.Next = q4Node_9;
            q4Node_9.Next = q4Node_7;

            Console.WriteLine(CheckLinkedListLoop(q4Node_7));


            Console.WriteLine("----QUESTION 5----");

            string q5String_1 = "()";
            string q5String_2 = "(){}[]";
            string q5String_3 = "([})";
            string q5String_4 = "[({})]";

            Console.WriteLine(IsBracketStringValid(q5String_1));
            Console.WriteLine(IsBracketStringValid(q5String_2));
            Console.WriteLine(IsBracketStringValid(q5String_3));
            Console.WriteLine(IsBracketStringValid(q5String_4));
        }
    }
}
