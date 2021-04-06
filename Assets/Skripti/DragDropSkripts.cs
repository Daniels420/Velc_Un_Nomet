using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jāimportē, lai varētu strādāt ar  EventSystems
using UnityEngine.EventSystems;

public class DragDropSkripts : MonoBehaviour, IpointerDownHandler, IBeginDragHandler, IDragHandler, IEndHandler {
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



    
        
    
}
