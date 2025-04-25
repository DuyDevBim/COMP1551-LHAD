using System;
using System.Data;
using MySql.Data.MySqlClient;

// Abstract class
abstract class StringProcessorBase
{
    public abstract string Encode();
    public abstract string Print();
    public abstract int[] InputCode();
    public abstract int[] OutputCode();
    public abstract string Sort();
}

abstract class StringProcessing : StringProcessorBase
{
    protected string s;

    public string S
    {
        get { return s; }
        set
        {
            if (value.Length > 40 || !IsAllUpperCase(value))
                throw new ArgumentException("String must contain only uppercase letters and maximum 40 characters.");
            s = value;
        }
    }

    public StringProcessing(string input)
    {
        S = input;
    }

    public override string Print()
    {
        return Encode();
    }
    public override int[] InputCode()
    {
        int[] asciiCodes = new int[s.Length];
        for (int i = 0; i < s.Length; i++)
            asciiCodes[i] = (int)s[i];
        return asciiCodes;
    }

    public override int[] OutputCode()
    {
        string encoded = Encode();
        int[] asciiCodes = new int[encoded.Length];
        for (int i = 0; i < encoded.Length; i++)
            asciiCodes[i] = (int)encoded[i];
        return asciiCodes;
    }

    public override string Sort()
    {
        char[] sorted = s.ToCharArray();
        Array.Sort(sorted);
        return new string(sorted);
    }

    private bool IsAllUpperCase(string str)
    {
        foreach (char c in str)
            if (c < 'A' || c > 'Z') return false;
        return true;
    }
}
// Caesar
class CaesarProcessing : StringProcessing
{
    private int n;

    public int N
    {
        get { return n; }
        set
        {
            if (value < -25 || value > 25)
                throw new ArgumentException("N must be in the range [-25, 25].");
            n = value;
        }
    }

    public CaesarProcessing(string input, int shift) : base(input)
    {
        N = shift;
    }

    public override string Encode()
    {
        char[] encodedChars = new char[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            encodedChars[i] = ShiftCharacter(s[i], n);
        }
        return new string(encodedChars);
    }

    private char ShiftCharacter(char c, int shift)
    {
        int newChar = c + shift;
        if (newChar > 'Z') newChar -= 26;
        if (newChar < 'A') newChar += 26;
        return (char)newChar;
    }
}
// Atbash
class AtbashProcessing : StringProcessing
{
    public AtbashProcessing(string input) : base(input) { }

    public override string Encode()
    {
        char[] encodedChars = new char[s.Length];
        for (int i = 0; i < s.Length; i++)
            encodedChars[i] = (char)('Z' - (s[i] - 'A'));
        return new string(encodedChars);
    }
}
// Mirror
class MirrorProcessing : StringProcessing
{
    public MirrorProcessing(string input) : base(input) { }

    public override string Encode()
    {
        char[] mirrored = s.ToCharArray();
        Array.Reverse(mirrored);
        return new string(mirrored);
    }
}


//Database
class DatabaseManager
{
    private readonly string connectionString;

    public DatabaseManager(string server, string database, string username, string password)
    {
        connectionString = $"Server={server};Database={database};Uid={username};Pwd={password};";
    }

    public void SaveToDatabase(string original, int shift, string encoded)
    {
        using (var conn = new MySqlConnection(connectionString))
        {
            conn.Open();
            string query = "INSERT INTO encoded_strings (original_string, shift, encoded_string) VALUES (@original, @shift, @encoded)";
            using (var cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@original", original);
                cmd.Parameters.AddWithValue("@shift", shift);
                cmd.Parameters.AddWithValue("@encoded", encoded);
                cmd.ExecuteNonQuery();
            }
        }
    }
}


class Program
{
    static void Main()
    {
        string input;
        int shift = 0;

        DatabaseManager db = new DatabaseManager("localhost", "stringdb", "root", "");

        while (true)
        {
            try
            {
                Console.Write("Enter a string of uppercase letters: ");
                input = "HELLO";
                Console.WriteLine(input);

                Console.Write("Enter integer N for Caesar (-25 to 25): ");
                shift = 5;
                Console.WriteLine(shift);

                StringProcessorBase caesarProcessor = new CaesarProcessing(input, shift);
                StringProcessorBase atbashProcessor = new AtbashProcessing(input);
                StringProcessorBase mirrorProcessor = new MirrorProcessing(input);

                // Caesar
                Console.WriteLine("\n--- Caesar Encoding ---");
                string caesarEncoded = caesarProcessor.Print();
                Console.WriteLine("Encoded string: " + caesarEncoded);
                Console.WriteLine("ASCII code of original string: " + string.Join(", ", caesarProcessor.InputCode()));
                Console.WriteLine(
                    "ASCII code of the encoded string: " + string.Join(", ", caesarProcessor.OutputCode()));
                Console.WriteLine("Alphabetical order string: " + caesarProcessor.Sort());

                db.SaveToDatabase(input, shift, caesarEncoded);

                // Atbash
                Console.WriteLine("\n--- Atbash Encoding ---");
                string atbashEncoded = atbashProcessor.Print();
                Console.WriteLine("Encoded string: " + atbashEncoded);
                Console.WriteLine("ASCII code of original string: " + string.Join(", ", atbashProcessor.InputCode()));
                Console.WriteLine(
                    "ASCII code of the encoded string: " + string.Join(", ", atbashProcessor.OutputCode()));
                Console.WriteLine("Alphabetical order string: " + atbashProcessor.Sort());

                db.SaveToDatabase(input, 0, atbashEncoded);

                // Mirror
                Console.WriteLine("\n--- Mirror Encoding ---");
                string mirrorEncoded = mirrorProcessor.Print();
                Console.WriteLine("Encoded string: " + mirrorEncoded);
                Console.WriteLine("ASCII code of original string: " + string.Join(", ", mirrorProcessor.InputCode()));
                Console.WriteLine(
                    "ASCII code of the encoded string: " + string.Join(", ", mirrorProcessor.OutputCode()));
                Console.WriteLine("Alphabetical order string: " + mirrorProcessor.Sort());

                db.SaveToDatabase(input, 0, mirrorEncoded);

                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                break;
            }
        }
    }

}
