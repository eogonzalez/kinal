   M S B A M L   `   `   `  ����W  SInterfazWPFCentralTelefonica, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:InterfazWPFCentralTelefonicaInterfazWPFCentralTelefonica  5   	   7    1InterfazWPFCentralTelefonica.FormularioTelefonico   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:InterfazWPFCentralTelefonica     5   	     � Title$  FormularioTelefonico��5   	   $��315.79��6&   $��322.557��66   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��100* �6   �� 5      $
��227* �6    � ColumnDefinitions 5   
   �� 5      $
��137* �6   �� 5      $
��155* �6   .+�5   
   �� -   5         ��Name$ imgCompania��5      $
��Left=�6%   $��72��6@   $��10,5,0,0q�6L   $	��Top=�6^   $	��117��6v   � 5   
   $
��Left=�6   $	��144��6*   $��	10,10,0,0q�67   $��1��6J   $	��Top=�6W   $	��117��6o    5      �� 5      $	��25* �6    �� 5      $	��25* �6    �� 5      $	��25* �6    �� 5      $	��25* �6    �� 5      $	��25* �6    .+�5      �� -   5         ��Name$ lblNumeroOrigen��5   !   $��0��6   $��Numero Origen:��6:   $
��Left=�6S   $��10,0,0,0q�6n   $	��Top=�6�   $��97��6�   �� 5      -   5        $ lblNumeroDestino��5   !   $��1��6   $��Numero Destino:��6;   $
��Left=�6U   $��10,0,0,0q�6p   $	��Top=�6�   $��97��6�   �� 5      -   5        $ lblDuracion��5   !   $��2��6   $��
Duración:��66   $
��Left=�6J   $��10,0,0,0q�6e   $	��Top=�6w   $��97��6�   �� 5      -   5        $ lblTipoLlamada��5   !   $��3��6   $��Tipo Llamada��69   $
��Left=�6P   $��10,0,0,0q�6k   $	��Top=�6}   $��97��6�   �� 5      -   5        $ 	lblFranja��5   !   $��4��6   $��Label��64   $
��Left=�6D   $��10,0,0,0q�6_   $	��Top=�6q   $��97��6�   5       � 5!   
   $��1��6   $
��Left=�6   $	��144��6:   $��	10,10,0,0q�6G   $��1��6Z   $	��Top=�6g   $	��153��6    5"      �� 5#      $	��25* �6    �� 5$      $	��25* �6    �� 5%      $	��25* �6    �� 5&      $	��25* �6    �� 5'      $	��25* �6    .+�5)      �� -   5         ��Name$ txtNumeroOrigen��5)   #   $��0��6   $
��Left=�6<   $��23��6W   $��0,2,0,0q�6c    �� TextWrapping$
 Wrap=�6t   $	��Top=�6�   $	��142��6�   �� 5*      -   5        $ txtNumeroDestino��5*   #   $��1��6   $
��Left=�6=   $��23��6X   $��0,2,0,0q�6d   $
 Wrap=�6u   $	��Top=�6�   $	��142��6�   �� 5+      -	   5        $ txtDuracion��5+   #   $��2��6   $
��Left=�68   $��23��6S   $��0,3,0,0q�6_   $
 Wrap=�6p   $	��Top=�6�   $	��142��6�   	� 5-      -
   5         	�Name$ rbtLocal��5-   '   $��3��6   $��Local��69   $
��Left=�6I   $��	10,10,0,0q�6d   $	��Top=�6x   	� 5.      -   5        $ rbtDepto��5.   '   $��3��6   $��Depto��69   $
��Left=�6I   $��	90,10,0,0q�6d   $	��Top=�6x   �� 5/      -   5         ��Name$ 	cmbFranja��5/      $
��Left=�6*   $��0,3,0,0q�6E   $��4��6V   $	��Top=�6c   $	��142��6{   .@�50      �� $��Seleccionar��6   �� 51      $��1��6   �� 52      $��2��6   �� 53      $��3��6   54      57      �� 58   
   -   5        	 ��Name$	 btnRegistrar��58      $��	Registrar��6'   $��1��6;   $
��Left=�6K   $��
49,166,0,0q�6f   $��1��6z   $	��Top=�6�   $��75��6�   $��20��6�   �� 59   
   -   5        $ lblCompañia��59      $��	Compañia��6%   $��1��68   $
��Left=�6H   $��	22,44,0,0q�6c   $	��Top=�6v   $��33��6�   $��87��6�   $��16(�6�   $
��Bold"�6�   5;      5<      