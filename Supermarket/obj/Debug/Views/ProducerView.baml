   M S B A M L   `   `   `  ����F  BSupermarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Supermarket.ViewModelsSupermarket.ViewModels  5   	   ?$clr-namespace:Supermarket.ConvertersSupermarket.Converters  5   	   $    Supermarket.Views.ProducerView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Supermarket.ViewModels     5   	   ;
converters$clr-namespace:Supermarket.Converters     5   	     � Title$  ProducerView��5	   	   $	��450��6   $	��900��6+    � DataContext 5
      '  !Supermarket.ViewModels.ProducerVM  5   
    � 	Resources 5      ;   5Supermarket.Converters.ProducerCountryIdNameConverter "  producerCountryIdNameConverter4   .Supermarket.Converters.ProducerIdNameConverter  producerIdNameConverter0   *Supermarket.Converters.ProducerIdConverter  producerIdConverter��%W   &	        &	      &	 &       5   
   64     5   
   6-     5   
   6)   5      .��5      � ��5   
   �� 5       �� ImageSource$$ /Images/producerBackground.jpg��6   .+�5   
   �� .+�5      �� $��Center=�6   $	��170��65   $	��0 5q�6A   
������� �� TextAlignment$ Center=�6e   $��Consolas)�6|   $��25(�6�   	Producers6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   
����ح�$	��410��6x   $��50��6�   .+�5      �� $
��Left=�6   $��
15,15,0,15q�67   $	��107��6K   $��25��6W   $��15(�6c   $��Consolas)�6q   Add producer:6�   �� 5      -   5        $��producerCountryId��5      $��25��63   $��25��6>   $��
15,10,0,15q�6J   �� 5      -   5        $��producerName��5      $	��105��6.   $��25��6:   $��
15,10,0,15q�6F   �� 5      $
��Left=�6   $��15,10,15,15q�64   $��Add in database��6I   $	��105��6c   $��25��6o   $��Consolas)�6{   ��6�   �� *
AddCommand+��5      `� 5       `� 	Converter# [  6'   .1�5      ��  �� ElementName$ producerCountryId��6&    �� Path$
 Text�6F   �� 5       $ producerName��6&   $
 Text�6A   5!      5#      5$      �� 5%      $ 
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   
����ح�$	��857��6x   $	��250��6�   .+�5&      &   System.Windows.Controls.DataGrid  -   5        $��producersGrid��5&      $��
15,15,0,15q�60   	   AutoGenerateColumns	 .  $	��175��6`   $	��200��6l   $��Consolas)�6y   $��Visible=�6�   ��6�   �� *ProducersList+
 �� UpdateSourceTrigger$
 PropertyChanged=�   Columns 5'      0  *System.Windows.Controls.DataGridTextColumn  5(      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 25 69   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6D   �� *Item1+  5)      $ id__country��6-   $ 75 6B    6M   �� *Item2+  5*      $
 name��6-   $	 100 6;    6G   �� *Item3+5,      �� 5-      $��Center=�6   $��Center=�6:   $	��185��6U   $	��220��6a   .+�5.      �� $ 
Horizontal=�6!   
����ح�$	��215��6Q   $��45��6]   .+�5/      �� $
��Left=�6$   $��
12,11,0,15q�6?   $��50��6S   $��25��6^   $��15(�6j   $��Consolas)�6x   Id:6�   �� 50      -   5        $��producerIdToEdit��50   "   $��75��6:   $��25��6E   $��-5,0,0,5q�6Q   $��Consolas)�6c   51      �� 52      $ 
Horizontal=�6!   
����ح�$	��215��6Q   $��45��6]   .+�53      �� $
��Left=�6$   $��
12,11,0,15q�6?   $��80��6S   $��25��6^   $��15(�6j   $��Consolas)�6x   Name:6�   �� 54      -   5        $��producerNameToEdit��54   "   $��75��6<   $��25��6G   $��	-35,0,0,5q�6S   $��Consolas)�6f   �� 55      $��	5,5,15,10q�6!   $
��Edit��64   $��45��6C   $��25��6N   $��Consolas)�6Z   ��6p   �� *EditProducerNameCommand+��56      `� 57   "   # [ 6/   .1�58   &   �� $ producerIdToEdit��6.   $
 Text�6M   �� 59   &   $ producerNameToEdit��6.   $
 Text�6O   5:   #   5<      5=      �� 5>      $ 
Horizontal=�6!   
����ح�$	��215��6Q   $��45��6]   .+�5?      �� $
��Left=�6$   $��
12,11,0,15q�6?   $��50��6S   $��25��6^   $��15(�6j   $��Consolas)�6x   Id:6�   �� 5@      -   5        $��producerIdToDelete��5@   "   $��75��6<   $��25��6G   $��-5,0,0,5q�6S   $��Consolas)�6e   �� 5A      $��	5,5,15,10q�6!   $��Delete��64   $��45��6E   $��25��6P   $��Consolas)�6\   ��6r   �� *DeleteProducerCommand+��5B      �� 5C   "   $ producerIdToDelete��6*   $
 Text�6K    �� 	Converter# [ 6W   5E      5F      5G      �� 5H      $��Center=�6   $	��310��68   $	��220��6D   .+�5I        -   5        $%��producersProductsCategoriesGrid��5I      $��	-5,8,0,15q�6F   	 .  $	��295��6u   $	��200��6�   $��Consolas)�6�   $��Visible=�6�   ��6�   �� *!ProducersProductsCategoriesList+$
 PropertyChanged=� 5J        5K      $ producer__name��61   $ 95 6I    6T   �� *Item1+  5L      $ product__name��61   $ 88 6H    6S   �� *Item2+  5M      $ category__name��61   $ 95 6I    6T   �� *Item3+5O      5P      �� 5Q      $��
-10,11,0,0q�6   $	��185��61   .+�5R      �� $ 
Horizontal=�6!   
����ح�$	��180��6Q   $��45��6]   .+�5S      �� $
��Left=�6$   $��
12,11,0,15q�6?   $	��115��6S   $��25��6_   $��15(�6k   $��Consolas)�6y   	Producer:6�   �� 5T      -   5        $��producerNameForShow��5T   #   $��75��6>   $��25��6I   $��	-35,0,0,5q�6U   $��Consolas)�6h   ��6~   �� *ActiveProducersList+$
 PropertyChanged=� �� SelectedItem 6�   �� *SelectedProducer+$
 PropertyChanged=�5U      �� 5V      $��Center=�6!   
����ح�$	��180��6S   $��45��6_   .+�5W      �� $��
20,5,15,10q�6!   $
��Show��65   $��45��6D   $��25��6O   $��Consolas)�6[   ��6q   �� *(&ShowProducersProductsCategoriesCommand+5X      5Y      5Z      �� 5[      $��Go back��6   $	��150��6'   $��35��63   $
��0 20q�6?   $��Consolas)�6M   $��15(�6c   ��6q   �� *GoBackCommand+5\      5]      5^      