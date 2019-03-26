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

namespace MesCharades.Models
{
    public  class StoreEntities : List<CharadeVM>
    {
        private static StoreEntities instance;
        private StoreEntities() { }

        public static StoreEntities Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StoreEntities();
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est un déterminant possessif. Mon deuxième est utilisé pour écrire sur un tableau. Si on dévoile mon tout il n'existe plus",
                        Reponse = "SECRET",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est un oiseau plutôt bavard. mon deuxième est la onzième lettre de l'alphabet. mon troisième sert à transporter beaucoup d'eau. mon tout est un peintre très célèbre",
                        Reponse = "PICASSO",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est difficile a trouver dans le dessert. Mon deuxième se fait toujours a l'école primaire. Mon troisième est aimer par les enfants et les ados. mon tout est un fruit",
                        Reponse = "ORANGE",
                    });
                    
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est un insecte qui vit dans les cheveux. Mon deuxième est le contraire de laide. On passe avec un camion pour vider mon tout",
                        Reponse = "POUBELLE",
                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est la première lettre de l’alphabet. Mon deuxième est le contraire de dur. Mon troisième est la 18e lettre de l’alphabet. Mon tout est un mot doux",
                        Reponse = "AMOUR",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est le féminin de canard. Mon deuxième est la 1ere lettre de l'alphabet. Mon troisième est un oui russe. Mon tout est un pays d'Amérique.",
                        Reponse = "CANADA",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier sert à couper du bois. Mon deuxième est la 2e syllabe d'égal. Mon troisième est un déterminant masculin singulier. Mon tout est le héros d'une célèbre fable",
                        Reponse = "CIGALE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier se trouve dans une année. Mon second est un animal de la savane. Mon tout est une généralité",
                        Reponse = "MOYENNE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est l'abréviation d'une forme de société. Mon deuxième est une préposition. Mon troisième est un dieu égyptien. Mon tout un lieu d'Afrique",
                        Reponse = "SAHARA",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier s'affiche sur un tableau dans un stade de football. Mon deuxième est un objet utilisé dans le jeu de dames. Mon tout est un insecte symbole d'un signe astrologique",
                        Reponse = "SCORPION",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est le temps mis par la Terre pour accomplir une révolution autour du Soleil. Mon deuxième est l'admirateur d'une star. Mon troisième est un adjectif démonstratif. Mon tout est une partie de la vie qui passe très vite",
                        Reponse = "ENFANCE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est un instrument de musique à vent. Mon second est le contraire de laid. Mon tout est un oiseau noir",
                        Reponse = "CORBEAU",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier transporte des passagers. On mange sur mon deuxième. On amène mon tout à l’école",
                        Reponse = "CARTABLE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est la première lettre de l'alphabet. Mon second désigne l'argent en langage familier. Mon tout est un continent",
                        Reponse = "AFRIQUE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est un oiseau bavard. Mon second est une note de musique. Mon troisième se trouve au milieu du visage. Mon tout est un massif montagneux.",
                        Reponse = "PYRENEES",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon 1er se trouve sur le visage des personne âgées. Mon 2nd est une boisson. Mon tout est un tissus",
                        Reponse = "RIDEAU",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est un animal que l'on dit voleur. Mon second est un outil qui coupe le bois. Mon troisième est une négation. Mon tout est aimé par les enfants en été.",
                        Reponse = "PISCINE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est le verbe avoir conjugué au présent à la troisième personne du singulier. Mon deuxième est le feminin de roi. Les combats de gladiateur avaient lieu dans mon tout. ",
                        Reponse = "ARENE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est une céréale. Mon second garde les buts. Mon troisième est une voyelle. Mon quatrième est un chiffre pair. Mon tout arrive après une histoire drôle.",
                        Reponse = "RIGOLADE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier n'est pas beau. Mon deuxième est une autre façon de dire personnes. Mon troisième est le résultat de 1 + 1. Mon tout désigne une histoire imaginaire",
                        Reponse = "LEGENDE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est la mamelle de la vache. Mon deuxième vit dans les égouts. Mon troisième est la troisième note de la gamme de musique. Mon quatrième est la moitié de quatre. Mon tout est en Égypte.",
                        Reponse = "PYRAMIDE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier ne dit pas la vérité. Il faut être mon deuxième pour former une paire. Mon troisième est une note de musique. Mon tout est un homme d'État sud-africain",
                        Reponse = "MANDELA",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est une syllabe de jamais. Mon deuxième permet de traverser un fleuve. Mon tout est un pays d'Asie",
                        Reponse = "JAPON",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est chassé par le chien. Mon second est chassé par le chat. Mon troisième est le résultat de quatre moins deux. Mon tout est ce jeux",
                        Reponse = "CHARADE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier s'obtient en pressant un fruit. Mon second est rouge, blanc ou rosé. Mon troisième est un pronom personnel sujet. Mon quatrième est le son du serpent qui siffle sur nos têtes. Mon tout est une célèbre équipe de football Italienne",
                        Reponse = "JUVENTUS",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "On pousse mon premier quand on a peur. Sur mon second, on attend le train. Mon tout est un insecte bon sauteur",
                        Reponse = "CRIQUET",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "On se sert de mon premier pour couper le bois. Mon deuxiéme couvre la maison. Mon troisième est un mammifère qui se nourrit de charognes. Mon tout est un individu considéré du point de vue de ses droits politiques.",
                        Reponse = "CITOYEN",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Les chiens rapportent parfois mon premier. Mon second est utiliser pas les chasseurs en Afrique. Mon tout est un symbole de la justice",
                        Reponse = "BALANCE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier, nul n'est censé l'ignorer. On dit de second qu'il est la vie. Mon troisième est un boisson chaude. Mon tout est la fidélité et le dévouement envers une cause ou une personne",
                        Reponse = "LOYAUTE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est une portion. Mon deuxième est l'action de donner. Mon tout est le réseultat de l'acte pardonner, la rémission d'une faute.",
                        Reponse = "PARDON",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier s’allonge chez Pinocchio. Mon deuxième n’est pas habillé. Mon troisième permet de rouler la nuit. Mon tout est une fleur qui s’épanouit dans l’eau",
                        Reponse = "NENUPHAR",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est un oiseau dit voleur. Mon deuxième est un animal aux longues oreilles. Mon troisième est la 15ème lettre de l’alphabet. Mon tout est aimé par Mozart",
                        Reponse = "PIANO",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est un animal domestique. Mon second est le contraire de tard. Mon tout est une construction destinée à protéger les seigneurs",
                        Reponse = "CHATEAU",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier sert à couper le bois. Mon deuxième est au milieu de la figure. Mon troisième est sur un bateau. Mon tout est une activité de loisirs.",
                        Reponse = "CINEMA",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier fait le lien entre toujours et jamais. Mon deuxième se dit d'un corps qui repose à terre. Mon troisième est la 16 lettre de l'alphabet. Mon quatrième est un pronom personnel. Mon tout est un pays d'Afrique",
                        Reponse = "EGYPTE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est la première lettre de l'alphabet. Mon deuxième est ce que fait le roi. Mon troisième est à la fin du mot année. Mon tout est un insecte à plusieurs pattes",
                        Reponse = "ARAIGNEE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est le début du mot Marie. Mon deuxième se mange beaucoup en Chine. Mon troisième est le nombre d’années que tu as. Mon tout est un jour heureux",
                        Reponse = "MARIAGE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est la première lettre de l'alphabet. Mon second est la maison des oiseaux. Mon troisième est le contraire de femelle. Mon tout est un synonyme d’une bête.",
                        Reponse = "ANIMAL",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier arrive lorsque la guerre est finie. Mon second fait sans arrêt des tours. Mon tout est un pays d’Amérique latine",
                        Reponse = "PEROU",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon tout est un pays d’Amérique latine. Mon tout est un pays d’Amérique latine. Mon tout est une plante",
                        Reponse = "RADIS",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est la troisième lettre de l'alphabet. Mon deuxième est au milieu de la figure. Mon troisième est une maladie. Mon tout est un pays d'Afrique",
                        Reponse = "SENEGAL",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est la 3ème voyelle de l'alphabet. Mon deuxième est le bruit du serpent. De tuile ou d'ardoise, mon troisième couvre la maison. Mon quatrième est un préfixe signifiant faire une nouvelle fois. Mon tout désigne un récit.",
                        Reponse = "HISTOIRE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est ce qu'on attend d'un bébé après manger. Mon second est le contraire de laid. Mon tout est bourré d’électronique.",
                        Reponse = "ROBOT",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier ne sent pas bon. Mon deuxième se trouve au milieu de la figure. Mon troisième est le en anglais. Mon tout est un insecte",
                        Reponse = "PUNAISE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est porté par les filles. Mon second est la neuvième lettre de l'alphabet. Mon troisième à la troisième planète à partir du soleil. Mon tout est une cousine de mon troisième",
                        Reponse = "JUPITER",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est la manifestation d’une maladie ou d’un problème chez une personne. Mon deuxième est un pronom. Mon troisième est une couleur de cheveux. Mon quatrième est la 14 lettre de l'alphabet. Mon tout est un pays d'Afrique",
                        Reponse = "CAMEROUN",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est un oiseau bavard. Mon deuxième est un rongeur. Mon troisième est la 14ème lettre de l'alphabet. Mon quatrième est la carte la plus forte. Mon tout est un poisson dangereux.",
                        Reponse = "PIRANHA",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est égal à 3,1415. Mon deuxième vit dans les égouts. Mon troisième est un pronom personnel complément, de la deuxième personne du singulier. Mon tout est redouté en mer",
                        Reponse = "PIRATE",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est une syllabe du mot qui désigne une noix de palmier. Mon second est ce que tu remets au gagnant d’une loterie. Mon troisième est un rongeur un peu plus gros qu’une souris. C’est dans mon quatrième qu'est située ma colonne vertébrale. Mon tout est un État des États-Unis.",
                        Reponse = "COLORADO",

                    });
                    instance.Add(new CharadeVM
                    {
                        Charade = "Mon premier est une planète. Mon deuxième est à l’intérieur du pain. Mon troisième est la lettre qui suit le s dans l’alphabet. Mon tout commet des dégâts dans les constructions.",
                        Reponse = "TERMITE",

                    });
                    //instance.Add(new CharadeVM
                    //{
                    //    Charade = "",
                    //    Reponse = "ARENE",

                    //});
                    //instance.Add(new CharadeVM
                    //{
                    //    Charade = "",
                    //    Reponse = "ARENE",

                    //});
                    //instance.Add(new CharadeVM
                    //{
                    //    Charade = "",
                    //    Reponse = "ARENE",

                    //});
                }
                return instance;
            }
        }
    }
}