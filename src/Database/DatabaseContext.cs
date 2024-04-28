
using sda_onsite_2_csharp_backend_teamwork.src.Entity;

namespace sda_onsite_2_csharp_backend_teamwork.src.Database;
public class DatabaseContext
{
    public List<User> Users;
    public List<Product> Products;
    public DatabaseContext()
    {
        Products = [
            new Product("11","a","Rose",6,"link1",200,"The rose, with its velvety petals and captivating fragrance, epitomizes timeless beauty and heartfelt sentiment, perfect for adding an exquisite touch to any occasion or space."),
            new Product("22","b","Cactus",28,"link2",50,"Transform your space with a vibrant touch of desert charm - our majestic cactus, boasting intricate spines and unparalleled resilience, brings a unique flair and effortless elegance to any environment."),
            new Product("33","c","Lavender",16,"link3",120,"Lavender, with its soothing aroma and gentle purple hues, offers a fragrant embrace, inviting tranquility and serenity into any space, creating a blissful sanctuary for the senses."),
            new Product("44","a","Orchid",18,"link4",180,"Graceful and exotic, the orchid enchants with its delicate blooms and elegant allure, infusing any setting with a touch of sophistication and natural splendor."),
        ];
        Users = [
            new User("1224567","Raghad Alghunaim","575870","0568890978","raghad@gmail.com","admin"),
            new User("1228902","Shama Alzhalidi","454353","0568843467","shama@gmail.com","customer"),
            new User("1323243","Omnia AlZahrani","455350","0542296512","omnia@gmail.com","customer"),
            new User("1004394","Sara Alanzi","345900","0564459812","sara@gmail.com","customer"),
        ];

    }
}



