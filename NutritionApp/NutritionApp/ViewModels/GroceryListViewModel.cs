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

        //Głównym zadaniem tej klasy jest sumowanie składników i wydrukowanie PDF
        //Sumujemu wszystkie składniki z PlanForWeek a następnie dodajemy te które sie powtażają każystajac z metody wbudowanej w Ingredient
        //Warto zwórcić uwage na metode print w której budujemy naszego PDF precyzując po kolei Meta data, czcionki wygląd tabeli i inne 

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
            
            foreach (Ingredient ing in rec.Ingredients)
            {
                if (!inList.Contains(ing.Name))
                {
                    inList.Add(ing.Name);
                    GroceryList.Add(new Ingredient(ing.Name, ing.Count, ing.Units));
                }
                else
                {
                    for (int k = 0; k < GroceryList.Count; k++)
                    {
                        if (GroceryList[k].Name == ing.Name)
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

            iTextSharp.text.Document oDoc = new iTextSharp.text.Document(PageSize.A4 ,25 , 25, 30 ,30);

            try {
                PdfWriter.GetInstance(oDoc, new FileStream(fileName, FileMode.Create));

                oDoc.Open();

                //Meta data
                oDoc.AddAuthor("Dariusz Momot & Łukasz Kudzia");
                oDoc.AddCreator("NutritionApp");
                oDoc.AddTitle("Grocery List");

                //Fonts
                Font titleFont = FontFactory.GetFont("Verdana", 8, Font.ITALIC);
                titleFont.Color = BaseColor.DARK_GRAY;

                Font cellFonnt = FontFactory.GetFont(FontFactory.COURIER, 12, BaseColor.DARK_GRAY);

                //Title
                Paragraph title = new Paragraph("Your grocery list from " + DateTime.Now, titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                oDoc.Add(title);
                oDoc.Add(new Paragraph("\n"));
                oDoc.Add(new Paragraph("\n"));

                //Table 
                PdfPTable table = new PdfPTable(3);
                foreach (var item in GroceryList)
                {
                    table.AddCell(item.Count.ToString());
                    table.AddCell(item.Units.ToString());
                    table.AddCell(item.Name);
                }
                table.HorizontalAlignment = Element.ALIGN_CENTER;
                table.PaddingTop = 20f;
                oDoc.Add(table);
                oDoc.Add(new Paragraph("\n"));
                oDoc.Add(new Paragraph("\n"));

                Paragraph foter = new Paragraph("Create by NutritionApp", titleFont);
                oDoc.Add(foter);
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Cannot save your list", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                oDoc.Close();
            }
        }
    }
}
