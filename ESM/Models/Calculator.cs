/// https://wynagrodzenia.pl/artykul/jak-obliczyc-wynagrodzenie-netto
/// Artykuł odnośnie obliczania składek oraz wynagrodzenia
/// ***************
/// 
/// Metoda Calculator do łatwego przeliczania wynagrodzeń pracowników
/// 
/// ***************


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ESM.Models
{
    class Calculator
    {
        // Deklaracja zmiennych kalkulatora

        public bool HomeWorker { get; set; } // czy pracownik miejscowy czy dojezdzajacy - potrzebne do kosztow uzyskania przychodów 
        // true > pracownik miejscowy, false > dojeżdzający
        public double Kup { get; set; } // koszt uzyskania przychodu

        public double Brutto { get; set; } //kwota brutto wynagrodzenia

        public double Netto { get; set; } //kwota netto wynagrodzenia

        public double EmployeeCost { get; set; } //pełny koszt pracodawcy związany z zatrudnieniem pracownika

        // Deklaracja metod

        // Kalkulator obliczający kwotę netto
        public double CalcNetto()  //kalkulator obliczający kwotę netto z podanej kwoty brutto
        {
            //ustalanie zmiennej koszt uzyskania przychodów
            if (HomeWorker == true)
            {
                Kup = 111.25;
            }
            else
            {
                Kup = 139.06;
            }

            double wynik = 0;
            double suSpol = 0; //składki na ubezpieczenie społeczne
            double suZdrow = 0; //składki na ubezpieczenie zdrowotne
            double kwop = 46.33; //kwota wolna od podatku
            double znpd = 0; //zaliczka na podatek dochodowy
            double znpdpo = 0; //zaliczka na podatek dochowowy przed odliczeniem 
            double znpdWlasciwa = 0; //wlasciwa zaliczka na podatek dochodowy

            // poboczne skladki
            double emerytalna = 0;
            double rentowa = 0;
            double chorobowa = 0;

            // obliczenie skladek na ubezpieczenie spoleczne

            emerytalna = Brutto * 0.0976;
            rentowa = Brutto * 0.015;
            chorobowa = Brutto * 0.0245;

            suSpol = (emerytalna + rentowa + chorobowa);

            //obliczanie skladek na obezpieczenia zdrowotne

            suZdrow = (Brutto - suSpol);
            suZdrow *= 0.09;

            //obliczanie zaliczki na podatek dochodowy

            znpd = (Brutto - suSpol - Kup);
            znpd *= 0.18;
            znpd -= kwop;

            //obliczanie zaliczki na podatek dochodowy przed odliczeniem

            znpdpo = (Brutto - suSpol);
            znpdpo *= 0.0775;

            //obliczanie zaliczki własciwej

            znpdWlasciwa = znpd - znpdpo;
            znpdWlasciwa = System.Math.Round(znpdWlasciwa);

            //obliczanie wlasciwego wyniku

            wynik = (Brutto - suSpol - suZdrow - znpdWlasciwa);

            Netto = wynik;

            return wynik;
        }

        public double CalcEmployeeCost() //kalkulator obliczający pełne koszty pracodawcy z podanej kwoty brutto
        {
            double wynik = 0;

            //deklaracja zmiennych

            double emerytalna = 0;
            double rentowa = 0;
            double chorobowa = 0;
            double snfp = 0; //skladka na fundusz pracy
            double fgsp = 0; //składka na FGŚP

            //obliczamy

            emerytalna = Brutto * 0.0976;
            rentowa = Brutto * 0.065;
            chorobowa = Brutto * 0.018;
            snfp = Brutto * 0.0245;
            fgsp = Brutto * 0.001;

            wynik = Brutto + emerytalna + rentowa + chorobowa + snfp + fgsp;

            EmployeeCost = wynik;

            return wynik;
        }
    }


}

