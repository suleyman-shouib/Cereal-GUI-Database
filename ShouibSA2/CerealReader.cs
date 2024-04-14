using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data;

namespace ShouibSA2
{
    class CerealReader
    {
        List<Cereal> cerealList = new List<Cereal>();
        List<Cereal> filteredCerealList = new List<Cereal>();
        string fileName = "cereal.csv";

        /// <summary>
        /// Goes through cereal.csv and reads every line, saving one line into a string. 
        /// Then call CreateCereal to create Cereal objects based off of data from each line from the file and add to cerealList
        /// </summary>
        public void LoadCereal()
        {
            try
            {
                //Read cereal.csv with reader
                using (StreamReader reader = new StreamReader(fileName))
                {
                    reader.ReadLine();  //Burn through the first line which outlines the csv's structure

                    while (!reader.EndOfStream) //While cereal.csv has not reached the end,
                    {
                        string line = reader.ReadLine();
                        cerealList.Add(CreateCereal(line));
                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Creates a cereal object for each line in cereal.csv and returns it
        /// </summary>
        /// <returns>Newly created Cereal object</returns>
        private Cereal CreateCereal(string cerealLine)
        {
            var dataColumn = cerealLine.Split(',');

            String name = dataColumn[0];
            int calories = int.Parse(dataColumn[3]);
            int protein = int.Parse(dataColumn[4]);
            int fat = int.Parse(dataColumn[5]);
            int sodium = int.Parse(dataColumn[6]);
            double fiber = double.Parse(dataColumn[7]);
            double carbo = double.Parse(dataColumn[8]);
            int sugars = int.Parse(dataColumn[9]);
            int potass = int.Parse(dataColumn[10]);
            int vitamins = int.Parse(dataColumn[11]);

            return new Cereal(name, calories, protein, fat, sodium, fiber, carbo, sugars, potass, vitamins);
        }

        /// <summary>
        /// Gets the original cereal list
        /// </summary>
        /// <returns>Original list of type Cereal, cerealList</returns>
        public List<Cereal> GetCerealList()
        {
            return cerealList;
        }

        /// <summary>
        /// Gets the final cereal list to be displayed onto the Data Grid, filteredCerealList
        /// </summary>
        /// <returns>List of type Cereal used after a query, filteredCerealList</returns>
        public List<Cereal> GetFilteredCerealList()
        {
            return filteredCerealList;
        }

        /// <summary>
        /// Clears filteredCerealList that way another query can be performed while reusing this list
        /// </summary>
        public void ClearFilteredCerealList()
        {
            filteredCerealList.Clear();
        }

        /// <summary>
        /// Runs a query given all sorts of filters and will save it to a var cerealFilter. 
        /// Afterwards, it will save all the contents from cerealFilter into filteredCerealList.
        /// </summary>
        public void CerealQuery(bool sortByAtLeast, bool sortCerealName, string nameFilter, int caloriesFilter, int proteinFilter, int fatFilter, int sodiumFilter, double fiberFilter, double carboFilter, int sugarFilter, int potassFilter, int vitaminFilter)
        {
            //If the user wants to run a query using a name filter
            if (sortCerealName)
            {
                if (sortByAtLeast)  //If the user wants to sort by "at least x amount" then use >= 
                {
                    var cerealFilter = from Cereal cereal in cerealList
                                       where (cereal.GetName().Contains(nameFilter)) &&
                                              (cereal.GetCalories() >= caloriesFilter) &&
                                              (cereal.GetProtein() >= proteinFilter) &&
                                              (cereal.GetFat() >= fatFilter) &&
                                              (cereal.GetSodium() >= sodiumFilter) &&
                                              (cereal.GetFiber() >= fiberFilter) &&
                                              (cereal.GetCarbo() >= carboFilter) &&
                                              (cereal.GetSugars() >= sugarFilter) &&
                                              (cereal.GetPotassium() >= potassFilter) &&
                                              (cereal.GetVitamins() >= vitaminFilter)
                                       orderby cereal
                                       select cereal;

                    //Add everything in cerealFilter to filteredCerealList
                    foreach (Cereal i in cerealFilter)
                    {
                        filteredCerealList.Add(i);
                    }
                }
                else    //Else the user wants to sort by "At most x amount" then use <=
                {
                    var cerealFilter = from Cereal cereal in cerealList
                                       where (cereal.GetName().Contains(nameFilter)) &&
                                              (cereal.GetCalories() <= caloriesFilter) &&
                                              (cereal.GetProtein() <= proteinFilter) &&
                                              (cereal.GetFat() <= fatFilter) &&
                                              (cereal.GetSodium() <= sodiumFilter) &&
                                              (cereal.GetFiber() <= fiberFilter) &&
                                              (cereal.GetCarbo() <= carboFilter) &&
                                              (cereal.GetSugars() <= sugarFilter) &&
                                              (cereal.GetPotassium() <= potassFilter) &&
                                              (cereal.GetVitamins() <= vitaminFilter)
                                       orderby cereal
                                       select cereal;

                    //Add everything in cerealFilter to filteredCerealList
                    foreach (Cereal i in cerealFilter)
                    {
                        filteredCerealList.Add(i);
                    }
                }
            }

            //Else the user doesn't want to sort with a name filter
            else
            {
                if (sortByAtLeast)  //If the user wants to sort by "at least x amount" then use >= 
                {
                    var cerealFilter = from Cereal cereal in cerealList
                                       where (cereal.GetCalories() >= caloriesFilter) &&
                                              (cereal.GetProtein() >= proteinFilter) &&
                                              (cereal.GetFat() >= fatFilter) &&
                                              (cereal.GetSodium() >= sodiumFilter) &&
                                              (cereal.GetFiber() >= fiberFilter) &&
                                              (cereal.GetCarbo() >= carboFilter) &&
                                              (cereal.GetSugars() >= sugarFilter) &&
                                              (cereal.GetPotassium() >= potassFilter) &&
                                              (cereal.GetVitamins() >= vitaminFilter)
                                       orderby cereal
                                       select cereal;

                    //Add everything in cerealFilter to filteredCerealList
                    foreach (Cereal i in cerealFilter)
                    {
                        filteredCerealList.Add(i);
                    }
                }

                //Else the user wants to sort by "At most x amount" then use <=
                else
                {
                    var cerealFilter = from Cereal cereal in cerealList
                                       where (cereal.GetCalories() <= caloriesFilter) &&
                                              (cereal.GetProtein() <= proteinFilter) &&
                                              (cereal.GetFat() <= fatFilter) &&
                                              (cereal.GetSodium() <= sodiumFilter) &&
                                              (cereal.GetFiber() <= fiberFilter) &&
                                              (cereal.GetCarbo() <= carboFilter) &&
                                              (cereal.GetSugars() <= sugarFilter) &&
                                              (cereal.GetPotassium() <= potassFilter) &&
                                              (cereal.GetVitamins() <= vitaminFilter)
                                       orderby cereal
                                       select cereal;

                    //Add everything in cerealFilter to filteredCerealList
                    foreach (Cereal i in cerealFilter)
                    {
                        filteredCerealList.Add(i);
                    }
                }
            }
        }
    }
}