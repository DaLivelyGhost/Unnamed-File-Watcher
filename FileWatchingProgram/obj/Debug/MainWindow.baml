   M S B A M L   `   `   `  ����N  JFileWatchingProgram, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:FileWatchingProgramFileWatchingProgram  5   	   $    FileWatchingProgram.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:FileWatchingProgram     5   	   -   5          �Name$  window_main��5   	    � Title$ 
MainWindow��5   	   $	��552��6   $	��800��6)   .��5	      � $��0,0,2,-2q�6   $��Right=�6   $	��790��69   $	��513��6E   $��Bottom=�6R   .+�5
   
   �� -   5         ��Name$ txtbox_DirectoryInput��5
      $
��Left=�61   $��24��6L   $��
28,103,0,0q�6X    �� TextWrapping$
 Wrap=�6l   $	��Top=�6�   $	��184��6�    J� 	AllowDrop .  6�   �� 5   
   -   5         ��Name$ txtblk_EnterADirectory��5      $
��Left=�64   $��	28,83,0,0q�6O   $
��Wrap=�6b   $��Enter a Directory:��6v   $	��Top=�6�   �� 5   
   -   5         ��Name$ 	btn_Apply��5      $��Apply��6$   $
��Left=�64   $	��Top=�6O   $��80��6g   $��400,103,0,0q�6r   $��24��6�    � Cursor$
 Hand��6�   {�.  6�   �� 5   
   -   5        $ txtbox_ExtensionInput��5      $
��Left=�61   $��24��6L   $��282,103,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $��61��6�   �� 5   
   -   5        $ txtblk_Extension��5      $
��Left=�6.   $��
282,83,0,0q�6I   $
��Wrap=�6]   $��
Extension:��6q   $	��Top=�6�   o� 5   
   -   5         o�Name$ mnu_MainMenu��5      $
��Left=�6%   $��28��6@   $	��Top=�6L   $	��780��6d   $��10,3,0,0q�6p   .@�5      m� -   5        	 m�Name$	 mnuitm_File��5      $��_File��6,   $��28��6;   $��31��6G   .@�5      m� -	   5        $	 mnuitm_Start��5      $��Start��61   $
��Left=�6@   $��18��6[   $	��230��6g   $��27,0,-145,0q�6s   $��Center=�6�   m� 5      -
   5        $	 mnuitm_Stop��5      $
��Stop��60   $
��Left=�6>   $��20��6Y   $	��230��6e   $��27,0,-117,0q�6q   $��Center=�6�   m� 5      -   5        $	 mnuitm_Query��5      $��Query Database��61   $
��Left=�6I   $��18��6d   $	��230��6p   $��Center=�6|   $��	0,0,-90,0q�6�   6�   m� 5      -   5        $	 mnuitm_Close��5      $��Close��61   $��18��6@   $	��230��6L   $��Center=�6s   $
��Left=�6�   $��	0,0,-90,0q�6�   5      m� 5      -   5        $	 mnuitm_Edit��5      $��_Edit��6,   $��28��6;   $��36��6G   6R   m� 5      -   5        $	 mnuitm_Help��5      $��_Help��6,   $��28��6;   $��39��6G   .@�5      m� -   5        $	 mnuitm_About��5      $��About��61   $
��Left=�6@   $��18��6[   $	��141��6g   $��0,0,-1,0q�6s   6�   m� 5      -   5        $	 mnuitm_Shortcuts��5      $��	Shortcuts��65   $
��Left=�6H   $��18��6c   $	��140��6o   6{   5      5      �� 5   
   ���	#FFE6E6E6$
��Left=�6%   $��52��6@   $��	10,83,0,0q�6L   
�������$	��Top=�6n   $	��489��6�   
 K� ZIndex$
 -1��6�   �� 5   
   ���	#FFE6E6E6$
��Left=�6%   $	��304��6@   $��
10,191,0,0q�6M   
�������$	��Top=�6p   $	��770��6�   $
 -1��6�   �� 5   
   -   5        $ 	btn_Start��5      $��Start��6$   $
��Left=�64   $	��Top=�6O   $��75��6g   $��
29,202,0,0q�6r   $
 Hand��6�   {�.  6�   �� 5   
   -   5        $ btn_Stop��5      $
��Stop��6#   $
��Left=�62   $	��Top=�6M   $��75��6e   $��137,202,0,0q�6p   $
 Hand��6�   {�.  6�   �� 5    
   -   5        $ txtblk_Status��5       $
��Left=�6+   $��
29,170,0,0q�6F   $
��Wrap=�6Z   $	��Top=�6n   $	��470��6�   &   System.Windows.Controls.DataGrid  5!   
   -   5          Name$ dataGrid��5!      $
��Left=�6%   $	��235��6@   $��
29,241,0,0q�6M   $	��Top=�6a   $	��732��6y      GridLinesVisibility$ 
Horizontal=�6�      AutoGenerateColumns .     Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ 	File Name��6e      MinWidth$	 100Q�6x   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
FileName+   ClipboardContentBinding 6B   Z� 6x     5$      $ 	Extension��6f   $ 30Q�6y    6%   �� *	Extension+ 6C   Z� 6y     5%      $
 Path��6a   $	 315Q�6o    6%   �� *Path+ 6>   Z� 6o     5&      $ Event��6b   $	 100Q�6q    6%   �� *Event+ 6?   Z� 6q     5'      $ 	Date/Time��6h   $	 150Q�6{    6%   �� *DateAndTime+ 6E   Z� 6{   5)      c� 5*   
   $
��Left=�6   $��47��6-   $��	10,31,0,0q�69   $	��Top=�6L   $	��780��6d   ���	#FFF0F0F0.@�5+      �� -   5        $ tlbr_startbtn��5+      $��15��6,   $��15��68   $
��10,0q�6^    � ToolTip$ Begin the file watch��6l   {�.  ��5,      �� 5-       �� ImageSource$ 	Start.png��6!    J� Effect 5/      3  -System.Windows.Media.Effects.DropShadowEffect  50         
BlurRadius$ 2Q�6'      Color$ 	#FF1C4859��66      Opacity$	 0.4Q�6H      ShadowDepth$ 2Q�6V   52      �� 53      -   5        $ tlbr_stopbtn��53      $��15��6+   $��15��67   $
��10,0q�6B   $ End the file watch��6P   {�.   54        55      $ 2Q�6'   $	 0.4Q�66   $ 2Q�6D   ��57      �� 58      $ Stop.png��6!    j� Stretch$ Uniform=�68   5:      �� 5;      �� 5<      -   5        $ tlbr_OpenDatabase��5<      $ Opens the database window��6P   $
��0,10q�6t   $	��116��6�   .��5=      ��  �� Orientation$ 
Horizontal=�6   .+�5>      �� $��Database.png��6   �� 5?      $��  Database View��6    5@      5A      �� 5B      �� 5C      -   5        $ tlbr_exitbtn��5C      $��27��6+   $��0,10,0,5q�67   $��59��6I   $ Exit the program��6o    J� RenderTransformOrigin$ 2.565,1.324&�6�   .��5D      �� $ 
Horizontal=�6   .+�5E      �� $��Exit.png��6   �� 5F      $��  Exit ��6    5G      5H      5I      �� 5J   
   -   5        $ 
btn_commit��5J      $��Commit to Database��6%   $
��Left=�6B   $��607,202,0,0q�6]   $	��Top=�6r   $	��154��6�   {�.  $( "Commit current results to database��6�   ��6�   Z� 6�   5K      5L      