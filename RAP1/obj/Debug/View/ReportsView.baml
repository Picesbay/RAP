   M S B A M L   `   `   `  ����?  ;RAP1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:RAP.ViewRAP.View  5   	       RAP.View.ReportsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:RAP.View     5   	     � Title$  Performance Reports��5   	   $
��Auto��6%   $	��520��63   .��5	      �� .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $	��360��6;   $��50��6G   $��Center=�6S   $
��Left=�5      .+�5      !   RAP.View.FilterByReportView  $��0��6'   $��Center=�67   $	��200��6T   $��50,0,0,0q�6`   $	��Top=�5   #   $��49��6;   �� 5      -   5        $��
Copy email��5      $��Right=�6*   $��Bottom=�6F   $��80��6a   $��	20,0,0,15q�6l   $
��Auto��5      6#   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ report��5         AutoGenerateColumns .     
IsReadOnly . $
��Left=�6Q   $	��470��5   M   ��6   ��    	staffList �� Source# [     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Report name��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5   %   �� 	 �� Path$	 PerformanceLabel�  5      $ Performance��6%    5   %   �� $	 PerformancePercentage�  5       $
 Name��6%    5!   %   �� $
	 Name�  5"      $ Email��6%    5#   %   �� $	 Email�5%      5'      5)      