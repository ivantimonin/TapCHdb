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

        public Add_Import_Impuls_VM(MainVM mainVMdata)
        {
            MainVM_Data = mainVMdata;
            QueryAllImpuls();
            LoadImpulsOnMainForm = new DelegateCommand(LoadImpulsOnMainFormFunction);            
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
                                    "[Transformer] " +
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
        #endregion


       
    }
}

