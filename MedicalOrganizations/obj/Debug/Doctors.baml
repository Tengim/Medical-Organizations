   M S B A M L   `   `   `  ����O  KMedicalOrganizations, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:MedicalOrganizationsMedicalOrganizations  5      "    MedicalOrganizations.Doctors   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:MedicalOrganizations     5      .��5	      �   � RowDefinitions  5
   
   �� 5      -   5         ��Name$ 	ButtonRow��5      $
��50px �6/   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� -   5         ��Name$	 Add��5      $��0��6   $��Добавить��6.      CustomButtonStyle#��[  6A   6l   �� 5   
   -   5        $	 Del��5      $��1��6   $��Удалить��6.   #��[  6@   6k   �� 5   
   -   5        $	 Upd��5      $��2��6   $��Изменить��6.   #��[  6A   6l   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DoctorDataGrid��5      $��1��6+   $��4��68   ���	#FF1D1D1D
���   �
���   �   AutoGenerateColumns .  $
��Left=�6�   $	��800��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Доктор��6%      
IsReadOnly . 	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6�   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6�     5      $  Специализация��6%    . $	 * 6�   
 6<   �� *Specialization+$ PropertyChanged=�6�     5      $ Степень��6%    . $	 * 6�   
 66   �� *Degree+$ PropertyChanged=�6�     5      $ Больница��6%    . $	 * 6�   
 67   �� *
Hospital+$ PropertyChanged=�6�     5      $ Поликлиника��6%    . $	 * 6�   
 6:   �� *
Policlinic+$ PropertyChanged=�6�   5      5      5       