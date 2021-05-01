using FindInWord.ViewModel;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TAP_DB.Model;
using TAP_DB.View;


namespace TAP_DB.ViewModel
{
    public partial class MainVM :INotifyPropertyChanged
    {
        /// <summary>
        /// Состояние без доступа, то есть блокировать интерфейс
        /// </summary>
        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Мощность ступени
        /// </summary>
        private string sst = "0";
        public string Sst
        {
            get { return sst; }
            set
            {
                if (value == "")
                {
                    sst = "0";
                }
                else
                {
                    sst = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Наибольшее рабочее напряжение, кВ
        /// </summary>
        private string ust_V = "0";
        public string Ust_V
        {
            get { return ust_V; }
            set
            {
                if (value == "")
                {
                    ust_V = "0";
                }
                else
                {
                    ust_V = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Описание схемы переключения РПН
        /// </summary>
        private string shema_perekl = "Shema_details";
        public string Shema_perekl
        {
            get { return shema_perekl; }
            set
            {
                if (value == null)
                {
                    shema_perekl = "Shema_details";
                }
                else
                {
                    shema_perekl = "'" + value + "'";
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Импульсное напряжение на землю, кВ
        /// </summary>
        private string lI_kV = "0";
        public string LI_kV
        {
            get { return lI_kV; }
            set
            {
                if (value == "")
                {
                    lI_kV = "0";
                }
                else
                {
                    lI_kV = value;
                }
                OnPropertyChanged();
                //QueryAllTap();

            }
        }

        /// <summary>
        /// Таблица, которая содержит все данные по РПН
        /// </summary>
        private DataTable allTapCh;
        public DataTable AllTapCh
        {
            get { return allTapCh; }
            set
            {                
                allTapCh = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Ток термической стойкости
        /// </summary>
        private string itermal = "0";
        public string Itermal
        {
            get { return itermal; }
            set
            {
                if (value == "")
                {
                    itermal = "0";
                }
                else
                {
                    itermal = value;
                }
                OnPropertyChanged();
                // QueryAllTap();
            }
        }

        /// <summary>
        /// Ток динамической стойкости
        /// </summary>
        private string idinamic = "0";
        public string Idinamic
        {
            get { return idinamic; }
            set
            {
                if (value == "")
                {
                    idinamic = "0";
                }
                else
                {
                    idinamic = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Максимальный ток РПН
        /// </summary>
        private string maxCurrent = "0";
        public string MaxCurrent
        {
            get { return maxCurrent; }
            set
            {
                if (value == "")
                {
                    maxCurrent = "0";
                }
                else
                {
                    maxCurrent = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Испытательное ОПЧ
        /// </summary>
        private string kV50Hz1min = "0";
        public string KV50Hz1min
        {
            get { return kV50Hz1min; }
            set
            {
                if (value == "")
                {
                    kV50Hz1min = "0";
                }
                else
                {
                    kV50Hz1min = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Импульсное на диапазон, кВ
        /// </summary>
        private string lI_b1 = "0";
        public string LI_b1
        {
            get { return lI_b1; }
            set
            {
                if (value == "")
                {
                    lI_b1 = "0";
                }
                else
                {
                    lI_b1 = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КПЧ на диапазон
        /// </summary>
        private string aC_b1 = "0";
        public string AC_b1
        {
            get { return aC_b1; }
            set
            {
                if (value == "")
                {
                    aC_b1 = "0";
                }
                else
                {
                    aC_b1 = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Импульсное ступени, кВ
        /// </summary>
        private string lI_a0 = "0";
        public string LI_a0
        {
            get { return lI_a0; }
            set
            {
                if (value == "")
                {
                    lI_a0 = "0";
                }
                else
                {
                    lI_a0 = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КПЧ ступени,кВ
        /// </summary>
        private string aC_a0 = "0";
        public string AC_a0
        {
            get { return aC_a0; }
            set
            {
                if (value == "")
                {
                    aC_a0 = "0";
                }
                else
                {
                    aC_a0 = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Импульсное межфазное, кВ
        /// </summary>
        private string lI_b2 = "0";
        public string LI_b2
        {
            get { return lI_b2; }
            set
            {
                if (value == "")
                {
                    lI_b2 = "0";
                }
                else
                {
                    lI_b2 = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КПЧ межфазное, кВ
        /// </summary>
        private string aC_b2 = "0";
        public string AC_b2
        {
            get { return aC_b2; }
            set
            {
                if (value == "")
                {
                    aC_b2 = "0";
                }
                else
                {
                    aC_b2 = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Число переключений до ревизии
        /// </summary>
        private string number_select_to_revisions = "0";
        public string Number_select_to_revisions
        {
            get { return number_select_to_revisions; }
            set
            {
                if (value == "")
                {
                    number_select_to_revisions = "0";
                }
                else
                {
                    number_select_to_revisions = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Число переключений до замены контактов
        /// </summary>
        private string number_select_to_change_contact = "0";
        public string Number_select_to_change_contact
        {
            get { return number_select_to_change_contact; }
            set
            {
                if (value == "")
                {
                    number_select_to_change_contact = "0";
                }
                else
                {
                    number_select_to_change_contact = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Механический ресурс РПН
        /// </summary>
        private string number_select_mechanical = "0";
        public string Number_select_mechanical
        {
            get { return number_select_mechanical; }
            set
            {
                if (value == "")
                {
                    number_select_mechanical = "0";
                }
                else
                {
                    number_select_mechanical = value;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Все схемы переключения
        /// </summary>
        private DataTable allShem;
        public DataTable AllShem
        {
            get { return allShem; }
            set
            {
                allShem = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateDocx { get; private set; }
        public ICommand DoQuery { get; private set; }
        public ICommand ClearInputData { get; private set; }
       
        public MainVM()
        {
            CreateDocx = new DelegateCommand(CreateFileDocx);
            ClearInputData = new DelegateCommand(ClearInputDataFunctiun);
            DoQuery = new DelegateCommand(QueryAllTap);
            QueryAllTap();// получаем данные из таблицы       
        }

        /// <summary>
        /// Метод создания отчета по характеристикам РПН
        /// </summary>
        /// <param name="obj"></param>
        public async void CreateFileDocx(object obj)
        {
            await Task.Run(() =>
            {               
                CreateDocx someDocx = new CreateDocx(this);                
            });
        }

        /// <summary>
        /// Метод сброса всех фильтров
        /// </summary>
        /// <param name="obj"></param>
        public void ClearInputDataFunctiun(object obj)
        {
            MaxCurrent = "";
            Itermal = "";
            Idinamic = "";
            ust_V = "";
            Sst = "";
            LI_kV = "";
            KV50Hz1min = "";
            LI_b1 = "";
            AC_b1 = "";
            LI_a0 = "";
            AC_a0 = "";
            LI_b2 = "";
            AC_b2 = "";
            Number_select_to_revisions = "";
            Number_select_to_change_contact = "";
            Number_select_mechanical = "";
            Ust_V = "";

            Number_select_mechanicalSelected = "";
            TapCHname = "";
            ShemaСoncretCH = "";
            Number_select_to_revisionsSelected = "";
            AC_b2Selected = "";
            LI_b2Selected = "";
            AC_a0Selected = "";
            LI_a0Selected = "";
            AC_b1Selected = "";
            KV50Hz1minSelected = "";
            LI_kVSelected = "";
            IdinamiclSelected = "";
            Ust_V_Selected = "";
            SstSelected = "";
            MaxCurrentSelected = "";
            ItermalSelected = "";
            LI_b1Selected = "";
            Number_select_to_change_contactSelected = "";
            QueryAllTap();
        }

        /// <summary>
        /// Метод обработки запроса в БД
        /// </summary>        
        public DataTable Select(string selectSQL) // функция  обработка запросов
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;//достаем строку подключения из config

            SqlConnection sqlConnection = new SqlConnection(connectionString); // подключаемся к базе данных
            DataTable dataTable = new DataTable("dataTable");// создаём таблицу в приложении
            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();// открываем базу данных  
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
                    sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
                    sqlDataAdapter.Fill(dataTable);                                  // возращаем таблицу с результатом             
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                sqlConnection.Close();
            }
            return dataTable;
        }

        /// <summary>
        /// Реализация PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        /// <summary>
        /// Запрос всех схем на нужный РПН
        /// </summary>      
        public void QueryAllShem(object obj = null)
        {
            #region Query
            AllShem = Select("USE TAP_CHANGER " +
                            "SELECT DISTINCT " +
                            "CONCAT([Type], ' ', Seria, ' ', Phaze_number, '-', I_A, ' ', Simbol, '/', Um_kV_rms, ' ', Izbiratel_value), " +
                            "Shema, " +
                            "Shema_details " +
                            "FROM TapChanger " +
                            "JOIN Uispitael " +
                            "ON TapChanger.Um_kV_rms_id = Uispitael.Um_kV_rms_id " +
                            "JOIN Type " +
                            "ON TapChanger.Type_id = Type.Type_id " +
                            "JOIN Contact_type " +
                            "ON Type.Selector_type = Contact_type.Id " +
                            "JOIN Seria " +
                            "ON TapChanger.Seria_id = Seria.Seria_Id " +
                            "JOIN Catalog " +
                            "ON Seria.Seria_Id = Catalog.Seria_id and Type.Type_id = Catalog.Type_id " +
                            "JOIN Phaze_number " +
                            "ON TapChanger.Phaze_Number_id = Phaze_number.Phaze_Number_id " +
                            "JOIN Concrete_Phaze_number " +
                            "ON Phaze_number.Concrete_Phaze_number_id = Concrete_Phaze_number.Concrete_Phaze_number_id " +
                            "JOIN[Current] " +
                            "ON Phaze_number.Current_id =[Current].Current_Id " +
                            "JOIN Izbiratel " +
                            "ON TapChanger.Izbiratel_id = Izbiratel.Izbiratel_id " +
                            "JOIN Shema " +
                            "ON TapChanger.Shema_id = Shema.Shema_id " +
                            "Where " +
                            $"CONCAT([Type],' ',Seria,' ',Phaze_number,'-', I_A,' ',Simbol,'/',Um_kV_rms,' ',Izbiratel_value)= '{TapCHname}'");

            #endregion
        }

        /// <summary>
        /// Запрос всех РПН
        /// </summary>        
        public async void QueryAllTap(object obj = null)
        {
            
            await Task.Run(() =>
            {
                IsBusy = true;
                #region Query
                AllTapCh = Select("USE TAP_CHANGER " +
              "SELECT DISTINCT " +
              "CONCAT([Type], ' ', Seria, ' ', Phaze_number, '-', I_A, ' ', Simbol, '/', Um_kV_rms, ' ', Izbiratel_value)," +
              "[Type], " +
              "Seria, " +
              "Contact_type, " +
              "Phaze_number, " +
              "Details, " +
              "I_A, " +
              "[Iterm_kA], " +
              "[Idinamic_kA], " +
              "[Ust_V], " +
              "[S_kVA], " +
              "Um_kV_rms " +
              ",[kV50Hz1min] " +
              ",[SI_kV] " +
              ",[LI_kV] " +
              ",[Izbiratel_value] " +
              ",[LI_a0] " +
              ",[LI_b1] " +
              ",[LI_b2] " +
              ",[LI_c1] " +
              ",[LI_c2] " +
              ",[LI_d] " +
              ",[AC_a0] " +
              ",[AC_b1] " +
              ",[AC_b2] " +
              ",[AC_c1] " +
              ",[AC_c2] " +
              ",[AC_d], " +
                "Number_select_to_revisions, " +
                "Number_select_to_change_contact, " +
                "Number_select_mechanical, " +
                "About_Catalog " +
                "FROM TapChanger " +
                "JOIN Uispitael " +
                "ON TapChanger.Um_kV_rms_id = Uispitael.Um_kV_rms_id " +
                "JOIN Type " +
                "ON TapChanger.Type_id = Type.Type_id " +
                "JOIN Contact_type " +
                "ON Type.Selector_type = Contact_type.Id " +
                "JOIN Seria " +
                "ON TapChanger.Seria_id = Seria.Seria_Id " +
                "JOIN Catalog " +
                "ON Seria.Seria_Id = Catalog.Seria_id and Type.Type_id = Catalog.Type_id " +
                "JOIN Phaze_number " +
                "ON TapChanger.Phaze_Number_id = Phaze_number.Phaze_Number_id " +
                "JOIN Concrete_Phaze_number " +
                "ON Phaze_number.Concrete_Phaze_number_id = Concrete_Phaze_number.Concrete_Phaze_number_id " +
                "JOIN[Current] " +
                "ON Phaze_number.Current_id =[Current].Current_Id " +
                "JOIN Izbiratel " +
                "ON TapChanger.Izbiratel_id = Izbiratel.Izbiratel_id " +
                "JOIN Shema " +
                "ON TapChanger.Shema_id = Shema.Shema_id Where " +
                $"I_A>={maxCurrent} and " +
                $"Iterm_kA>={itermal} and " +
                $"Idinamic_kA>={idinamic} and " +
                $"Ust_V>={ust_V} and " +
                $"S_kVA>={sst} and " +
                $"LI_kV>={lI_kV} and " +
                $"kV50Hz1min>={kV50Hz1min} and " +
                $"LI_b1>={lI_b1} and " +
                $"AC_b1>={aC_b1} and " +
                $"LI_a0>={lI_a0} and " +
                $"AC_a0>={aC_a0} and " +
                $"LI_b2>={lI_b2} and " +
                $"AC_b2>={aC_b2} and " +
                $"Number_select_to_revisions>={number_select_to_revisions} and " +
                $"Number_select_to_change_contact>={number_select_to_change_contact} and " +
                $"Number_select_mechanical>={number_select_mechanical}");
                #endregion
                IsBusy = false;                
            });

        }
    }
}
