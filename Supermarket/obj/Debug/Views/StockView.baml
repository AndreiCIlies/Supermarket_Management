   M S B A M L   `   `   `  ����F  BSupermarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Supermarket.ViewModelsSupermarket.ViewModels  5   	   ?$clr-namespace:Supermarket.ConvertersSupermarket.Converters  5   	   !    Supermarket.Views.StockView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Supermarket.ViewModels     5   	   ;
converters$clr-namespace:Supermarket.Converters     5   	     � Title$  	StockView��5	   	   $	��550��6   $	��950��6(    � DataContext 5
      $  Supermarket.ViewModels.StockVM  5   
    � 	Resources 5      .   (Supermarket.Converters.AddStockConverter   addStockConverter/   )Supermarket.Converters.EditStockConverter  editStockConverter-   'Supermarket.Converters.StockIdConverter  stockIdConverter��%W   &	        &	      &	 &       5   
   6'     5   
   6(     5   
   6&   5      .��5      � ��5   
   �� 5       �� ImageSource$! /Images/stockBackground.jpg��6   .+�5   
   �� .+�5      �� $��Center=�6   $	��170��65   $	��0 5q�6A   
������� �� TextAlignment$ Center=�6e   $��Consolas)�6|   $��25(�6�   Stocks6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   
����ح�$	��695��6x   $��50��6�   .+�5      �� $
��Left=�6   $��
33,15,0,15q�67   $	��100��6K   $��25��6W   $��15(�6c   $��Consolas)�6q   
Add stock:6�   �� 5      -   5        $��stockProductId��5      $��25��60   $��25��6;   $��	0,10,0,15q�6G   $��Consolas)�6Z   �� 5      -   5        $��stockQuantity��5      $��40��6/   $��25��6:   $��
15,10,0,15q�6F   $��Consolas)�6Z   �� 5      -   5        $��stockSupplyDate��5      $	��100��61   $��25��6=   $��
15,10,0,15q�6I   $��Consolas)�6]   �� 5      -   5        $��stockExpirationDate��5      $	��100��65   $��25��6A   $��
15,10,0,15q�6M   $��Consolas)�6a   �� 5      -   5        $��stockPurchasePrice��5      $��85��64   $��25��6?   $��
15,10,0,15q�6K   $��Consolas)�6_   �� 5      $
��Left=�6   $��15,10,15,15q�64   $��Add in database��6I   $	��105��6c   $��25��6o   $��Consolas)�6{   ��6�   �� *
AddCommand+��5       `� 5!       `� 	Converter# [  6'   .1�5"      ��  �� ElementName$ stockProductId��6&    �� Path$
 Text�6C   �� 5#      $ stockQuantity��6&   $
 Text�6B   �� 5$      $ stockSupplyDate��6&   $
 Text�6D   �� 5%      $ stockExpirationDate��6&   $
 Text�6H   �� 5&      $ stockPurchasePrice��6&   $
 Text�6G   5'      5)      5*      �� 5+      $ 
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   
����ح�$	��910��6x   $	��350��6�   .+�5,      &   System.Windows.Controls.DataGrid  -   5        $��
stocksGrid��5,      $��	15,5,0,15q�6-   	   AutoGenerateColumns	 .  $	��560��6\   $	��200��6h   $��Consolas)�6u   $��Visible=�6�   ��6�   �� *
StocksList+
 �� UpdateSourceTrigger$
 PropertyChanged=�   Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 25 69   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6D   �� *Item1+  5/      $ product��6-   $ 56 6>    6I   �� *Item2+  50      $ quantity��6-   $ 63 6?    6J   �� *Item3+  51      $ supply__date��6-   $ 83 6C    6N   �� *Item4+ �� StringFormat$ {0:dd.MM.yyyy}��  52      $ expiration__date��6-   $	 110 6G    6S   �� *Item5+$ {0:dd.MM.yyyy}��  53      $ purchase__price��6-   $	 110 6F    6R   �� *Item6+  54      $ selling__price��6-   $	 110 6E    6Q   �� *Item7+56      �� 57      $��Center=�6   $��Center=�6:   $	��240��6U   $	��315��6a   .+�58      �� $ 
Horizontal=�6!   
����ح�$	��220��6Q   $��45��6]   .+�59      �� $
��Left=�6$   $��	0,11,0,15q�6?   $��50��6R   $��25��6]   $��15(�6i   $��Consolas)�6w   Id:6�   �� 5:      -   5        $��stockIdToEdit��5:   "   $��75��67   $��25��6B   $��86,0,0,5q�6N   $��Consolas)�6`   5;      �� 5<      $ 
Horizontal=�6!   
����ح�$	��220��6Q   $��45��6]   .+�5=      �� $
��Left=�6$   $��	0,11,0,15q�6?   $	��105��6R   $��25��6^   $��15(�6j   $��Consolas)�6x   Product Id:6�   �� 5>      -   5        $��stockProductIdToEdit��5>   "   $��75��6>   $��25��6I   $��31,0,0,5q�6U   $��Consolas)�6g   5?      �� 5@      $ 
Horizontal=�6!   
����ح�$	��220��6Q   $��45��6]   .+�5A      �� $
��Left=�6$   $��	0,11,0,15q�6?   $	��105��6R   $��25��6^   $��15(�6j   $��Consolas)�6x   	Quantity:6�   �� 5B      -	   5        $��stockQuantityToEdit��5B   "   $��75��6=   $��25��6H   $��31,0,0,5q�6T   $��Consolas)�6f   5C      �� 5D      $ 
Horizontal=�6!   
����ح�$	��220��6Q   $��45��6]   .+�5E      �� $
��Left=�6$   $��	0,11,0,15q�6?   $	��100��6R   $��25��6^   $��15(�6j   $��Consolas)�6x   Supply Date:6�   �� 5F      -
   5        $��stockSupplyDateToEdit��5F   "   $��75��6?   $��25��6J   $��37,0,0,5q�6V   $��Consolas)�6h   5G      �� 5H      $ 
Horizontal=�6!   
����ح�$	��220��6Q   $��45��6]   .+�5I      �� $
��Left=�6$   $��	0,11,0,15q�6?   $	��135��6R   $��25��6^   $��15(�6j   $��Consolas)�6x   Expiration Date:6�   �� 5J      -   5        $��stockExpirationDateToEdit��5J   "   $��75��6C   $��25��6N   $��2,0,0,5q�6Z   $��Consolas)�6k   5K      �� 5L      $ 
Horizontal=�6!   
����ح�$	��220��6Q   $��45��6]   .+�5M      �� $
��Left=�6$   $��	0,11,0,15q�6?   $	��120��6R   $��25��6^   $��15(�6j   $��Consolas)�6x   Selling Price:6�   �� 5N      -   5        $��stockSellingPriceToEdit��5N   "   $��75��6A   $��25��6L   $��18,0,0,5q�6X   $��Consolas)�6j   5O      �� 5P      $ 
Horizontal=�6!   
����ح�$	��220��6Q   $��50��6]   .+�5Q      �� $
��Left=�6!   $��
55,0,15,15q�6<   $
��Edit��6P   $	��105��6_   $��25��6k   $��Consolas)�6w   ��6�   �� *EditStockCommand+��5R      `� 5S   "   # [ 6/   .1�5T   &   �� $ stockIdToEdit��6.   $
 Text�6J   �� 5U   &   $ stockProductIdToEdit��6.   $
 Text�6Q   �� 5V   &   $ stockQuantityToEdit��6.   $
 Text�6P   �� 5W   &   $ stockSupplyDateToEdit��6.   $
 Text�6R   �� 5X   &   $ stockExpirationDateToEdit��6.   $
 Text�6V   �� 5Y   &   $ stockSellingPriceToEdit��6.   $
 Text�6T   5Z   #   5\      5]      5^      �� 5_      $��Center=�6   $��Center=�6:   $��90��6U   $	��275��6`   $��	0,-42,0,0q�6m   .+�5`      �� $ 
Horizontal=�6!   
����ح�$	��215��6Q   $��45��6]   .+�5a      �� $
��Left=�6$   $��
12,11,0,15q�6?   $��50��6S   $��25��6^   $��15(�6j   $��Consolas)�6x   Id:6�   �� 5b      -   5        $��stockIdToDelete��5b   "   $��25��69   $��25��6D   $��	-15,0,0,5q�6P   $��Consolas)�6c   5c      �� 5d      $ 
Horizontal=�6!   
����ح�$��90��6Q   $��50��6\   .+�5e      �� $
��Left=�6!   $��
10,5,15,15q�6<   $��Delete��6P   $��70��6a   $��25��6l   $��Consolas)�6x   ��6�   �� *DeleteStockCommand+��5f      �� 5g   "   $ stockIdToDelete��6*   $
 Text�6H    �� 	Converter# [ 6T   5i      5j      5k      5l      �� 5m      $��Go back��6   $	��150��6'   $��35��63   $
��0 20q�6?   $��Consolas)�6M   $��15(�6c   ��6q   �� *GoBackCommand+5n      5o      5p      