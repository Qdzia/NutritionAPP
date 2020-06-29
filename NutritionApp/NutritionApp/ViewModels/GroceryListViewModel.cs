using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Win32;
using NutritionApp.Base;
using NutritionApp.Data;
using NutritionApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NutritionApp.ViewModels
{
    class GroceryListViewModel : BaseVM
    {
        private Ingredient _selectedIngredient;
        private List<string> inList;
        private List<Ingredient> _groceryList;

        public Recepie[][] PlanForWeek;
        public RelayCommand DeleteIngredientCommand { get; set; }
        public RelayCommand PrintListToPDF { get; set; }

        public List<Ingredient> GroceryList
        {
            get { return _groceryList; }
            set { SetProperty(ref _groceryList, value); }
        }
        
        public Ingredient SelectedIngredient
        {
            get { return _selectedIngredient; }
            set { SetProperty(ref _selectedIngredient, value); }
        }
        
        public GroceryListViewModel()
        {
            _groceryList = new List<Ingredient>();
            inList = new List<string>();
            PlanForWeek = RecepieBase.Instance.PlanForWeek;
            SumItUp();
            DeleteIngredientCommand = new RelayCommand(DeleteIngredient);
            PrintListToPDF = new RelayCommand(PrintPDF, CanPrintPDF);
        }

        public void DeleteIngredient()
        {
            List<Ingredient> list = new List<Ingredient>();
            GroceryList.Remove(SelectedIngredient);
            foreach (var ing in GroceryList)
            {
                list.Add(ing);
            }
            GroceryList = list;
        }

        public void SumItUp()
        {
            GroceryList = new List<Ingredient>();
            inList = new List<string>();

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    AddRecepieToGroceryList(PlanForWeek[i][j]);
                }
            }
        }

        void AddRecepieToGroceryList(Recepie rec)
        {
            if (rec == null) return;
            
            foreach (Ingredient ing in rec.ingredients)
            {
                if (!inList.Contains(ing.name))
                {
                    inList.Add(ing.name);
                    GroceryList.Add(new Ingredient(ing.name, ing.count, ing.unit));
                }
                else
                {
                    for (int k = 0; k < GroceryList.Count; k++)
                    {
                        if (GroceryList[k].name == ing.name)
                        {
                            GroceryList[k].SumIngredient(ing);
                            k = GroceryList.Count;
                        }
                    }
                }
            }
        }
        
        public bool CanPrintPDF(object param)
        {
            if(GroceryList.Count == 0)
            {
                return false;
            }
            return true;
        }
        public void PrintPDF()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "pdf|*.pdf" };
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;

            iTextSharp.text.Document oDoc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(oDoc, new FileStream(fileName, FileMode.Create));
            oDoc.Open();
            foreach (var item in GroceryList)
            {
                oDoc.Add(new Paragraph(item.ToString()));
            }
            
            oDoc.Close();
        }
    }
}
