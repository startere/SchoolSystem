using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SchoolSystem.Contracts;
using SchoolSystem.Models;

namespace SchoolSystem.Core
{
    public class Validators
    {
        public static void NameValidator(string nameInput)
        {
            if (nameInput.Length < 2 || nameInput.Length > 31)
            {
                throw new FormatException("Names must have a length between 2 and 31 symbols long.");
            }

            if (!Regex.IsMatch(nameInput, @"^[a-zA-Z]+$"))
            {
                throw new FormatException("Names must consist only of characters of the latin alphabet.");
            }
        }

        public static void NumberOfMarksValidator(IList<IMark> marksInput)
        {
            if (marksInput.Count == 20)
            {
                throw new ArgumentException("Each student cannot have more than 20 marks.");
            }
        }

        public static void MarkValueValidator(float markValueInput)
        {
            if (markValueInput < 2f || markValueInput > 6f)
            {
                throw new ArgumentOutOfRangeException("Every grade should be between 2 and 6.");
            }
        }

        public static string StudentHasNoMarksValidator(IList<IMark> marksInput)
        {
            if (marksInput.Count == 0)
            {
                return "Student has no marks.";
            }

            return string.Empty;
        }
    }
}