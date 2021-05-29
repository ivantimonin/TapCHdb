
using Syncfusion.UI.Xaml.Grid;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TAP_DB.Command;
using TAP_DB.Model;
using TAP_DB.View;

namespace TAP_DB.ViewModel
{

    public partial class MainVM : INotifyPropertyChanged
    {
        #region Поля класса
        /// <summary>
        /// Индиктор нажатия кнопки подтверждения фильтрации
        /// </summary>
        private bool IsConfirmCleareFilterTrue=false;


        /// <summary>
        /// Очистка умных таблиц (индикатор)
        /// </summary>        
        private bool cleareSmartTable=true;
        public bool CleareSmartTable
        {
            get { return cleareSmartTable; }
            set
            {               
                cleareSmartTable = value;
              
            }
        }
        /// <summary>
        /// Очистка введенных данных (индикатор)
        /// </summary>        
        private bool сleareInputData = true;
        public bool CleareInputData
        {
            get { return сleareInputData; }
            set
            {        
                сleareInputData = value;                
            }
        }


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
                MessageBox.Show($"old_value={lI_kV}");
                MessageBox.Show($"value={value}");
              
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
        /// DatagidBase
        /// </summary>       
        private SfDataGrid myDtataGrid;
        public SfDataGrid MyDtataGridBase
        {
            get { return myDtataGrid; }
            set
            {
                myDtataGrid = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// DatagidShema
        /// </summary>       
        private SfDataGrid myDtataGridShema;
        public SfDataGrid MyDtataGridShema
        {
            get { return myDtataGridShema; }
            set
            {
                myDtataGridShema = value;
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

        #endregion


        public ICommand ConfirmCleareFilter { get; private set; }
        public ICommand CreateDocx { get; private set; }
        public ICommand DoQuery { get; private set; }
        public ICommand ClearInputData { get; private set; }
        public ICommand Save { get; private set; }
        public ICommand Open { get; private set; }
        public ICommand ImpulseDataOn { get; private set; }
        public ICommand LoadImpulsOnMainForm { get; private set; }

        public MainVM()
        {
            LoadImpulsOnMainForm = new DelegateCommand(LoadImpulsOnMainFormFunction);
            ImpulseDataOn = new DelegateCommand(ImpulseDataOnFunction);
            ConfirmCleareFilter = new DelegateCommand(ConfirmCleareFilterFunction);
            CreateDocx = new DelegateCommand(CreateFileDocx);
            ClearInputData = new DelegateCommand(ClearInputDataFunctiun);
            DoQuery = new DelegateCommand(QueryAllTap);
            Save = new DelegateCommand(SaveWork);
            Open = new DelegateCommand(OpenWork);
            QueryAllTap();// получаем данные из таблицы   
            
        }

        public  void LoadImpulsOnMainFormFunction(object obj)
        {
            // var mainVM = (Window)obj;
            //mainVM.Close();
          
            KV50Hz1min = KV50Hz1min_impuls;
            LI_b1 = LI_b1_impuls;
            AC_b1 = AC_b1_impuls;
            LI_a0 = LI_a0_impuls;
            AC_a0 = AC_a0_impuls;
            LI_b2 = LI_b2_impuls;
            AC_b2 = AC_b2_impuls;

            OnPropertyChanged();
            MessageBox.Show("Данные по испытательным напряжениям выгружены на основную форму");
        }

       

        /// <summary>
        /// Открытие окна данных испытательных напряжений и загрузка данных из БД
        /// </summary>    
        public void ImpulseDataOnFunction(object obj)
        {
          
            QueryAllImpuls();
            Add_Import_Impulse imp = new Add_Import_Impulse(this);
            imp.ShowDialog();
        }

        /// <summary>
        /// Метод сохранения данных
        /// </summary>
        /// <param name="obj"></param>
        public void SaveWork(object obj)
        {            
            Save data = new Save(this);
            data.CreateFoldreSave();
            #region Серриализация умных таблиц
            MainVM mainVM = (MainVM)obj;
            MyDtataGridBase = mainVM.MyDtataGridBase;
            MyDtataGridShema = mainVM.MyDtataGridShema;
            using (var file = File.Create(@"Save\DataGridBaseSave.xml"))
            {
                MyDtataGridBase.Serialize(file);
            }
            #endregion

            using (var file = File.Create(@"Save\DataGridShemaSave.xml"))
            {
                MyDtataGridShema.Serialize(file);
            }

            data.SerializableFile();
            data.CreateZip();
        }

        /// <summary>
        /// Метод чтения данных
        /// </summary>
        /// <param name="obj"></param>
        public void OpenWork(object obj)
        {
            Save data = new Save();
            Save oldData = data.DeSerializableFile();
            #region Дессериализация умных таблиц
            MainVM mainVM = (MainVM)obj;
            MyDtataGridBase = mainVM.MyDtataGridBase;
            MyDtataGridShema = mainVM.MyDtataGridShema;

            try
            {
                using (var file = File.Open(@"Save\DataGridBaseSave.xml", FileMode.Open))
                {
                    MyDtataGridBase.Deserialize(file);
                }
                using (var file = File.Open(@"Save\DataGridShemaSave.xml", FileMode.Open))
                {
                    MyDtataGridShema.Deserialize(file);
                }
            }

            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            #endregion

            if (oldData != null)
            {
                MaxCurrent = oldData.maxCurrent;
                Itermal = oldData.itermal;
                Idinamic = oldData.idinamic;
                ust_V = oldData.Ust_V;
                Sst = oldData.sst;
                LI_kV = oldData.lI_kV;
                KV50Hz1min = oldData.kV50Hz1min;
                LI_b1 = oldData.lI_b1;
                AC_b1 = oldData.aC_b1;
                LI_a0 = oldData.lI_a0;
                AC_a0 = oldData.aC_a0;
                LI_b2 = oldData.lI_b2;
                AC_b2 = oldData.aC_b2;
                Number_select_to_revisions = oldData.Number_to_revisions;
                Number_select_to_change_contact = oldData.Number_select_to_change_contact;
                Number_select_mechanical = oldData.Number_select_mechanical;
                Ust_V = oldData.Ust_V;

                Number_select_mechanicalSelected = oldData.Number_select_mechanicalSelected;
                TapCHname = oldData.tapCHnameSelected;
                ShemaСoncretCH = oldData.shemaСoncretCH;
                Number_select_to_revisionsSelected = oldData.Number_select_to_revisions;
                AC_b2Selected = oldData.aC_b2Selected;
                LI_b2Selected = oldData.lI_b2Selected;
                AC_a0Selected = oldData.aC_a0Selected;
                LI_a0Selected = oldData.lI_a0Selected;
                AC_b1Selected = oldData.aC_b1Selected;
                KV50Hz1minSelected = oldData.kV50Hz1minSelected;
                LI_kVSelected = oldData.lI_kVSelected;
                IdinamiclSelected = oldData.idinamiclSelected;
                Ust_V_Selected = oldData.Ust_V_Selected;
                SstSelected = oldData.sstSelected;
                MaxCurrentSelected = oldData.maxCurrentSelected;
                ItermalSelected = oldData.itermalSelected;
                LI_b1Selected = oldData.lI_b1Selected;
                Number_select_to_change_contactSelected = oldData.Number_select_to_change_contactSelected;
                AllTapCh = oldData.AllTapCh;
                AllShem = oldData.AllShem;
                // MessageBox.Show($"{oldData.SelectedIndex}");
                // SelectedIndex = oldData.SelectedIndex;               
                //SelectedShema = oldData.SelectedShema;



            }
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
        /// Подтвердить сброс фильтров
        /// </summary>        
        public void ConfirmCleareFilterFunction(object obj)
        {
            OnPropertyChanged();
            IsConfirmCleareFilterTrue = true;
            var mainVM = (Window)obj;
            mainVM.Close();
        }

        /// <summary>
        /// Метод сброса всех фильтров
        /// </summary>
        /// <param name="obj"></param>
        public void ClearInputDataFunctiun(object obj)
        {           
            CleareFilter Filter = new CleareFilter(this);
            Filter.ShowDialog();
            
            if (CleareSmartTable && IsConfirmCleareFilterTrue)
            {              
                #region Сброс фильтров таблицы
                MainVM mainVM = (MainVM)obj;
                MyDtataGridBase = mainVM.MyDtataGridBase;
                MyDtataGridShema = mainVM.MyDtataGridShema;

                MyDtataGridShema.GroupColumnDescriptions.Clear();
                MyDtataGridBase.GroupColumnDescriptions.Clear();
                SelectedShema = "-1";
                SelectedIndex = "-1";
                MyDtataGridShema.SortColumnDescriptions.Clear();
                MyDtataGridBase.SortColumnDescriptions.Clear();
                MyDtataGridShema.ClearFilters();         
                MyDtataGridBase.ClearFilters();
                #endregion

                #region Сброс найденных данных
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
                #endregion
            }

            if (CleareInputData && IsConfirmCleareFilterTrue)
            {

                #region Сброс исходных данных
                MaxCurrent = "";
                Itermal = "";
                Idinamic = "";
                Ust_V = "";
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
                #endregion

                #region Сброс найденных данных
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
                #endregion

                #region Обновить данные из  БД
                try
                {
                    QueryAllTap();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
                #endregion
            }
            IsConfirmCleareFilterTrue = false;
            CleareSmartTable = true;
            CleareInputData = true;
        }

        /// <summary>
        /// Метод обработки запроса в БД
        /// </summary>        
        public DataTable Select(string selectSQL) // функция  обработка запросов
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;//достаем строку подключения из config
            SqlConnection sqlConnection = new SqlConnection(connectionString); // подключаемся к базе данных
            try
            {

                DataTable dataTable = new DataTable("dataTable");// создаём таблицу в приложении

                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();// открываем базу данных  
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
                    sqlCommand.CommandText = selectSQL;                             // присваиваем команде текст
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
                    sqlDataAdapter.Fill(dataTable);                                  // возращаем таблицу с результатом             
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                sqlConnection.Close();
            }
            return AllTapCh;
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

        #region Запросы

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
                            $"CONCAT([Type],' ',Seria,' ',Phaze_number,'-', I_A,' ',Simbol,'/',Um_kV_rms,' ',Izbiratel_value)= '{TapCHname}' "+
                            $"and S_kVA={(SelectedItem==null?(SstSelected):(selectedItem[10]))}");

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

        /// <summary>
        /// Запрос на получение всех испытательных напряжений
        /// </summary>       
        public void QueryAllImpuls(object obj = null)
        {         
            #region Query
            AllImpulseData = Select("USE TAP_CHANGER " +
                                     "Select "+
                                    "[Transformer] "+
                                    ",[U_klass_kV] "+
                                    ",[CLI_kV] "+
                                    ",[LI_kV] "+
                                    ",[One_min_kV] "+
                                    ",[SI_kV] "+
                                    ",[GOST_ISO] "+
                                    ",[LI_kV_RPN] "+
                                    ",[KV50Hz1minRPN] "+
                                    ",[LI_b1] "+
                                    ",[AC_b1] "+
                                    ",[LI_a0] "+
                                    ",[AC_a0] "+
                                    ",[LI_b2] "+
                                    ",[AC_b2] "+
                                    ",TKP_RR1 "+
                                    "FROM[TAP_CHANGER].[dbo].[Impulse]"  );

            #endregion
        }

        #endregion

    }
}
