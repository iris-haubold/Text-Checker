using Caliburn.Micro;
using System;
using System.Linq;


namespace Text_Checker.ViewModels
{
    public class PalindromeViewModel : Screen
    {
        private string palindromes;

        public PalindromeViewModel(string textInput) 
        {
            palindromes = FindPalindromes(textInput, "");
            if (palindromes == "")
            {
                palindromes = "Keine Palindrome gefunden :/";
            }
        }
         
        public string Palindromes
        {
            get { return palindromes; }
            set { palindromes = value; }
        }

        // discovers all palindromes included in the text
        // only checks strings separated by spaces
        public string FindPalindromes(string text, string palindromes)
        {
            //separate text into words by looking for spaces
            //for each word: check if it is a palindrome
            //if it is a palindrome, add it to the palindromes string

            int firstSpace = text.IndexOf(' ');
           
            string nextWord = firstSpace == -1? text : text.Substring(0, firstSpace);
            palindromes += IsPalindrome(nextWord) ? nextWord + " " : "";

            return firstSpace == -1 ? palindromes : FindPalindromes(text.Substring(firstSpace + 1), palindromes);

        }

        // checks whether word is a palindrome in the sense that is the same forwards as backwards
        // does not check for palindromes like "Regal - Lager"
        // also does not check whether the word makes sense
        public bool IsPalindrome(string word)
        {
            // if word contains chars other than letters or is empty, it isn't a palindrome
            if (!word.All(Char.IsLetter) || word == "")
            {
                return false;
            }

            word = word.ToLower();
            string wordReversed = Reverse(word);
            
            return word.Equals(wordReversed);
        }

        // reverses a string so it's backwards
        public string Reverse(string word)
        {
            char[] tempArray = word.ToCharArray();
            Array.Reverse(tempArray);
            return new string(tempArray);
        }
    }  
}
