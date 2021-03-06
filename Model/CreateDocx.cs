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
        /// Механический ресурс
        /// </summary>
        private string Number_select_mechanicalSelected;

        /// <summary>
        /// Механический ресурс требуемый
        /// </summary>
        private string Number_select_mechanical;


        /// <summary>
        /// Переключений до замены контактов
        /// </summary>
        private string Number_select_to_change_contactSelected;

        /// <summary>
        /// Переключений до замены контактов труется
        /// </summary>
        private string Number_select_to_change_contact;


        /// <summary>
        /// Переключений до ревиизии
        /// </summary>
        private string Number_select_to_revisions;

        /// <summary>
        /// Переключений до ревиизии требуется
        /// </summary>
        private string Number_to_revisions;


        /// <summary>
        /// фазное напряжение ступени
        /// </summary>
        private string Ust_V_Selected;

        /// <summary>
        /// фазное напряжение ступени требуется
        /// </summary>
        private string Ust_V;


        /// <summary>
        /// Число ступеней
        /// </summary>
        private string StepNumberSelected;

        /// <summary>
        /// Число ступеней требуется
        /// </summary> 
        private string StepNumber;


        /// <summary>
        /// Включение РО
        /// </summary>
        private string ConnectionToTapSelected;

        /// <summary>
        /// Включение РО требуется
        /// </summary>
        private string ConnectionToTap;


        /// <summary>
        /// Наименовние схемы для типа РПН
        /// </summary>
        private string shemaСoncretCHSelected;

        /// <summary>
        /// Наименовние схемы для типа РПН требуется
        /// </summary>
        private string shemaСoncretCH;


        /// <summary>
        /// Наименовние найденного РПН
        /// </summary>
        private string tapCHnameSelected;


        /// <summary>
        /// КПЧ межфазное
        /// </summary>
        private string aC_b2Selected;

        /// <summary>
        /// КПЧ межфазное требуется
        /// </summary>
        private string aC_b2;


        /// <summary>
        /// Импульсное межфазное
        /// </summary>
        private string lI_b2Selected;

        /// <summary>
        /// Импульсное межфазное требуется
        /// </summary>
        private string lI_b2;


        /// <summary>
        /// КПЧ ступени
        /// </summary>
        private string aC_a0Selected;

        /// <summary>
        /// КПЧ ступени требуется
        /// </summary>
        private string aC_a0;



        /// <summary>
        /// Импульсное ступени
        /// </summary>
        private string lI_a0Selected;

        /// <summary>
        /// Импульсное ступени требуется
        /// </summary>
        private string lI_a0;


        /// <summary>
        /// КПЧ на диапазон
        /// </summary>
        private string aC_b1Selected;

        /// <summary>
        /// КПЧ на диапазон требуется
        /// </summary>
        private string aC_b1;


        /// <summary>
        /// КПЧ на землю
        /// </summary>
        private string kV50Hz1minSelected;

        /// <summary>
        /// КПЧ на землю требуется
        /// </summary>
        private string kV50Hz1min;


        /// <summary>
        /// Импульсное на землю
        /// </summary>
        private string lI_kVSelected;


        /// <summary>
        /// Импульсное на землю требуется
        /// </summary>
        private string lI_kV;


        /// <summary>
        /// Наибольший ударный ток
        /// </summary>
        private string idinamiclSelected;

         /// <summary>
        /// Наибольший ударный ток требуется
        /// </summary>
        private string idinamic;


        /// <summary>
        /// Мощность ступени, кВА
        /// </summary>
        private string sstSelected;

        /// <summary>
        /// Мощность ступени, кВА требуется
        /// </summary>
        private string sst;


        /// <summary>
        /// Выбранный рабочий ток
        /// </summary>
        private string maxCurrentSelected;

        /// <summary>
        /// Выбранный рабочий ток требуется
        /// </summary>
        private string maxCurrent;


        /// <summary>
        /// Ток термической стойкости выбранный
        /// </summary>
        private string itermalSelected;

        /// <summary>
        /// Ток термической стойкости выбранный требуется
        /// </summary>
        private string itermal;

        /// <summary>
        /// Импульсное на диапазон
        /// </summary>
        private string lI_b1Selected;

        /// <summary>
        /// Импульсное на диапазон требуется
        /// </summary>
        private string lI_b1;

        public CreateDocx(MainVM FindData)
        {

            //выбранные параметры  
            this.tapCHnameSelected = FindData.TapCHname != null ? FindData.TapCHname : " ";
            this.aC_b2Selected = FindData.AC_b2Selected != null ? FindData.AC_b2Selected : " ";
            this.lI_b2Selected = FindData.LI_b2Selected != null ? FindData.LI_b2Selected : " ";
            this.aC_a0Selected = FindData.AC_a0Selected != null ? FindData.AC_a0Selected : " ";
            this.lI_a0Selected = FindData.LI_a0Selected != null ? FindData.LI_a0Selected : " ";
            this.aC_b1Selected = FindData.AC_b1Selected != null ? FindData.AC_b1Selected : " ";
            this.kV50Hz1minSelected = FindData.KV50Hz1minSelected != null ? FindData.KV50Hz1minSelected : " ";
            this.lI_kVSelected = FindData.LI_kVSelected != null ? FindData.LI_kVSelected : " ";
            this.idinamiclSelected = FindData.IdinamiclSelected != null ? FindData.IdinamiclSelected : " ";
            this.sstSelected = FindData.SstSelected != null ? FindData.SstSelected : " ";
            this.maxCurrentSelected = FindData.MaxCurrentSelected != null ? FindData.MaxCurrentSelected : " ";
            this.itermalSelected = FindData.ItermalSelected != null ? FindData.ItermalSelected : " ";
            this.lI_b1Selected = FindData.LI_b1Selected != null ? FindData.LI_b1Selected : " ";
            this.Ust_V_Selected = FindData.Ust_V_Selected != null ? FindData.Ust_V_Selected : " ";
            this.ConnectionToTapSelected = FindData.SelectedItem != null ? Convert.ToString(FindData.SelectedItem[5]) : " ";
            this.StepNumberSelected = FindData.SelectedItemShem != null ? Convert.ToString(FindData.SelectedItemShem[2]) : " ";
            this.shemaСoncretCHSelected = FindData.ShemaСoncretCH != null ? FindData.ShemaСoncretCH : " ";
            this.Number_select_to_revisions = FindData.Number_select_to_revisionsSelected != null ? FindData.Number_select_to_revisionsSelected : " ";
            this.Number_select_to_change_contactSelected = FindData.Number_select_to_change_contactSelected != null ? FindData.Number_select_to_change_contactSelected : " ";
            this.Number_select_mechanicalSelected = FindData.Number_select_mechanicalSelected != null ? FindData.Number_select_mechanicalSelected : " ";
          
            //требуемые параметры                       
            this.aC_b2 = FindData.AC_b2 != null ? FindData.AC_b2 : " ";
            this.lI_b2 = FindData.LI_b2 != null ? FindData.LI_b2 : " ";
            this.aC_a0 = FindData.AC_a0 != null ? FindData.AC_a0 : " ";
            this.lI_a0 = FindData.LI_a0 != null ? FindData.LI_a0 : " ";
            this.aC_b1 = FindData.AC_b1 != null ? FindData.AC_b1 : " ";
            this.kV50Hz1min = FindData.KV50Hz1min != null ? FindData.KV50Hz1min : " ";
            this.lI_kV = FindData.LI_kV != null ? FindData.LI_kV : " ";
            this.idinamic = FindData.Idinamic != null ? FindData.Idinamic : " ";
            this.sst = FindData.Sst != null ? FindData.Sst : " ";
            this.maxCurrent = FindData.MaxCurrent != null ? FindData.MaxCurrent : " ";
            this.itermal = FindData.Itermal != null ? FindData.Itermal : " ";
            this.lI_b1 = FindData.LI_b1 != null ? FindData.LI_b1 : " ";
            this.Ust_V = FindData.Ust_V != null ? FindData.Ust_V : " ";
            this.ConnectionToTap = FindData.SelectedItem != null ? Convert.ToString(FindData.SelectedItem[5]) : " ";
            this.StepNumber = FindData.SelectedItemShem != null ? Convert.ToString(FindData.SelectedItemShem[2]) : " ";
            this.shemaСoncretCH = FindData.ShemaСoncretCH != null ? FindData.ShemaСoncretCH : " ";
            this.Number_to_revisions = FindData.Number_select_to_revisions != null ? FindData.Number_select_to_revisions : " ";
            this.Number_select_to_change_contact = FindData.Number_select_to_change_contact != null ? FindData.Number_select_to_change_contact : " ";
            this.Number_select_mechanical = FindData.Number_select_mechanical != null ? FindData.Number_select_mechanical : " ";
            StartCreateDocx();
        }

        public void StartCreateDocx()
        {
            var fieldValues = new Dictionary<string, string>
            {
                {"Наименовние найденного РПН", tapCHnameSelected+" "+shemaСoncretCHSelected },
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
                {"Включение РО", ConnectionToTapSelected },
                {"Число ступеней", StepNumberSelected },
                {"Схема переключения", shemaСoncretCHSelected },
                {"Фазное напряжение ступени, В", Ust_V_Selected},
                {"Импульсное на землю", lI_kVSelected},
                {"Переключений до ревиизии РПН", Number_select_to_revisions },
                {"До замены контактов", Number_select_to_change_contactSelected },
                {"Механический ресурс", Number_select_mechanicalSelected },

                {"КПЧ межфазное требуемое", aC_b2 },
                {"Импульсное межфазное требуемое", lI_b2 },
                {"КПЧ ступени требуемое", aC_a0 },
                {"Импульсное ступени требуемое", lI_a0},
                {"КПЧ на диапазон требуемое", aC_b1 },
                {"КПЧ на землю требуемое", kV50Hz1min },
                {"Наибольший ударный ток требуемый",idinamic },
                {"Мощность ступени, кВА требуемая", sst },
                {"Рабочий ток требуемый", maxCurrent },
                {"Ток термической стойкости требуемый", itermal },
                {"Импульсное на диапазон требуемое", lI_b1 },
                {"Включение РО требуемое", ConnectionToTap },
                {"Число ступеней требуемое", StepNumber },
                {"Схема переключения требуемая", shemaСoncretCH },
                {"Фазное напряжение ступени, В требуемое", Ust_V},
                {"Импульсное на землю требуемое", lI_kV},
                {"Переключений до ревиизии РПН требуемое", Number_to_revisions },
                {"До замены контактов требуемое", Number_select_to_change_contact },
                {"Механический ресурс требуемый", Number_select_mechanical }
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public string GetDirectoryPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "DocxFile(*.docx)|*.docx";
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
