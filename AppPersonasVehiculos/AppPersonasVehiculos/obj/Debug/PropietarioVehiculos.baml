   M S B A M L   `   `   `  ����O  KAppPersonasVehiculos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AppPersonasVehiculosAppPersonasVehiculos  5      /    )AppPersonasVehiculos.PropietarioVehiculos   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:AppPersonasVehiculos     5        N� Title$  Propietario - Vehiculos��5	      .��5
      � $��10,10,10,10q�6   ��5   
   �� 5       �� ImageSource$ watermark.png��6   67    � ColumnDefinitions 5   
   �� 5      $	��230 �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��1��6      headerTextStyle#��[  6    .��6I   Reporte de Vehiculos6_   � 5   
   $��1��6   $��1��6   $��10q�6,    5      �� 5      �� 5       5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      .+�5!      �� $��0��6   $��0��6)   $��2��67    �� Orientation$ 
Horizontal=�6K   .+�5"      ��   
labelStyle#��[ 6   .��6<   Nombre6D   �� 5#      #��[ 6   ��6<   ��  �� XPath$ @Nombre��6`   5$      �� 5%      $��0��6   $��1��6)   $��2��67   $ 
Horizontal=�6K   .+�5&      �� #��[ 6   .��6<   Departamento6J   �� 5'      #��[ 6   ��6<   �� $ @Departamento��6f   5(      � 5)      $��0��6   $��2��6#   $��2��60   $	��Top=�6D   $
��Left=�6\    � 	Resources 5*        placaItemTemplate  anioItemTemplate��%�   &	       &	 C     �� 5+      .R�5,      �� ��6    �� $ @Placa��5-      �� 5.      .R�5/      �� ��6    �� $ @Anio��50      51      .+�52      &   System.Windows.Controls.DataGrid    columnHeaderStyle   ColumnHeaderStyle# [ 6      AutoGenerateColumns .  	   RowHeaderWidth$	 0Q�6n   ��6�   �� $ Vehiculo��
   Columns
 53      0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ Placa��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� $ @Placa��  55      $
 Año��6-    6:   �� $ @Anio��57      58      59      5:      5;      