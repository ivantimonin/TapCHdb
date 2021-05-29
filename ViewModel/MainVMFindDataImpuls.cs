using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAP_DB.ViewModel
{
    partial class MainVM
    {
        /// <summary>
        /// Выбранная строка в таблице с РПН
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
    }
}
