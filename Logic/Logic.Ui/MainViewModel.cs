using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Input;
using System.Configuration;
using static Videothek.Logic.Ui.ViewModel.SQLCommandViewModel;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;

namespace Videothek.Logic.Ui.ViewModel
{
	public class MainViewModel : ViewModelBase
	{
		private string msg = "StartClick";

		private string msg2;

		private bool bol = true;

		private CategoryTable SelectedCategory2;
		private CustomerTable SelectedCustomer2;
		private ItemTable SelectedItem2;

		public MainViewModel()
		{

		}


		private string _Btn;
		/// <summary>
		/// Binding to Button Content to Look if it needs to Add or Edit the Value
		/// </summary>
		public string Btn
		{
			get { return _Btn; }
			set { _Btn = value; }
		}

		private ICommand _StartClick;
		/// <summary>
		/// MVVM Messenger for Show ChildWindow, ChildWindowPickData Change for ContentControl and Which Table should be shown in PickData
		/// </summary>
		public ICommand StartClick
		{
			get
			{
				if (_StartClick == null || msg != "")
				{
					_StartClick = new RelayCommand<string>((str) =>
					{
						switch (str)
						{
							case "Add":
								if (msg != "StartClick")
								{
									msg = msg2;
									_SelectedCustomer = null;
									_SelectedItem = null;
									_SelectedCategory = null;
									_SelectedItemBorrowed = null;
									bol = true;
								}
								break;
							case "Edit":
								if (msg != "StartClick")
								{
									msg = msg2;
									bol = false;
								}
								break;

							case "Delete":
								if (msg != "StartClick")
								{
									msg = "Delete";
								}
								break;
							case "KundeID":
								msg = "KundeID";
								SelectedDataPick = GetCustomerTable().Cast<dynamic>().ToList();
								break;
							case "ArtikelID":
								msg = "ArtikelID";
								SelectedDataPick = GetItemTable().Cast<dynamic>().ToList();
								break;
							case "KategorieID":
								msg = "KategorieID";
								SelectedDataPick = GetCategoryTable().Cast<dynamic>().ToList();
								break;
							default:
								break;
						}
						var l = new ChangeWindow() { Result = bol };
						var p = new PropertyChangedMessage<ChangeWindow>(null, l, msg);
						Messenger.Default.Send<PropertyChangedMessage<ChangeWindow>>(p);
					});

				}
				return _StartClick;

			}
		}

		private ICommand _SelectTable;

		/// <summary>
		/// Select Wich Table should be shown in HauptFenster
		/// </summary>
		public ICommand SelectTable
		{
			get
			{
				if (_SelectTable == null)
				{
					_SelectTable = new RelayCommand<string>((table) =>
					{
						switch (table)
						{
							case "Kunde":
								msg = "Kunde";
								msg2 = "Kunde";
								SelectedData = GetCustomerTable().Cast<dynamic>().ToList();
								break;
							case "Artikel":
								msg = "Artikel";
								msg2 = "Artikel";
								SelectedData = GetItemTable().Cast<dynamic>().ToList();

								break;
							case "Kategorie":
								msg = "Kategorie";
								msg2 = "Kategorie";
								SelectedData = GetCategoryTable().Cast<dynamic>().ToList();
								break;
							case "Art_Ausgeliehen":
								msg = "Art_Ausgeliehen";
								msg2 = "Art_Ausgeliehen";
								SelectedData = GetItemBorrowedTable().Cast<dynamic>().ToList();
								break;
							default:
								break;
						}
					});

				}
				return _SelectTable;
			}
		}

		/// <summary>
		/// Select Wich Table should be shown in DataPick Datagrid
		/// </summary>
		public dynamic SelectedRowDataPick
		{
			set
			{
				if (value != null)
				{
					switch (msg)
					{
						case "KundeID":
							SelectedCustomer2 = value;
							_SelectedItemBorrowed.KundeID = +SelectedCustomer2.ID;
							RaisePropertyChanged("SelectedItemBorrowed");


							break;
						case "ArtikelID":
							SelectedItem2 = value;
							_SelectedItemBorrowed.ArtikelID = +SelectedItem2.ID;
							RaisePropertyChanged("SelectedItemBorrowed");
							break;
						case "KategorieID":
							SelectedCategory2 = value;
							_SelectedItem.KategorieID = +SelectedCategory2.ID;
							RaisePropertyChanged("SelectedItem");
							break;
						default:
							break;
					}
				}
			}
		}

		private List<dynamic> _SelectedData;
		/// <summary>
		/// ItemSource Binding for Datagrid in HauptFenster
		/// </summary>
		public List<dynamic> SelectedData
		{
			get => _SelectedData;
			set
			{
				_SelectedData = value;
				RaisePropertyChanged("SelectedData");
			}
		}

		private List<dynamic> _SelectedDataPick;
		/// <summary>
		/// ItemSource Binding for Datagrid in PickData
		/// </summary>
		public List<dynamic> SelectedDataPick
		{
			get => _SelectedDataPick;
			set
			{
				_SelectedDataPick = value;
				RaisePropertyChanged("SelectedDataPick");
			}
		}

		/// <summary>
		/// Saves Selected Data From DataGrid HauptFenster
		/// </summary>
		public dynamic SelectedRowData
		{
			set
			{
				if (value != null)
				{
					switch (msg)
					{
						case "Kunde":
							SelectedCustomer = value;
							break;
						case "Artikel":
							SelectedItem = value;
							break;
						case "Kategorie":
							SelectedCategory = value;
							break;
						case "Art_Ausgeliehen":
							SelectedItemBorrowed = value;
							break;
						default:
							break;
					}
				}
				RaisePropertyChanged("SelectedRowDelete");
			}
		}

		/// <summary>
		/// Result for MVVM Messenger(StartClick)
		/// </summary>
		public class ChangeWindow
		{
			public bool? Result { get; set; }
		}

		/// <summary>
		/// Result for MVVM Messenger for Add or Edit SQL Row
		/// </summary>
		public class AddOrEdit
		{
			public bool? Result { get; set; }
		}

		/// <summary>
		/// Result for MVVM Messenger to Delete a SQL Row
		/// </summary>
		public class Delete
		{
			public bool? Result { get; set; }
		}

		#region ClassTable
		public class CustomerTable
		{
			public int ID { get; set; }
			public string Name { get; set; }
			public string Vorname { get; set; }
			public string Strasse { get; set; }
			public string Hausnummer { get; set; }
			public int PLZ { get; set; }
			public string Ort { get; set; }
		}
		public class ItemTable
		{
			public int ID { get; set; }
			public string Bezeichnung { get; set; }
			public int Menge { get; set; }
			public double Leihpreis { get; set; }
			public int KategorieID { get; set; }
		}
		public class CategoryTable
		{
			public int ID { get; set; }
			public string Bezeichnung { get; set; }
		}
		public class ItemBorrowedTable
		{
			public int ID { get; set; }
			public int KundeID { get; set; }
			public int ArtikelID { get; set; }
			public string Abgabedatum { get; set; }
			public string Leihdatum { get; set; }
		}
		#endregion

		#region Delete Row
		private ICommand _DeleteRowCommand;
		//Delete SQL Row
		public ICommand DeleteRowCommand
		{
			get 
			{
				_DeleteRowCommand = new RelayCommand(() =>
				{
					string str;
					bool bol = false;
					SQLCommandViewModel sql = new SQLCommandViewModel();
					switch (msg2)
					{
						case "Kunde":
							str = "Kunde";
							if (sql.DeleteRow(msg2, SelectedCustomer.ID))
							{
								bol = true;
							}
							break;
						case "Artikel":
							str = "Artikel";
							if (sql.DeleteRow(msg2, SelectedItem.ID))
							{
								bol = true;
							}
							break;
						case "Kategorie":
							str = "Kategorie";
							if (sql.DeleteRow(msg2, SelectedCategory.ID))
							{
								bol = true;
							}
							break;
						case "Art_Ausgeliehen":
							str = "Art_Ausgeliehen";
							if (sql.DeleteRow(msg2, SelectedItemBorrowed.ID))
							{
								bol = true;
							}
							break;
						default:
							break;
					}
					var l = new Delete() { Result = bol };
					var p = new PropertyChangedMessage<Delete>(null, l, msg2);
					Messenger.Default.Send<PropertyChangedMessage<Delete>>(p);
					switch (msg2)
					{
						case "Kunde":
							SelectedData = GetCustomerTable().Cast<dynamic>().ToList();
							break;
						case "Artikel":
							SelectedData = GetItemTable().Cast<dynamic>().ToList();
							break;
						case "Kategorie":
							SelectedData = GetCategoryTable().Cast<dynamic>().ToList();
							break;
						case "Art_Ausgeliehen":
							SelectedData = GetItemBorrowedTable().Cast<dynamic>().ToList();
							break;
						default:
							break;
					}

				});
				return _DeleteRowCommand; 
			}

		}
		#endregion

		#region Add Or Edit Customer
		private ICommand _AddOrEditCustomerStart;
		// Add or Edit Customer Row
		public ICommand AddOrEditCustomerStart
		{
			get
			{
				_AddOrEditCustomerStart = new RelayCommand(() =>
				{
					SQLCommandViewModel sql = new SQLCommandViewModel();
					if (sql.AddOrEditKunde(Btn,SelectedCustomer.ID,SelectedCustomer.Name, SelectedCustomer.Vorname,
						SelectedCustomer.Strasse, SelectedCustomer.Hausnummer, SelectedCustomer.PLZ, SelectedCustomer.Ort))
					{
						var l = new AddOrEdit() { Result = true };
						var p = new PropertyChangedMessage<AddOrEdit>(null, l, "AddKunde");
						Messenger.Default.Send<PropertyChangedMessage<AddOrEdit>>(p);
					}
					else
					{
						var l = new AddOrEdit() { Result = false };
						var p = new PropertyChangedMessage<AddOrEdit>(null, l, "AddKunde");
						Messenger.Default.Send<PropertyChangedMessage<AddOrEdit>>(p);
					}
					SelectedData = GetCustomerTable().Cast<dynamic>().ToList();

				});

				return _AddOrEditCustomerStart;
			}
		}

		CustomerTable CT = new CustomerTable();

		private CustomerTable _SelectedCustomer;

		public CustomerTable SelectedCustomer
		{
			get { return CTChange(_SelectedCustomer); }
			set
			{
				_SelectedCustomer = value;
				RaisePropertyChanged("SelectedCustomer");
			}
		}

		private CustomerTable CTChange(CustomerTable value)
		{
			if (value == null)
			{
				CT.ID = 0;
				CT.Name = "";
				CT.Vorname = "";
				CT.Strasse = "";
				CT.Hausnummer = "";
				CT.PLZ = 0;
				CT.Ort = "";
				return _SelectedCustomer = CT;
			}
			else
			{
				return value;
			}
		}
		#endregion

		#region Add Or Edit Item
		private ICommand _AddOrEditItemStart;
		//Add or Edit Item Row
		public ICommand AddOrEditItemStart
		{
			get
			{
				_AddOrEditItemStart = new RelayCommand(() =>
				{
					SQLCommandViewModel sql = new SQLCommandViewModel();
					RaisePropertyChanged("SelectedItem");
					if (sql.AddOrEditArtikel(Btn, SelectedItem.ID, SelectedItem.Bezeichnung, SelectedItem.Menge, SelectedItem.Leihpreis, SelectedItem.KategorieID))
					{
						var l = new AddOrEdit() { Result = true };
						var p = new PropertyChangedMessage<AddOrEdit>(null, l, "AddArtikel");
						Messenger.Default.Send<PropertyChangedMessage<AddOrEdit>>(p);
					}
					else
					{
						var l = new AddOrEdit() { Result = false };
						var p = new PropertyChangedMessage<AddOrEdit>(null, l, "AddArtikel");
						Messenger.Default.Send<PropertyChangedMessage<AddOrEdit>>(p);
					}
					SelectedData = GetItemTable().Cast<dynamic>().ToList();

				});
				return _AddOrEditItemStart;
			}
		}

		ItemTable IT = new ItemTable();

		private ItemTable _SelectedItem;

		public ItemTable SelectedItem
		{
			get { return CTChange(_SelectedItem); }
			set
			{
				_SelectedItem = value;
				RaisePropertyChanged("SelectedItem");
			}
		}

		private ItemTable CTChange(ItemTable value)
		{
			if (value == null)
			{
				IT.ID = 0;
				IT.Bezeichnung = "";
				IT.Menge = 0;
				IT.Leihpreis = 0;
				IT.KategorieID = 0;

				return _SelectedItem = IT;
			}
			else
			{
				return value;
			}
		}

		#endregion

		#region Add Or Edit Category
		private ICommand _AddOrEditCategoryStart;
		// Add or Edit Category Row
		public ICommand AddOrEditCategoryStart
		{
			get
			{
				_AddOrEditCategoryStart = new RelayCommand(() =>
				{
					SQLCommandViewModel sql = new SQLCommandViewModel();
					if (sql.AddOrEditKategorie(Btn, SelectedCategory.ID, SelectedCategory.Bezeichnung))
					{
						var l = new AddOrEdit() { Result = true };
						var p = new PropertyChangedMessage<AddOrEdit>(null, l, "AddKategorie");
						Messenger.Default.Send<PropertyChangedMessage<AddOrEdit>>(p);
					}
					else
					{
						var l = new AddOrEdit() { Result = false };
						var p = new PropertyChangedMessage<AddOrEdit>(null, l, "AddKategorie");
						Messenger.Default.Send<PropertyChangedMessage<AddOrEdit>>(p);
					}
					SelectedData = GetCategoryTable().Cast<dynamic>().ToList();

				});

				return _AddOrEditCategoryStart;
			}
		}

		CategoryTable CategoryT = new CategoryTable();

		private CategoryTable _SelectedCategory;

		public CategoryTable SelectedCategory
		{
			get { return CategoryTChange(_SelectedCategory); }
			set
			{
				_SelectedCategory = value;
				RaisePropertyChanged("SelectedCategory");
			}
		}

		private CategoryTable CategoryTChange(CategoryTable value)
		{
			if (value == null)
			{
				CategoryT.ID = 0;
				CategoryT.Bezeichnung = "";
				return _SelectedCategory = CategoryT;
			}
			else
			{
				return value;
			}
		}
		#endregion

		#region Add Or Edit Item Borrowed

		private ICommand _AddOrEditItemBorrowedStart;
		//Add or Edit Item-Borowed SQL Row
		public ICommand AddOrEditItemBorrowedStart
		{
			get
			{
				_AddOrEditItemBorrowedStart = new RelayCommand(() =>
				{
					SQLCommandViewModel sql = new SQLCommandViewModel();
					if (sql.AddOrEditArt_Ausgeliehen(Btn,SelectedItemBorrowed.ID, SelectedItemBorrowed.KundeID,
						SelectedItemBorrowed.ArtikelID, SelectedItemBorrowed.Abgabedatum, SelectedItemBorrowed.Leihdatum))
					{
						var l = new AddOrEdit() { Result = true };
						var p = new PropertyChangedMessage<AddOrEdit>(null, l, "Art_Ausgeliehen");
						Messenger.Default.Send<PropertyChangedMessage<AddOrEdit>>(p);
					}
					else
					{
						var l = new AddOrEdit() { Result = false };
						var p = new PropertyChangedMessage<AddOrEdit>(null, l, "Art_Ausgeliehen");
						Messenger.Default.Send<PropertyChangedMessage<AddOrEdit>>(p);
					}
					SelectedData =GetItemBorrowedTable().Cast<dynamic>().ToList();

				});

				return _AddOrEditItemBorrowedStart;
			}
		}

		private ItemBorrowedTable _SelectedItemBorrowed;

		public ItemBorrowedTable SelectedItemBorrowed
		{
			get { return ItemBorrowedTChange(_SelectedItemBorrowed); }
			set
			{
				_SelectedItemBorrowed = value;
				RaisePropertyChanged("SelectedItemBorrowed");
			}
		}

		ItemBorrowedTable IBT = new ItemBorrowedTable();


		private ItemBorrowedTable ItemBorrowedTChange(ItemBorrowedTable value)
		{
			if (value == null)
			{
				IBT.ID = 0;
				IBT.ArtikelID = 0;
				IBT.KundeID = 0;
				IBT.Abgabedatum = "";
				IBT.Leihdatum = "";
				
				return _SelectedItemBorrowed = IBT;
			}
			else
			{
				return value;
			}
		}
		#endregion
	}
}