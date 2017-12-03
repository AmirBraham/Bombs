using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shopNavigator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int YPos = 50;
        Database database = Resources.Load("Database") as Database;
        for (int i = 0; i < database.itemsNames.Length;i++) {
            
            GameObject item = new GameObject(database.itemsNames[i], typeof(RectTransform), typeof(Image));
            item.transform.parent = transform;
           // GameObject instItem = Instantiate(item,item.transform.position, Quaternion.identity) as GameObject;
            item.GetComponent<RectTransform>().sizeDelta = new Vector2(50,50);
            item.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            item.GetComponent<Image>().sprite = database.inventorySprites[i];

            if(i == 0 ) {
                item.GetComponent<RectTransform>().anchoredPosition = new Vector3(-50, 50);
            } else{
                YPos -= 50;
                item.GetComponent<RectTransform>().anchoredPosition = new Vector3(-50, YPos);

            }


        }



	}


}
