   M S B A M L   `   `   `  ����F  BSupermarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Supermarket.ViewModelsSupermarket.ViewModels  5   	   ?$clr-namespace:Supermarket.ConvertersSupermarket.Converters  5   	   #    Supermarket.Views.ProductView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Supermarket.ViewModels     5   	   ;
converters$clr-namespace:Supermarket.Converters     5   	     � Title$  ProductView��5	   	   $	��500��6   $
��1000��6*    � DataContext 5
      &   Supermarket.ViewModels.ProductVM  5   
    � 	Resources 5      0   *Supermarket.Converters.AddProductConverter   addProductConverter1   +Supermarket.Converters.EditProductConverter  editProductConverter/   )Supermarket.Converters.ProductIdConverter  productIdConverter��%W   &	        &	      &	 &       5   
   6)     5   
   6*     5   
   6(   5      .��5      � ��5   
   �� 5       �� ImageSource$# /Images/productBackground.jpg��6   .+�5   
   �� .+�5      �� $��Center=�6   $	��170��65   $	��0 5q�6A   
������� �� TextAlignment$ Center=�6e   $��Consolas)�6|   $��25(�6�   
Products6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   
����ح�$	��600��6x   $��50��6�   .+�5      �� $
��Left=�6   $��
37,15,0,15q�67   $	��100��6K   $��25��6W   $��15(�6c   $��Consolas)�6q   Add product:6�   �� 5      -   5        $��productProducerId��5      $��25��63   $��25��6>   $��
15,10,0,15q�6J   $��Consolas)�6^   �� 5      -   5        $��productCategoryId��5      $��25��63   $��25��6>   $��
15,10,0,15q�6J   $��Consolas)�6^   �� 5      -   5        $��productName��5      $	��100��6-   $��25��69   $��
15,10,0,15q�6E   $��Consolas)�6Y   �� 5      -   5        $��productBarcode��5      $	��100��60   $��25��6<   $��
15,10,0,15q�6H   $��Consolas)�6\   �� 5      $
��Left=�6   $��15,10,15,15q�64   $��Add in database��6I   $	��105��6c   $��25��6o   $��Consolas)�6{   ��6�   �� *
AddCommand+��5      `� 5        `� 	Converter# [  6'   .1�5!      ��  �� ElementName$ productProducerId��6&    �� Path$
 Text�6F   �� 5"      $ productCategoryId��6&   $
 Text�6F   �� 5#      $ productName��6&   $
 Text�6@   �� 5$      $ productBarcode��6&   $
 Text�6C   5%      5'      5(      �� 5)      $ 
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   
����ح�$	��695��6x   $	��300��6�   .+�5*      &   System.Windows.Controls.DataGrid  -   5        $��productsGrid��5*      $��	15,5,0,15q�6/   	   AutoGenerateColumns	 .  $	��390��6^   $	��200��6j   $��Consolas)�6w   $��Visible=�6�   ��6�   �� *ProductsList+
 �� UpdateSourceTrigger$
 PropertyChanged=�   Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 25 69   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6D   �� *Item1+  5-      $ producer__name��6-   $ 96 6E    6P   �� *Item2+  5.      $ category��6-   $ 63 6?    6J   �� *Item3+  5/      $
 name��6-   $	 100 6;    6G   �� *Item4+  50      $ barcode��6-   $	 100 6>    6J   �� *Item5+52      �� 53      $��Center=�6   $��Center=�6:   $	��195��6U   $	��275��6a   .+�54      �� $ 
Horizontal=�6!   
����ح�$	��195��6Q   $��45��6]   .+�55      �� $
��Left=�6$   $��
12,11,0,15q�6?   $��50��6S   $��25��6^   $��15(�6j   $��Consolas)�6x   Id:6�   �� 56      -   5        $��productIdToEdit��56   "   $��75��69   $��25��6D   $��50,0,0,5q�6P   $��Consolas)�6b   57      �� 58      $ 
Horizontal=�6!   
����ح�$	��195��6Q   $��45��6]   .+�59      �� $
��Left=�6$   $��
12,11,0,15q�6?   $	��105��6S   $��25��6_   $��15(�6k   $��Consolas)�6y   Producer Id:6�   �� 5:      -   5        $��productProducerIdToEdit��5:   "   $��75��6A   $��25��6L   $��-5,0,0,5q�6X   $��Consolas)�6j   5;      �� 5<      $ 
Horizontal=�6!   
����ح�$	��195��6Q   $��45��6]   .+�5=      �� $
��Left=�6$   $��
12,11,0,15q�6?   $	��105��6S   $��25��6_   $��15(�6k   $��Consolas)�6y   Category Id:6�   �� 5>      -   5        $��productCategoryIdToEdit��5>   "   $��75��6A   $��25��6L   $��-5,0,0,5q�6X   $��Consolas)�6j   5?      �� 5@      $ 
Horizontal=�6!   
����ح�$	��195��6Q   $��45��6]   .+�5A      �� $
��Left=�6$   $��
12,11,0,15q�6?   $��50��6S   $��25��6^   $��15(�6j   $��Consolas)�6x   Name:6�   �� 5B      -	   5        $��productNameToEdit��5B   "   $��75��6;   $��25��6F   $��50,0,0,5q�6R   $��Consolas)�6d   5C      �� 5D      $ 
Horizontal=�6!   
����ح�$	��195��6Q   $��45��6]   .+�5E      �� $
��Left=�6$   $��
12,11,0,15q�6?   $��70��6S   $��25��6^   $��15(�6j   $��Consolas)�6x   
Barcode:6�   �� 5F      -
   5        $��productBarcodeToEdit��5F   "   $��75��6>   $��25��6I   $��30,0,0,5q�6U   $��Consolas)�6g   5G      �� 5H      $ 
Horizontal=�6!   
����ح�$	��195��6Q   $��50��6]   .+�5I      �� $
��Left=�6!   $��
45,0,15,15q�6<   $
��Edit��6P   $	��105��6_   $��25��6k   $��Consolas)�6w   ��6�   �� *EditProductCommand+��5J      `� 5K   "   # [ 6/   .1�5L   &   �� $ productIdToEdit��6.   $
 Text�6L   �� 5M   &   $ productProducerIdToEdit��6.   $
 Text�6T   �� 5N   &   $ productCategoryIdToEdit��6.   $
 Text�6T   �� 5O   &   $ productNameToEdit��6.   $
 Text�6N   �� 5P   &   $ productBarcodeToEdit��6.   $
 Text�6Q   5Q   #   5S      5T      5U      �� 5V      $��Center=�6   $��Center=�6:   $��90��6U   $	��275��6`   .+�5W      �� $ 
Horizontal=�6!   
����ح�$	��215��6Q   $��45��6]   .+�5X      �� $
��Left=�6$   $��
12,11,0,15q�6?   $��50��6S   $��25��6^   $��15(�6j   $��Consolas)�6x   Id:6�   �� 5Y      -   5        $��productIdToDelete��5Y   "   $��25��6;   $��25��6F   $��	-15,0,0,5q�6R   $��Consolas)�6e   5Z      �� 5[      $ 
Horizontal=�6!   
����ح�$��90��6Q   $��50��6\   .+�5\      �� $
��Left=�6!   $��
10,5,15,15q�6<   $��Delete��6P   $��70��6a   $��25��6l   $��Consolas)�6x   ��6�   �� *DeleteProductCommand+��5]      �� 5^   "   $ productIdToDelete��6*   $
 Text�6J    �� 	Converter# [ 6V   5`      5a      5b      5c      �� 5d      $��Go back��6   $	��150��6'   $��35��63   $
��0 20q�6?   $��Consolas)�6M   $��15(�6c   ��6q   �� *GoBackCommand+5e      5f      5g      