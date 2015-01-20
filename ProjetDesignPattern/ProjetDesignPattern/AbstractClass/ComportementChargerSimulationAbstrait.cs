﻿using System;

namespace ProjetDesignPattern
{
	public abstract class ComportementChargerSimulationAbstrait 
	{

		public abstract void chargerLesPersonnages();
		public abstract void chargerZonePresentParPersonnage();
		public abstract void chargerListeObjervateurParPersonnage();

		public abstract void chargerLesZones();
		public abstract void chargerLesAcces();

		protected FabriqueAbstraite fabrique;
		protected Simulation simulation;

	}
}

