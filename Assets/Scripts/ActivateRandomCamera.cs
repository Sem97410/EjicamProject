using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRandomCamera : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToActivate; // Les objets que tu veux activer/d�sactiver
    [SerializeField] private float minActivationTime = 2f;    // Temps d'activation minimum
    [SerializeField] private float maxActivationTime = 5f;    // Temps d'activation maximum

    void Start()
    {
        // D�sactiver tous les objets au d�but
        DeactivateAllObjects();

        // Lancer la coroutine pour activer al�atoirement les objets
        StartCoroutine(ActivateRandomObjectsRoutine());
    }

    void DeactivateAllObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false);
        }
    }

    IEnumerator ActivateRandomObjectsRoutine()
    {
        while (true)
        {
            // Choisir un indice al�atoire
            int randomIndex = Random.Range(0, objectsToActivate.Length);

            // Activer l'objet choisi
            objectsToActivate[randomIndex].SetActive(true);

            // Attendre un temps al�atoire entre minActivationTime et maxActivationTime avant de d�sactiver � nouveau tous les objets
            yield return new WaitForSeconds(Random.Range(minActivationTime, maxActivationTime));

            // D�sactiver tous les objets
            DeactivateAllObjects();
        }
    }
}
