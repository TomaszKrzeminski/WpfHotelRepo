   M S B A M L   `   `   `  ????  ReserveModule"    ReserveModule.Views.AddMeals   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      N JPrism.DryIoc.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=nullS OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  True??5      ??5      ?? *Header+.??5      ?  ? ColumnDefinitions 5	   
   ?? 5
      $	??33* ?6   ?? 5      $	??33* ?6   ?? 5      $	??33* ?6    ? RowDefinitions 5   
   ?? 5      $	??10* ?6   ?? 5      $	??20* ?6   ?? 5      $	??10* ?6   ?? 5      $	??20* ?6   ?? 5      $	??20* ?6   .+?5   
   ?? $??0??6   $??3??6"   $??Stretch=?66    ?? Orientation$ Vertical=?6T   .+?5      ?? $??Center=?6   $??30(?61   .??6?   Wybierz posiłki6P   ? 5       5      ?? 5      $	??33* ?6'   65   ?? 5      $	??33* ?6'   65   ?? 5      $	??33* ?6'   65    5      ?? 5      6'   .+?5!      ?? $??Center=?6   $??0??65   $??0??6B   $??20(?6R   .??6`   
Śniadanie6k   ?? 5"      $??Center=?6   $??0??65   $??1??6B   $??20(?6R   .??6`   Obiad6g   ?? 5#      $??Center=?6   $??0??65   $??2??6B   $??20(?6R   .??6`   	Kolacja6i   5$      5&      &   System.Windows.Controls.DataGrid  5'   
   -   5          Name$ BrakfastList??5'   ?      AutoGenerateColumns$ False??6   $??1??6/   $??0??6<      CanUserAddRows$ false??6?   ??6M   ??  ?? Path$ BreakfastList? ?? SelectedItem 6x   ?? $ SelectedBreakfastList?	   Columns	 5(      0  *System.Windows.Controls.DataGridTextColumn  5)      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 15* 6%      Header$ Nazwa??61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   ?? $
 Name?  5*      $	
 15* 6%   $
 Cena??61    6?   ?? $ Price?4  .System.Windows.Controls.DataGridTemplateColumn  5+       5,      ?? 5-      	Wybierz6-      CellTemplate 5/      ?? 50      .R?51      ?? ??6%   ?? $ DataContext.AddBreakFast? ?? RelativeSource ??  ?? AncestorType"  .??52   f   Dodaj6m   53      55      59        5:   
   -   5        $ 
DinnerList??5:   ?   $ False??6   $??1??6/   $??1??6<   $ false??6?   ??6M   ?? $ 
DinnerList? 6u   ?? $ SelectedDinnerList?	 5;        5<      $	
 15* 6%   $ Nazwa??61    6@   ?? $
 Name?  5=      $	
 15* 6%   $
 Cena??61    6?   ?? $ Price?  5>       5?      ?? 5@      	Wybierz6-    5B      ?? 5C      .R?5D      ?? ??6%   ?? $ DataContext.AddDinner? ?? "  .??5E   f   Dodaj6m   5F      5H      5L        5M   
   -   5        $ 
SupperList??5M   ?   $ False??6   $??1??6/   $??2??6<   $ false??6?   ??6M   ?? $ 
SupperList? 6u   ?? $ SelectedSupperList?	 5N        5O      $	
 15* 6%   $ Nazwa??61    6@   ?? $
 Name?  5P      $	
 15* 6%   $
 Cena??61    6?   ?? $ Price?  5Q       5R      ?? 5S      	Wybierz6-    5U      ?? 5V      .R?5W      ?? ??6%   ?? $ DataContext.AddSupper? ?? "  .??5X   f   Dodaj6m   5Y      5[      5_      ?? 5`   
   $??2??6   $??3??6"   $??Center=?66   $ 
Horizontal=?6S   .+?5a      ?? $	??0,2q?6   $??Stretch=?6!   $??20(?6=   .??6K   	Wybrane6T   ?? 5b      $
??0,10q?63   $??Stretch=?6A   ??6   ?? $ Count?6`   ?? 5c      $
??0,10q?6   $??Stretch=?6#   .??6?   /6B   ?? 5d      $
??0,10q?66   $??Stretch=?6D   ??6   ?? $ CountMax?6b   ?? 5e      $
??0,10q?6   $??Stretch=?6"   .??6>   
Dopłata :6I   ?? 5f      $
??0,10q?63   $??Stretch=?6A   ??6   ?? $ Price?6_   5g        5i   
   -   5        $ BrakfastListChosen??5i   ?   $ False??6   $??3??6/   $??0??6<   $ false??6?   ??6M   ?? $ BreakfastListChosen? 6~   ?? $! SelectedBreakfastListChosen?	 5j        5k      $	
 15* 6%   $ Nazwa??61    6@   ?? $
 Name?  5l      $	
 15* 6%   $
 Cena??61    6?   ?? $ Price?  5n       5o      ?? 5p      Anuluj6,    5r      ?? 5s      .R?5t      ?? ??6%   ?? $! DataContext.RemoveBreakfast? ?? "  .??5u   f   Usuń6l   5v      5x      5{        5|   
   -   5        $ DinnerListChosen??5|   ?      
IsReadOnly$
 True??6   $ False??6%   $??3??6A   $??1??6N   $ false??6?   ??6_   ?? $ DinnerListChosen? 6?   ?? $ SelectedDinnerListChosen?	 5}        5~      $	
 15* 6%   $ Nazwa??61    6@   ?? $
 Name?  5      $	
 15* 6%   $
 Cena??61    6?   ?? $ Price?  5?       5?      ?? 5?      Anuluj6,    5?      ?? 5?      .R?5?      ?? ??6%   ?? $ DataContext.RemoveDinner? ?? "  .??5?   f   Usuń6l   5?      5?      5?        5?   
   -   5        $ SupperListChosen??5?   ?   $
 True??6   $ False??6%   $??3??6A   $??2??6N   $ false??6?   ??6_   ?? $ SupperListChosen? 6?   ?? $ SelectedSupperListChosen?	 5?        5?      $	
 15* 6%   $ Nazwa??61    6@   ?? $
 Name?  5?      $	
 15* 6%   $
 Cena??61    6?   ?? $ Price?  5?       5?      ?? 5?      Anuluj6,    5?      ?? 5?      .R?5?      ?? ??6%   ?? $ DataContext.RemoveSupper? ?? "  .??5?   f   Usuń6l   5?      5?      5?      ?? 5?   
   $??4??6   $??3??6"   $ 
Horizontal=?66   $??Center=?6O   .+?5?      ?? $??0,0,10,0q?6   $??45??6'   $??20(?66   $??Center=?6D   $??Center=?6a   ??6|   ?? $ Reset?.??6?   	Wyczyść6?   ?? 5?      $??45??6   $??20(?6$   $??Center=?62   $??Center=?6O   ??6j   ?? $
 Send?.??6?   
Zatwierdź6?   5?      5?      5?      