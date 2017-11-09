using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scoring_MGDP.ViewModel
{
    public class YesNoViewModel
    {
        public YesNoViewModel(string id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public String Id { get; set; }
        public String Nombre { get; set; }

        public static List<YesNoViewModel> GetYesNoList()
        {
            var yesNoList = new List<YesNoViewModel>();
            yesNoList.Add(new YesNoViewModel("S", "Sí"));
            yesNoList.Add(new YesNoViewModel("N", "No"));

            return yesNoList;
        }
    }
}