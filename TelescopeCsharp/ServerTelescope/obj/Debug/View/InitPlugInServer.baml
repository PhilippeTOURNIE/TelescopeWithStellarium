   M S B A M L   `   `   `  ����J  FServerTelescope, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ServerTelescope.PropertiesServerTelescope.Properties  5      G(clr-namespace:ServerTelescope.ConvertersServerTelescope.Converters  5      +    %ServerTelescope.View.InitPlugInServer   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?
properties(clr-namespace:ServerTelescope.Properties     5      9conv(clr-namespace:ServerTelescope.Converters     5      .��5
      �   � 	Resources  5   
   4   .ServerTelescope.Converters.ValidationConverter   ValidationConverter��%   &	          5      6'   5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $
��Left=�6   $��0��6,   $	��216��6:   *   $ServerTelescope.Properties.Resources   InitPlugInServerTitle#��Z 6F   � 5   
   $��1��6    5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6     � ColumnDefinitions 5      �� 5      �� 5      �� 5       �� 5!      �� 5"      �� 5#      .+�5&      �� $��0��6   $��0��6)      InitPlugInServerService#��Z 66   $��10q�6u   �� 5'      $��1��6   $��0��6)      InitPlugInServerStart#��Z 66   $��10q�6s   �� 5(      $��2��6   $��0��6)      InitPlugInServerStop#��Z 66   $��10q�6r   �� 5)      $��3��6   $��0��6)      InitPlugInServerStatus#��Z 66   $��10q�6t   �� 5*      $��4��6   $��0��6)       InitPlugInClientConnected#��Z 66   $��10q�6w   �� 5+      $��5��6   $��0��6)   	   InitPlugInInit#��Z	 66   $��10q�6l   �� 5-      $��0��6   $��1��6)   !
   InitPlugInServerStellarium#��Z
 66   $��10q�6x   �� 5.      $��0��6   $��2��6)       InitPlugInServerTelescope#��Z 66   $��10q�6w   �� 50      $��10q�6   $��1��6!   $��1��6.   $��start��6^   ��6>   �� *StartServer+6^   �� 51      $��10q�6   $��1��6!   $��2��6.   $
��stop��6]   ��6>   �� *
StopServer+6]   �� 52      $��10q�6   $��2��6!   $��1��6.   $��start��6a   ��6>   �� *StartSerialCom+6a   �� 53      $��10q�6   $��2��6!   $��2��6.   $
��stop��6`   ��6>   �� *StopSerialCom+6`   �� 55      $��25��6   $��25��6   $��10q�6+   $��1��68   $��3��6E   ��6U   �� *StatusServer+ �� 	Converter# [  �� 56      $��25��6   $��25��6   $��10q�6+   $��2��67   $��3��6D   ��6T   �� *StatusSerial+# [  �� 58      $��25��6   $��25��6   $��10q�6+   $��1��68   $��4��6E   ��6U   �� *ClientConnectedServer+# [  �� 59      $��25��6   $��25��6   $��10q�6+   $��2��67   $��4��6D   ��6T   �� *ClientConnectedSerial+# [  �� 5;      $��10q�6   $��1��6!   $��5��6.   $��2��6>      InitPlugInServerSetInit � ToolTip# Z 6O      InitPlugInServerSet#��Z 6�   ��6�   �� *SetInitServer+5=      5?      5E      5F      