   M S B A M L   `   `   `  ����O  KAppPersonasVehiculos, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:AppPersonasVehiculosAppPersonasVehiculos  5      *    $AppPersonasVehiculos.PaginaPrincipal   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:AppPersonasVehiculos     5        N� Title$  PaginaPrincipal��5	      .��5
      � $��
10,6,10,14q�6    � 	Resources 5   
      nombreItemTemplate �� XPath  PropietariosSource � XPath��%  &	        &	 D     �� 5      .R�5      �� ��6   �� $ @Nombre��5      � 5      $ Propietarios��69   .��5      �	�<Propietarios xmlns="">
                        <Propietario Nombre="Juan" Departamento="Guatemala">
                            <Vehiculo Placa="P-654987" Anio="2012"></Vehiculo>
                            <Vehiculo Placa="P-987654" Anio="2014"></Vehiculo>
                        </Propietario>
                        <Propietario Nombre="Luis" Departamento="Coban">
                            <Vehiculo Placa="P-654987" Anio="2012"></Vehiculo>
                            <Vehiculo Placa="P-987654" Anio="2014"></Vehiculo>
                        </Propietario>
                        <Propietario Nombre="Melisa" Departamento="Peten">
                            <Vehiculo Placa="P-654987" Anio="2010"></Vehiculo>
                            <Vehiculo Placa="P-987654" Anio="2011"></Vehiculo>
                            <Vehiculo Placa="P-321654" Anio="2016"></Vehiculo>
                        </Propietario>
                        <Propietario Nombre="Raul" Departamento="Zacapa">
                            <Vehiculo Placa="P-654987" Anio="2012"></Vehiculo>
                        </Propietario>
                    </Propietarios>        5$      5%       � ColumnDefinitions 5&   
   �� 5'      $	��230 �6   �� 5(       � RowDefinitions 5*   
   �� 5+      �� 5,      $
��auto �6   �� 5-      �� 5.      $
��auto �6   ��50   
   �� 51       �� ImageSource$ watermark.png��6   .+�53   
   �� $��1��6     headerTextStyle#��[ 6    .��6I   Reporte propietarios6_   �� 54   
   $��1��6   $��1��6!     listHeaderStyle#��[ 6.   ._�55      ��   listHeaderTextStyle#��[ 6   .��6A   Name6G   56      �� 57   
   -   5        $��propietariosListBox��57   �   #��[  6j   $��1��6�   $��2��6�   ��6   ��  �� Source# [ $ Propietario��6�   �� 58   
   -   5        $��1��58   *   $��3��6:     buttonStyle#��[ 6G   .��6m   	Vehiculos6x   5:      5;      