using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Videothek.Logic.Ui.ViewModel.SQLCommandViewModel;
using static Videothek.Logic.Ui.ViewModel.MainViewModel;

namespace Videothek.Ui.Desktop
{
	/// <summary>
	/// Interaction logic for HauptFenster.xaml
	/// </summary>
	public partial class HauptFenster : UserControl
	{
		public HauptFenster()
		{
			InitializeComponent();
		}
	}
}
