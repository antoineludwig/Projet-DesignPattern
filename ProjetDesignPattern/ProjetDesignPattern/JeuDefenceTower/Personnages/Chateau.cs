﻿using ProjetDesignPattern.JeuDefenceTower.Etat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetDesignPattern.JeuDefenceTower
{

    public class Chateau : PersonnageAbstrait
    {
        public int ptAttaque;
        private bool mort = false;
        public int dégatsreçus = 0;
        public int nbBallesTotal;
        public int nbBallesCourant = 0;
        public EtatAbstraitDT etatTir;

        public Chateau(string _nom, int _pv, int _atq)
        {
            PV=_pv;
            Nom = _nom;
            ptAttaque = _atq;
            /*comportementSeDeplacer = new ComportementSeDeplacerAPiedDT();
            comportementCombattre = new ComportementCombattreDT();
            comporterSeDefendre = new ComportementSeDefendreDT();*/
            Position = new ZoneDT();
            Position.positionX = 10;
            Position.positionY = 10;
            etatTir= new EChargeurNonVide(this);
            nbBallesTotal = 10;
        }

        public Chateau(string _nom)
        {
            Nom = Nom;
            /*comportementSeDeplacer = new ComportementSeDeplacerAPiedDT();
            comportementCombattre = new ComportementCombattreDT();
            comporterSeDefendre = new ComportementSeDefendreDT();*/
            Position = new ZoneDT();
            Position.positionX = 10;
            Position.positionY = 10;
            etatTir = new EChargeurNonVide(this);
            nbBallesTotal = 10;
        }

        public void initChateau(int _pv, int _atq,int nbballes)
        {
            PV = _pv;
            ptAttaque = _atq;
            nbBallesTotal = nbballes;
            nbBallesCourant = nbBallesTotal;
        }

        public override void AnalyserSituation()
        {
            //est-tu mort
            if (PV == 0) mort = true;
            //a tu pris un dégât -> défini à l'attaque des ennemis
        }

        public override void Execution()
        {

            //si tu es mort -> game over
            if (mort) MessageBox.Show("Château détruit");
            //if (mort) -> lance la fin du jeu
            //si tu t'es pris un dégât -> baisse tes points de vie
            if (dégatsreçus > 0)
            {
                PV -= dégatsreçus;

                dégatsreçus = 0;
            }
            //si sort : change d'état le tire
            
        }

        public override void MiseAJour()
        {
            
        }

        public int Tirer()
        {
            return etatTir.Tirer();
        }

        public void Recharger()
        {
            etatTir = new ERechargement(this);
            for (int i = 0; i < nbBallesTotal; i++)
            {
                System.Threading.Thread.Sleep(100);
                nbBallesCourant++;
            }
            etatTir = new EChargeurNonVide(this);
        }
    }
}

//CHATEAU
//1. Propagation des informations générales
//2. Propagation des ordres (ne plus bouger, sans ordre….) – propagation hiérarchique
//lancement d'un sort
//Attaque ennemi
//3. Pour chaque personnage : AnalyseSituation()     
//est-tu mort
//a tu pris un dégât

//4. Pour chaque personnage : Execution()
//si tu es mort -> game over
//si tu t'es pris un dégât -> baisse tes points de vie
//si tu a cliquer sur un ennemi -> attaque
//si sort : change d'état le tire

//5. Pour chaque Conflit : Médiation des conflits()
//6. Pour chaque objet : MiseAJour()
//7. RécupérerInformations() + CalculStatistique()
//si degat -> incremente nb degat reçu
//enleve les pv du château si il en à perdu
//8. Affichage
//actualisation de l'affichage (changement du nb de point de vie visible du château + sort)
