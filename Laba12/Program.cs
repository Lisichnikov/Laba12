using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            string path = @"C:\Users\alexo\OneDrive\Рабочий стол\145.txt";
            StreamReader file = new(path);
            string buffer = file.ReadToEnd();
            Regex regexIp = new(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
            MatchCollection matches = regexIp.Matches(buffer);
            if (matches.Count > 0)
            {
                foreach (Match match in matches.Cast<Match>())
                    Console.WriteLine(match.Value);
            }
            else
            {
                Console.WriteLine("Совпадений не найдено");
            }
            file.Close();
        }
        catch(System.IO.FileNotFoundException)
        {
            Console.WriteLine("Возникло исключение, придурок");
        }
    }
}
