
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Data.Json;
using Windows.Storage;
using Data;

namespace MVVMJSON.Model
{
    class Dogs
    {
        public List<myDogs> Breeds { get; set; }
        public static List<myDogs> gDogList = new List<myDogs>();
        public String BreedName { get; set; }

        public Dogs()
        {
            LoadData();
            Breeds = gDogList;
        }

        public static async Task LoadData()
        {
            await LoadLocalData();
        }

        public static async Task LoadLocalData()
        {
            // reads in the json from the myEnemies text file
            var file = await Package.Current.InstalledLocation.GetFileAsync("Data\\myEnemies.txt");
            var result = await FileIO.ReadTextAsync(file);

            var jDogList = JsonArray.Parse(result);
            CreateDogsList(jDogList);
        }

        private static void CreateDogsList(JsonArray jDogList)
        {
            foreach (var item in jDogList)
            {
                var oneDog = item.GetObject();
                myDogs nDog = new myDogs();

                foreach (var key in oneDog.Keys)
                {
                    IJsonValue value;
                    if (!oneDog.TryGetValue(key, out value))
                        continue;

                    switch (key)
                    {
                        // reads in the valaues from each of the areas
                        case "breed":
                            nDog.breed = value.GetString();
                            break;
                        case "category":
                            nDog.category = value.GetString();
                            break;
                        case "grooming":
                            nDog.grooming = value.GetString();
                            break;
                        case "activity":
                            nDog.activity = value.GetString();
                            break;
                        case "image":
                            nDog.image = value.GetString();
                            break;
                    }
                } 
                gDogList.Add(nDog);
            } 
        }
    }
}



    

