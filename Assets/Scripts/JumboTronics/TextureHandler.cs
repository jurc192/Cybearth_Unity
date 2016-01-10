using UnityEngine;
using System.Collections;
using System.Linq;

public class TextureHandler : MonoBehaviour {

	public int terminalNum = 0;		//kateri terminal nadzira ta jumbo
	public int textureSwapRate= 5;	//koliko sekund traja ena reklama
	
	private GameObject screen;
	public Texture2D hackedTex;
	private Texture2D[] textures;
	private int numTextures;
	
	// Use this for initialization
	void Start () {
		
		//init textures array & numTextures
		
		//textures = Resources.LoadAll("AdTextures", typeof(Texture2D)); NI DELALO, MORS CASTAT IZ OBJECT -> TEXTURE2D
		textures = System.Array.ConvertAll(Resources.LoadAll("AdTextures", typeof(Texture2D)),o=>(Texture2D)o);
		numTextures = textures.Length;
		screen = this.transform.Find("Screen").gameObject;
		
		//Debug.Log("Num textures: "+numTextures);
		
		//swap textures every x seconds
		InvokeRepeating("ChangeTexture", 0.1f, textureSwapRate);
		
	}
	
	
	private void ChangeTexture() {
		
		//random int
		int textureNum = Random.Range(0, numTextures);
		
		//swap texture
		Texture2D newTexture= textures[textureNum];

		screen.GetComponent<Renderer>().material.mainTexture = newTexture;
		
	}
	
	public void HackedTexture() {
		
		//stop autoscrolling advert textures
		CancelInvoke();
		
		//texture = BSOD
		screen.GetComponent<Renderer>().material.mainTexture = hackedTex;
		
	}
	
	public int GetTerminalNumber() {
		return this.terminalNum;
	}
	
}
