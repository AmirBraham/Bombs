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
            GameObject instItem = Instantiate(item,item.transform.position, Quaternion.identity);
            instItem.GetComponent<RectTransform>().sizeDelta = new Vector2(50,50);
            instItem.GetComponent<Image>().sprite = database.inventorySprties[i];
            if(database.itemsNames[i] != "default") {
                instItem.GetComponent<RectTransform>().position = new Vector3(-50, YPos - 50);
            }

        }



	}


}
