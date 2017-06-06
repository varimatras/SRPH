﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SRPH
{
    /// <summary>
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    public partial class ReservationWindow : Window
    {
        public bool compatibilityForm { get; set; }
        public ReservationWindow(int ResNumber)
        {
            InitializeComponent();
            //wywowałąc metoda ładującą dane z bazy danych

        }

        public ReservationWindow()
        {
            InitializeComponent();

        }
        DateTime DatePickerFrom()
        {
            DateTime DateFrom = new DateTime();
            DateTime? Date = DP_DateFrom.SelectedDate;
            if (Date == null)
            {
                compatibilityForm = false;
                //brak daty
            }
            else
            {
                DateFrom = Date.Value.Date;
            }
            return DateFrom;
        }
        DateTime DatePickerTo()
        {
            DateTime DateTo = new DateTime();
            DateTime? Date = DP_DateTo.SelectedDate;
            if (Date == null)
            {
                compatibilityForm = false;
                //brak daty
            }
            else
            {
                DateTo = Date.Value.Date;
            }
            return DateTo;
        }
        string GetName()
        {
            string Name = TB_Name.Text;
            if (Name == string.Empty)
            {
                compatibilityForm = false;
            }

            return Name;
        }
        string GetSurName()
        {
            string SurName = TB_SurName.Text;
            if (SurName == string.Empty)
            {
                compatibilityForm = false;
            }

            return SurName;
        }
        string GetPesel()
        {
            string Pesel = TB_Pesel.Text;
            if (Pesel == string.Empty)
            {
                compatibilityForm = false;
            }

            return Pesel;
        }
        int GetPhoneNumber()
        {
            int PhoneNumber;
            bool result = Int32.TryParse(TB_PhoneNumber.Text, out PhoneNumber);
            if (PhoneNumber == 0 || result == false)
            {
                compatibilityForm = false;
            }

            return PhoneNumber;
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            compatibilityForm = true;

            DateTime DataOd = DatePickerFrom();
            DateTime DataDo = DatePickerTo();
            if (DataOd > DataDo)
            {
                compatibilityForm = false;
            }
            string Imie = GetName();
            string Nazwisko = GetSurName();
            string Pesel = GetPesel();
            int Telefon = GetPhoneNumber();
            if (compatibilityForm == true)
            {
                //TODO zapis do bazy
                MessageBox.Show("Zapisano!");
            }
            else
            {
                MessageBox.Show("Popraw bo z dupy masz te dane!");
            }
            //TODO sprawdzenie poprawnosci i zapis do bazy
        }
        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
