   M S B A M L   `   `   `  ����O  KVideothek.Ui.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Videothek.Ui.DesktopVideothek.Ui.Desktop  5      /    )Videothek.Ui.Desktop.Ausgeliehene_Artikel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Videothek.Ui.Desktop     5        � DataContext  5   6   ��    Locator �� Source# [  .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��90 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $	��ID:��6   $��0��6   �� 5   
   $��	Kunde ID:��6   $��1��6$   �� 5   
   $��Artikel ID:��6   $��2��6&   �� 5   
   $��Abgabedatum:��6   $��3��6'   �� 5   
   $��
Leihdatum:��6   $��4��6%   �� 5   
   $��0��6   $��1��6    �� 
IsReadOnly . ��6A   �� *Main.SelectedItemBorrowed.ID+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� 5   
   $��1��6   $��1��6     ButtonContenControl#��[ 6.   $��KundeID��6�   ��6[   �� *Main.StartClick+��5      �� *#!Main.SelectedItemBorrowed.KundeID+$ PropertyChanged=�$ TwoWay=��� 5    
   $��2��6   $��1��6   #��[ 6.   $��	ArtikelID��6   ��6[   �� *Main.StartClick+��5!      �� *%#Main.SelectedItemBorrowed.ArtikelID+$ PropertyChanged=�$ TwoWay=�(  "System.Windows.Controls.DatePicker  5"   
   $��3��6   $��1��6"      Text 62   �� *'%Main.SelectedItemBorrowed.Abgabedatum+$ PropertyChanged=�$ TwoWay=�  5#   
   $��4��6   $��1��6"    62   �� *%#Main.SelectedItemBorrowed.Leihdatum+$ PropertyChanged=�$ TwoWay=��� 5&   
   $��	Abbrechen��6   $��7��6%   $��0��62   $��2��6C   $
��Left=�6W    
 Button#��[ 6r   �� 5'   
   -   5         ��Name$ Ausgeliehene_ArtikelBtn��5'   _   $��7��6�   $��1��6�   $��Right=�6�   #��[ 5(   E   ��5'      �� *
Main.Btn+$ TwoWay=�$ PropertyChanged=���5(      �� *!Main.AddOrEditItemBorrowedStart+6E   5)      5*      