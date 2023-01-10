using SimpleTrader.WPF.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace SimpleTrader.WPF.Models;

public class ObservableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}