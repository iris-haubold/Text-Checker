using Caliburn.Micro;

namespace Text_Checker.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
		private string _textInput;

		public string TextInput
		{
			get { return _textInput; }
			set 
			{ 
				_textInput = value;
				NotifyOfPropertyChange(() => TextInput);
			}
		}

		// true if text input is not empty
		public bool CanClearText(string textInput)
		{
			return !string.IsNullOrWhiteSpace(textInput);
		}

		// clears the input text
		public void ClearText(string textInput)
		{
			TextInput = string.Empty;
		}

		public void LoadPalindromePage()
		{
			ActivateItemAsync(new PalindromeViewModel(TextInput));
		}

	}
}
