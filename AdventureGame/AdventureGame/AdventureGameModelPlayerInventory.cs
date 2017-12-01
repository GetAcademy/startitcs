using System.Collections.Generic;

namespace AdventureGame
{
    public partial class AdventureGameModelPlayerInventory
    {
        public void RemoveItem(AdventureGameModelPlayerInventoryKey item)
        {
            var list = new List<AdventureGameModelPlayerInventoryKey>(Item);
            list.Remove(item);
            Item = list.ToArray();
        }

        public void AddItem(AdventureGameModelPlayerInventoryKey item)
        {
            Item = new List<AdventureGameModelPlayerInventoryKey>(Item) {item}.ToArray();
        }
    }
}
