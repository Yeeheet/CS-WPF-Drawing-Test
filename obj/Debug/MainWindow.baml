   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��29* �6   �� 5      $	��70* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� -   5        $	��txt��5   =   $��0��6   $��25��6   {�.  $��	0,0,270,0q�6H   $��2��6[   �� 5   
   -   5        $��Canvas_1��5      $��1��6�   
�������$��	104,0,0,0q�6�   $��2��6�   .+�5      �� -   5        $��listBox��5      $	��397��6%   $	��101��62    �� SelectionMode$ Single=�6>    �� Left$
 -104��6U   
 �� Top$ -1��6h   6x   �� 5      -   5        $��slider��5      $	 478��6#   $	 -22��65   $��22��6F   $	��210��6R    � Minimum$ 30Q�6�    � Maximum$	 100Q�6�    � SmallChange$ 5Q�6�   	 � LargeChange$	 10Q�6�   
 � Value$
 50Q�6�   �� 5      -   5        $��
TextScroll��5      $��22��6(   $	 426��64    �� TextWrapping$
 Wrap=�6F   $��50��6Z   $	 -22��6d   $��40��6u   �� 5      -   5         ��Name$ ColorPalette��5      $��C��6+   $	 658��67   $	 364��6I   $��20��6Z   6e   5      5      5      