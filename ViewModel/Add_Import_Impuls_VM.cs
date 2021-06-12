using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TAP_DB.Model;
using TAP_DB.View;
using TAP_DB.ViewModel.Base;

namespace TAP_DB.ViewModel
{
    class Add_Import_Impuls_VM : BaseVM
    {

        #region Поля
        /// <summary>
        /// ссылка на MainVM
        /// </summary>      

        public MainVM MainVM_Data;

        #region Поля вкладки импорт
        /// <summary>
        /// Таблица, которая содержит все данные по испытательным напряжениям
        /// </summary>      
        private DataTable allImpulseData;
        public DataTable AllImpulseData
        {
            get { return allImpulseData; }
            set
            {
                allImpulseData = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Выбранная строка в таблице с импульсами
        /// </summary>
        private DataRowView selectedImpulse;
        public DataRowView SelectedImpulse
        {
            get { return selectedImpulse; }
            set
            {
                selectedImpulse = value;

                if (selectedImpulse != null)
                {
                    LI_kV_impuls = Convert.ToString(selectedImpulse[7]);
                    KV50Hz1min_impuls = Convert.ToString(selectedImpulse[8]);
                    LI_b1_impuls = Convert.ToString(selectedImpulse[9]);
                    AC_b1_impuls = Convert.ToString(selectedImpulse[10]);
                    LI_a0_impuls = Convert.ToString(selectedImpulse[11]);
                    AC_a0_impuls = Convert.ToString(selectedImpulse[12]);
                    LI_b2_impuls = Convert.ToString(selectedImpulse[13]);
                    AC_b2_impuls = Convert.ToString(selectedImpulse[14]);
                    OnPropertyChanged();
                }
            }
        }

       

        /// <summary>
        /// Импульсное напряжение на землю, кВ
        /// </summary>

        private string lI_kV_impuls;
        public string LI_kV_impuls
        {
            get
            {
                return lI_kV_impuls;
            }
            set
            {
                lI_kV_impuls = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КПЧ на землю
        /// </summary>
        private string kV50Hz1min_impuls;
        public string KV50Hz1min_impuls
        {
            get
            {
                return kV50Hz1min_impuls;
            }
            set
            {

                kV50Hz1min_impuls = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Импульсное на диапазон
        /// </summary>
        private string lI_b1_impuls;
        public string LI_b1_impuls
        {
            get
            {
                return lI_b1_impuls;
            }
            set
            {
                lI_b1_impuls = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КПЧ ступени
        /// </summary>
        private string aC_a0_impuls;
        public string AC_a0_impuls
        {
            get
            {
                return aC_a0_impuls;
            }
            set
            {
                aC_a0_impuls = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Импульсное ступени
        /// </summary>
        private string lI_a0_impuls;
        public string LI_a0_impuls
        {
            get
            {
                return lI_a0_impuls;
            }
            set
            {
                lI_a0_impuls = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КПЧ на диапазон
        /// </summary>
        private string aC_b1_impuls;
        public string AC_b1_impuls
        {
            get
            {
                return aC_b1_impuls;
            }
            set
            {
                aC_b1_impuls = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Импульсное межфазное
        /// </summary>
        private string lI_b2_impuls;
        public string LI_b2_impuls
        {
            get
            {
                return lI_b2_impuls;
            }
            set
            {
                lI_b2_impuls = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КПЧ межфазное
        /// </summary>
        private string aC_b2_impuls;
        public string AC_b2_impuls
        {
            get
            {
                return aC_b2_impuls;
            }
            set
            {
                aC_b2_impuls = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Поля вкладки добавить в БД

        /// <summary>
        /// Выбранная строка в таблице с импульсами вкладки добавления в БД
        /// </summary>
        private DataRowView selectedImpulseAdd;
        public DataRowView SelectedImpulseAdd
        {
            get { return selectedImpulseAdd; }
            set
            {
                selectedImpulseAdd = value;

                if (selectedImpulseAdd != null)
                {
                    ID = Convert.ToString(selectedImpulseAdd[0]);                
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// ID выбранной строки в БД
        /// </summary>
        private string iD;
        public string ID
        {
            get
            {
                return iD;
            }
            set
            {
                iD = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Импульсное напряжение на землю, кВ
        /// </summary>
        private string lI_kV_impuls_add = "null";
        public string LI_kV_impuls_add
        {
            get
            {
                return lI_kV_impuls_add;
            }
            set
            {
                lI_kV_impuls_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КПЧ на землю
        /// </summary>
        private string kV50Hz1min_impuls_add = "null";
        public string KV50Hz1min_impuls_add
        {
            get
            {
                return kV50Hz1min_impuls_add;
            }
            set
            {
                kV50Hz1min_impuls_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Импульсное на диапазон
        /// </summary>
        private string lI_b1_impuls_add = "null";
        public string LI_b1_impuls_add
        {
            get
            {
                return lI_b1_impuls_add;
            }
            set
            {
                lI_b1_impuls_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КПЧ ступени
        /// </summary>
        private string aC_a0_impuls_add = "null";
        public string AC_a0_impuls_add
        {
            get
            {
                return aC_a0_impuls_add;
            }
            set
            {
                aC_a0_impuls_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Импульсное ступени
        /// </summary>
        private string lI_a0_impuls_add = "null";
        public string LI_a0_impuls_add
        {
            get
            {
                return lI_a0_impuls_add;
            }
            set
            {
                lI_a0_impuls_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КПЧ на диапазон
        /// </summary>
        private string aC_b1_impuls_add = "null";
        public string AC_b1_impuls_add
        {
            get
            {
                return aC_b1_impuls_add;
            }
            set
            {
                aC_b1_impuls_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Импульсное межфазное
        /// </summary>
        private string lI_b2_impuls_add = "null";
        public string LI_b2_impuls_add
        {
            get
            {
                return lI_b2_impuls_add;
            }
            set
            {
                lI_b2_impuls_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КПЧ межфазное
        /// </summary>
        private string aC_b2_impuls_add = "null";
        public string AC_b2_impuls_add
        {
            get
            {
                return aC_b2_impuls_add;
            }
            set
            {
                aC_b2_impuls_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Тип трансформатора
        /// </summary>
        private string transformer_add = "null";
        public string Transformer_add
        {
            get
            {
                return transformer_add;
            }
            set
            {
                transformer_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Класс напряжения
        /// </summary>
        private string u_klass_kV_add = "null";
        public string U_klass_kV_add
        {
            get
            {
                return u_klass_kV_add;
            }
            set
            {
                u_klass_kV_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// ПГИ, кВ
        /// </summary>
        private string lI_kV_add = "null";
        public string LI_kV_add
        {
            get
            {
                return lI_kV_add;
            }
            set
            {
                lI_kV_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// CГИ, кВ
        /// </summary>
        private string cLI_kV_add = "null";
        public string CLI_kV_add
        {
            get
            {
                return cLI_kV_add;
            }
            set
            {
                cLI_kV_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// ОПЧ, кВ
        /// </summary>
        private string one_min_kV_add = "null";
        public string One_min_kV_add
        {
            get
            {
                return one_min_kV_add;
            }
            set
            {
                one_min_kV_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КИ, кВ
        /// </summary>
        private string sI_kV_add = "null";
        public string SI_kV_add
        {
            get
            {
                return sI_kV_add;
            }
            set
            {
                sI_kV_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// ГОСТ или МЭК, кВ
        /// </summary>
        private string gOST_ISO_add = "null";
        public string GOST_ISO_add
        {
            get
            {
                return gOST_ISO_add;
            }
            set
            {
                gOST_ISO_add = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// ТКП или РР1, кВ
        /// </summary>
        private string tKP_RR1_add="null";
        public string TKP_RR1_add
        {
            get
            {
                return tKP_RR1_add;
            }
            set
            {
                tKP_RR1_add = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #endregion

        #region Команда загрузки данных на основную форму
        public ICommand LoadImpulsOnMainForm { get; private set; }

        public void LoadImpulsOnMainFormFunction(object obj)
        {
            MainVM_Data.LI_kV = lI_kV_impuls;
            MainVM_Data.KV50Hz1min = KV50Hz1min_impuls;
            MainVM_Data.LI_b1 = LI_b1_impuls;
            MainVM_Data.AC_b1 = AC_b1_impuls;
            MainVM_Data.LI_a0 = LI_a0_impuls;
            MainVM_Data.AC_a0 = AC_a0_impuls;
            MainVM_Data.LI_b2 = LI_b2_impuls;
            MainVM_Data.AC_b2 = AC_b2_impuls;
            MessageBox.Show("Данные по испытательным напряжениям выгружены на основную форму");
        }
        #endregion

        #region Команда добавления испытательных напряжений в БД
        public ICommand AddToDataBase { get; private set; }

        public void AddToDataBaseFunction(object obj)
        {
            try
            {
                InsertImpuls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
            QueryAllImpuls();
        }
        #endregion

        #region Команда удаления испытательных напряжений из БД
        public ICommand DelateRowFromDb { get; private set; }

        public void DelateRowFromDbFunction(object obj)
        {
            try
            {
                DelateRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            QueryAllImpuls();
        }
        #endregion



        public Add_Import_Impuls_VM(MainVM mainVMdata)
        {
            MainVM_Data = mainVMdata;
            QueryAllImpuls();
            LoadImpulsOnMainForm = new DelegateCommand(LoadImpulsOnMainFormFunction);
            AddToDataBase = new DelegateCommand(AddToDataBaseFunction);
            DelateRowFromDb = new DelegateCommand(DelateRowFromDbFunction);
        }

        #region Запросы  
        /// <summary>
        /// Запрос на получение всех испытательных напряжений
        /// </summary>       
        public void QueryAllImpuls(object obj = null)
        {
            #region Query
            AllImpulseData = DataBase.Select("USE TAP_CHANGER " +
                                     "Select " +
                                     "ID "+
                                    ",[Transformer] " +
                                    ",[U_klass_kV] " +
                                    ",[CLI_kV] " +
                                    ",[LI_kV] " +
                                    ",[One_min_kV] " +
                                    ",[SI_kV] " +
                                    ",[GOST_ISO] " +
                                    ",[LI_kV_RPN] " +
                                    ",[KV50Hz1minRPN] " +
                                    ",[LI_b1] " +
                                    ",[AC_b1] " +
                                    ",[LI_a0] " +
                                    ",[AC_a0] " +
                                    ",[LI_b2] " +
                                    ",[AC_b2] " +
                                    ",TKP_RR1 " +
                                    "FROM[TAP_CHANGER].[dbo].[Impulse]");

            #endregion
        }

        /// <summary>
        /// Запрос на удаление  строки из бд
        /// </summary>       
        public void DelateRow(object obj = null)
        {            
            #region Query
            AllImpulseData = DataBase.Select("USE TAP_CHANGER " +
               $"DELETE FROM [TAP_CHANGER].[dbo].[Impulse] WHERE [ID] = {ID}");

            #endregion
        }


        /// <summary>
        /// Запрос на добавление  испытательных напряжений
        /// </summary>       
        public void InsertImpuls(object obj = null)
        {
            #region Query
            AllImpulseData = DataBase.Select("USE TAP_CHANGER " +
                "INSERT INTO Impulse "+
                $"VALUES('{Transformer_add}', " +
                $"{U_klass_kV_add}, " +
                $"{CLI_kV_add}, " +
                $"{LI_kV_add}, " +
                $"{One_min_kV_add}, " +
                $"{SI_kV_add}, " +
                $"{GOST_ISO_add}, " +
                $"{LI_kV_impuls_add}, " +
                $"{KV50Hz1min_impuls_add}, " +
                $"{LI_b1_impuls_add}, " +
                $"{AC_b1_impuls_add}, " +
                $"{LI_a0_impuls_add}, " +
                $"{AC_a0_impuls_add}, " +
                $"{LI_b2_impuls_add}, " +
                $"{AC_b2_impuls_add}, " +
                $"{TKP_RR1_add})");

            #endregion
        }
        #endregion



    }
}

