   M S B A M L   `   `   `  ????H  DReserveModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ReserveModule.ViewsReserveModule.Views  5      %    ReserveModule.Views.ShowSummary   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:ReserveModule.Views     5      N JPrism.DryIoc.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=nullS OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5	      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  True??5
      .??5      ? 
??????? ? RowDefinitions 5   
   ?? 5      6    ? ColumnDefinitions 5   
   ?? 5      $	??50* ?6   6-   ?? 5      $??1* ?6   6,   ?? 5      $	??49* ?6   6-   .+?5   
   ?? $??2??6   $??Center=?5      $??Stretch=?5      
???   ? ?? ShowsPreview$
 True??5      $??1??5       ? 5&   
   $??0??6   $??0??6    5'      ?? 5(      $	??50* ?6#   61   ?? 5)      $	??50* ?6#   61    5+      ?? 5,      $??5* ?6    6.   ?? 5-      $	??50* ?6    6/   ?? 5.      $	??10* ?6    6/   .+?51      ?? $??0??6   $??40(?6!   $??4??6/   $??Center=?6C   .??6`   Podsumowanie Rezerwacji53      ?? 54   
   $??1??6   $??0??6"    ?? Orientation$ Vertical=?62   .+?55      ?? $??20(?6   .??6"   Imię6(   ?? 56      $??20(?6   .??6"   
Nazwisko6,   ?? 57      $??20(?6   .??6"   Pesel6)   ?? 58      $??20(?6   .??6"   OD6&   ?? 59      $??20(?6   .??6"   Do6&   ?? 5:      $??20(?6   .??6"   
Liczba Dni6.   ?? 5;      $??20(?6   .??6"   	Nr pokoju6-   ?? 5<      $??20(?6   .??6"   Koszt pokoju60   ?? 5=      $??20(?6   .??6"   Dodatkowy koszt posiłków6<   ?? 5>      $??20(?6   .??6"   Dodatkowy koszt aktywności6>   ?? 5?      $??20(?6   .??6"   Całkowity koszt63   5@      ?? 5A   
   $??1??6   $??1??6"   .+?5B      ?? $??20(?6<   ??6   ??  ?? Path$ model.UserName?6L   ?? 5C      $??20(?6?   ??6   ?? $ model.UserSurname?6O   ?? 5D      $??20(?6B   ??6   ?? $ model.PersonalNumber?6R   ?? 5E      $??20(?6=   ??6   ?? $ model.From.Date?6M   ?? 5F      $??20(?6;   ??6   ?? $ model.To.Date?6K   ?? 5G      $??20(?68   ??6   ?? $ 
model.Days?6H   ?? 5H      $??20(?6?   ??6   ?? $ model.room.RoomID?6O   ?? 5I      $??20(?6>   ??6   ?? $ model.room.Price?6N   ?? 5J      $??20(?6B   ??6   ?? $ model.ActivitiesCost?6R   ?? 5K      $??20(?6=   ??6   ?? $ model.MealsCost?6M   ?? 5L      $??30(?6>   ??6   ?? $ model.FinalCost?6N   5M      ?? 5N   
   $??2??6   $??3??6"   $??Center=?66   .+?5O      ?? $??20(?6   ??6'   ?? $ ReserveRoom?.??6L   
Zatwierdź6W   5P      5R      ? 5S   
   $??0??6   $??2??6    5T      ?? 5U      $	??50* ?6#   61   ?? 5V      $	??50* ?6#   61    5X      ?? 5Z      6#   .+?5^      &   System.Windows.Controls.DataGrid  -   5          Name$ SupperListChosen??5^   }      AutoGenerateColumns$ False??6   $??0??65   $??0??6B      CanUserAddRows$ false??6?   ??6S   ?? $ model.meals?	   Columns	 5_      0  *System.Windows.Controls.DataGridTextColumn  5`      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 15* 6)      Header$ Nazwa??65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   ?? $
 Name?  5a      $	
 15* 6)   $
 Cena??65    6C   ?? $ Price?5c        5e      -   5        $ Removed??5e   ?   $ False??6   $??0??63   $??1??6@   $ false??6?   ??6Q   ?? $ model.activities?	 5f        5g      $	
 20* 6)   $ Nazwa??65    6D   ?? $ 
ActivityID?  5h      $	
 20* 6)   $ Nazwa??65    6D   ?? $
 Name?  5i      $	
 20* 6)   $
 Cena??65    6C   ?? $ Price?  5j      $	
 20* 6)   $
 Cena??65    6C   ?? $ Description?5o      5r      5t      5u      