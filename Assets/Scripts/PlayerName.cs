using Fusion;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class PlayerName : NetworkBehaviour
{
    public TMP_Text name;
    string[] names = { "Taiga", "Moss", "Pine", "Oakley", "Lichen", "Sap", "Pine", "Cobble", "Mud"};
    int store = 1;
    private int rand;
    public int Rand { get { return rand; } set { rand = value; } }

    [Networked, OnChangedRender(nameof(NameChanged))]
    public string NetworkedName { get; set; }


    void Start()
    {
        if (HasStateAuthority)
        {
            NetworkedName = createName();
        }
    }

    void NameChanged()
    {
        name.text = NetworkedName;
    }

    public override void Render()
    {
        if (name.text != NetworkedName)
            NameChanged();
        store = Rand;
    }

    public string createName()
    {
        string nameC = "";
        Rand = Random.Range(0, 8);

        if (Rand != store)
        {
            nameC = "" + names[Rand];
        }
        else
        {
            Rand = Random.Range(0, 8);
        }
        return nameC;

    }
}
