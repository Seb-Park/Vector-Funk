using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour {

    public int[] prices;
    public int[] paid;
    [SerializeField]
    private int[] paidPlayerprefs;
    public string[] names;
    public string type;

	// Use this for initialization
	void Start () {

        updatePrices();
	}

    public void updatePrices(){
        for (int i = 0; i < paid.Length; i++)
        {
            paid[i] = PlayerPrefs.GetInt(names[i]+"Price")+prices[i];//setting all of the items in the paid array to see how much I've paid off. 
            //Giving them all names so that I can easily switch the order of the  balls in the menu
            //paid[i] = PlayerPrefs.GetInt(type + i + "price") + prices[i];
        }
        paidPlayerprefs = new int[paid.Length];
        for (int i = 0; i < paidPlayerprefs.Length; i++)
        {
            paidPlayerprefs[i] = PlayerPrefs.GetInt(names[i] + "Price");
        }
    }

	// Update is called once per frame
	void Update () 
    {
		
	}
}
