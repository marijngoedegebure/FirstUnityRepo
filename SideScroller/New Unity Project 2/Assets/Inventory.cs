using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	/*
	 * The idea behind this class is to create an inventory which you can cycle through
	 * This inventory will hold the multiple melee and ranged weapons
	 * 
	 */
	
	// TODO: Creating a enum of meleeweapons
	
	// TODO: Creating a enum of rangedweapons
	
	/*
	 * public currentMeleeWeapon = ???
	 * public currentRangedWeapon = ???
	 * List collectedMeleeWeapons
	 * List collectedRangedWeapons
	 */
	
	public enum MeleeWeapons {
		Normal = 1,
		Fire,
		Ice,
		Water		
	};
	
	public enum RangedWeapons {
		None = 1,
		Bow,
		Wand,
		Ninjastar
	};
	
	private ArrayList collectedMeleeWeapons = new ArrayList();
	private ArrayList collectedRangedWeapons = new ArrayList();
	
	public int currentMeleeWeapon = 0;
	public int currentRangedWeapon = 0;
	public int sizeOfCollectedMelee = 0;
	public int sizeOfCollectedRanged = 0;
	
	// Use this for initialization
	void Start () {
		addMeleeWeapon(MeleeWeapons.Normal);
		nextMeleeWeapon();
		addRangedWeapon(RangedWeapons.None);
		nextRangedWeapon();
	}
	
	// Update is called once per frame
	void Update () {
		sizeOfCollectedMelee = collectedMeleeWeapons.Count;
		sizeOfCollectedRanged = collectedRangedWeapons.Count;
	}
	
	// Cycles through the array of melee weapons
	public void nextMeleeWeapon() {
		currentMeleeWeapon = rotateArray(collectedMeleeWeapons,currentMeleeWeapon);	
	}
	
	// Cycles through the array of ranged weapons
	public void nextRangedWeapon() {
		currentRangedWeapon = rotateArray(collectedRangedWeapons,currentRangedWeapon);
	}
	
	private int rotateArray(ArrayList list, int current) {
		if(current+1 > list.Count) {
			return 1;	
		}
		else {
			return current+1;	
		}
	}
	
	/*
	 * Adds a weapon to the CollectedMeleeWeapons list
	 */
	public void addMeleeWeapon(MeleeWeapons item) {
		if(!collectedMeleeWeapons.Contains(item) ) {
			collectedMeleeWeapons.Add(item);
		}
		else {
			Debug.Log ("you allready have this weapon!");	
		}
	}
	
	/*
	 * Adds a weapon to the CollectedRangedWeapons list
	 */
	public void addRangedWeapon(RangedWeapons item) {
		if(!collectedRangedWeapons.Contains(item) ) {
			collectedRangedWeapons.Add(item);
		}
		else {
			Debug.Log ("you allready have this weapon!");	
		}
	}
}
