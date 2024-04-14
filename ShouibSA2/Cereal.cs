using System;

namespace ShouibSA2
{
    public class Cereal : IComparable
    {
        String name;
        int calories;
        int protein;
        int fat;
        int sodium;
        double fiber;
        double carbo;
        int sugars;
        int potass;
        int vitamins;


        /// <summary>
        /// Constructor for Cereal Object
        /// </summary>
        public Cereal(string name, int calories, int protein, int fat, int sodium, double fiber, double carbo, int sugars, int potass, int vitamins)
        {
            this.name = name;
            this.calories = calories;
            this.protein = protein;
            this.fat = fat;
            this.sodium = sodium;
            this.fiber = fiber;
            this.carbo = carbo;
            this.sugars = sugars;
            this.potass = potass;
            this.vitamins = vitamins;
        }

        /// <summary>
        /// Returns the cereals Name
        /// </summary>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Returns the cereals Calories value
        /// </summary>
        public int GetCalories()
        {
            return calories;
        }

        /// <summary>
        /// Returns the cereals Protein value
        /// </summary>
        public int GetProtein()
        {
            return protein;
        }

        /// <summary>
        /// Returns the cereals Fat value
        /// </summary>
        public int GetFat()
        {
            return fat;
        }
        
        /// <summary>
        /// Returns the cereals Sodium value
        /// </summary>
        public int GetSodium()
        {
            return sodium;
        }

        /// <summary>
        /// Returns the cereals Fiber value
        /// </summary>
        public double GetFiber()
        {
            return fiber;
        }

        /// <summary>
        /// Returns the cereals Carbohydrates value
        /// </summary>
        public double GetCarbo()
        {
            return carbo;
        }

        /// <summary>
        /// Returns the cereals Sugar value
        /// </summary>
        public int GetSugars()
        {
            return sugars;
        }

        /// <summary>
        /// Returns the cereals Potassium value
        /// </summary>
        public int GetPotassium()
        {
            return potass;
        }

        /// <summary>
        /// Returns the cereals Vitamin value
        /// </summary>
        public int GetVitamins()
        {
            return vitamins;
        }

        /// <summary>
        /// CompareTo method required for CerealQuery in CerealReader
        /// </summary>
        /// <returns>1 (true)</returns>
        public int CompareTo(object obj)
        {
            return 1;
        }
    }
}
