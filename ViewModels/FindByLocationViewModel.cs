﻿using MonkeysMVVM.Models;
using MonkeysMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonkeysMVVM.ViewModels
{
    public class FindByLocationViewModel:ViewModel
    {

        
        private string country;
        private int numMonkeysFound;
        public int NumMonkeysFound { get { return numMonkeysFound; } set { numMonkeysFound = value; OnPropertyChanged(); } }
        public string Country { get { return country; } set { country = value; OnPropertyChanged(); ((Command)SearchByCountryCommand).ChangeCanExecute(); } }
        public ICommand SearchByCountryCommand { get; set; }
        private Monkey monkey;
        public string Name { get { return monkey.Name; } }
        public string ImageUrl { get { return monkey.ImageUrl; } }



        public FindByLocationViewModel()
        {
            monkey = new Monkey() {Name = "no monkeys now" };
            SearchByCountryCommand = new Command(FindMonkeys, () => !String.IsNullOrEmpty(Country));
        }
        private void FindMonkeys()
        {
            MonkeysService service = new MonkeysService();
            List<Monkey> lst = service.FindMonkeysByLocation(Country);

            if (lst.Count > 0)
                monkey = lst[0];
            else
                monkey = new Monkey() { Name = "no monkeys" };
            NumMonkeysFound = lst.Count;
            RefreshData();
            Country = null;
        }
        private void RefreshData()
        {
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(ImageUrl));
        }
      
    }
}
