using System.Collections.Generic;

namespace AdventureGame
{
    public partial class AdventureGameModelRoomInventory
    {
        public void RemoveItem(AdventureGameModelRoomInventoryKey item)
        {
            var list = new List<AdventureGameModelRoomInventoryKey>(Item);
            list.Remove(item);
            Item = list.ToArray();
        }

        public void AddItem(AdventureGameModelRoomInventoryKey item)
        {
            Item = new List<AdventureGameModelRoomInventoryKey>(Item) { item }.ToArray();
        }
    }
}
