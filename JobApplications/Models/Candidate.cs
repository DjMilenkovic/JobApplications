using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobApplications.Models
{
    public class Candidate
    {
        private string ime;
        private string prezime;
        private int? zeljena_plata;
        private int godine_iskustva;
        private DateTime datum_prijave;

        public int? Zeljena_Plata
        {
            get { return zeljena_plata; }
            set { zeljena_plata = value; }
        }

        public string Ime { get { return ime; } }
        public string Prezime { get { return prezime; } }
        public int Godine_Iskustva { get { return godine_iskustva; } }
        public DateTime Datum_Prijave { get { return datum_prijave; } }

        public Candidate(string ime, string prezime, int godine_iskustva)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.godine_iskustva = godine_iskustva;

            //  "Central Europe Standard Time"
            string timeZone = TimeZone.CurrentTimeZone.StandardName;           
            datum_prijave = TimeZoneInfo.ConvertTime(DateTime.Now,
                 TimeZoneInfo.FindSystemTimeZoneById(timeZone));
        }
        
        public string IspisPodataka()
        {
            string ispisiPodatke = string.Empty;
            if (Zeljena_Plata != null)
            {
                ispisiPodatke = string.Format("Dana {0} prijavu za posao poslao je {1} {2} i njegova željena plata je {3} RSD", datum_prijave, ime, prezime, zeljena_plata);
            }
            else
            {
                ispisiPodatke = string.Format("Dana {0} prijavu za posao poslao je {1} {2} ali nije želeo da se izjasni koja mu je željena plata", datum_prijave, ime, prezime);
            }
            return ispisiPodatke;
        }
    }
}