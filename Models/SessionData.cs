using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace STEF.Models
{
    public class SessionData
    {

        public static Korisnik user
        {
            get { return (Korisnik)HttpContext.Current.Session["Korisnik"]; }
            set
            {
                HttpContext.Current.Session["Korisnik"] = value;
            }
        }

        public static bool IsAuthenticated
        {
            get
            {
               return HttpContext.Current.Session["Korisnik"]!=null;
               
            }
        }
        public static bool IsAdmin
        {
            get
            {
               Korisnik user = (Korisnik)HttpContext.Current.Session["Korisnik"];
                return user.Ime=="admin";

            }
        }
    }
    }
    