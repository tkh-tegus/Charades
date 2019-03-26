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

namespace Charades
{
    public class Fin_Jeu
    {
        public static void showDialog(MainActivity activity)
        {
            Dialog dialog = new Dialog(activity);
            //dialog.RequestWindowFeature(WindowFeatures.NoTitle);
            dialog.SetContentView(Resource.Layout.Fin);

            dialog.Show();

        }
    }
}