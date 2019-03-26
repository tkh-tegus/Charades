using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content.PM;
using System.Collections.Generic;
using MesCharades.Models;
using Java.Util;
using System;
using Android.Content;
using Android.Support.V7.App;
using Charades.Utils;
using Android.Gms.Ads;


namespace Charades
{
    [Activity(Label = "Charades", ScreenOrientation = ScreenOrientation.Portrait, Icon = "@mipmap/logo", Theme = "@style/MyTheme")]
    public class MainActivity : AppCompatActivity
    {
        public TextView charade_tv, score_tv, aide_tv, qst_en_cours;
        public List<TextView> grid_reponse= new List<TextView>();
        public List<TextView> grid_clavier = new List<TextView>();
        public StoreEntities db = StoreEntities.Instance;
        public int niveau = 0;
        public int score = 0;
        public string aide = "";
        public CharadeVM charadeEncours;
        public List<string> alphabet = new List<string> { "A", "Z", "E", "R", "T", "Y", "U", "I", "O", "P", "Q", "S", "D", "F", "G", "H", "J", "K", "L", "M", "W", "X", "C", "V", "B", "N" };
        public ISharedPreferences Preference_utilisateur;
        public ISharedPreferencesEditor Preference_utilisateure_editor;
        public InterstitialAd mInterstitialAd;
        public bool IsloadInterstitialAd = false;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            Window.RequestFeature(WindowFeatures.NoTitle);
            SetContentView (Resource.Layout.Main);

            var adRequest = new AdRequest.Builder().Build();
            mInterstitialAd = new InterstitialAd(this);
            mInterstitialAd.AdUnitId = GetString(Resource.String.test_interstitial_ad_unit_id); ;
            mInterstitialAd.AdListener = new AdListener(this);
            

            charade_tv = FindViewById<TextView>(Resource.Id.charade_textView);
            qst_en_cours = FindViewById<TextView>(Resource.Id.qst_en_cours);
            score_tv = FindViewById<TextView>(Resource.Id.score_tv);
            aide_tv = FindViewById<TextView>(Resource.Id.aide_tv);
            aide_tv.Click += (s, e) =>
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                Android.App.AlertDialog alert = dialog.Create();
                alert.SetTitle("Vous avez demandé de l'aide");
                alert.SetMessage("Voulez vous prendre une lettre contre 10 points?");
                //alert.SetIcon(Resource.Drawable.question);
                alert.SetButton("OUI", (c, ev) =>
                {
                    Aide();
                });
                alert.SetButton2("NON", (c, ev) =>
                {
                    //if (mInterstitialAd.IsLoaded)
                    //{
                    //    LoadInterstitialAd();
                    //}

                });
                alert.Show();
            };

            Preference_utilisateur = GetPreferences(FileCreationMode.Private);
            Preference_utilisateure_editor = Preference_utilisateur.Edit();
            niveau = Preference_utilisateur.GetInt("niveau", 0);
            score = Preference_utilisateur.GetInt("score", 0);
            aide = Preference_utilisateur.GetString("aide", "");
           
            initIdGrid();
            CharadeSuivante();

           
        }

        public void LoadInterstitialAd()
        {
            if (mInterstitialAd.IsLoaded)
            {
                IsloadInterstitialAd = false;
                mInterstitialAd.Show();
            }
            else
            {
                IsloadInterstitialAd = true;
            }
        }
        protected override void OnResume()
        {
            base.OnResume();           
            if (!mInterstitialAd.IsLoaded)
            {
                RequestNewInterstitial();
            }
        }

        protected override void OnDestroy()
        {
            if (mInterstitialAd.IsLoaded)
            {
                mInterstitialAd.Show();
            }
            base.OnDestroy();
        }

        protected void RequestNewInterstitial()
        {
            var adRequest = new AdRequest.Builder().Build();
            mInterstitialAd.LoadAd(adRequest);
        }
        class AdListener : Android.Gms.Ads.AdListener
        {
            MainActivity that;

            public AdListener(MainActivity t)
            {
                that = t;
            }

            public override void OnAdClosed()
            {
                that.RequestNewInterstitial(); 
            }
        }


        public bool isJeuFini()
        {
            return niveau >= this.db.Count;
        }

        public void CharadeSuivante()
        {
            if (isJeuFini())
            {
                //var second = new Intent(this, typeof(FinJeuActivity));
                //StartActivity(second);
                niveau = 0;
                score = 0;
                aide = "";
            }
            Preference_utilisateure_editor.PutInt("niveau", niveau);
            Preference_utilisateure_editor.PutInt("score", score);
            Preference_utilisateure_editor.PutString("aide", aide);
            Preference_utilisateure_editor.Apply();
                        
            if((niveau != 0 && niveau % 5 == 0) || IsloadInterstitialAd)
            {
                LoadInterstitialAd();
            }

            updateTextViewPoint();
            this.charadeEncours = db[niveau];
            initVisibilityGridReponse();
            initGridClavier();           
            charade_tv.Text = this.charadeEncours.Charade;  
            qst_en_cours.Text = "Charade " + (niveau + 1);

        }

        public void updateTextViewPoint()
        {
            score_tv.Text = "Score : " + score;
        }

        public void OnClickListerClavier(object sender, EventArgs e)
        {
            var clavier = (TextView)sender;
            if (!string.IsNullOrWhiteSpace(clavier.Text))
            {
                for(int i = 0; i < this.charadeEncours.Reponse.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(this.grid_reponse[i].Text))
                    {
                        this.grid_reponse[i].Text = clavier.Text;
                        clavier.Text = "";
                        break;
                    }
                }
            }
            if (CheckReponse() == 1)
            {
                this.score += 5;
                this.niveau++;
                this.aide = "";

                foreach (var item in grid_reponse)
                {
                    item.SetBackgroundResource(Resource.Drawable.btn_succes);
                }
                //L'application attends 2 secondes avant de passer à la question suivante
                Handler handler = new Handler();
                Action myAction = () =>
                {
                    CharadeSuivante();
                };
                handler.PostDelayed(myAction, 2000);
                
            }
        }

        public void OnClickListerReponse(object sender, EventArgs e)
        {
            var reponse = (TextView)sender;
            if (!string.IsNullOrWhiteSpace(reponse.Text))
            {
                for (int i = 0; i < this.grid_clavier.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(this.grid_clavier[i].Text))
                    {
                        this.grid_clavier[i].Text = reponse.Text;
                        reponse.Text = "";
                        break;
                    }
                }
            }
        }

        public int CheckReponse()
        {
            string val = "";
            for(int i = 0; i < this.charadeEncours.Reponse.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(this.grid_reponse[i].Text))
                {
                    val = val + "" + this.grid_reponse[i].Text;
                }
            }

            if (this.charadeEncours.Reponse.Equals(val))
            {
                return 1;
            }
            return 0;
        }

        public void initGridClavier()
        {
            var liste = charadeEncours.Reponse.GetListKeyboard(aide);
            Java.Util.Random rnd = new Java.Util.Random();
            for (int i = 0; i < grid_clavier.Count; i++)
            {
                int j = rnd.NextInt(liste.Count);
                this.grid_clavier[i].Text = liste[j];
                liste.RemoveAt(j);
            }
        }

        public void initVisibilityGridReponse()
        {
            var liste = aide.ToList_OUF();
            for(int i = 0; i < grid_reponse.Count; i++)
            {
                if(liste.Count > i)
                {
                    grid_reponse[i].Text = liste[i];
                }
                else
                {
                    grid_reponse[i].Text = "";
                }
                grid_reponse[i].SetBackgroundResource(Resource.Drawable.bg_button_black);
               
            }

            for(int i = 0; i < grid_reponse.Count; i++)
            {
                if (i < charadeEncours.Reponse.Length)
                {
                    this.grid_reponse[i].Visibility = ViewStates.Visible;
                }
                else
                {
                    this.grid_reponse[i].Visibility = ViewStates.Gone;
                }
            }
        }

        public void initIdGrid()
        {
            //grid reponse
            this.grid_reponse.Add(FindViewById<TextView>(Resource.Id.reponse_1));
            this.grid_reponse.Add(FindViewById<TextView>(Resource.Id.reponse_2));
            this.grid_reponse.Add(FindViewById<TextView>(Resource.Id.reponse_3));
            this.grid_reponse.Add(FindViewById<TextView>(Resource.Id.reponse_4));
            this.grid_reponse.Add(FindViewById<TextView>(Resource.Id.reponse_5));
            this.grid_reponse.Add(FindViewById<TextView>(Resource.Id.reponse_6));
            this.grid_reponse.Add(FindViewById<TextView>(Resource.Id.reponse_7));
            this.grid_reponse.Add(FindViewById<TextView>(Resource.Id.reponse_8));

            //grid clavier
            this.grid_clavier.Add(FindViewById<TextView>(Resource.Id.clavier_1));
            this.grid_clavier.Add(FindViewById<TextView>(Resource.Id.clavier_2));
            this.grid_clavier.Add(FindViewById<TextView>(Resource.Id.clavier_3));
            this.grid_clavier.Add(FindViewById<TextView>(Resource.Id.clavier_4));
            this.grid_clavier.Add(FindViewById<TextView>(Resource.Id.clavier_5));
            this.grid_clavier.Add(FindViewById<TextView>(Resource.Id.clavier_6));
            this.grid_clavier.Add(FindViewById<TextView>(Resource.Id.clavier_7));
            this.grid_clavier.Add(FindViewById<TextView>(Resource.Id.clavier_8));
            this.grid_clavier.Add(FindViewById<TextView>(Resource.Id.clavier_9));
            this.grid_clavier.Add(FindViewById<TextView>(Resource.Id.clavier_10));
            this.grid_clavier.Add(FindViewById<TextView>(Resource.Id.clavier_11));
            this.grid_clavier.Add(FindViewById<TextView>(Resource.Id.clavier_12));

            this.grid_reponse[0].Click += OnClickListerReponse;
            this.grid_reponse[1].Click += OnClickListerReponse;
            this.grid_reponse[2].Click += OnClickListerReponse;
            this.grid_reponse[3].Click += OnClickListerReponse;
            this.grid_reponse[4].Click += OnClickListerReponse;
            this.grid_reponse[5].Click += OnClickListerReponse;
            this.grid_reponse[6].Click += OnClickListerReponse;
            this.grid_reponse[7].Click += OnClickListerReponse;

            this.grid_clavier[0].Click += OnClickListerClavier;
            this.grid_clavier[1].Click += OnClickListerClavier;
            this.grid_clavier[2].Click += OnClickListerClavier;
            this.grid_clavier[3].Click += OnClickListerClavier;
            this.grid_clavier[4].Click += OnClickListerClavier;
            this.grid_clavier[5].Click += OnClickListerClavier;
            this.grid_clavier[6].Click += OnClickListerClavier;
            this.grid_clavier[7].Click += OnClickListerClavier;
            this.grid_clavier[8].Click += OnClickListerClavier;
            this.grid_clavier[9].Click += OnClickListerClavier;
            this.grid_clavier[10].Click += OnClickListerClavier;
            this.grid_clavier[11].Click += OnClickListerClavier;


        }

        public void Aide()
        {
            if(score >= 10)
            {
                string val = "";
                for (int i = 0; i < this.grid_reponse.Count; i++)
                {
                    if (string.IsNullOrWhiteSpace(this.grid_reponse[i].Text))
                    {
                        val = this.charadeEncours.Reponse[i].ToString();
                        this.grid_reponse[i].Text = val;
                        break;
                    }
                }
                for(int i = 0; i < this.grid_clavier.Count; i++)
                {
                    if (this.grid_clavier[i].Text.Equals(val))
                    {
                        this.grid_clavier[i].Text = "";
                        break;
                    }
                }
                score = score - 10;
                aide = aide + "" + val;
                Preference_utilisateure_editor.PutInt("score", score);
                Preference_utilisateure_editor.PutString("aide", aide);
                Preference_utilisateure_editor.Apply();
                updateTextViewPoint();
                if (CheckReponse() == 1)
                {
                    this.score += 5;
                    this.niveau++;
                    this.aide = "";
                    foreach (var item in grid_reponse)
                    {
                        item.Text = "";
                        item.SetBackgroundResource(Resource.Drawable.btn_succes);
                    }
                    //L'application attends 2 secondes avant de passer à la question suivante
                    Handler handler = new Handler();
                    Action myAction = () =>
                    {
                        CharadeSuivante();
                    };
                    handler.PostDelayed(myAction, 2000);

                }
            }
            else
            {
                Toast.MakeText(this, "Vous n'avez pas assez de point pour soliciter de l'aide", ToastLength.Long).Show();
            }
        }
    }
}

