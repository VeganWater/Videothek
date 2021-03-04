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
using static Videothek.Logic.Ui.ViewModel.MainViewModel;
using static Videothek.Logic.Ui.ViewModel.SQLCommandViewModel;

namespace Videothek.Ui.Desktop
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			#region Mesenger for Window
			///Messenger For ContentControl, UserControl and Window
			Messenger.Default.Register<PropertyChangedMessage<ChangeWindow>>(this, (PropertyChangedMessage<ChangeWindow> e) =>
			 {
				 ///Put inside ContenControl form MainWindow.xaml Hauptfenster	 
				 if (e.PropertyName.Equals("StartClick"))
				 {
					 HauptFenster HF = new HauptFenster();
					 MainWindowCC.Content = HF;

				 }
				 // Open Delete Window
				 else if (e.PropertyName.Equals("Delete"))
				 {
					 DeleteChildWindow DeleteCW = new DeleteChildWindow();
					 DeleteCW.ShowDialog();
				 }
				 ///Open ChildWindow and insert Kunde.xaml
				 else if (e.PropertyName.Equals("Kunde"))
				 {
					 ChildWindow CW = new ChildWindow();
					 Kunde Kn = new Kunde();
					 CW.ChildWindowCC.Content = Kn;
					 if (e.NewValue.Result == true)
					 {
						 Kn.KundeBtn.Content = "Hinzufügen";
					 }
					 else
					 {
						 Kn.KundeBtn.Content = "Bearbeiten";
					 }
					 CW.Show();
				 }
				 ///Open ChildWindow and insert Artikel.xaml
				 else if (e.PropertyName.Equals("Artikel"))
				 {
					 ChildWindow CW = new ChildWindow();

					 Artikel Ar = new Artikel();
					 CW.ChildWindowCC.Content = Ar;
					 if (e.NewValue.Result == true)
					 {
						 Ar.ArtikelBtn.Content = "Hinzufügen";
					 }
					 else
					 {
						 Ar.ArtikelBtn.Content = "Bearbeiten";
					 }
					 CW.Show();
				 }
				 ///Open ChildWindow and insert Kategorie.xaml
				 else if (e.PropertyName.Equals("Kategorie"))
				 {
					 ChildWindow CW = new ChildWindow();
					 Kategorie Kg = new Kategorie();
					 CW.ChildWindowCC.Content = Kg;
					 if (e.NewValue.Result == true)
					 {
						 Kg.KategorieBtn.Content = "Hinzufügen";
					 }
					 else
					 {
						 Kg.KategorieBtn.Content = "Bearbeiten";
					 }
					 CW.Show();
				 }
				 ///Open ChildWindow and insert Ausgeliehene_Artikel.xaml
				 else if (e.PropertyName.Equals("Art_Ausgeliehen"))
				 {
					 ChildWindow CW = new ChildWindow();
					 Ausgeliehene_Artikel Kn = new Ausgeliehene_Artikel();
					 CW.ChildWindowCC.Content = Kn;
					 if (e.NewValue.Result == true)
					 {
						 Kn.Ausgeliehene_ArtikelBtn.Content = "Hinzufügen";
					 }
					 else
					 {
						 Kn.Ausgeliehene_ArtikelBtn.Content = "Bearbeiten";
					 }
					 CW.Show();
				 }
				 ///Open ChildWindowPickData and insert PickData.xaml
				 else if (e.PropertyName.Equals("KundeID") || e.PropertyName.Equals("ArtikelID") || e.PropertyName.Equals("KategorieID"))
				 {
					 ChildWindowPickData CWPD = new ChildWindowPickData();
					 PickData PD = new PickData();
					 CWPD.ChildWindowPickDataCC.Content = PD;
					 CWPD.ShowDialog();
				 }

			 });
			#endregion

			#region Add Or Edit Messenger
			// Messenger For Add Or Edit SQL Row
			Messenger.Default.Register<PropertyChangedMessage<AddOrEdit>>(this, (PropertyChangedMessage<AddOrEdit> e) =>
			{
				if (e.PropertyName.Equals("AddKunde"))
				{
					if (e.NewValue.Result == true)
					{
						MessageBox.Show("Kunde wurde Hinzugefügt oder Bearbeitet!");
					}
					else if (e.NewValue.Result == false)
					{
						MessageBox.Show("Kunde konnte nicht Hinzugefügt oder Bearbeitet werden");
					}
				}
				else if (e.PropertyName.Equals("AddArtikel"))
				{
					if (e.NewValue.Result == true)
					{
						MessageBox.Show("Artikel wurde Hinzugefügt oder Bearbeitet!");
					}
					else if (e.NewValue.Result == false)
					{
						MessageBox.Show("Artikel konnte nicht Hinzugefügt oder Bearbeitet werden");
					}
				}
				else if (e.PropertyName.Equals("AddKategorie"))
				{
					if (e.NewValue.Result == true)
					{
						MessageBox.Show("Kategorie wurde Hinzugefügt oder Bearbeitet!");

					}
					else if (e.NewValue.Result == false)
					{
						MessageBox.Show("Kategorie konnte nicht Hinzugefügt oder Bearbeitet werden");
					}
				}
				else if (e.PropertyName.Equals("Art_Ausgeliehen"))
				{
					if (e.NewValue.Result == true)
					{
						MessageBox.Show("Artikel Ausgeliehen wurde Hinzugefügt oder Bearbeitet!");

					}
					else if (e.NewValue.Result == false)
					{
						MessageBox.Show("Artikel Ausgeliehen konnte nicht Hinzugefügt oder Bearbeitet werden");
					}
				}
			});
			#endregion

			#region Messenger For Delete SQL Row
			//Messenger For Delete SQL Row
			Messenger.Default.Register<PropertyChangedMessage<Delete>>(this, (PropertyChangedMessage<Delete> e) =>
			{
				switch (e.PropertyName)
				{
					case "Kunde":
						if (e.NewValue.Result == true)
						{
							MessageBox.Show("Kunde wurde gelöscht!");
						}
						else
						{
							MessageBox.Show("Kunde konnte nicht gelöscht werden!");
						}
						break;
					case "Artikel":
						if (e.NewValue.Result == true)
						{
							MessageBox.Show("Artikel wurde gelöscht!");
						}
						else
						{
							MessageBox.Show("Artikel konnte nicht gelöscht werden!");
						}
						break;
					case "Kategorie":
						if (e.NewValue.Result == true)
						{
							MessageBox.Show("Kategorie wurde gelöscht!");
						}
						else
						{
							MessageBox.Show("Kategorie konnte nicht gelöscht werden!");
						}
						break;
					case "Art_Ausgeliehen":
						if (e.NewValue.Result == true)
						{
							MessageBox.Show("Artikel-Ausgeliehen wurde gelöscht!");
						}
						else
						{
							MessageBox.Show("Artikel-Ausgeliehen konnte nicht gelöscht werden!");
						}
						break;
					default:
						break;
				}
			});
			#endregion
		}

		/// <summary>
		/// Put inside ContenControl From MainWindow StartSeite.xaml
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void StartSeiteLoad(object sender, RoutedEventArgs e)
		{
			StartSeite St = new StartSeite();
			MainWindowCC.Content = St;
		}
	}
}
