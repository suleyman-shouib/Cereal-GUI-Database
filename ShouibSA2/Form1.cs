using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShouibSA2
{
    public partial class Form1 : Form
    {
        #region Creation of Tools for Form
        //Object to read a file, perform queries and other things
        CerealReader cerealReader = new CerealReader();

        //Data Grid (Used to display the list of cereals)
        DataGridView cerealGrid = new DataGridView();

        //Text Boxes (Used so the user can input information to filter their search)
        TextBox cerealNameTextBox = new TextBox();
        TextBox cerealCaloriesTextBox = new TextBox();
        TextBox cerealProteinTextBox = new TextBox();
        TextBox cerealFatTextBox = new TextBox();
        TextBox cerealSodiumTextBox = new TextBox();
        TextBox cerealFiberTextBox = new TextBox();
        TextBox cerealCarboTextBox = new TextBox();
        TextBox cerealSugarTextBox = new TextBox();
        TextBox cerealPotassTextBox = new TextBox();
        TextBox cerealVitaminTextBox = new TextBox();

        //Labels (Used to briefly explain what each text box filters)
        Label cerealNameLabel = new Label();
        Label cerealCaloriesLabel = new Label();
        Label cerealProteinLabel = new Label();
        Label cerealFatLabel = new Label();
        Label cerealSodiumLabel = new Label();
        Label cerealFiberLabel = new Label();
        Label cerealCarboLabel = new Label();
        Label cerealSugarLabel = new Label();
        Label cerealPotassLabel = new Label();
        Label cerealVitaminLabel = new Label();

        //Buttons (Used to either perform a query and update the data grid, or reset the data grid and show original list)
        Button updateButton = new Button();
        Button resetButton = new Button();

        //Radio Buttons (Used so the user can control their filter by having the filter be "at least x value" or "at most x value")
        RadioButton sortAtLeastToggle = new RadioButton();
        RadioButton sortAtMostToggle = new RadioButton();

        //CheckBoxes (Used so the user can toggle which categories they want to search by)
        CheckBox searchNameToggle = new CheckBox();
        CheckBox searchCaloriesToggle = new CheckBox();
        CheckBox searchProteinToggle = new CheckBox();
        CheckBox searchFatToggle = new CheckBox();
        CheckBox searchSodiumToggle = new CheckBox();
        CheckBox searchFiberToggle = new CheckBox();
        CheckBox searchCarboToggle = new CheckBox();
        CheckBox searchSugarToggle = new CheckBox();
        CheckBox searchPotassToggle = new CheckBox();
        CheckBox searchVitaminToggle = new CheckBox();
        #endregion

        /// <summary>
        /// Initialize the form, and call CreateListBox to fill in the form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            CreateCerealListForm();
        }

        /// <summary>
        /// Set the size and location for the cereal DataGridView and create all Columns
        /// </summary>
        public void LoadCerealDataGridView()
        {
            cerealGrid.Size = new System.Drawing.Size(1324, 960);
            cerealGrid.Location = new System.Drawing.Point(10, 10);

            cerealGrid.Columns.Add("name", "Name");
            cerealGrid.Columns.Add("calories", "Calories");
            cerealGrid.Columns.Add("protein", "Protein");
            cerealGrid.Columns.Add("fat", "Fat");
            cerealGrid.Columns.Add("sodium", "Sodium");
            cerealGrid.Columns.Add("fiber", "Fiber");
            cerealGrid.Columns.Add("carbo", "Carbohydrates");
            cerealGrid.Columns.Add("sugars", "Sugars");
            cerealGrid.Columns.Add("potass", "Potassium");
            cerealGrid.Columns.Add("vitamins", "Vitamins");
        }

        /// <summary>
        /// Set the location and fill in sample text inside every text box
        /// </summary>
        public void LoadSearchTextBoxes()
        {
            //Names
            cerealNameTextBox.Location = new System.Drawing.Point(1470, 90);
            cerealNameTextBox.Text = "Name";

            //Calories
            cerealCaloriesTextBox.Location = new System.Drawing.Point(1470, 140);
            cerealCaloriesTextBox.Text = "10";

            //Proteins
            cerealProteinTextBox.Location = new System.Drawing.Point(1470, 190);
            cerealProteinTextBox.Text = "10";

            //Fats
            cerealFatTextBox.Location = new System.Drawing.Point(1470, 240);
            cerealFatTextBox.Text = "10";

            //Sodium
            cerealSodiumTextBox.Location = new System.Drawing.Point(1470, 290);
            cerealSodiumTextBox.Text = "10";

            //Fiber
            cerealFiberTextBox.Location = new System.Drawing.Point(1470, 340);
            cerealFiberTextBox.Text = "10.5";

            //Carbo
            cerealCarboTextBox.Location = new System.Drawing.Point(1470, 390);
            cerealCarboTextBox.Text = "10.5";

            //Sugars
            cerealSugarTextBox.Location = new System.Drawing.Point(1470, 440);
            cerealSugarTextBox.Text = "10";

            //Potassiums
            cerealPotassTextBox.Location = new System.Drawing.Point(1470, 490);
            cerealPotassTextBox.Text = "10";

            //Vitamins
            cerealVitaminTextBox.Location = new System.Drawing.Point(1470, 540);
            cerealVitaminTextBox.Text = "10";

        }

        /// <summary>
        /// Loads the Labels for their corresponding text box
        /// </summary>
        public void LoadTextBoxLabels()
        {
            //Names
            cerealNameLabel.Text = "Filter Search by Name";
            cerealNameLabel.Size = new System.Drawing.Size(100, 45);
            cerealNameLabel.Location = new System.Drawing.Point(1350, 80);

            //Calories
            cerealCaloriesLabel.Text = "Filter Search by Calories";
            cerealCaloriesLabel.Size = new System.Drawing.Size(100, 45);
            cerealCaloriesLabel.Location = new System.Drawing.Point(1350, 130);
            //Proteins
            cerealProteinLabel.Text = "Filter Search by Proteins";
            cerealProteinLabel.Size = new System.Drawing.Size(100, 45);
            cerealProteinLabel.Location = new System.Drawing.Point(1350, 180);

            //Fats
            cerealFatLabel.Text = "Filter Search by Fat";
            cerealFatLabel.Size = new System.Drawing.Size(100, 45);
            cerealFatLabel.Location = new System.Drawing.Point(1350, 230);

            //Sodium
            cerealSodiumLabel.Text = "Filter Search by Sodium";
            cerealSodiumLabel.Size = new System.Drawing.Size(100, 45);
            cerealSodiumLabel.Location = new System.Drawing.Point(1350, 280);

            //Fiber
            cerealFiberLabel.Text = "Filter Search by Fiber";
            cerealFiberLabel.Size = new System.Drawing.Size(100, 45);
            cerealFiberLabel.Location = new System.Drawing.Point(1350, 330);

            //Carbo
            cerealCarboLabel.Text = "Filter Search by Carbs";
            cerealCarboLabel.Size = new System.Drawing.Size(100, 45);
            cerealCarboLabel.Location = new System.Drawing.Point(1350, 380);

            //Sugars
            cerealSugarLabel.Text = "Filter Search by Sugar";
            cerealSugarLabel.Size = new System.Drawing.Size(100, 45);
            cerealSugarLabel.Location = new System.Drawing.Point(1350, 430);

            //Potassiums
            cerealPotassLabel.Text = "Filter Search by Potassium";
            cerealPotassLabel.Size = new System.Drawing.Size(100, 45);
            cerealPotassLabel.Location = new System.Drawing.Point(1350, 480);

            //Vitamins
            cerealVitaminLabel.Text = "Filter Search by Vitamin";
            cerealVitaminLabel.Size = new System.Drawing.Size(100, 45);
            cerealVitaminLabel.Location = new System.Drawing.Point(1350, 530);

        }

        /// <summary>
        /// Set the text, size and location of the search and reset buttons
        /// </summary>
        public void LoadSearchResetButtons()
        {
            updateButton.Text = "Search";
            updateButton.Size = new System.Drawing.Size(100, 100);
            updateButton.Location = new System.Drawing.Point(1350, 600);

            resetButton.Text = "Reset";
            resetButton.Size = new System.Drawing.Size(100, 100);
            resetButton.Location = new System.Drawing.Point(1550, 600);
        }

        /// <summary>
        /// Autosize and set the text and locations of the sortAtLeast and sortAtMost radio buttons
        /// </summary>
        public void LoadLeastMostRadioButton()
        {
            sortAtLeastToggle.Text = "Contains At least";
            sortAtLeastToggle.AutoSize = true;
            sortAtLeastToggle.Location = new System.Drawing.Point(1350, 10);
            sortAtLeastToggle.Checked = true;   //Have sortAtLeast radio button be toggled true by default

            sortAtMostToggle.Text = "Contains At most";
            sortAtMostToggle.AutoSize = true;
            sortAtMostToggle.Location = new System.Drawing.Point(1350, 45);
        }

        /// <summary>
        /// Autosize and set the text and locations of all of the check boxes
        /// </summary>
        public void LoadCheckBox()
        {
            //Name
            searchNameToggle.Text = "Search Cereal Name";
            searchNameToggle.AutoSize = true;
            searchNameToggle.Location = new System.Drawing.Point(1600, 90);

            //Calories
            searchCaloriesToggle.Text = "Search Cereal Calories";
            searchCaloriesToggle.AutoSize = true;
            searchCaloriesToggle.Location = new System.Drawing.Point(1600, 140);

            //Proteins
            searchProteinToggle.Text = "Search Cereal Proteins";
            searchProteinToggle.AutoSize = true;
            searchProteinToggle.Location = new System.Drawing.Point(1600, 190);

            //Fat
            searchFatToggle.Text = "Search Cereal Fat";
            searchFatToggle.AutoSize = true;
            searchFatToggle.Location = new System.Drawing.Point(1600, 240);

            //Sodium
            searchSodiumToggle.Text = "Search Cereal Sodium";
            searchSodiumToggle.AutoSize = true;
            searchSodiumToggle.Location = new System.Drawing.Point(1600, 290);

            //Fiber
            searchFiberToggle.Text = "Search Cereal Fiber";
            searchFiberToggle.AutoSize = true;
            searchFiberToggle.Location = new System.Drawing.Point(1600, 340);

            //Carbs
            searchCarboToggle.Text = "Search Cereal Carbs";
            searchCarboToggle.AutoSize = true;
            searchCarboToggle.Location = new System.Drawing.Point(1600, 390);

            //Sugar
            searchSugarToggle.Text = "Search Cereal Sugar";
            searchSugarToggle.AutoSize = true;
            searchSugarToggle.Location = new System.Drawing.Point(1600, 440);

            //Potassium
            searchPotassToggle.Text = "Search Cereal Potassium";
            searchPotassToggle.AutoSize = true;
            searchPotassToggle.Location = new System.Drawing.Point(1600, 490);

            //Vitamin
            searchVitaminToggle.Text = "Search Cereal Vitamin";
            searchVitaminToggle.AutoSize = true;
            searchVitaminToggle.Location = new System.Drawing.Point(1600, 540);
        }

        /// <summary>
        /// Load all of the tools needed for the form
        /// Call function to read cereal.csv file and display the default list
        /// Add all of the tools needed for the form
        /// Have events for the Search and Reset Buttons
        /// </summary>
        public void CreateCerealListForm()
        {
            LoadCerealDataGridView();
            LoadSearchTextBoxes();
            LoadTextBoxLabels();
            LoadSearchResetButtons();
            LoadLeastMostRadioButton();
            LoadCheckBox();

            cerealReader.LoadCereal(); 
            DisplayListBox(cerealReader.GetCerealList()); 

            //DataGrid
            this.Controls.Add(cerealGrid);
            //TextBoxes
            this.Controls.Add(cerealNameTextBox);
            this.Controls.Add(cerealCaloriesTextBox);
            this.Controls.Add(cerealProteinTextBox);
            this.Controls.Add(cerealFatTextBox);
            this.Controls.Add(cerealSodiumTextBox);
            this.Controls.Add(cerealFiberTextBox);
            this.Controls.Add(cerealCarboTextBox);
            this.Controls.Add(cerealSugarTextBox);
            this.Controls.Add(cerealPotassTextBox);
            this.Controls.Add(cerealVitaminTextBox);
            //Labels
            this.Controls.Add(cerealNameLabel);
            this.Controls.Add(cerealCaloriesLabel);
            this.Controls.Add(cerealProteinLabel);
            this.Controls.Add(cerealFatLabel);
            this.Controls.Add(cerealSodiumLabel);
            this.Controls.Add(cerealFiberLabel);
            this.Controls.Add(cerealCarboLabel);
            this.Controls.Add(cerealSugarLabel);
            this.Controls.Add(cerealPotassLabel);
            this.Controls.Add(cerealVitaminLabel);
            //Buttons
            this.Controls.Add(resetButton);
            this.Controls.Add(updateButton);
            //Radio Buttons
            this.Controls.Add(sortAtLeastToggle);
            this.Controls.Add(sortAtMostToggle);
            //Check Boxes
            this.Controls.Add(searchNameToggle);
            this.Controls.Add(searchCaloriesToggle);
            this.Controls.Add(searchProteinToggle);
            this.Controls.Add(searchFatToggle);
            this.Controls.Add(searchSodiumToggle);
            this.Controls.Add(searchFiberToggle);
            this.Controls.Add(searchCarboToggle);
            this.Controls.Add(searchSugarToggle);
            this.Controls.Add(searchPotassToggle);
            this.Controls.Add(searchVitaminToggle);

            updateButton.Click += UpdateButton_Click;
            resetButton.Click += ResetButton_Click;
        }

        /// <summary>
        /// When the Reset Button is clicked, clear all the rows in the display.
        /// Then repopulate it with the cereals from the original cereal list.
        /// </summary>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            cerealGrid.Rows.Clear();
            DisplayListBox(cerealReader.GetCerealList());
        }

        /// <summary>
        /// When the Update Button is clicked, check the settings the user toggled for their search
        /// Given the user toggles, run a query with the filters from the user input in the text boxes 
        /// Clear all the rows in the datagrid, then repopulate it with the list produced from the query
        /// Update the cereal data grid then clear the filtered list so another query can be run
        /// </summary>
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            bool sortByAtLeast = true;
            bool nameFilter = true;
            int caloriesFilter = 0;
            int proteinFilter = 0;
            int fatFilter = 0;
            int sodiumFilter = 0;
            double fiberFilter = 0;
            double carboFilter = 0;
            int sugarFilter = 0;
            int potassFilter = 0;
            int vitaminFilter = 0;

            CheckToggles(ref sortByAtLeast, ref nameFilter, ref caloriesFilter, ref proteinFilter, ref fatFilter, 
                ref sodiumFilter, ref fiberFilter, ref carboFilter, ref sugarFilter, ref potassFilter, ref vitaminFilter);

            cerealReader.CerealQuery(sortByAtLeast, nameFilter, cerealNameTextBox.Text, caloriesFilter, proteinFilter, fatFilter,
                sodiumFilter, fiberFilter, carboFilter, sugarFilter, potassFilter, vitaminFilter);

            cerealGrid.Rows.Clear();
            DisplayListBox(cerealReader.GetFilteredCerealList());

            cerealGrid.Update();
            cerealGrid.Refresh();
           
            cerealReader.ClearFilteredCerealList();
        }

        public void CheckToggles(ref bool sortByAtLeast,ref bool nameFilter, ref int caloriesFilter, ref int proteinFilter, ref int fatFilter, ref int sodiumFilter, ref double fiberFilter, ref double carboFilter, ref int sugarFilter, ref int potassFilter, ref int vitaminFilter)
        {
            //If the toggle is true, the user wants to sort by the toggles name else, they want to do the opposite
            sortByAtLeast = sortAtLeastToggle.Checked ? true : false;
            nameFilter = searchNameToggle.Checked ? true : false;

            //Calories
            if (searchCaloriesToggle.Checked) //User wants to input a filter
            {
                caloriesFilter = int.Parse(cerealCaloriesTextBox.Text);
            }
            else //Else they don't want to input a filter so set the filter to hold a very high or low value that won't be surpassed
            {
               caloriesFilter = sortByAtLeast ? -999 : 999;
            }

            //Protein
            if (searchProteinToggle.Checked) 
            {
                proteinFilter = int.Parse(cerealProteinTextBox.Text);
            }
            else
            {
                proteinFilter = sortByAtLeast ? -999 : 999;
            }

            //Fat
            if (searchFatToggle.Checked) 
            {
                fatFilter = int.Parse(cerealFatTextBox.Text);
            }
            else
            {
                fatFilter = sortByAtLeast ? -999 : 999;
            }

            //Sodium
            if (searchSodiumToggle.Checked) 
            {
                sodiumFilter = int.Parse(cerealSodiumTextBox.Text);
            }
            else
            {
                sodiumFilter = sortByAtLeast ? -999 : 999;
            }

            //Fiber
            if (searchFiberToggle.Checked) 
            {
                fiberFilter = double.Parse(cerealFiberTextBox.Text);
            }
            else
            {
                fiberFilter = sortByAtLeast ? -999 : 999;
            }

            //Carbohydrates
            if (searchCarboToggle.Checked)
            {
                carboFilter = double.Parse(cerealCarboTextBox.Text);
            }
            else
            {
                carboFilter = sortByAtLeast ? -999 : 999;
            }

            //Sugar
            if (searchSugarToggle.Checked)
            {
                sugarFilter = int.Parse(cerealSugarTextBox.Text);
            }
            else
            {
                sugarFilter = sortByAtLeast ? -999 : 999;
            }

            //Potassium
            if (searchPotassToggle.Checked)
            {
                potassFilter = int.Parse(cerealPotassTextBox.Text);
            }
            else
            {
                potassFilter = sortByAtLeast ? -999 : 999;
            }

            //Vitamin
            if (searchVitaminToggle.Checked)
            {
                vitaminFilter = int.Parse(cerealVitaminTextBox.Text);
            }
            else
            {
                vitaminFilter = sortByAtLeast ? -999 : 999;
            }
        }

        /// <summary>
        /// Prints out all of the cereals in a list, onto the datagrid in the form
        /// </summary>
        public void DisplayListBox(List<Cereal> cerealList)
        {
            for(int i = 0; i < cerealList.Count; i++)
            {
                cerealGrid.Rows.Add(cerealList[i].GetName(), cerealList[i].GetCalories(), cerealList[i].GetProtein(), cerealList[i].GetFat(),
                    cerealList[i].GetSodium(), cerealList[i].GetFiber(), cerealList[i].GetCarbo(), cerealList[i].GetSugars(), 
                    cerealList[i].GetPotassium(), cerealList[i].GetVitamins());
            }
        }
    }
}