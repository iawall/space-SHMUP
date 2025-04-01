
 using System.Collections;          // Required for Arrays & other Collections
 using System.Collections.Generic;  // Required for Lists and Dictionaries
 using UnityEngine;                 // Required for Unity
 public class Enemy : MonoBehaviour {
    [Header("Set in Inspector: Enemy")]
    public float      speed = 10f;      // The speed in m/s
    public float      fireRate = 0.3f;  // Seconds/shot (Unused)
    public float      health = 10;
    public int         score = 100;      // Points earned for destroying this
    // This is a Property: A method that acts like a field
     public float      showDamageDuration = 0.1f; // # seconds to show damage //a
    [Header("Set Dynamically: Enemy")]
    public Color[]    originalColors;
    public Material[] materials;// All the Materials of this & its children

    public bool       showingDamage = false;
    public float      damageDoneTime; // Time to stop showing damage
    public bool       notifiedOfDestruction = false;



    protected BoundsCheck bndCheck;
    void Awake()
    {
     bndCheck = GetComponent<BoundsCheck>();  
     materials = Utils.GetAllMaterials( gameObject ); 
      originalColors = new Color[materials.Length];
        for (int i=0; i<materials.Length; i++) {
            originalColors[i] = materials[i].color;
        }
    }
    public Vector3 pos {                                                     //
 
        get {
            return( this.transform.position );
        }
        set {
            this.transform.position = value;
        }
    }
    void Update() {
        Move();
        if ( showingDamage && Time.time > damageDoneTime ) {                 //c
            UnShowDamage();
        }
         if ( bndCheck != null && bndCheck.offDown ) 
         {                    //
            // Check to make sure it's gone off the bottom of the screen
                   //
 
                // We're off the bottom, so destroy this GameObject
                Destroy( gameObject );
         }
            
        
        
 }
 //
 public virtual void Move() {                                             
Vector3 tempPos = pos;
 tempPos.y -= speed * Time.deltaTime;
 pos = tempPos;
 }



 void OnCollisionEnter( Collision coll ) {                                //a
        GameObject otherGO = coll.gameObject;
        switch (otherGO.tag) {
            case "ProjectileHero":                                           //b
                Projectile p = otherGO.GetComponent<Projectile>();
                
                // If this Enemy is off screen, don't damage it.
                if ( !bndCheck.isOnScreen ) {                                //c
                    Destroy( otherGO );
                    break;
                }
                // Hurt this Enemy
                ShowDamage();
                // Get the damage amount from the Main WEAP_DICT.
                health -= Main.GetWeaponDefinition(p.type).damageOnHit;
                if (health <= 0) {                                           //d
                    // Destroy this Enemy
                    Destroy(this.gameObject);
                }
                Destroy( otherGO );                                          //e
                break;
            default:
                print( "Enemy hit by non-ProjectileHero: " + otherGO.name ); //f
                break;
        }

 }
         void ShowDamage() {                                                      //e
        foreach (Material m in materials) {
            m.color = Color.red;
        }
        showingDamage = true;
 
        damageDoneTime = Time.time + showDamageDuration;
    }

    void UnShowDamage() {                                                    //f
        for ( int i=0; i<materials.Length; i++ ) {
            materials[i].color = originalColors[i];
        }
        showingDamage = false;
    }





    }



 