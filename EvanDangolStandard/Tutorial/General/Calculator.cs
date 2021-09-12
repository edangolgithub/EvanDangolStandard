﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvanDangolStandard.Tutorial.General
{
    public class Calculator
    {
        public int Add(int valueOne, int valueTwo)
        {
            return valueOne + valueTwo;
        }
        public bool IsOddNumber(int number)
        {
            return number % 2 != 0;
        }
    }
    public class AnimalRepository
    {
        private readonly List<string> _animals = new List<string>()
        {
            "TIGER",
            "LION",
            "DOG",
            "CAT",
            "COW",
            "PIG"
        };
        public string Find(SearchCriteria searchCriteria)
        {
            if (searchCriteria == null)
            {
                throw new ArgumentNullException(nameof(searchCriteria));
            }

            return _animals.FirstOrDefault(e => e.Contains(searchCriteria.SearchTerm.ToUpper()));
        }
    }

    public class SearchCriteria
    {
        public SearchCriteria(string searchTerm, bool ignoreCase = false)
        {
            SearchTerm = searchTerm ?? throw new ArgumentNullException(nameof(searchTerm));
            IgnoreCase = ignoreCase;
        }

        public string SearchTerm { get; }

        public bool IgnoreCase { get; }
    }
}
