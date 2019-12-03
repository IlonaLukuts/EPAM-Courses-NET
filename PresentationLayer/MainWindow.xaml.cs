namespace PresentationLayer
{
    using System.IO;
    using System.Text;
    using System.Windows;

    using NLog;

    using PresentationLayer.Configuration;

    using ServiceLayer;
    using ServiceLayer.Impl;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private Section section;

        private ITextProcessingService textProcessingService;

        public MainWindow()
        {
            InitializeComponent();
            this.section = new Section();

            this.textProcessingService = new TextProcessingService();
        }

        private void ButtonSentenceOrder_OnClick(object sender, RoutedEventArgs e)
        {
            var sentences = this.textProcessingService.AllSentencesOrderedByWordsAmount();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var sentence in sentences)
            {
                stringBuilder.Append(sentence.ToString());
                stringBuilder.Append('\n');
            }
            this.TextBox.Text = stringBuilder.ToString();
        }

        private void ButtonInterrogativeSentences_OnClick(object sender, RoutedEventArgs e)
        {
            var sentences = this.textProcessingService.WordsInInterrogativeSentences(int.Parse(this.LengthInterrogativeTextBox.Text));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var sentence in sentences)
            {
                foreach (var wordItem in sentence)
                {
                    stringBuilder.Append(wordItem.ToString());
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append('\n');
            }
            this.TextBox.Text = stringBuilder.ToString();
        }

        private void ButtonReplaceWordsInSentence_OnClick(object sender, RoutedEventArgs e)
        {
            this.textProcessingService.ReplaceWordInSentence(
                this.textProcessingService.FindSentence(int.Parse(this.SentenceIdTextBox.Text)),
                int.Parse(this.LengthTextBox.Text),
                this.ReplaceStringTextBox.Text);
            this.UpdateText();
        }

        private void ButtonDeleteWordsOnLetter_OnClick(object sender, RoutedEventArgs e)
        {
            this.TextBox.Text = this.textProcessingService.TextWithoutWordsStartWithConsonantLetters().ToString();
        }

        private void ButtonLoadText_OnClick(object sender, RoutedEventArgs e)
        {
            var file = this.section.Configure().textFile;
            this.textProcessingService.ParseText(new FileStream(file, FileMode.Open));
            this.UpdateText();
        }

        private void UpdateText()
        {
            this.TextBox.Text = this.textProcessingService.GetText().ToString();
        }
    }
}
