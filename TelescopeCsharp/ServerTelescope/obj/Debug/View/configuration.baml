   M S B A M L   `   `   `  ����J  FServerTelescope, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:ServerTelescope.ViewServerTelescope.View  5      G(clr-namespace:ServerTelescope.PropertiesServerTelescope.Properties  5      E'clr-namespace:ServerTelescope.ViewModelServerTelescope.ViewModel  5      (    "ServerTelescope.View.configuration   5      +View"clr-namespace:ServerTelescope.View  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?
properties(clr-namespace:ServerTelescope.Properties     5      6vm'clr-namespace:ServerTelescope.ViewModel     5        � 	Resources  5      3   -ServerTelescope.ViewModel.InitPluginViewModel   InitPluginViewModel4   .ServerTelescope.ViewModel.CoordonneesViewModel  CoordonneesViewModel��%:   &	        &	        5   
   6!     5   
   6"   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��20,10q�6   $��0��6#   $��0��60   *   $ServerTelescope.Properties.Resources   ConfigTitle#��Z 6A   �� 5!   
   $
��20,0q�6   $��1��6#   $��0��61   $
��Wrap=�6D      ConfigPortNumber#��Z 6X   �� 5"   
   $��1��6   $��1��6"   $
��Left=�62   $	��Top=�6�   $	��100��6�   ��6N   �� *IdPort+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 6�   �� 5$   
   $��20,10q�6   $��2��6#   $��0��60      ConfigTitle2#��Z 6A   �� 5%   
   $
��20,0q�6   $��3��6"   $��0��60   $
��Wrap=�6B      ConfigPortSerie#��Z 6V   �� 5&   
   	 �� Orientation$	 
Horizontal=�6   $��3��6.   $��1��6<   .+�5'      �� $	��180��6   ��6$   �� *	ComSource+
 �� SelectedItem
 6F   �� *ComSelected+$ TwoWay=��� 5(      $
��20,0q�6   $
��Left=�6D   $��75��6`      Refresh#��Z 6k   ��6$   �� *SendRefresh+6k   5)      �� 5*   
   $��4��6   $	��200��6      
ConfigSave#��Z 6*   ��6`   �� *SaveCommand++   %ServerTelescope.View.InitPlugInServer  5,   
    � DataContext# [  6    $
��Left=�6S   $��5��6n   $��2��6{   $��20q�6�   &    ServerTelescope.View.Coordonnees  5-   
   # [ 6   $
��Left=�6O   $��6��6j   $��2��6x   $��20q�6�   5.      5/      