   M S B A M L   `   `   `  ����O  KMedicalOrganizations, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MedicalOrganizationsMedicalOrganizations  5           MedicalOrganizations.Quers   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:MedicalOrganizations     5      ���	#FF1D1D1D.��5	      �   � RowDefinitions  5
   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      .+�5   
   �� $#��Выберите запрос��6   $��20(�6*   �� 5   
   $��1��6   $0��*Введите доп информацию��6   $��20(�6>   �� 5   
   -   5         ��Name$ Filter��5      $��1��6"   $��1��62   $��Center=�6?   $
��15,0q�6Z   $��20(�6h   �� 5   
   -   5         ��Name$ 
ChoseQuery��5      $��1��6'   $��Center=�67   $
��15,0q�6R   $��20(�6`   6n   &   System.Windows.Controls.DataGrid  5   
   -   5        $��QueryDataGrid��5      $��2��6(   $��3��65      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6I   5      5      