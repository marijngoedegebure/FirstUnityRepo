using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {
	
	enum KindOfPickup {
		FireSword=1,
		IceSword,
		WaterSword,
		Bow,
		Wand,
		NinjaStars
	}
	
	public int kindOf = 1;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate(new Vector3(0,3,0));
	}
	
	void OnTriggerEnter(Collider other) {
		Destroy (this.gameObject);
		Inventory script = (Inventory) GameObject.Find("Dude").GetComponent(typeof (Inventory));
		if(kindOf > 3) {
			if(kindOf-3 == 1) {
				script.addRangedWeapon(Inventory.RangedWeapons.Bow);
			}
			else if(kindOf-3 == 2) {
				script.addRangedWeapon(Inventory.RangedWeapons.Wand);	
			}
			else {
				script.addRangedWeapon(Inventory.RangedWeapons.Ninjastar);	
			}
		}
		else {
			if(kindOf == 1) {
				script.addMeleeWeapon(Inventory.MeleeWeapons.Fire);
			}
			else if(kindOf == 2) {
				script.addMeleeWeapon(Inventory.MeleeWeapons.Ice);	
			}
			else {
				script.addMeleeWeapon(Inventory.MeleeWeapons.Water);	
			}
		}
	}
}
