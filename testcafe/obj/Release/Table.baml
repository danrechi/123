   M S B A M L   `   `   `  ����   testcafe    Wpf_cafe.TableWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � WindowStartupLocation$  CenterScreen=� � Title$ Table��$	��500��$	��800��.��� ����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,1&�.���  � Color$ 	LightGray�� � Offset$ 0Q�� $ DarkGray��$ 1Q�.+��� .@��� $
��Food��.��� .+��� 
������� �� CornerRadius$ 5��$��10,10,10,10q�._�� .+�&   System.Windows.Controls.DataGrid  -     Name$ foodDataGrid��   AutoGenerateColumns . 
���   �
���   �$��1q�$	��286��$	��Top=��� $��Center=�$��	0,329,0,0q�$��87��$	��Top=�.+��� $
��Type��$��Center=�	 �� TextAlignment$	 Center=�
���   �$��Bookman Old Style)��� -   
 ��Name$
 foodTypeTextBox��$	��200��$��5q�
���   �
������  �� 
CaretBrush
 �����
���   �$��0,0,0,1q�$��20,0,0,0q�$��Bookman Old Style)��� -   $��Add product��$��5q�
���   ����	#FFF9B769$��Bookman Old Style)�����  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R��� #��z��$ 5��._��� $��Center=�$��Center=��� -   $��Delete product��$��5q�
���   ����	#FFF9B769$��Bookman Old Style)����� " ��.���  � �� �� " ��.R��� #��z��$ 5��._��� $��Center=�$��Center=��� $��Products��.��� .+��� 
�������$ 5��$��10,10,10,-8q�._�� $	��436��$	��Top=�.+�  -   $ productsDataGrid�� . 
���   �
���   �$��1q�$��	0,0,0,150q��� $��Center=�$��	0,376,0,0q�$	��218��$��50��$	��Top=�.+��� -   $��Add product��$��5q�
���   ����	#FFF9B769$��Bookman Old Style)�$	��200������ " ��.���  � �� �� " ��.R��� #��z��$ 5��._��� $��Center=�$��Center=��� -   $��Delete product��$��5q�
���   ����	#FFF9B769$��Bookman Old Style)�$	��200������ " ��.���  � �� �� " ��.R��� #��z��$ 5��._��� $��Center=�$��Center=��� $��Center=�$��	0,350,0,0q�$��41��$	��Top=�.+��  � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $
 productNameTextBox��$	��200��$��5q�
���   �
������ 
 �����
���   �$��0,0,0,1q�$��20,0,0,0q�$��Bookman Old Style)��� -	   $
 productFoodTypeTextBox��$	��200��$��1��$��5q�
���   �
������ 
 �����
���   �$��0,0,0,1q�$��20,0,0,0q�$��Bookman Old Style)��� -
   $
 productPriceTextBox��$	��200��$��2��$��5q�
���   �
������ 
 �����
���   �$��0,0,0,1q�$��20,0,0,0q�$��Bookman Old Style)��� $��Center=�$��	0,302,0,0q� �� Orientation$ 
Horizontal=�$	��630��$��74��$	��Top=�.+�� $��5q� �� $
��Auto �.+��� $
��Name��$��Center=�$	��200��$	 Center=�
���   �$��Bookman Old Style)�� $��5q� �� $
��Auto �.+��� $��FoodType��$��Center=�$	��200��$	 Center=�
���   �$��Bookman Old Style)�� $��5q� �� $
��Auto �.+��� $��Price��$��Center=�$	��200��$	 Center=�
���   �$��Bookman Old Style)�