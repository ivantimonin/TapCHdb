using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using TAP_DB.ViewModel;
using System.IO.Compression;
using Microsoft.Win32;
using System.Data;

namespace TAP_DB.Model
{
    [Serializable]
    public class Save
    {
        #region Поля класса
        /// <summary>
        /// Основная таблица всех схем РПН
        /// </summary>
        public DataTable AllShem;

        /// <summary>
        /// Основная таблица всех РПН
        /// </summary>
        public DataTable AllTapCh;

        /// <summary>
        /// Выбранная строка РПН
        /// </summary>
        public string SelectedIndex;

        /// <summary>
        /// Выбранная строка схемы
        /// </summary>
        public string SelectedShema;

        /// <summary>
        /// Механический ресурс
        /// </summary>
        public string Number_select_mechanicalSelected;

        /// <summary>
        /// Механический ресурс требуемый
        /// </summary>
        public string Number_select_mechanical;


        /// <summary>
        /// Переключений до замены контактов
        /// </summary>
        public string Number_select_to_change_contactSelected;

        /// <summary>
        /// Переключений до замены контактов труется
        /// </summary>
        public string Number_select_to_change_contact;


        /// <summary>
        /// Переключений до ревиизии
        /// </summary>
        public string Number_select_to_revisions;

        /// <summary>
        /// Переключений до ревиизии требуется
        /// </summary>
        public string Number_to_revisions;


        /// <summary>
        /// фазное напряжение ступени
        /// </summary>
        public string Ust_V_Selected;

        /// <summary>
        /// фазное напряжение ступени требуется
        /// </summary>
        public string Ust_V;


        /// <summary>
        /// Число ступеней
        /// </summary>
        public string StepNumberSelected;

        /// <summary>
        /// Число ступеней требуется
        /// </summary> 
        public string StepNumber;


        /// <summary>
        /// Включение РО
        /// </summary>
        public string ConnectionToTapSelected;

        /// <summary>
        /// Включение РО требуется
        /// </summary>
        public string ConnectionToTap;


        /// <summary>
        /// Наименовние схемы для типа РПН
        /// </summary>
        public string shemaСoncretCHSelected;

        /// <summary>
        /// Наименовние схемы для типа РПН требуется
        /// </summary>
        public string shemaСoncretCH;


        /// <summary>
        /// Наименовние найденного РПН
        /// </summary>
        public string tapCHnameSelected;


        /// <summary>
        /// КПЧ межфазное
        /// </summary>
        public string aC_b2Selected;

        /// <summary>
        /// КПЧ межфазное требуется
        /// </summary>
        public string aC_b2;


        /// <summary>
        /// Импульсное межфазное
        /// </summary>
        public string lI_b2Selected;

        /// <summary>
        /// Импульсное межфазное требуется
        /// </summary>
        public string lI_b2;


        /// <summary>
        /// КПЧ ступени
        /// </summary>
        public string aC_a0Selected;

        /// <summary>
        /// КПЧ ступени требуется
        /// </summary>
        public string aC_a0;



        /// <summary>
        /// Импульсное ступени
        /// </summary>
        public string lI_a0Selected;

        /// <summary>
        /// Импульсное ступени требуется
        /// </summary>
        public string lI_a0;


        /// <summary>
        /// КПЧ на диапазон
        /// </summary>
        public string aC_b1Selected;

        /// <summary>
        /// КПЧ на диапазон требуется
        /// </summary>
        public string aC_b1;


        /// <summary>
        /// КПЧ на землю
        /// </summary>
        public string kV50Hz1minSelected;

        /// <summary>
        /// КПЧ на землю требуется
        /// </summary>
        public string kV50Hz1min;


        /// <summary>
        /// Импульсное на землю
        /// </summary>
        public string lI_kVSelected;


        /// <summary>
        /// Импульсное на землю требуется
        /// </summary>
        public string lI_kV;


        /// <summary>
        /// Наибольший ударный ток
        /// </summary>
        public string idinamiclSelected;

        /// <summary>
        /// Наибольший ударный ток требуется
        /// </summary>
        public string idinamic;


        /// <summary>
        /// Мощность ступени, кВА
        /// </summary>
        public string sstSelected;

        /// <summary>
        /// Мощность ступени, кВА требуется
        /// </summary>
        public string sst;


        /// <summary>
        /// Выбранный рабочий ток
        /// </summary>
        public string maxCurrentSelected;

        /// <summary>
        /// Выбранный рабочий ток требуется
        /// </summary>
        public string maxCurrent;


        /// <summary>
        /// Ток термической стойкости выбранный
        /// </summary>
        public string itermalSelected;

        /// <summary>
        /// Ток термической стойкости выбранный требуется
        /// </summary>
        public string itermal;

        /// <summary>
        /// Импульсное на диапазон
        /// </summary>
        public string lI_b1Selected;

        /// <summary>
        /// Импульсное на диапазон требуется
        /// </summary>
        public string lI_b1;
        #endregion
        public Save() { }       
        
        // передаем в конструктор тип класса
        [NonSerialized]
        private XmlSerializer formatter = new XmlSerializer(typeof(Save));      

        public Save(MainVM FindData)
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
            this.SelectedIndex= FindData.SelectedIndex != null ? FindData.SelectedIndex : "-1";
            this.SelectedShema = FindData.SelectedShema != null ? FindData.SelectedShema : "-1";
            this.AllTapCh = FindData.AllTapCh;
            this.AllShem = FindData.AllShem;
        }

        /// <summary>
        /// Серриализация
        /// </summary>
        public void SerializableFile()
        {            
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(@"Save\MainVM.xml", FileMode.Create))
            {
                formatter.Serialize(fs, this);              
            }
        }

        /// <summary>
        /// Дессериализация
        /// </summary>
        public Save DeSerializableFile()
        {
            
            try
            {
                ExtractZip();
                using (FileStream fs = new FileStream(@"Save\MainVM.xml", FileMode.Open))
                {
                    Save old_data = (Save)formatter.Deserialize(fs);
                    // MessageBox.Show("Файл выгружен");
                    return old_data;
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
            
        }

        /// <summary>
        /// Метод создает папку куда будут сохраняться все XML файлы
        /// </summary>       
        public void CreateFoldreSave()
        {           
            string path = Directory.GetCurrentDirectory() + @"\Save";         
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }      
        }
       
        /// <summary>
        /// Метод, который архивирует  папку сохранения в указанную пользователем дирректорию
        /// </summary>
        public void CreateZip()
        {
            string sourceFolder = Directory.GetCurrentDirectory() + @"\Save"; // исходная папка
            string zipFile = SaveDirectoryPath(); // сжатый файл
            if (zipFile != "")
            {
                FileInfo fileInfo = new FileInfo(zipFile);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                ZipFile.CreateFromDirectory(sourceFolder, zipFile);// архивация   
            }                        
        }

        private void ExtractZip()
        {           
            string targetFolder = Directory.GetCurrentDirectory() + @"\Save"; // исходная папка
            string zipFile = OpenDirectoryPath(); // сжатый файл
            DirectoryInfo dirInfo = new DirectoryInfo(targetFolder);
            if (dirInfo.Exists)
            {
                dirInfo.Delete(true);
            }
            ZipFile.ExtractToDirectory(zipFile, targetFolder);//распаковка
        }

        private string SaveDirectoryPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "SavedFile(*.smtt)|*.smtt";        
            saveFileDialog.AddExtension = true;            
            saveFileDialog.ShowDialog();
            return saveFileDialog.FileName;
        }

        private string OpenDirectoryPath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "OpenFile(*.smtt|*.smtt";
            openFileDialog.AddExtension = true;
            openFileDialog.ShowDialog();
            return openFileDialog.FileName;
        }
    }
}
