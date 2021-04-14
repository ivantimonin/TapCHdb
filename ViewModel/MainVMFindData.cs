using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TAP_DB.ViewModel
{
    partial class MainVM
    {
        private DataRowView selectedItem;
        public DataRowView SelectedItem
        {
            get { return selectedItem; }
            set
            {               
                selectedItem = value;
                
                if (selectedItem != null)
                {
                    TapCHname = Convert.ToString(selectedItem[0]);
                    MaxCurrentSelected = Convert.ToString(selectedItem[6]);
                    ItermalSelected = Convert.ToString(selectedItem[7]);
                    IdinamiclSelected = Convert.ToString(selectedItem[8]);

                    SstSelected = Convert.ToString(selectedItem[10]);
                    UrmsSelected = Convert.ToString(selectedItem[11]);
                    KV50Hz1minSelected = Convert.ToString(selectedItem[12]);

                    LI_kVSelected = Convert.ToString(selectedItem[14]);

                    LI_a0Selected = Convert.ToString(selectedItem[16]);
                    LI_b1Selected = Convert.ToString(selectedItem[17]);
                    LI_b2Selected = Convert.ToString(selectedItem[18]);

                    AC_a0Selected = Convert.ToString(selectedItem[22]);
                    AC_b1Selected = Convert.ToString(selectedItem[23]);                  
                    AC_b2Selected = Convert.ToString(selectedItem[24]);

                    Number_select_to_revisionsSelected = Convert.ToString(selectedItem[28]);
                    Number_select_to_change_contactSelected = Convert.ToString(selectedItem[29]);
                    Number_select_mechanicalSelected= Convert.ToString(selectedItem[30]);
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Схема переключения
        /// </summary>
        private DataRowView selectedItemShem;
        public DataRowView SelectedItemShem
        {
            get { return selectedItemShem; }
            set
            {
                selectedItemShem = value;

                if (selectedItemShem != null)
                {
                    ShemaСoncretCH = Convert.ToString(selectedItemShem[1]);                                      
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Наименовние схемы для типа РПН
        /// </summary>
        private string shemaСoncretCH;
        public string ShemaСoncretCH
        {
            get
            {
                return shemaСoncretCH;
            }
            set
            {
                shemaСoncretCH = value;               
                OnPropertyChanged();
            }
        }
      

        /// <summary>
        /// Наименовние найденного РПН
        /// </summary>
        private string tapCHname;
        public string TapCHname
        {
            get
            {
                return tapCHname;
            }
            set
            {
                tapCHname = value;
                QueryAllShem();
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Ресурс механической стойкости
        /// </summary>
        private string number_select_mechanicalSelected;
        public string Number_select_mechanicalSelected
        {
            get
            {
                return number_select_mechanicalSelected;
            }
            set
            {
                number_select_mechanicalSelected = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Число переключений до замены контактов
        /// </summary>
        private string number_select_to_change_contactSelected;
        public string Number_select_to_change_contactSelected
        {
            get
            {
                return number_select_to_change_contactSelected;
            }
            set
            {
                number_select_to_change_contactSelected = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Число переключений до ревизии
        /// </summary>
        private string number_select_to_revisionsSelected;
        public string Number_select_to_revisionsSelected
        {
            get
            {
                return number_select_to_revisionsSelected;
            }
            set
            {
                number_select_to_revisionsSelected = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// КПЧ межфазное
        /// </summary>
        private string aC_b2Selected;
        public string AC_b2Selected
        {
            get
            {
                return aC_b2Selected;
            }
            set
            {
                if (selectedItem != null && Convert.ToString(selectedItem[4]) == "I")//если число фаз равно 1 (тогда медуфазного напряжения нет)
                {
                    aC_b2Selected = "-";
                }
                else
                {
                    aC_b2Selected = value;
                }
                OnPropertyChanged();
            }
        }


        private string lI_b2Selected;
        public string LI_b2Selected
        {
            get
            {
                return lI_b2Selected;
            }
            set
            {
                if (selectedItem != null && Convert.ToString(selectedItem[4]) == "I")//если число фаз равно 1 (тогда медуфазного напряжения нет)
                    {
                    lI_b2Selected = "-";
                }
                else
                {
                    lI_b2Selected = value;
                }
                OnPropertyChanged();
            }
        }

        private string aC_a0Selected;
        public string AC_a0Selected
        {
            get
            {
                return aC_a0Selected;
            }
            set
            {
                aC_a0Selected = value;
                OnPropertyChanged();
            }
        }

        private string lI_a0Selected;
        public string LI_a0Selected
        {
            get
            {
                return lI_a0Selected;
            }
            set
            {
                lI_a0Selected = value;
                OnPropertyChanged();
            }
        }

        private string aC_b1Selected;
        public string AC_b1Selected
        {
            get
            {
                return aC_b1Selected;
            }
            set
            {
                aC_b1Selected = value;
                OnPropertyChanged();
            }
        }

        private string kV50Hz1minSelected;
        public string KV50Hz1minSelected
        {
            get
            {
                return kV50Hz1minSelected;
            }
            set
            {
                kV50Hz1minSelected = value;
                OnPropertyChanged();
            }
        }


        private string lI_kVSelected;
        public string LI_kVSelected
        {
            get
            {
                return lI_kVSelected;
            }
            set
            {
                lI_kVSelected = value;
                OnPropertyChanged();
            }
        }

        private string idinamiclSelected;
        public string IdinamiclSelected
        {
            get
            {
                return idinamiclSelected;
            }
            set
            {
                idinamiclSelected = value;
                OnPropertyChanged();
            }
        }

        private string urmsSelected;
        public string UrmsSelected
        {
            get
            {
                return urmsSelected;
            }
            set
            {
                urmsSelected = value;
                OnPropertyChanged();
            }
        }

        private string sstSelected;
        public string SstSelected
        {
            get
            {
                return sstSelected;
            }
            set
            {
                sstSelected = value;
                OnPropertyChanged();
            }            
        }

        /// <summary>
        /// Выбранный рабочий ток
        /// </summary>
        private string maxCurrentSelected;
        public string MaxCurrentSelected
        {
            get
            {
                return maxCurrentSelected;
            }
            set
            {              
                maxCurrentSelected = value;
                OnPropertyChanged();
            }           
        }

        /// <summary>
        /// Ток термической стойкости выбранный
        /// </summary>
        private string itermalSelected;
        public string ItermalSelected
        {
            get
            {
                return itermalSelected;
            }
            set
            {
                itermalSelected = value;
                OnPropertyChanged();
            }
        }

        private string lI_b1Selected;
        public string LI_b1Selected
        {
            get
            {
                return lI_b1Selected;
            }
            set
            {
                lI_b1Selected = value;
                OnPropertyChanged();
            }
        }
    }
}
