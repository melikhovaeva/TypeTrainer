   M S B A M L   `   `   `  ����  
TypeMaster#    TypeMaster.Views.SettingsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5         BackgroundBrush#��[  5      $��20q�5      .��5      �� .+�5   
   �� $��Настройки��6   $��18(�5      $
��Bold"�5	      $��0,0,0,10q�5
      �� 5   
     �� Orientation$  
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� $ ��Размер шрифта:��6   $��Center=�6.   �� 5      $	��200��6    � Minimum$ 10Q�6!    � Maximum$ 30Q�6.   $
��10,0q�5       � Value 5      �� *Settings.FontSize+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      $��Center=�5      $
��10,0q�5      ��5      �� *Settings.FontSize+ �� StringFormat$ N0��5      5      �� 5   
   $  
Horizontal=�6   $��0,0,0,20q�6.   .+�5      �� $'��!Длина теста (слов):��6   $��Center=�63   �� 5      $��60��6   $
��10,0q�5      ��5      �� *Settings.TestLengthWords+$ PropertyChanged=�5      5      �� 5   
   $  
Horizontal=�6   $��Center=�6.   .+�5      �� $��Сохранить��6   $��0,0,10,0q�6I   ��6)   �� *SaveCommand+6I   �� 5      $��
Назад��6   ��6)   �� *BackCommand+5       5!      5"      