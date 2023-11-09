namespace WebWebWeb.Models
{
    public class ItemRepos
    {
        public void addProduct(InventoryItem item)
        {
            GiftShopOneContext cx=new GiftShopOneContext();
            cx.InventoryItems.Add(item);
            cx.SaveChanges();
        }

        public void updateProduct(InventoryItem item)
        {
            GiftShopOneContext cx=new GiftShopOneContext();
            var items = cx.InventoryItems.ToList();
            foreach(InventoryItem item2 in items)
            {
                if(item.ItemName==item2.ItemName && item.Category==item2.Category)
                {
                    if(item.Price!=null)
                    {
                        item2.Price=item.Price;
                    }
                    if(item.Quantity!=null)
                    {
                        item2.Quantity=item.Quantity;
                    }
                    if(item.Weight!=null)
                    {
                        item2.Weight=item.Weight;
                    }
                    if(item.imagePath!=null)
                    {
                        item2.imagePath = item.imagePath;
                    }
                    cx.SaveChanges();
                    break;

                }

            }

        }

        public bool removeProduct(InventoryItem t)
        {
            GiftShopOneContext cx = new GiftShopOneContext();
            var items=cx.InventoryItems.ToList();
            foreach(InventoryItem item in items)
            {
                if(item.ItemName == t.ItemName && item.Category==t.Category)
                {
                    cx.InventoryItems.Remove(item);
                    cx.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool isItem(InventoryItem t)
        {
            GiftShopOneContext cx = new GiftShopOneContext();
            var items = cx.InventoryItems.ToList();
            foreach (InventoryItem item in items)
            {
                if (item.ItemName == t.ItemName && item.Category == t.Category)
                {
                    return true;
                }
            }
            return false;

        }

        public InventoryItem? getItem(int id)
        {
            GiftShopOneContext cx = new GiftShopOneContext();
            var items = cx.InventoryItems.ToList();
            foreach (InventoryItem item in items)
            {
                if (item.ItemId == id )
                {
                    return item;
                }

            }
            return null;
            
        }
        public List<InventoryItem> findBirthdayItems()
        {
            List<InventoryItem> itemList = new List<InventoryItem>();
            GiftShopOneContext cx = new GiftShopOneContext();
            var items = cx.InventoryItems.ToList();
            foreach (InventoryItem item in items)
            {
                if (item.Category == "birthday" && item.IsDeleted != true)
                {
                    itemList.Add(item);
                }
            }
            return itemList;

        }


        public List<InventoryItem> findAnniversaryItems()
        {
            List<InventoryItem> itemList = new List<InventoryItem>();
            GiftShopOneContext cx = new GiftShopOneContext();
            var items = cx.InventoryItems.ToList();
            foreach (InventoryItem item in items)
            {
                if (item.Category == "anniversary" && item.IsDeleted!=true)
                {
                    itemList.Add(item);
                }
            }
            return itemList;

        }

        public List<InventoryItem> findGiftBasketItems()
        {
            List<InventoryItem> itemList = new List<InventoryItem>();
            GiftShopOneContext cx = new GiftShopOneContext();
            var items = cx.InventoryItems.ToList();
            foreach (InventoryItem item in items)
            {
                if (item.Category == "basket" && item.IsDeleted != true)
                {
                    itemList.Add(item);
                }
            }
            return itemList;

        }


    }
}
