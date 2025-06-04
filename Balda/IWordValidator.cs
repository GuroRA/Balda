namespace Balda
{
    /// <summary>
    /// Проверяет, является ли данное слово допустимым.
    /// </summary>
    public interface IWordValidator
    {
        bool IsValidWord(string word);
    }
}
