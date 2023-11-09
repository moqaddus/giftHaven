namespace WebWebWeb.Models
{
    public class UserRepos
    {

        
        public int isUser(User u)
        {
            GiftShopOneContext cx = new GiftShopOneContext();
            User temp = new User();
            var users=cx.Users.ToList();
            foreach(var user in users)
            {
                if(user.UserName==u.UserName && user.Password==u.Password)
                {
                    return user.Id;
                }
            }
            return 0;


        }




        public void addUser(User u)
        {
            GiftShopOneContext cx = new GiftShopOneContext();
            cx.Users.Add(u);
            cx.SaveChanges();
        }
    }
}
