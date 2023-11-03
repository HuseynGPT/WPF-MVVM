using CommandMVVM.Commands;
using CommandMVVM.Models;
using CommandMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandMVVM.ViewModels.WindowViewModels
{
    internal class EditCarViewModel:NotificationService
    {
        private Car temp1;
        private Car car1;

        public Car car { get => car1; set { car1 = value; OnPropertyChanged(); } }
        public Car temp { get => temp1; set { temp1 = value; OnPropertyChanged(); } }

        public ICommand SaveCommand { get; set; }

        public EditCarViewModel(Car car)
        {
            temp = car;
            car1 = new Car();
            car1.Make = car.Make;
            car1.Model = car.Model;
            car1.Year = car.Year;

            SaveCommand = new RelayCommand(Save);

        }

        public void Save(object? parameter)
        {
            temp.Make = car.Make;
            temp.Model = car.Model;
            temp.Year = car.Year;
        }

     













    }
}
