using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace MVVMJSON.ViewModel
{
    public class DogViewModel : NotificationBase<Data.myDogs>
    {
        public DogViewModel(Data.myDogs dog = null) : base(dog) { }

        public String Breed
        {
            get { return This.breed; }
            set { SetProperty(This.breed, value, () => This.breed = value); }
        }
        public String Grooming
        {
            get { return This.grooming; }
            set { SetProperty(This.grooming, value, () => This.grooming = value); }
        }
        public String Category
        {
            get { return This.category; }
            set { SetProperty(This.category, value, () => This.category = value); }
        }
        public String Activity
        {
            get { return This.activity; }
            set { SetProperty(This.activity, value, () => This.activity = value); }
        }

        public String Image
        {

            get { return This.image; }
            set { SetProperty(This.image, value, () => This.image = value); }
        }
    }
}
