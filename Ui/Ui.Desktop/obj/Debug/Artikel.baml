   M S B A M L   `   `   `  ����O  KVideothek.Ui.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Videothek.Ui.DesktopVideothek.Ui.Desktop  5      "    Videothek.Ui.Desktop.Artikel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Videothek.Ui.Desktop     5        � DataContext  5   7   ��    Locator �� Source# [  .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��90 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $	��ID:��6   $��0��6   �� 5   
   $��Bezeichnung:��6   $��1��6'   �� 5   
   $��Menge:��6   $��2��6!   �� 5   
   $��
Leihpreis:��6   $��3��6%   �� 5   
   $��
Kategorie:��6   $��4��6%   �� 5   
   $��0��6   $��1��6    �� 
IsReadOnly . ��6A   �� *Main.SelectedItem.ID+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� 5   
   $��1��6   $��1��6   ��6/   �� *Main.SelectedItem.Bezeichnung+$ PropertyChanged=�$ TwoWay=��� 5   
   $��2��6   $��1��6   ��6/   �� *Main.SelectedItem.Menge+$ PropertyChanged=�$ TwoWay=��� 5    
   $��3��6   $��1��6   ��6/   �� *Main.SelectedItem.Leihpreis+$ PropertyChanged=�$ TwoWay=� �� StringFormat$ N2���� 5"   
   $��4��5#      $��1��6     ButtonContenControl#��[ 5$      $��KategorieID��5%   5   ��5"      �� *Main.SelectedItem.KategorieID+$ PropertyChanged=�$ TwoWay=���5%      �� *Main.StartClick+65   �� 5'   
   $��	Abbrechen��6   $��7��6%   $��0��62   $��2��6C   $
��Left=�6W    
 Button#��[ 6r   �� 5(   
   -   5         ��Name$ 
ArtikelBtn��5(      $��7��6%   $��1��62   $��Right=�6B   #��[ 6^   ��5)      �� *
Main.Btn+$ PropertyChanged=�$ TwoWay=���5*      �� *Main.AddOrEditItemStart+5+      5,      