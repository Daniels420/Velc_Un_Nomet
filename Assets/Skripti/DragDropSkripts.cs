using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jāimportē, lai varētu strādāt ar  EventSystems
using UnityEngine.EventSystems;

public class DragDropSkripts : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler {
//Uzglabās noraidi uz objektu skriptu
public Objekti objektuSkripts;
//Velkamam objektam piestiprinātā komponente
private CanvasGroup kanvasGrupa;
//Vilktā objekta atrašanās vietas koordinātu maiņa
private RectTransform velkObjRectTransf;

void Awake() 
    {
//Piekļūst objektam piesaistītajai CanvasGroup komponentei
kanvasGrupa = GetComponent<CanvasGroup>();
//Piekļūst objekta RectTransform komponentei
velkObjRectTransf = GetComponent<RectTransform>();
    }

//Nostrādā nospiežot peles klikšķi uz objekta
public void OnPointerDown(PointerEventData notikums)
    {
        Debug.Log("Uzklikšķināts uz velkamā objekta!");
    }
//Nostrādā uzsākot vilkšanu

public void OnBeginDrag(PointerEventData notikums)
    {   
        Debug.Log("Uzsākta vilkšana!");
        //Attīra pēdējo vilkto objektu
        objektuSkripts.pedejaisVilktais = null;
        //Uzsākot vilkt objektu tas paliek nedaudz caurspīdīgs
        kanvasGrupa.alpha = 0.6f;
        //Lai objektam varētu iet cauri raycast stars
        kanvasGrupa.blocksRaycasts = false;
    }

    //Nostrādā reāli notiekot vilkšanai
public void OnDrag(PointerEventData notikums)
{
    Debug.Log("Notiek vilkšana!");
    velkObjRectTransf.anchoredPosition += notikums.delta / objektuSkripts.kanva.scaleFactor;
}
//Nostrādā,kad tiek beigta vilkšana
public void OnEndDrag(PointerEventData notikums)
{
    //Atlaižot objektu iestata to kā pēdējo vilkto
    objektuSkripts.pedejaisVilktais = notikums.pointerDrag;
    Debug.Log("Pēdējais vilktais objekts: "+objektuSkripts.pedejaisVilktais);
    Debug.Log("Beigta vilkšana!");
    //Atlaižot objektu tas atkal paliek necaurspīdīgs
    kanvasGrupa.alpha = 1f;

    //Pārbauda vai objekts ir vienkārši nomest vai arī nomests pareizajā vietā
    if(objektuSkripts.vaiIstajaVieta == false)
    {
        //Ja nav nomests pareizajā vietā,tad atkal padara velkamu
        kanvasGrupa.blocksRaycasts = true;


    }
    else
    {
      /*Ja objekts nolikts pereizajā vietā, izmērā, rotācijā, tad
      pēdējo vilkto attīra*/
      objektuSkripts.pedejaisVilktais = null;
      } 
      objektuSkripts.vaiIstajaVieta = false; 
    }
}
