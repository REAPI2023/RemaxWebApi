using RemaxWebAPI.Models;

namespace RemaxWebApi.Models
{
    public class APIModel
    {
        private Leads leads;

        public Leads Leads
        {
            get { return leads; }
            set { 
                leads = value; 
            }
        }

        public CodeTypes CodeTypes { get; set; }
    }
}
