
[System.Serializable]
public class InventoryItem {

    public ItemData data;
    public int countItem;

    public InventoryItem(ItemData data) {
        this.data = data;
        AddCount();
    }

    public void AddCount() {
        countItem++;
    }

    public void RemoveCount() {
        countItem--;
    }


}
