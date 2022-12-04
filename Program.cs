// See https://aka.ms/new-console-template for more information
public class allMethods 
{
    public static void day1() 
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

    public static void day2_1()
    {
        var score = 0;
        IDictionary<char, int> opp = new Dictionary<char, int>(){
            {'A',1}, {'B',2}, {'C',3}
        };
        IDictionary<char, int> us = new Dictionary<char, int>(){
            {'X',1}, {'Y',2}, {'Z',3}
        };

        var lines = File.ReadLines("./challenges/day2.txt");
        foreach (var line in lines)
        {
            score += us[line[2]];

            if (opp[line[0]] == us[line[2]]) {
                score += 3;
            }
            else if ((us[line[2]]-opp[line[0]]+3) % 3 == 1) {
                score += 6;
            }
            // if (line[2] == 'X') 
            // {
            //     score += 1;
            //     if (line[0] == 'A') 
            //     {
            //         score += 3;
            //     }
            //     else if (line[0] == 'C') 
            //     {
            //         score += 6;
            //     }
            // }
            // else if (line[2] == 'Y') 
            // {
            //     score += 2;
            //     if (line[0] == 'A') 
            //     {
            //         score += 6;
            //     }
            //     else if (line[0] == 'B') 
            //     {
            //         score += 3;
            //     }
            // }
            // else if (line[2] == 'Z') 
            // {
            //     score += 3;
            //     if (line[0] == 'B') 
            //     {
            //         score += 6;
            //     }
            //     else if (line[0] == 'C') 
            //     {
            //         score += 3;
            //     }
            // }
        }
        Console.WriteLine(score);
    }
    public static void day2_2()
    {
        var score = 0;
        IDictionary<char, int> opp = new Dictionary<char, int>(){
            {'A',1}, {'B',2}, {'C',3}
        };
        
        var lines = File.ReadLines("./challenges/day2.txt");
        foreach (var line in lines)
        {
            if (line[2] == 'X') 
            {
                // A - 1->3
                score += ((opp[line[0]] + 1) % 3) + 1;
                // if (line[0] == 'A') 
                // {
                //     score += 3;
                // }
                // else if (line[0] == 'B') 
                // {
                //     score += 1;
                // }
                // else if (line[0] == 'C') 
                // {
                //     score += 2;
                // }
            }
            else if (line[2] == 'Y') 
            {
                score += 3 + opp[line[0]];
                // if (line[0] == 'A') 
                // {
                //     score += 1;
                // }
                // else if (line[0] == 'B') 
                // {
                //     score += 2;
                // }
                // else if (line[0] == 'C') 
                // {
                //     score += 3;
                // }
            }
            else if (line[2] == 'Z') 
            {
                score += 6 + (opp[line[0]]%3+1);
                // if (line[0] == 'A') 
                // {
                //     score += 2;
                // }
                // else if (line[0] == 'B') 
                // {
                //     score += 3;
                // }
                // else if (line[0] == 'C') 
                // {
                //     score += 1;
                // }
            }
        }
        Console.WriteLine(score);
    }

    public static void day3_1() 
    {
        var p = 0;
        var lines = File.ReadLines("./challenges/day3.txt");
        foreach (var line in lines)
        {
            var s1 = line.Substring(0, line.Length/2);
            var s2 = line.Substring(line.Length/2);
            var intersect = s1.Intersect(s2);
            foreach (var k in intersect) {
                if (k < 91) {
                    p += k-38;
                }
                else p += k-96;
            }
        }
        Console.WriteLine(p);
    }
    public static void day3_2() 
    {
        var p = 0;
        var s1 = "";
        var s2 = "";
        var s3 = "";
        string[] lines = File.ReadAllLines("./challenges/day3.txt");
        for (int i = 0; i < lines.Length; i += 3)
        {
            s1 = lines[i];
            s2 = lines[i+1];
            s3 = lines[i+2];
            var inter = s1.Intersect(s2.Intersect(s3));
            foreach (var k in inter) {
                if (k < 91) p += k-38;
                else p += k-96;
            }
        }
        Console.WriteLine(p);
    }

    public static void day4_1() {
        var p = 0;
        var lines = File.ReadLines("./challenges/day4.txt");
        foreach (var line in lines)
        {
            char[] delims = {',', '-'};
            string[] list = line.Split(delims);
            int[] l = new int[4];
            for (int i = 0; i < 4; i++) {
                l[i]=int.Parse(list[i]);
            }
            if ((l[0]<=l[2] && l[1] >= l[3]) || (l[0]>=l[2] && l[1] <= l[3])) p++;
        }
        
        Console.WriteLine(p);
    }
    public static void day4_2() {
        var p = 0;
        var lines = File.ReadLines("./challenges/day4.txt");
        foreach (var line in lines)
        {
            char[] delims = {',', '-'};
            string[] list = line.Split(delims);
            int[] l = new int[4];
            for (int i = 0; i < 4; i++) {
                l[i]=int.Parse(list[i]);
            }
            if ((l[0]<=l[2] && l[1] >= l[2]) || (l[0]>=l[2] && l[0] <= l[3])) p++;
        }
        Console.WriteLine(p);
    }
}

class Caller
{
    public static void Main(string[] args)
    {
        //allmethods.day1();
        //allmethods.day2_1();
        //allmethods.day2_2();
        //allmethods.day3_1();
        //allmethods.day3_2();
        allMethods.day4_1();
        allMethods.day4_2();
    }
}