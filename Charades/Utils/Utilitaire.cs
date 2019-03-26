using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Charades.Utils
{
    public static class Utilitaire
    {
        public readonly static List<string> ALPHABET = new List<string> { "A", "Z", "E", "R", "T", "Y", "U", "I", "O", "P", "Q", "S", "D", "F", "G", "H", "J", "K", "L", "M", "W", "X", "C", "V", "B", "N" };



        public static List<string> ToList_OUF(this string param)
        {
            List<string> retrun_var = new List<string>();
            if (!string.IsNullOrWhiteSpace(param))
            {
                for (int i = 0; i < param.Length; i++)
                {
                    retrun_var.Add(param[i].ToString());
                }
            }
            return retrun_var;
        }


        public static List<string> ReplaceWidthWhiteSpace(this List<string> param, string e)
        {
            for(int i = 0; i < param.Count; i++)
            {
                if (param[i].Equals(e))
                {
                    param[i] = "";
                    break;
                }
            }
            return param;
        }

        public static List<string> GetListKeyboard(this string param, string aide)
        {
            Java.Util.Random rnd = new Java.Util.Random();
            List<string> return_var = param.ToList_OUF();
            for(int i = param.Length; i < 12; i++)
            {
                int element = rnd.NextInt(ALPHABET.Count);
                return_var.Add(ALPHABET[element]);
            }

            for (int i = 0; i < aide.Length; i++)
            {
                return_var.ReplaceWidthWhiteSpace(aide[i].ToString());
            }

            return return_var;

        }
    }
}