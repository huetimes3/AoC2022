public class day5
{   
    public static Stack<char>[] setup(string[] input, int w, int h) {
        string[] delimsC = {"[", "] "};
        Stack<char>[] crates = new Stack<char>[w];
        for (int j = 0; j < w; j++) {
            Stack<char> col = new Stack<char>();
            for (int i = h-1; i >= 0; i--) {
                char c = input[i][j*4+1];    // from the ith row, take the jth char
                if (c != ' ') col.Push(c);    // add c in that spot if it exists
            }
            crates[j] = col;
        }
        return crates;
    }

    
    public static void q1() 
    {
        var lines = File.ReadLines("./challenges/day5.txt");
        
        using (var lineEnum = lines.GetEnumerator())
        {
            var setupL = new List<string>();
            int w = 0;
            int h = 0;
            Stack<char>[] crates = {};
            while (lineEnum.MoveNext()) 
            {
                string currL = lineEnum.Current;
                if (currL[1] == '1') 
                {
                    w = currL.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                    crates = setup(setupL.ToArray(), w, h);
                    lineEnum.MoveNext();
                    break;
                } 
                else
                {
                    setupL.Add(currL);
                    h++;
                }
            }
            // by this point we've parsed the crates into an array of lists, now we want to move them around

            string[] delimsM = {"move ", " from ", " to "};
            while (lineEnum.MoveNext()) 
            {
                string[] list = lineEnum.Current.Split(delimsM, StringSplitOptions.RemoveEmptyEntries);
                int n = int.Parse(list[0]);
                int s = int.Parse(list[1]);
                int t = int.Parse(list[2]);
                for (int i = 0; i < n; i++)
                {
                    crates[t-1].Push(crates[s-1].Pop());
                }
            }
            lineEnum.Dispose();
            foreach (var col in crates)
            {
                Console.WriteLine(col.Peek());
            }
        }
    }
    public static void q2() 
    {
        var lines = File.ReadLines("./challenges/day5.txt");
        
        using (var lineEnum = lines.GetEnumerator())
        {
            var setupL = new List<string>();
            int w = 0;
            int h = 0;
            Stack<char>[] crates = {};
            while (lineEnum.MoveNext()) 
            {
                string currL = lineEnum.Current;
                if (currL[1] == '1') 
                {
                    w = currL.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
                    crates = setup(setupL.ToArray(), w, h);
                    lineEnum.MoveNext();
                    break;
                } 
                else
                {
                    setupL.Add(currL);
                    h++;
                }
            }
            // by this point we've parsed the crates into an array of lists, now we want to move them around

            string[] delimsM = {"move ", " from ", " to "};
            Stack<char> crane = new Stack<char>();
            while (lineEnum.MoveNext()) 
            {
                string[] list = lineEnum.Current.Split(delimsM, StringSplitOptions.RemoveEmptyEntries);
                int n = int.Parse(list[0]);
                int s = int.Parse(list[1]);
                int t = int.Parse(list[2]);
                for (int i = 0; i < n; i++)
                {
                    crane.Push(crates[s-1].Pop());
                }
                for (int i = 0; i < n; i++)
                {
                    crates[t-1].Push(crane.Pop());
                }
            }
            lineEnum.Dispose();
            foreach (var col in crates)
            {
                Console.WriteLine(col.Peek());
            }
        }
    }
}