using System;

namespace RecipeMaker
{
    public class Recipe
    {   
        public int Id {get; set;} 
        public string Name { get; set; }

        public string Instructions { get; set; }

        public string Ingredients {get; set; }

        public int Calories {get; set;}

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Ingredients: {Ingredients}, Instructions: {Instructions}";
        }
    }
}