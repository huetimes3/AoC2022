public class day1 
{
    public static void q1() 
    {
        var top1 = 0;
        var top2 = 0;
        var top3 = 0;
        var cal = 0;
        var lines = File.ReadLines("./challenges/day1.txt");
        foreach (var line in lines)
        {
            // we wanna do something when we just hit an empty line
            if (line.Length == 0)  
            {
                // check if the cal is bigger than max and reset variable
                if (cal > top1) 
                {
                    top3 = top2;
                    top2 = top1;
                    top1 = cal;
                }
                else if (cal > top2) 
                {
                    top3 = top2;
                    top2 = cal;
                }
                else if (cal > top3) 
                {
                    top3 = cal;
                }
                cal = 0;
            } 
            // otherwise
            else 
            {
                // typecast line to integer and add it to cal
                cal += int.Parse(line);
            }
        }
        Console.WriteLine(top1+top2+top3);
    }

}