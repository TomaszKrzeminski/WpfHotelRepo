   M S B A M L   `   `   `  ????  ReserveModule'    !ReserveModule.Views.AddActivities   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      N JPrism.DryIoc.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=nullS OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  True??5      ??5      ?? *Header+.??5      ?  ? ColumnDefinitions 5	   
   ?? 5
      $	??50* ?6   ?? 5      $	??50* ?6    ? RowDefinitions 5   
   ?? 5      $	??10* ?6   ?? 5      $??5* ?6   ?? 5      $??5* ?6   ?? 5      $	??20* ?6   ?? 5      $	??20* ?6   .+?5   
   ?? $??0??6   $??2??6"   $??Center=?66   .+?5      ?? $??40(?6   .??6"   Wybierz dodatkowe aktywności6@   5      ?? 5   
   $??1??6   $??2??6"   $
??Left=?66    ?? Orientation$ 
Horizontal=?6Q   .+?5      ?? $??20(?6   .??6"   
Dodano :6-   ?? 5      $??20(?67   ??6   ??  ?? Path$ 	ListCount?6G   5      ?? 5   
   $??2??6   $??2??6"   $
??Left=?66   $ 
Horizontal=?6Q   .+?5      ?? $??20(?6   .??6"   Cena :6+   ?? 5      $??20(?63   ??6   ?? $ Price?6C   5       &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ Added??5!   ?      
IsReadOnly$
 True??6      AutoGenerateColumns$ False??6%   $??3??6A   $??0??6N      CanUserAddRows$ false??6?   ??6_   ?? $ ActivitiesList?	 ?? SelectedItem	 6?   ?? $ Selected?
   Columns
 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 20* 6%      Header$ Nazwa??61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   ?? $ 
ActivityID?  5$      $	 20* 6%   $ Nazwa??61    6@   ?? $
 Name?  5%      $	 20* 6%   $
 Cena??61    6?   ?? $ Price?  5&      $	 20* 6%   $
 Cena??61    6?   ?? $ Description?4  .System.Windows.Controls.DataGridTemplateColumn  5'      $	 20* 6)    5(      ?? 5)      	Wybierz6-      CellTemplate 5+      ?? 5,      .R?5-      ?? ??6%   ?? $ DataContext.AddActivity? ?? RelativeSource ??  ?? AncestorType"  .??5.   f   Dodaj6m   5/      51      55        56   
   -   5        $ Removed??56   ?   $
 True??6   $ False??6%   $??3??6A   $??1??6N   $ false??6?   ??6_   ?? $ AddedActivitiesList?	 6?   ?? $ 	SelectedA?
 57        58      $	 20* 6%   $ Nazwa??61    6@   ?? $ 
ActivityID?  59      $	 20* 6%   $ Nazwa??61    6@   ?? $
 Name?  5:      $	 20* 6%   $
 Cena??61    6?   ?? $ Price?  5;      $	 20* 6%   $
 Cena??61    6?   ?? $ Description?  5<      $	 20* 6)    5=      ?? 5>      Anuluj6,    5@      ?? 5A      .R?5B      ?? ??6%   ?? $  DataContext.RemoveActivity? ?? "  .??5C   f   Usuń6l   5D      5F      5J      ?? 5K   
   $
??0,10q?6   $??4??6#   $ 
Horizontal=?60   $??Center=?6I   $	??Top=?6f   $??1??6~   .+?5L      ?? $??0,0,10,0q?6   ??6'   ?? $ Reset?.??6F   	Wyczyść6O   ?? 5M      ??6   ?? $
 Send?.??63   
Zatwierdź6>   5N      5Q      5R      