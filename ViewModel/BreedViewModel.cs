using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMJSON.ViewModel
{
    public class BreedViewModel : NotificationBase
    {
        Model.Dogs breeds;

        public BreedViewModel()
        {
            Model.Dogs test = new Model.Dogs();

            foreach (var dog in test.Breeds)
            {
                var np = new DogViewModel(dog);
                _dog.Add(np);
            }
        }


        ObservableCollection<DogViewModel> _dog
               = new ObservableCollection<DogViewModel>();

        public ObservableCollection<DogViewModel> Dog
        {
            get { return _dog; }
            set { SetProperty(ref _dog, value); }
        }

        //String _Name;
        //public String Name
        //{
        //    get { return breeds.BreedName; }
        //}

        int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                { RaisePropertyChanged(nameof(SelectedDog)); }
            }
        }

        public DogViewModel SelectedDog
        {
            get { return (_SelectedIndex >= 0) ? _dog[_SelectedIndex] : null;}
        }
    }
}
