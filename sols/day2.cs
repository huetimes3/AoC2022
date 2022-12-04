public class day2 
{
    public static void q1()
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
            
        }
        Console.WriteLine(score);
    }
    public static void q2()
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
            }
            else if (line[2] == 'Y') 
            {
                score += 3 + opp[line[0]];
            }
            else if (line[2] == 'Z') 
            {
                score += 6 + (opp[line[0]]%3+1);
            }
        }
        Console.WriteLine(score);
    }

}