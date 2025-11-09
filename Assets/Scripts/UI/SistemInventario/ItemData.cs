using UnityEngine;

//al crearse se llamara Inventory Data, para crearlo esta en "create/inventory System/..."
[CreateAssetMenu(fileName = "Inventory Data", menuName = "Inventory System / Create new Item Data")]
public class ItemData : ScriptableObject {

    [Tooltip("Unico ID Item.")]
    public string ItemID;

    [Tooltip("Nombre del Item, Aparece en Inventario")]
    public string ItemName;

    [Tooltip("Sprite 2D del Item, Aparece en Inventario")]
    public Sprite ItemIcon;

    [Tooltip("Item GameObject")]
    public GameObject ItemPrefab;

    [TextArea(17, 1000)]
    public string Comment = "Type comments here";

}
