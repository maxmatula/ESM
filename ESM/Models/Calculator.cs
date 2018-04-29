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
    public class Calculator
    {

        public string HomeWorker { get; set; } // czy pracownik miejscowy czy dojezdzajacy - potrzebne do kosztow uzyskania przychodów 
        public decimal Kup { get; set; }      // koszt uzyskania przychodu
        public decimal Brutto { get; set; }   //kwota brutto wynagrodzenia
        public decimal Netto { get; set; }    //kwota netto wynagrodzenia
        public decimal EmployeeCost { get; set; } //pełny koszt pracodawcy związany z zatrudnieniem pracownika
        public decimal CalcNetto()  //kalkulator obliczający kwotę netto z podanej kwoty brutto
        {

            if (HomeWorker == "Tak")
            {
                Kup = 111.25M;
            }
            else
            {
                Kup = 139.06M;
            }

            decimal wynik = 0;
            decimal suSpol = 0; //składki na ubezpieczenie społeczne
            decimal suZdrow = 0; //składki na ubezpieczenie zdrowotne
            decimal kwop = 46.33M; //kwota wolna od podatku
            decimal znpd = 0; //zaliczka na podatek dochodowy
            decimal znpdpo = 0; //zaliczka na podatek dochowowy przed odliczeniem 
            decimal znpdWlasciwa = 0; //wlasciwa zaliczka na podatek dochodowy

            // poboczne skladki
            decimal emerytalna = 0;
            decimal rentowa = 0;
            decimal chorobowa = 0;

            // obliczenie skladek na ubezpieczenie spoleczne
            emerytalna = Brutto * 0.0976M;
            rentowa = Brutto * 0.015M;
            chorobowa = Brutto * 0.0245M;
            suSpol = (emerytalna + rentowa + chorobowa);

            //obliczanie skladek na obezpieczenia zdrowotne
            suZdrow = (Brutto - suSpol);
            suZdrow *= 0.09M;

            //obliczanie zaliczki na podatek dochodowy
            znpd = (Brutto - suSpol - Kup);
            znpd *= 0.18M;
            znpd -= kwop;

            //obliczanie zaliczki na podatek dochodowy przed odliczeniem
            znpdpo = (Brutto - suSpol);
            znpdpo *= 0.0775M;

            //obliczanie zaliczki własciwej
            znpdWlasciwa = znpd - znpdpo;
            znpdWlasciwa = System.Math.Round(znpdWlasciwa);

            //obliczanie wlasciwego wyniku
            wynik = (Brutto - suSpol - suZdrow - znpdWlasciwa);
            Netto = wynik;
            return Math.Round(wynik, 2);
        }

        public decimal CalcEmployeeCost()
        {
            decimal wynik = 0;
            decimal emerytalna = 0;
            decimal rentowa = 0;
            decimal chorobowa = 0;
            decimal snfp = 0; //skladka na fundusz pracy
            decimal fgsp = 0; //składka na FGŚP

            emerytalna = Brutto * 0.0976M;
            rentowa = Brutto * 0.065M;
            chorobowa = Brutto * 0.018M;
            snfp = Brutto * 0.0245M;
            fgsp = Brutto * 0.001M;

            wynik = Brutto + emerytalna + rentowa + chorobowa + snfp + fgsp;
            EmployeeCost = wynik;
            return Math.Round(wynik, 2);
        }
    }


}

