   M S B A M L   `   `   `  ����B  >WpfApp5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp5WpfApp5  5   	       WpfApp5.BookWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp5     5   	     � Title$  
BookWindow��5   	   $	��400��6   $	��500��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��185* �6   �� 5      $
��316* �6   .+�5   
   �� $��Название��6   $
��Left=�6#   $��	68,35,0,0q�6>   $	��Top=�6Q   �� 5   
   $��
Автор��6   $
��Left=�6    $��	68,72,0,0q�6;   $	��Top=�6N   $��62��6f   �� 5   
   $��Жанр��6   $
��Left=�6   $��
68,124,0,0q�6:   $	��Top=�6N   �� 5   
   $!��Год публикации��6   $
��Left=�6)   $��
68,174,0,0q�6D   $	��Top=�6X   �� 5   
   $S��MМеждународный стандартный 
книжный номер��6   $
��Left=�6L   $��
68,220,0,0q�6g   $	��Top=�6{   $��2��6�   �� 5   
   $,��&Количество на складе��6   $
��Left=�6/   $��
68,272,0,0q�6J   $	��Top=�6^   $��2��6v   �� 5   
   -   5        $��Добавить��5   +   $
��Left=�6>   $��
24,323,0,0q�6Y   $	��Top=�6m   $��40��6�   $	��110��6�   $��1��6�   �� 5   
   -   5         ��Name$ NameBbox��5      $
��Left=�6$   $��	80,35,0,0q�6?    �� TextWrapping$
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��120��6�   $��1��6�   �� 5   
   -   5        $ 	Authorbox��5      $
��Left=�6%   $��	80,72,0,0q�6@   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��120��6�   $��1��6�   �� 5   
   -   5        $ Genrebox��5      $
��Left=�6$   $��
80,124,0,0q�6?   $
 Wrap=�6S   $�� ��6g   $	��Top=�6o   $	��120��6�   $��1��6�   �� 5   
   -   5        $ 
Publishbox��5      $
��Left=�6&   $��
80,178,0,0q�6A   $
 Wrap=�6U   $�� ��6i   $	��Top=�6q   $	��120��6�   $��1��6�   �� 5   
   -   5        $ ISBNbox��5      $
��Left=�6#   $��
80,232,0,0q�6>   $
 Wrap=�6R   $�� ��6f   $	��Top=�6n   $	��120��6�    J� RenderTransformOrigin$ 
-0.23,0.57&�6�   $��1��6�   �� 5   
   -   5        $ Quantitybox��5      $
��Left=�6'   $��
80,276,0,0q�6B   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��120��6�   $��1��6�   5      5      