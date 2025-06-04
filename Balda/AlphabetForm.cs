namespace Balda
{
    /// <summary>
    /// Форма с алфавитом
    /// </summary>
    public partial class AlphabetForm : Form
    {
        /// <summary>
        /// Выбранная буква из алфавита
        /// </summary>
        public char SelectedLetter { get; private set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public AlphabetForm()
        {
            InitializeComponent();
            InitializeAlphabetButtons();
        }

        private void InitializeAlphabetButtons()
        {

            string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            int buttonSize = 30;
            int padding = 5;
            int x = 10;
            int y = 10;
            int buttonsPerRow = 10;

            for (int i = 0; i < alphabet.Length; i++)
            {
                char letter = alphabet[i];
                Button button = new Button();
                button.Text = letter.ToString();
                button.Size = new Size(buttonSize, buttonSize);
                button.Location = new Point(x, y);
                button.Font = new Font("Arial", 12);
                button.Click += LetterButton_Click;
                button.Tag = letter;
                this.Controls.Add(button);

                x += buttonSize + padding;
                if ((i + 1) % buttonsPerRow == 0)
                {
                    x = 10;
                    y += buttonSize + padding;
                }
            }
        }

        private void LetterButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            SelectedLetter = (char)button.Tag;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
