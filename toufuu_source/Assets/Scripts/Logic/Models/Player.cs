using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //wiimote this player is using
    public WiiURemote myRemote;
    //number of player (1-4)
    public int playerNum;
	// lives: one hit one kill. Set this < 1
	public int lives;
	// speed constant multiplied or added to move the player
	public float speed;
	// Weapon to hold weapon
	public Weapon weaponOne;
	public Weapon weaponTwo;
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
	}
	
	// Update is called once per frame
	void Update () {
		MoveUpDown();
		MoveLeftRight();
		Shoot();
	}
	
	public Transform MoveUpDown()
	{

        myRemote = WiiUInput.GetRemote((uint)playerNum);
        Vector3 positionnow = transform.position;

        if (myRemote.GetButton(WiiUButton.ButtonRight))//up on flipped d-pad
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(positionnow.x,positionnow.y+1,positionnow.z), speed * Time.deltaTime);
		}
        else if (myRemote.GetButton(WiiUButton.ButtonLeft))//down on flipped d-pad
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(positionnow.x,positionnow.y-1,positionnow.z), speed * Time.deltaTime);
		}
		return this.transform;
			
	}
	public Transform MoveLeftRight()
	{
		Vector3 positionnow = transform.position;
        if (myRemote.GetButton(WiiUButton.ButtonUp))//left on flipped d-pad
		{	
			transform.position = Vector3.Lerp(transform.position, new Vector3(positionnow.x-1,positionnow.y,positionnow.z), speed * Time.deltaTime);
		}
        else if (myRemote.GetButton(WiiUButton.ButtonDown))
		{
			transform.position = Vector3.Lerp(transform.position, new Vector3(positionnow.x+1,positionnow.y,positionnow.z), speed * Time.deltaTime);
		}
		return this.transform;
	}
	
	public void Shoot()
	{
        if (myRemote.GetButton(WiiUButton.Button2)) //2=A=weapon 1
		{
			//Transform bulletInstance;
			//bulletInstance = Instantiate(bullet,shootPosition.position, shootPosition.rotation) as Transform;		
		}
        if (myRemote.GetButton(WiiUButton.Button1)) //2=A=weapon 2
        {

        }
			
	}
    //old keyboard controls below
    /*
    if (Input.GetKey(KeyCode.UpArrow))  //up on the d-pad
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
    */
		
	
}
