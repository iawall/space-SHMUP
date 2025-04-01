 using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
/// <summary> 
/// This is an enum of the various possible weapon types. 
/// It also includes a "shield" type to allow a shield power-up. 
/// Items marked [NI] below are Not Implemented in the IGDPD book. 
/// </summary> 
public enum WeaponType { 
none,       
// The default / no weapon 
blaster,    
spread,     
phaser,     
missile,    
laser,      
shield      
} 
// A simple blaster 
// Two shots simultaneously 
// [NI] Shots that move in waves 
// [NI] Homing missiles 
// [NI]Damage over time 
// Raise shieldLevel 

[System.Serializable]                                                         //

public class WeaponDefinition{                                                //

    public WeaponType   type = WeaponType.none; 
    public string       letter;                // Letter to show on the power-up
    public Color        color = Color.white;       // Color of Collar & power-up
    public GameObject   projectilePrefab;          // Prefab for projectiles 
    public Color        projectileColor = Color.white; 
    public float        damageOnHit = 0;           // Amount of damage caused 
    public float        continuousDamage = 0;      // Damage per second (Laser) 
    public float        delayBetweenShots = 0; 
    public float        velocity = 20;             // Speed of projectiles 
} 
public class Weapon : MonoBehaviour {          
// The Weapon class will be filled in later in the chapter. 
} 