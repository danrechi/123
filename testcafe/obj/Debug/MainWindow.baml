   M S B A M L   `   `   `  ����  testcafe    Wpf_cafe.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � WindowStartupLocation$  CenterScreen=�5   	    � Title$ Log In��5   	   $	��200��6   $	��300��6%   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5	      �  � Color$ 	#FFFF6F00��6    � Offset$ 0Q�61   � 5
      $ 	#FFFFA705��6   $ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��	Username:��6   
���   �$
��Left=�5      $��Center=�5      $��10q�5      $��Bookman Old Style)�6   �� 5   
   -   5         ��Name$ usernameTextBox��5      $��1��5      $��Stretch=�5       $��Center=�5!      $��10q�5"      
���   �	 �� 
CaretBrush
	 �����
���   �$��0,0,0,1q�5&      $��20,0,0,0q�5'      $��Bookman Old Style)�6!   .��6@   ��5)      �� 5*      
 �� ImageSource$
 /Image/user-icon.png��6    j� Stretch$
 None=�5+       j� 
AlignmentX$
 Left=�5,      .��5-   "   5.      �� 50   
   $��	Password:��6   $��1��51      
���   �$
��Left=�53      $��Center=�54      $��10q�55      $��Bookman Old Style)�6   G� 56   
   -   5         G�Name$ passwordBox��56      $��1��57      $��1��58      $��Stretch=�59      $��Center=�5:      $��10q�5;      
���   � G� 
CaretBrush
 �����
���   �$��0,0,0,1q�5?      $��20,0,0,0q�5@      $��Bookman Old Style)�6)   ��5A      �� 5B      $
 /Image/key-icon.png��6   $
 None=�5C      $
 Left=�5D      5G      �� 5H   
   -   5         ��Name$ loginButton��5H      $��Log In��5I      
���   ����	#FFF9B769$��Bookman Old Style)�5L      $��2��5M      $��2��5N      $��Center=�5O      $��Center=�5P      $��75��5Q      $��10q�5R      ��5T      �� 5U       �� 
TargetType" ��6   .�5V      ��  �� Property � �� �� Value 5W      �� 5X       �� 
TargetType" ��6.   .R�5Y   "   �� #��z��6)    �� CornerRadius$ 5��5Z   )   ._�5[   &   �� $��Center=�67   $��Center=�5\   7   5]   #   5^      5`      5a      5c      5d      5e      