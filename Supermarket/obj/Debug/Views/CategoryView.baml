   M S B A M L   `   `   `  ����F  BSupermarket, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Supermarket.ViewModelsSupermarket.ViewModels  5   	   ?$clr-namespace:Supermarket.ConvertersSupermarket.Converters  5   	   $    Supermarket.Views.CategoryView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Supermarket.ViewModels     5   	   ;
converters$clr-namespace:Supermarket.Converters     5   	     � Title$  CategoryView��5	   	   $	��450��6   $	��800��6+    � DataContext 5
      '  !Supermarket.ViewModels.CategoryVM  5   
    � 	Resources 5      4   .Supermarket.Converters.CategoryIdNameConverter   categoryIdNameConverter0   *Supermarket.Converters.CategoryIdConverter  categoryIdConverter2   ,Supermarket.Converters.CategoryNameConverter  categoryNameConverter��%W   &	        &	      &	 &       5   
   6-     5   
   6)     5   
   6+   5      .��5      � ��5   
   �� 5       �� ImageSource$$ /Images/categoryBackground.jpg��6   .+�5   
   �� .+�5      �� $��Center=�6   $	��170��65   $	��0 5q�6A   
������� �� TextAlignment$ Center=�6e   $��Consolas)�6|   $��25(�6�   
Categories6�   �� 5       �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   
����ح�$	��410��6x   $��50��6�   .+�5      �� $
��Left=�6   $��
15,15,0,15q�67   $	��110��6K   $��25��6W   $��15(�6c   $��Consolas)�6q   Add category:6�   �� 5      -   5        $��categoryName��5      $	��135��6.   $��25��6:   $��
15,10,0,15q�6F   �� 5      $
��Left=�6   $��15,10,15,15q�64   $��Add in database��6I   $	��105��6c   $��25��6o   $��Consolas)�6{   ��6�   �� *
AddCommand+��5      �� 5       �� ElementName$ categoryName��6"    �� Path$
 Text�6=    �� 	Converter# [ 6I   5      5       �� 5!      $ 
Horizontal=�6   $��Center=�62   $��0,10,0,0q�6O   
����ح�$	��580��6x   $	��250��6�   .+�5"      &   System.Windows.Controls.DataGrid  -   5        $��categoriesGrid��5"      $��
15,15,0,15q�61   	   AutoGenerateColumns	 .  $	��175��6a   $	��200��6m   $��Consolas)�6z   $��Visible=�6�   ��6�   �� *CategoriesList+
 �� UpdateSourceTrigger$
 PropertyChanged=�   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 25 69   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6D   �� *Item1+  5%      $
 name��6-   $	 150 6;    6G   �� *Item2+5'      �� 5(      $��Center=�6   $��Center=�6:   $��12,0,0,0q�6U   $	��200��6g   $	��220��6s   .+�5)      �� $ 
Horizontal=�6!   $	��215��6:   $��45��6F   .+�5*      �� $
��Left=�6$   $��
12,11,0,15q�6?   $��50��6S   $��25��6^   $��15(�6j   $��Consolas)�6x   Id:6�   �� 5+      -   5        $��categoryIdToEdit��5+   "   $��75��6:   $��25��6E   $��-5,0,0,5q�6Q   $��Consolas)�6c   5,      �� 5-      $ 
Horizontal=�6!   $	��215��6:   $��45��6F   .+�5.      �� $
��Left=�6$   $��
12,11,0,15q�6?   $��50��6S   $��25��6^   $��15(�6j   $��Consolas)�6x   Name:6�   �� 5/      -   5        $��categoryNameToEdit��5/   "   $��75��6<   $��25��6G   $��-5,0,0,5q�6S   $��Consolas)�6e   �� 50      $��	5,5,15,10q�6!   $
��Edit��64   $��45��6C   $��25��6N   $��Consolas)�6Z   ��6p   �� *EditCategoryNameCommand+��51      `� 52   "    `� 	Converter# [  6/   .1�53   &   �� $ categoryIdToEdit��6.   $
 Text�6M   �� 54   &   $ categoryNameToEdit��6.   $
 Text�6O   55   #   57      58      �� 59      $ 
Horizontal=�6!   
����ح�$	��215��6Q   $��45��6]   .+�5:      �� $
��Left=�6$   $��
12,11,0,15q�6?   $��50��6S   $��25��6^   $��15(�6j   $��Consolas)�6x   Id:6�   �� 5;      -   5        $��categoryIdToDelete��5;   "   $��75��6<   $��25��6G   $��-5,0,0,5q�6S   $��Consolas)�6e   �� 5<      $��	5,5,15,10q�6!   $��Delete��64   $��45��6E   $��25��6P   $��Consolas)�6\   ��6r   �� *DeleteCategoryCommand+��5=      �� 5>   "   $ categoryIdToDelete��6*   $
 Text�6K   # [ 6W   5@      5A      5B      �� 5C      $��Center=�6   $	��170��68   $	��220��6D   .+�5D        -   5        $%��producersProductsCategoriesGrid��5D      $��1,8,0,15q�6F   	 .  $	��155��6t   $	��200��6�   $��Consolas)�6�   $��Visible=�6�   ��6�   �� *CategoriesValuesList+$
 PropertyChanged=� 5E        5F      $ category__name��61   $ 95 6I    6T   �� *Item1+  5G      $ value��61   $ 43 6@    6K   �� *Item2+5I      5J      5K      �� 5L      $��Go back��6   $	��150��6'   $��35��63   $
��0 20q�6?   $��Consolas)�6M   $��15(�6c   ��6q   �� *GoBackCommand+5M      5N      5O      