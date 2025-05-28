using NLog;

public interface IWordValidator
{
    bool IsValidWord(string word);
}


public class DictionaryWordValidator : IWordValidator
{
    private readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly HashSet<string> _validWords;

    public DictionaryWordValidator(string dictionaryFilePath)
    {
        _validWords = LoadWordsFromFile(dictionaryFilePath);
        
    }

    public bool IsValidWord(string word)
    {
        return _validWords.Contains(word.ToLower());
    }

    private HashSet<string> LoadWordsFromFile(string filePath)
    {
        HashSet<string> words = new HashSet<string>();
        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(line.Trim().ToLower());
                }
                Logger.Info($"Loaded {words.Count} words from {filePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading dictionary from {filePath}: {ex.Message}");
        }
        return words;
    }
}
