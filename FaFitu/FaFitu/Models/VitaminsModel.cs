using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FaFitu.Models
{
    public class VitaminsModel
    {
        public enum VitaminsNames
        {
            C, D, E
        }

        public Dictionary<VitaminsNames, double> Quantities;

        public VitaminsModel(Dictionary<VitaminsNames, double> quantities)
        {
            Quantities = new Dictionary<VitaminsNames, double>();
            foreach(VitaminsNames vit in (VitaminsNames[]) Enum.GetValues(typeof(VitaminsNames)))
            {
                if(quantities.ContainsKey(vit))
                {
                    Quantities[vit] = quantities[vit];
                }
                else
                {
                    Quantities[vit] = 0.0;
                }
            }
        }

        public static VitaminsModel OfMany(IEnumerable<VitaminsModel> vits)
        {
            Dictionary<VitaminsNames, double> quants = new Dictionary<VitaminsNames, double>();
            foreach (VitaminsNames vit in (VitaminsNames[])Enum.GetValues(typeof(VitaminsNames)))
            {
                quants[vit] = vits.Sum(v => v.Quantities[vit]);
            }
            return new VitaminsModel(quants);
        }
    }
}