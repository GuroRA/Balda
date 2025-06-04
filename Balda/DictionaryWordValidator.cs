using NLog;

/// <summary>
/// Реализует интерфейс используя словарь загруженный из файла.
/// </summary>
public class DictionaryWordValidator : Balda.IWordValidator
{
    private readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly HashSet<string> _validWords;

    /// <summary>
    /// Конструктор класса
    /// </summary>
    /// <param name="dictionaryFilePath"></param>
    public DictionaryWordValidator(string dictionaryFilePath)
    {
        _validWords = LoadWordsFromFile(dictionaryFilePath);
        
    }

    /// <summary>
    /// Проверка на валидность слова
    /// </summary>
    /// <param name="word"></param>
    /// <returns></returns>

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
