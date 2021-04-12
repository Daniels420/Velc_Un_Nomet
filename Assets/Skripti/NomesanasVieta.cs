using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jāimportē, lai varētu piesaistīt IDropHandler interfeisu un lietot OnDrop funkciju
using UnityEngine.EventSystems;

public class NomesanasVieta : MonoBehaviour, IDropHandler {
    //Uzglabās velkamā objekta rotāciju ap Z asi un noliekamās vietas rotāciju
    //Starpība uzglabās, cik liela Z ass rotācijas leņķa starpība starp abiem objektiem
    private float vietasZrot, velkamaObjektaZrot, rotacijasStarpiba;
    //Uzglabās velkamā objekta un nomešanas vietas izmērus
    private Vector2 vietasIzm, velkObjIzm;
    //Uzglabās objektu x un y ass izmēru starpību
    private float XIzmeruStarpiba, YIzmeruStarpiba;
    //Norāde uz skripu Objekti
    public Objekti objektuSkripts;

    //Nostrādā, ja objektu cenšās nomest uz nometamā lauka

    public void OnDrop(PointerEventData notikums)
    {
        //Pārbauda vai kāds objekts tiek vilkts un nomests
        if (notikums.pointerDrag != null)
        {
            //Ja nomešanas laukā uzmestā attēla tags sakrīt ar lauka tagu
            if ((notikums.pointerDrag.tag.Equals(tag))
            {
                //Iegūst objektu rotāciju grādos
                vietasZrot = notikums.pointerDrag.GetComponent<RectTransform>().transform.eulerAngles.z;
                velkamaObjektaZrot = GetComponent<RectTransform>().transform.eulerAngles.z;
                //Aprēķina rotācijas starpību
                rotacijasStarpiba = Mathf.Abs(vietasZrotZrot - velkamaObjektaZrot);
                //Iegūst objektu izmērus
                vietasIzm = notikums.pointerDrag.GetComponent < RectTransform.localScale;
                velkObjIzm = GetComponent<RectTransform>().localScale;
                XIzmeruStarpiba = Math.Abs(vietasIzm.x - velkObjIzm.x);

                YIzmeruStarpiba = Math.Abs(vietasIzm.y - velkObjIzm.y);

                //Pārbauda vai objektu savstarpējā rotācija neatšķiras vairāk par 9 grādiem
                //un vai x un y izmēri neatšķiras vairāk par 0.15
                if ((rotacijasStarpiba <= 9 || (rotacijasStarpiba >= 351 && rotacijasStarpiba <= 360))
                    && (XIzmeruStarpiba <= 0.15 && YIzmeruStarpiba <= 0.15))
                {
                    Objekti.vaiIstajaVieta = true;
                    //Nometamo objektu iecentrē nomešanas vietā
                    notikums.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    //Pielāgo nomestā objekta rotāciju
                    notikums.pointerDrag.GetComponent<RectTransform>().localRotation = GetComponent<RectTransform>().localScale;


                    //Pārbauda pēc tagiem, kurš no objektiem ir pareizi nomests,tad atskaņo atbilstošu skaņu
                    switch (notikums.pointerDrag.tag)
                    {
                        case "Atkritumi";
                            ObjektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAttskanot[1])
                                break;

                        case "Atrie";
                            ObjektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAttskanot[2])
                                break;

                        case "Skola";
                            ObjektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAttskanot[3])
                                break;

                        default:
                            Debug.Log("Nedefinēts tags!")
                                break;

                    }
                }
            }
            //Ja objektu tagi nesakrīt un nomet nepareizajā vietā
        } else {
            switch (notikums.pointerDrag.tag)
            {
                case "Atkritumi";
                    ObjektuSkripts.atroMasina.GetComponent<RectTransform>().localPosition = objektuSkripts.atkrKoord;
                    break;

                case "Atrie";
                    ObjektuSkripts.atroMasina.GetComponent<RectTransform>().localPosition = objektuSkripts.atroKoord;
                                break;

                case "Skola";
                    ObjektuSkripts.autobussMasina.GetComponent<RectTransform>().localPosition = objektuSkripts.autobussKoord;
                    break;

                default:
                    Debug.Log("Nedefinēts tags!")
                                break;

            }
            objektuSkripts.vaiIstajaVieta = false;
            //Atskaņo skaņu
            objektuSkripts.skanasAvots.PlayOneShot(objektuSkripts.skanaKoAtskanot[0)
        
                 /* Atkarībā 
                
                }   
             }
        }
    }
}

   
