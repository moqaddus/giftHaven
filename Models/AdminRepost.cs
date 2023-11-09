namespace WebWebWeb.Models
{
    public class AdminRepost
    {
        public bool isAdmin(Admin a)
        {
            GiftShopOneContext cx = new GiftShopOneContext();
            var ad = cx.Admins.ToList();
            foreach (var item in ad)
            {
                if (item.Email == a.Email && item.Password == a.Password)
                {
                    return true;
                }
            }
            return false;

        }

        public string getName(Admin a)
        {
            GiftShopOneContext cx = new GiftShopOneContext();
            var ad = cx.Admins.ToList();
            foreach (var item in ad)
            {
                if (item.Email == a.Email && item.Password == a.Password)
                {
                    return item.UserName;
                }
            }
            return null;

        }

        public void addAdmin(Admin a)
        {
            GiftShopOneContext cx = new GiftShopOneContext();
            cx.Admins.Add(a);
            cx.SaveChanges();
        }
    }
}
