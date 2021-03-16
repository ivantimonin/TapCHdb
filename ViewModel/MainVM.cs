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
using System.Threading.Tasks;
using System.Windows;


namespace TAP_DB.ViewModel
{
    class MainVM:INotifyPropertyChanged
    {
        
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
                //QueryAllTap();
            }
        }

        private string urms = "0";
        public string Urms
        {
            get { return urms; }
            set
            {
                if (value == "")
                {
                    urms = "0";
                }
                else
                {
                    urms = value;
                }
                OnPropertyChanged();
                //QueryAllTap();

            }
        }

        private string shema_perekl= "Shema_details";
        public string Shema_perekl
        {
            get { return shema_perekl; }
            set
            {
               
                if (value ==null)
                {                    
                    shema_perekl = "Shema_details";
                }
                else
                {
                    shema_perekl = "'"+value+"'";
                }                
                OnPropertyChanged();
                //QueryAllTap();

            }
        }



        private DataTable allShemPerkluch;
        public DataTable AllShemPerkluch
        {
            get { return allShemPerkluch; }
            set
            {
                allShemPerkluch = value;
                OnPropertyChanged();
            }
        }

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

        private string itermal="0";
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
                //QueryAllTap();
            }
        }

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
                //QueryAllTap();
            }
        }



        private string maxCurrent="0";
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
                //QueryAllTap();
            }
        }

        private DataTable allManufactures;
        public DataTable AllManufactures
        {
            get { return allManufactures; }
            set
            {
                allManufactures = value;
                OnPropertyChanged();               
            }
        }

        string connectionString;
        SqlConnection sqlConnection;

        public MainVM()
        {
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;//достаем строку подключения из config
                sqlConnection = new SqlConnection(connectionString); // подключаемся к базе данных
                sqlConnection.Open();// открываем базу данных
                                     // MessageBox.Show($"{connectionString }");
                allManufactures = Select("USE TAP_CHANGER SELECT Manufacturer  FROM Manufacturers");
                QueryAllTap();// получаем данные из таблицы
                allShemPerkluch = Select("USE TAP_CHANGER SELECT DISTINCT Shema_details FROM Shema order by Shema_details");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }         

            
        }

       



        public DataTable Select(string selectSQL) // функция  обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase");                // создаём таблицу в приложении                                                       
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом
           // sqlConnection.Close();
            return dataTable;
        }
       


        



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }



        public void QueryAllTap()
        {
            //MessageBox.Show("dddddd");
            try
            {           
                #region Query
            AllTapCh = Select("USE TAP_CHANGER " +
                      "SELECT DISTINCT " +
                      "CONCAT([Type], ' ', Seria, ' ', Phaze_number, '-', I_A, ' ', Simbol, '/', Um_kV_rms, ' ', Izbiratel_value, '-', Shema),"+
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
                      "Izbiratel_value " +
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
                        "Shema, " +
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
                        $"Iterm_kA>={itermal} and "+
                        $"Idinamic_kA>={idinamic} and "+
                        $"Um_kV_rms>={urms} and "+
                        $"S_kVA>={sst}");

                #endregion         
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");                
            }
        }
    }
}
