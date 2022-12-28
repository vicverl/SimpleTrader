using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTrader.WPF.State.Navigation;

namespace SimpleTrader.WPF.ViewModels;

public class MainViewModel : ViewModelBase
{
    private INavigator Navigator { get; set; } = new Navigator();
}