   M S B A M L   `   `   `  ����N  JFileWatchingProgram, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FileWatchingProgramFileWatchingProgram  5   	   (    "FileWatchingProgram.databaseWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:FileWatchingProgram     5   	   -   5          �Name$  	window_db��5   	    � Title$ databaseWindow��5   	   $	��513��6    $	��800��6-   .��5	      �  � RowDefinitions 5
   
   �� 5      $��0* �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   �� 5      $��0* �6   �� 5      $��0* �6   .+�5   
   �� ���	#FFDEDEDE$
��Left=�6%   $	��366��6@   $��	10,96,0,0q�6M   $	��Top=�6`   $	��772��6x   ���	#FFDEDEDE$��1��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ databaseGrid��5      $
��Left=�6)   $	��280��6D   $��
34,156,0,0q�6Q   $	��Top=�6e   $	��724��6}      AutoGenerateColumns .  $��1��6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	File Name��6e      MinWidth$	 100Q�6x   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *
FileName+
   ClipboardContentBinding
 6B   Z� 6x     5      $ 	Extension��6f   $ 40Q�6y   	 6%   �� *	Extension+
 6C   Z� 6y     5      $
 Path��6a   $	 300Q�6o   	 6%   �� *Path+
 6>   Z� 6o     5      $ Event��6b   $ 80Q�6q   	 6%   �� *Event+
 6?   Z� 6q     5      $ Date & Time��6h   $	 150Q�6�   	 6%   �� *DateAndTime+
 6E   Z� 6�   5      �� 5   
   -   5         ��Name$ btn_Refresh��5      $��Refresh��6&   $
��Left=�68   $��683,116,0,0q�6S   $��1��6h   $	��Top=�6u   $��75��6�   $��20��6�   �� 5   
   ���	#FFDEDEDE$
��Left=�6%   $��54��6@   $��	34,16,0,0q�6L   ���	#FFDEDEDE$	��Top=�6r   $	��227��6�   $��1��6�   �� 5    
   -   5         ��Name$ txtblk_QueryTitle��5       $
��Left=�6/   $��16��6J   $��	50,16,0,0q�6V   $
��Wrap=�6i   $��Query Extension��6}   $	��Top=�6�   $	��109��6�   $��1��6�   �� 5!   
   -   5         ��Name$ txtbox_Query��5!      $
��Left=�6(   $��23��6C   $��	50,37,0,0q�6O    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $��88��6�   $��1��6�   �� 5"   
   -   5        $ btn_submitQuery��5"      $��Submit��6*   $
��Left=�6;   $��
169,37,0,0q�6V   $	��Top=�6j   $��75��6�   $��23��6�   $��1��6�   5$      5%      