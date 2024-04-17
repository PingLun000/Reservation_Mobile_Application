using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using ReservationMobileApp.Model;
using ReservationMobileApp.ViewModels;
using Xamarin.Forms;

namespace ReservationMobileApp.Helpers
{
    public class AddServicesData
    {
        FirebaseClient client;

        //define a property to hold the list of services , providedservices is the name of the table 
        public List<ProvideItem> Services { get; set; }

        public AddServicesData()
        {
            client = new FirebaseClient("https://newapp2-df63e.firebaseio.com/");
            Services = new List<ProvideItem>()
            {       //adding data into Firebase and by categories
                   new ProvideItem
                {
                    ProductID=1,
                    CategoryID=1,
                    ImageUrl="Res1.jpg",
                    Name="Noma, Restaurant",
                    Description=" The World’s Best Restaurant in four years: 2010, 2011, 2012, and 2014. Copenhagen, Denmark",
                    Rating="4.8",
                    RatingDetail="(10 Ratings) ",
                    HomeSelected="CompleteHeart",
                    Price=10
                },

                  new ProvideItem
                {
                    ProductID=2,
                    CategoryID=1,
                    ImageUrl="salon.jpg",
                    Name="Arizona Hair Salon ",
                    Description="  Leading Hair Salon brand in Korea, Over 200 salons all over the world. Kuala Lumpur ",
                    Rating="4.0",
                    RatingDetail="(12 Ratings) ",
                    HomeSelected="CompleteHeart",
                    Price=5
                },

                  new ProvideItem
                {
                    ProductID=3,
                    CategoryID=2,
                    ImageUrl="construction.jpg",
                    Name="Ralifo Design",
                    Description="the art and science to form objects, systems, or organizations, Kuala Lumpur ",
                    Rating="2.8",
                    RatingDetail="(10 Ratings) ",
                    HomeSelected="EmptyHeart",
                    Price=100
                },
                      new ProvideItem
                {
                    ProductID=8,
                    CategoryID=2,
                    ImageUrl="construction2.jpg",
                    Name="Alitory Design ",
                    Description="the art and science to form objects, systems, or organizations, Kuala Lumpur ",
                    Rating="3.8",
                    RatingDetail="(22 Ratings) ",
                    HomeSelected="EmptyHeart",
                    Price=100
                },
                  new ProvideItem
                {
                    ProductID=4,
                    CategoryID=3,
                    ImageUrl="Tranning3.jpg",
                    Name="Management Training ",
                    Description="Training skills and knowledge that relate to specific useful competencies, Jakarta",
                    Rating="4.0",
                    RatingDetail="(1210 Ratings) ",
                    HomeSelected="completeHeart",
                    Price=3
                },
                    new ProvideItem
                {
                    ProductID=9,
                    CategoryID=3,
                    ImageUrl="Trainning2.jpg",
                    Name="Soft Skills Training ",
                    Description=" Training needed knowledge and abilities necessary to fulfill the specific requirements, Pinang",
                    Rating="4.4",
                    RatingDetail="(105 Ratings) ",
                    HomeSelected="completeHeart",
                    Price=3
                },

                  new ProvideItem
                {
                    ProductID=5,
                    CategoryID=4,
                    ImageUrl="cilantro.jpg",
                    Name="Cilantro Culinary Academy ",
                    Description="A trial Course at Malaysia's first vocational culinary and pastry academy to receive the prestigious Worldchefs, Selangor",
                    Rating="4.8",
                    RatingDetail="(33 Ratings) ",
                    HomeSelected="completeHeart",
                    Price=10
                },

                  new ProvideItem
                {
                    ProductID=6,
                    CategoryID=4,
                    ImageUrl="next.png",
                    Name="NEXTx Academy",
                    Description="A trail on NEXTx Academy is Southeast Asia's best full stack coding & digital marketing academy, Selangor",
                    Rating="4.9",
                    RatingDetail="(110 Ratings) ",
                    HomeSelected="completeHeart",
                    Price=120
                },
                  new ProvideItem
                  {

                    ProductID=7,
                    CategoryID=4,
                    ImageUrl="beauty.png",
                    Name="De'grace Beauty skin Centre",
                    Description="A trail to revive your look with skin care targeting specific skin concerns and skin types like dry skin, oily skin and more, Johor",
                    Rating="3.9",
                    RatingDetail="(11210 Ratings) ",
                    HomeSelected="completeHeart",
                    Price=120
                  }
             };
        }
        //define a method to add a data 
        public async Task AddServicesAsync()
        {
            try
            {
                foreach (var item in Services)
                {
                    await client.Child("ProvideItems").PostAsync(new ProvideItem()
                    {
                        CategoryID = item.CategoryID,
                        ProductID = item.ProductID,
                        Description = item.Description,
                        HomeSelected = item.HomeSelected,
                        ImageUrl = item.ImageUrl,
                        Name = item.Name,
                        Price = item.Price,
                        Rating = item.Rating,
                        RatingDetail = item.RatingDetail
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
