   M S B A M L   `   `   `  ????K  GNavigationModule, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:NavigationModule.ViewsNavigationModule.Views  5      +    %NavigationModule.Views.ViewNavigation   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:NavigationModule.Views     5      S OPrism.Wpf, Version=7.2.0.1422, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59$prismhttp://prismlibrary.com/  5	      !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel$
  True??5
      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??100* ?6   6,   .+?5   
   ? $??0??6    ? ColumnDefinitions 5      ?? 5      $	??10* ?6#   61   ?? 5      $	??10* ?6#   61   ?? 5      $	??80* ?6#   61   .+?5      ?? $??0??6    ?? Orientation$ 
Horizontal=?6*   $??Center=?6C   $??Center=?6^   .+?5      ?? ??6   ??  ?? Path$
 Home?.??68   Hotel6?   5      ?? 5      $??1??6   $ 
Horizontal=?6)   $??Center=?6B   .+?5      ?? $
??2,10q?67   ??6   ?? $
 Back?.??6E   Back6K   ?? 5      $
??2,10q?69   ??6   ?? $ Foward?.??6H   Foward6P   5      5      5!      5"      