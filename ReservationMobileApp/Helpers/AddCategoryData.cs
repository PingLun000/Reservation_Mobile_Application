using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using ReservationMobileApp.Model;
using Xamarin.Forms;

namespace ReservationMobileApp.Helpers
{
    public class AddCategoryData
    {
        public List<Category> Categories { get; set; }

        FirebaseClient client;

        //create a helper class from category.cs to add various of categories to the categories table 
        //within the firebase realtime database
        public AddCategoryData()
        {//define the variable for firebase client and used to connect with the database
            client = new FirebaseClient("https://newapp2-df63e.firebaseio.com/");
            //define a property to maintain the list of categories
            Categories = new List<Category>()
            {
                //add list
                new Category()
                {
                    CategoryID = 1,
                    CategoryName = "Business Service",
                    CategoryPoster = "PhysicalStore.jpg",
                    ImageUrl = "PhysicalStore.jpg"
                },
                new Category()
                {
                    CategoryID = 2,
                    CategoryName = "Construction & Design",
                    CategoryPoster = "TechnicalWorker.jpg",
                    ImageUrl = "TechnicalWorker.jpg"
                },

                new Category()
                {
                    CategoryID = 3,
                    CategoryName = "Training",
                    CategoryPoster = "Training.jpg",
                    ImageUrl = "Training.jpg"
                },
                new Category()
                {
                    CategoryID = 4,
                    CategoryName = "Education",
                    CategoryPoster = "Events",
                    ImageUrl = "Events.jpg"
                }
            };
        }
        //define method to add it into the database
        public async Task AddCategoriesAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryID = category.CategoryID,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        ImageUrl = category.ImageUrl
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
