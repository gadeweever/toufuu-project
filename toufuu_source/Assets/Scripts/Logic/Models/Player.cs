using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	
	// lives: one hit one kill. Set this < 1
	public int lives;
	// speed constant multiplied or added to move the player
	public float speed;
	// Weapon to hold weapon
	public Weapon weaponOne;
	public Weapon weaponTwo;
	public Weapon currentWeapon;
	// power determins how much damage they do
	public float power;
	// Class for specifying the drive associated with the player
	public Drive drive;
	// determines if the player can take damage
	public bool isInvincible;
	// determines if the player is physics incoherent
	public bool isShadowed;
	public int score;
	//input for instantiaing array of fixed size
	public int WeaponNumber;
	
	public Transform shootPosition;
	public Transform bullet;
	// Use this for initialization
	void Start () {
		score = 0;
		isInvincible = false;
		isShadowed = false;
		drive = GetComponent<Drive>();
		power = 0;
		currentWeapon = weaponOne;
	}
	
	// Update is called once per frame
	void Update () {
		MoveUpDown();
		MoveLeftRight();
		Shoot();
	}
	
	public Transform MoveUpDown()
	{
		Vector3 positionnow = transform.position;
		if(Input.GetKey(KeyCode.UpArrow))
		{	
			transform.position = Vector3.Lerp(transform.position, new Vector3(positionnow.x,positionnow.y+1,positionnow.z), speed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(positionnow.x,positionnow.y-1,positionnow.z), speed * Time.deltaTime);
		}
		return this.transform;
			
	}
	public Transform MoveLeftRight()
	{
		Vector3 positionnow = transform.position;
		if(Input.GetKey(KeyCode.LeftArrow))
		{	
			transform.position = Vector3.Lerp(transform.position, new Vector3(positionnow.x-1,positionnow.y,positionnow.z), speed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(positionnow.x+1,positionnow.y,positionnow.z), speed * Time.deltaTime);
		}
		return this.transform;
	}
	
	public void SwtichWeapon()
	{
		if(currentWeapon == weaponOne)
			currentWeapon = weaponTwo;
		else
			currentWeapon = weaponOne;
	}
	
	public void Shoot()
	{
		if(Input.GetKey(KeyCode.A))
		{
			Transform bulletInstance;
			bulletInstance = Instantiate(bullet,shootPosition.position, shootPosition.rotation) as Transform;
			
		}
			
	}
			
		
	
}
