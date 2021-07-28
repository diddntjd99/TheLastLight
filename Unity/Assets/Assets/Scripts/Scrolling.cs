using UnityEngine;
using System.Collections;

public class Scrolling : MonoBehaviour 
{
	public float velScroll;

	void Update () 
	{
        Scroll();
		
	}

    public void Scroll()
    {

        float offset = Time.time * velScroll * Time.fixedDeltaTime;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
