   M S B A M L   `   `   `  ����O  KMedicalOrganizations, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MedicalOrganizationsMedicalOrganizations  5   	   )    #MedicalOrganizations.PatcientInsert   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:MedicalOrganizations     5   	     � Title$  PatcientInsert��5   	   $	��500��6    $	��800��6-   ���	#FF1D1D1D.��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      $
��0.6* �6    � ColumnDefinitions 5   
   �� 5      $
��0.4* �6   �� 5      .+�5   
   �� $��Пациент��6   �� 5   
   $��1��6   $��Болезнь��6   �� 5   
   $��2��6   $%��Дата Поступления��6   �� 5   
   $��3��6   $��Лечащий врач��6   �� 5   
   -   5         ��Name$
 Name��5      $��1��6    $
��10,0q�60   $��Center=�6>      CustomBlock#��[  6Z   $��20(�6   �� 5   
   -   5         ��Name$ Bolezn��5      $��1��6#   $��1��63   $��Center=�6@   $
��10,0q�6[   $��20(�6i   �� 5   
   -   5        $ Vrema_P��5      $��1��6#   $��2��63   $
��10,0q�6@   $��Center=�6N   #��[  6j   $��20(�6�   �� 5   
   -   5        $ Doctor��5      $��1��6#   $��3��63   $��Center=�6@   $
��10,0q�6[   $��20(�6i   � 5   
   $��1��6   $��4��6   $
��10,0q�6,    5      �� 5      �� 5       .+�5"      �� -   5        $��Потвердить��5"      $��0,8,3,8q�6*   $��20(�6;     CustomButtonStyle#��[ 6I   6t   �� 5#      -   5        $��Отмена��5#      $	��0,8q�6&   $��1��63   $��20(�6C   #��[ 6Q   6|   5$      5%      5&      