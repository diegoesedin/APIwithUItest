using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tournament row Gameobject
/// UI item
/// </summary>
public class TournamentRow : MonoBehaviour
{
    /** Own tournament information **/
    private Tournament data;

    /// <summary>
    /// Initializes row
    /// </summary>
    /// <param name="_data"></param>
    public void Initialize(Tournament _data)
    {
        this.data = _data;
        this.transform.GetChild(0).gameObject.GetComponent<Text>().text = this.data.id;
        this.transform.GetChild(1).gameObject.GetComponent<Text>().text = this.data.attributes.createdAt;
    }
}
