   M S B A M L   `   `   `  ����  
TypeMaster%    TypeMaster.Views.StatisticsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5         BackgroundBrush#��[  5      $��20q�5      .��5      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��0��6   $��Статистика��5      $��18(�5      $
��Bold"�5      $
��Left=�5      &   System.Windows.Controls.DataGrid  5   
   $��1��6      AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         
IsReadOnly$
 True��5      $
��0,10q�5      ��5      �� *
Statistics+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Дата��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Date+ �� StringFormat$ dd.MM.yyyy HH:mm��  5      $	 WPM��6%    62   �� *WordsPerMinute+  5      $ Ошибки��6%    65   �� *Errors+  5      $ Словарь��6%    66   �� *DictionaryName+5      �� 5!   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5"      �� $��Экспорт в CSV��6   $��0,0,10,0q�6O   ��6-   �� *ExportCommand+6O   �� 5#      $��
Назад��6   ��6-   �� *BackCommand+5$      5%      5&      