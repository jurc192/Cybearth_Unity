using UnityEngine;
using System.Collections;

public class ControlTerminalScript : MonoBehaviour {

	public int terminalNumber = 0;				//stevilka tega terminala
	public GameObject jumboTronicContainer;		//container vseh jumbotov
	
	private Component[] screens;				//tabela textureHandler componente vsakega jumbota
	
	public void HackJumbo() {
		
		int numJumbos= jumboTronicContainer.transform.childCount;
		//Debug.Log("stJumbotov: "+numJumbos);
	
        screens = jumboTronicContainer.GetComponentsInChildren<TextureHandler>();
		
		
		for (int i= 0; i < numJumbos; i++) {
			
			TextureHandler th = (TextureHandler)screens[i];
			
			if (th.terminalNum == this.terminalNumber) {
				
				th.HackedTexture();
				
			}

		}
		
	}
}
