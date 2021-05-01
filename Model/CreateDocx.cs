using EasyDox;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TAP_DB.ViewModel;
using Application = Microsoft.Office.Interop.Word.Application;
using Document = Microsoft.Office.Interop.Word.Document;

namespace TAP_DB.Model
{
    public class CreateDocx
    {
        /// <summary>
        /// Переключений до ревиизии
        /// </summary>
        private string Number_select_to_revisions="";

        /// <summary>
        /// фазное напряжение ступени
        /// </summary>
        private string Ust_V="";

        /// <summary>
        /// Число ступеней
        /// </summary>
        private string StepNumber="";

        /// <summary>
        /// Включение РО
        /// </summary>
        private string ConnectionToTap="";

        /// <summary>
        /// Наименовние схемы для типа РПН
        /// </summary>
        private string shemaСoncretCH="";

        /// <summary>
        /// Наименовние найденного РПН
        /// </summary>
        private string tapCHname="";

        /// <summary>
        /// КПЧ межфазное
        /// </summary>
        private string aC_b2Selected="";

        /// <summary>
        /// Импульсное межфазное
        /// </summary>
        private string lI_b2Selected="";

        /// <summary>
        /// КПЧ ступени
        /// </summary>
        private string aC_a0Selected="";

        /// <summary>
        /// Импульсное ступени
        /// </summary>
        private string lI_a0Selected="";

        /// <summary>
        /// КПЧ на диапазон
        /// </summary>
        private string aC_b1Selected="";

        /// <summary>
        /// КПЧ на землю
        /// </summary>
        private string kV50Hz1minSelected="";

        /// <summary>
        /// Импульсное на землю
        /// </summary>
        private string lI_kVSelected="";

        /// <summary>
        /// Наибольший ударный ток
        /// </summary>
        private string idinamiclSelected="";

        /// <summary>
        /// Наибольшее рабочее напряжение, кВ
        /// </summary>
        private string urmsSelected="";

        /// <summary>
        /// Мощность ступени, кВА
        /// </summary>
        private string sstSelected="";

        /// <summary>
        /// Выбранный рабочий ток
        /// </summary>
        private string maxCurrentSelected="";

        /// <summary>
        /// Ток термической стойкости выбранный
        /// </summary>
        private string itermalSelected="";

        /// <summary>
        /// Импульсное на диапазон
        /// </summary>
        private string lI_b1Selected="";

        public CreateDocx(MainVM FindData)
        {
             
            this.tapCHname = FindData.TapCHname;
          
            this.aC_b2Selected = FindData.AC_b2Selected;
         
            this.lI_b2Selected = FindData.LI_b2Selected;
         
            this.aC_a0Selected = FindData.AC_a0Selected;
           
            this.lI_a0Selected = FindData.LI_a0Selected;
           
            this.aC_b1Selected = FindData.AC_b1Selected;

            this.kV50Hz1minSelected = FindData.KV50Hz1minSelected;
     
            this.lI_kVSelected = FindData.LI_kVSelected;
         
            this.idinamiclSelected = FindData.IdinamiclSelected;
        
            this.urmsSelected = FindData.Ust_V_Selected;
           
            this.sstSelected = FindData.SstSelected;
           
            this.maxCurrentSelected = FindData.MaxCurrentSelected;
       
            this.itermalSelected = FindData.ItermalSelected;
         
            this.lI_b1Selected = FindData.LI_b1Selected;
           
            this.Ust_V = FindData.Ust_V_Selected;
          
            this.ConnectionToTap = FindData.SelectedItem != null ? Convert.ToString(FindData.SelectedItem[5]):" ";
         
            this.StepNumber = FindData.SelectedItemShem != null ? Convert.ToString(FindData.SelectedItemShem[2]) : " ";

            this.shemaСoncretCH = FindData.ShemaСoncretCH != null ? FindData.ShemaСoncretCH : " ";

            this.Number_select_to_revisions = FindData.Number_select_to_revisionsSelected;
      
            StartCreateDocx();
        }

        public void StartCreateDocx()
        {
            var fieldValues = new Dictionary<string, string>
            {
                {"Наименовние найденного РПН", tapCHname+" "+shemaСoncretCH },
                {"КПЧ межфазное", aC_b2Selected },
                {"Импульсное межфазное", lI_b2Selected },
                {"КПЧ ступени", aC_a0Selected },
                {"Импульсное ступени", lI_a0Selected },
                {"КПЧ на диапазон", aC_b1Selected },
                {"КПЧ на землю", kV50Hz1minSelected },
                {"Наибольший ударный ток",idinamiclSelected },                
                {"Мощность ступени, кВА", sstSelected },
                {"Выбранный рабочий ток", maxCurrentSelected },
                {"Ток термической стойкости выбранный", itermalSelected },
                {"Импульсное на диапазон", lI_b1Selected },
                {"Включение РО", ConnectionToTap },
                {"Число ступеней", StepNumber },
                {"Схема переключения", shemaСoncretCH },
                {"Фазное напряжение ступени, В", Ust_V},
                {"Импульсное на землю", lI_kVSelected},
                {"Переключений до ревиизии РПН", Number_select_to_revisions }

            };
                     
            var engine = new Engine();
            string pathTemplate = Directory.GetCurrentDirectory();
            string userReport = GetDirectoryPath();
            if (userReport != "")
            {
                try
                {
                    engine.Merge($@"{pathTemplate}\template.docx", fieldValues, $@"{userReport}");
                    Openfile(userReport);
                    MessageBox.Show("Экспорт завершен!");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                
            }            
        }

        public string GetDirectoryPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter= "DocxFile(*.docx)|*.docx";
            saveFileDialog.ShowDialog();
            return saveFileDialog.FileName;
        }

        public void Openfile(string FileName)
        {
            Application app = new Application();
            Document doc = app.Documents.Open(FileName);
            try
            {
                app.Documents.Open(FileName);
            }
            catch (Exception ex)
            {
                doc.Close();
                app.Quit();
                MessageBox.Show(ex.Message);
            }
        }
    }

}
