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
        public static string getFormatedFieldsNames() 
        {
            return "(fname, uid, carbons, fats, proteins, isGround, description, recipe, weightSoFar)";
        }

        /*public static string getFormatedValues(FoodModel fo) 
        {
         /*   Queue<string> q = new Queue<string>();

            //Name;
            string NameS = Utils.UtilS.wrap(fo.Name);
            q.Enqueue(NameS);
            //Uid;
            string UidS = Utils.UtilS.maybeIntToS(fo.Uid);
            q.Enqueue(UidS);

            //carbons;
            string carbonsS = Utils.UtilS.maybeIntToS(fo.Nutrients.Carbons);
            q.Enqueue(carbonsS);

            //fats;
            string fatsS = Utils.UtilS.maybeIntToS(fo.Nutrients.Fats);
            q.Enqueue(fatsS);

            //proteins;
            string proteinsS = Utils.UtilS.maybeIntToS(fo.Nutrients.Proteins);
            q.Enqueue(proteinsS);

            //IsGround;
            string IsGroundS = fo.IsGround.ToString();
            q.Enqueue(IsGroundS);

            //Description;
            string DescriptionS = Utils.UtilS.wrap(fo.Description);
            q.Enqueue(DescriptionS);

            //Recipe;
            string RecipeS = Utils.UtilS.wrap(fo.Recipe);
            q.Enqueue(RecipeS);


            //putting it together
            string record = UtilS.map(q, ", ");
            record = UtilS.wrap("(", record, ")");

            return record;
        }*/


    }
}