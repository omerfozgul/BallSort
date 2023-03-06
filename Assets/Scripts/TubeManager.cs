using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class TubeManager : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private RectTransform rectTransform;
    private static string curTubeTag1 = null, curTubeTag2 = null;
    public static int startIndexTube = -1, endIndexTube = -1;
    public static bool busy = false;

    //
    public event Action<TubeManager> OnPointerDown;

    private void Awake(){
        rectTransform = transform.GetComponent<RectTransform>();

        //aslinda baska classlardan yapilacak, iletisim kurmak amaciyla yapiliyor
        OnPointerDown += (x) => Debug.Log("EVENT"); 
    }


    void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
        //OnPointerDown?.Invoke(this);


        if(curTubeTag1 == null) {
            curTubeTag1 = transform.tag;
            startIndexTube = TubeTagToIndex(curTubeTag1);
        }
        else if(curTubeTag2 == null){
            curTubeTag2 = transform.tag;

        }
        else {
            curTubeTag1 = transform.tag;
            curTubeTag2 = null;
        }
        startIndexTube = TubeTagToIndex(curTubeTag1);
        endIndexTube = TubeTagToIndex(curTubeTag2);
    }



    private int TubeTagToIndex(string tubeTag) {//converts tag-beher to beher-index
        if (tubeTag == null)
            return -1;
        string strIndex = tubeTag.Substring(4);
        int index = int.Parse(strIndex);
        return index;
    }


}
