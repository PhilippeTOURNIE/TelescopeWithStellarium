   M S B A M L   `   `   `  ����J  FServerTelescope, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ServerTelescope.PropertiesServerTelescope.Properties  5      %    ServerTelescope.View.TestSerial   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ?
properties(clr-namespace:ServerTelescope.Properties     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $
��20,0q�6   $
��Left=�6   $��0��69   $	��216��6G   *   $ServerTelescope.Properties.Resources   SelectSerialPort#��Z 6S   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $
��Left=�6;   $
��20,5q�6V   .+�5      �� $	��180��6   ��6$   �� *	ComSource+ �� SelectedItem 6F   �� *ComSelected+ �� Mode$ TwoWay=��� 5      $
��20,0q�6   $
��Left=�6D   $��25��6_   $��75��6k      Refresh#��Z 6v   ��6$   �� *SendRefresh+6v   5      �� 5   
   $
��20,0q�6   $
��Left=�6   $��2��69   $	��216��6G      Test#��Z 6S   �� 5   
   $ 
Horizontal=�6   $��3��6.   $
��Left=�6;   $
��20,5q�6V   .+�5      �� $��31��6    �� TextWrapping$
 Wrap=�6$   $	��Top=�6_   $	��180��6w   ��68   �� *
TextSend+$ TwoWay=�6w   �� 5         Send#��Z 6   $��31��6e   $
��20,0q�6r   $	��Top=�6�   $��74��6�   ��6E   �� *SendCommand+6�   5      �� 5    
   	   Listener#��Z	 6   $
��Left=�6C   $��33��6_   $
��20,0q�6k   $��4��6y   $	��Top=�6�   $	��216��6�   �� 5!   
   $��5��6   $��50��6D   $
��20,0q�6P   $	��300��6^   $
��Left=�6j   ��6   �� *RecieveDatas+��5"      �� 5#      .R�5$      �� ��6$   �� 5%      5'      �� 5)   
   
   Save#��Z
 6   $
��Left=�6A   $��31��6|   $��245,20,0,20q�6�   $��6��6�   $��74��6�   ��6\   �� *SendCommand+6�   5+      5,      