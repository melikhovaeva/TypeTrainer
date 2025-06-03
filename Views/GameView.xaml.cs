using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using TypeMaster.ViewModels;

namespace TypeMaster.Views
{
    public partial class GameView : UserControl
    {
        private GameViewModel? _vm;

        public GameView()
        {
            InitializeComponent();
            DataContextChanged += OnContextChanged;
        }

        private void OnContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is GameViewModel vm)
            {
                _vm = vm;
                InputBox.Document = vm.EditableDocument;
            }
        }

        private void InputBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_vm == null) return;

            var range = new TextRange(
                InputBox.Document.ContentStart,
                InputBox.Document.ContentEnd);
            var input = range.Text.TrimEnd('\r', '\n');

            if (input.Length == 1)
                _vm.StartTimerIfNeeded();

            _vm.ProcessInput(input);
            HighlightErrors(input);
        }

        private void HighlightErrors(string input)
        {
            if (_vm == null) return;

            var words = input.Split(new[] { ' ' }, StringSplitOptions.None);
            var paragraph = new Paragraph();

            for (int i = 0; i < words.Length; i++)
            {
                var run = new Run(words[i]);
                if (i >= _vm.Words.Length || words[i] != _vm.Words[i])
                    run.Foreground = Brushes.Red;
                paragraph.Inlines.Add(run);

                if (i < words.Length - 1)
                    paragraph.Inlines.Add(new Run(" "));
            }

            InputBox.TextChanged -= InputBox_TextChanged;

            InputBox.Document.Blocks.Clear();
            InputBox.Document.Blocks.Add(paragraph);

            var end = InputBox.Document.ContentEnd;
            InputBox.CaretPosition = end;
            InputBox.ScrollToEnd();

            InputBox.TextChanged += InputBox_TextChanged;
        }
    }
}
