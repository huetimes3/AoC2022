public class day7
{
    public static void q1() {
        Stack<int> dir = new Stack<int>();
        int sum = 0;
        var lines = File.ReadLines("./challenges/day7.txt");
        foreach (var line in lines)
        {
            string[] l = line.Split(' ');
            if (l[0] == "$") 
            {
                if (l[1] == "cd")
                {
                    if (l[2] == "..")
                    {
                        int cur = dir.Pop();
                        if (cur < 100000) sum += cur;
                        dir.Push(dir.Pop() + cur);
                    }
                    else // new dir
                    {
                        dir.Push(0);
                    }
               }            
            }
            else if (l[0] != "dir") // it's a file with size
            {
                dir.Push(dir.Pop() + int.Parse(l[0]));
            }
        }
        
        Console.WriteLine(sum);
    }

    public static void q2() {
        Stack<int> dir = new Stack<int>();
        int space = 70000000;
        var lines = File.ReadLines("./challenges/day7.txt");
        int best_dir = 70000000;
        foreach (var line in lines)
        {
            string[] l = line.Split(' ');
            if (l[0] != "$" && l[0] != "dir") space -= int.Parse(l[0]);
        }
        // space is now how much space we actually have in the fily system, let's change it so that it's the amt we want to reach
        space = 30000000 - space;
        foreach (var line in lines)
        {
            string[] l = line.Split(' ');
            if (l[0] == "$") 
            {
                if (l[1] == "cd")
                {
                    if (l[2] == "..")
                    {
                        int cur = dir.Pop();
                        if (cur > space && cur < best_dir) best_dir = cur;
                        dir.Push(dir.Pop() + cur);
                    }
                    else // new dir
                    {
                        dir.Push(0);
                    }
                }
            }
            else if (l[0] != "dir") // it's a file with size
            {
                dir.Push(dir.Pop() + int.Parse(l[0]));
            }
        }
        
        Console.WriteLine(best_dir);
    }
}