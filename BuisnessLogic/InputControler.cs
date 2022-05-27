using Contracts;
using System;
using System.Collections.Generic;

namespace BuisnessLogic
{
    public class InputControler : IInputControler //ne wordpickeris
    {

        public string InputVerifyer(string mainWordForAnagram)
        {
            if(mainWordForAnagram != null)
            {
                foreach (char letter in mainWordForAnagram)
                {
                    if (!Char.IsLetter(letter))
                    {
                        return "Every charracter supposed to be from a to z. You can't use any symbols or numbers.";
                    }
                }
            }
            return "valid";
        }

        public string NullVerifyer(string mainWordForAnagram)
        {
            if (String.IsNullOrWhiteSpace(mainWordForAnagram))
            {
                return "Please enter any word, because string can't be null or empty";
            }

            return InputVerifyer(mainWordForAnagram);
        }
    }
}