using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FaFitu.Models;
using FaFitu.Utils;

namespace FaFitu.DatabaseUtils
{
    public class PrettyPrinterFood
    {
        public static string getFormatedGroundNames() 
        {
            return "(fname, carbons, fats, proteins, description)";
        }

        public static string getFormatedGroundValues(GroundFoodModel fo) 
        {
            Queue<string> q = new Queue<string>();

            //Name;
            string NameS = Utils.UtilS.wrap(fo.Name);
            q.Enqueue(NameS);

            //carbons;
            string carbonsS = Utils.UtilS.maybeIntToS(fo.Nutrients.Carbons);
            q.Enqueue(carbonsS);

            //fats;
            string fatsS = Utils.UtilS.maybeIntToS(fo.Nutrients.Fats);
            q.Enqueue(fatsS);

            //proteins;
            string proteinsS = Utils.UtilS.maybeIntToS(fo.Nutrients.Proteins);
            q.Enqueue(proteinsS);


            //Description;
            string DescriptionS = Utils.UtilS.wrap(fo.Description);
            q.Enqueue(DescriptionS);


            //putting it together
            string record = UtilS.map(q, ", ");
            record = UtilS.wrap("(", record, ")");

            return record;
        }


    }
}