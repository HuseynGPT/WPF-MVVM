using CommandMVVM.Commands;
using CommandMVVM.Models;
using CommandMVVM.Services;
using CommandMVVM.ViewModels.WindowViewModels;
using CommandMVVM.Views.Windows;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommandMVVM.ViewModels.PageViewModels;

public class DashboardViewModel : NotificationService
{
    private Car? car1;
    public Car? car { get => car1; set { car1 = value; OnPropertyChanged(); } }

    public ObservableCollection<Car> Cars { get; set; }


    public ICommand AddCommand{ get; set; }
    public ICommand GetAllCommand{ get; set; }
    public ICommand EditCarCommand{ get; set; }
    public ICommand RemoveCommand{ get; set; }


    public DashboardViewModel()
    {
        Cars = new ObservableCollection<Car>()
        {
            new("Kia", "Optima", "2012"),
            new("Hyundai", "Elantra", "2014"),
            new("Audi", "Q7", "2023"),
        };

        car = new();


        AddCommand = new RelayCommand(AddCar, CanAddCar);
        GetAllCommand = new RelayCommand(GetAllCars, CanAllCars);
        EditCarCommand = new RelayCommand(EditCar, CanEditCar);
        RemoveCommand = new RelayCommand(Remove, CanRemove);
    }


    public void Remove(object? parameter)
    {
        var select = parameter as int?;
        if (select != null && select != -1)
        {
           
            Cars.RemoveAt(Convert.ToInt32(select));
        }
    }

    public bool CanRemove(object? parameter)
    {
        var select = parameter as int?;
        if (select != null && select != -1)
        {

            return true;
        }
        return false;

    }
    public void EditCar(object? parameter)
    {
        var select = parameter as int?;
        if (select != null && select != -1)
        {
            var editCarView = new EditCarView();
            editCarView.DataContext = new EditCarViewModel(Cars[Convert.ToInt32(select)]);
            editCarView.ShowDialog();
        }




    }
    public bool CanEditCar(object? parameter)
    {
        var select = parameter as int?;
        if (select != null && select != -1)
        {
            return true;
        }
        return false;
    }

    public void GetAllCars(object? parameter)
    {
        var getAllView = new AllCarView();
        getAllView.DataContext = new GetAllCarViewModel(Cars);
        getAllView.ShowDialog();
    }

    public bool CanAllCars(object? parameter)
    {
        return Cars.Count >= 5;
    }


    public void AddCar(object? parameter)
    {
       //var btn = parameter as Button;
       // MessageBox.Show($"{btn.Content} - {btn.Width} - {btn.Margin}");
        Cars.Add(car!);
        car = new();
        
    }

    public bool CanAddCar(object? parameter)
    {
        return !string.IsNullOrEmpty(car?.Make) &&
               !string.IsNullOrEmpty(car?.Model) &&
               !string.IsNullOrEmpty(car?.Year);
    }
}
