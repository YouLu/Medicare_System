   M S B A M L   `   `   `  ����Z  VMedicalSystem.Pf.UIControl.Form, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullzVclr-namespace:MedicalSystem.Pf.UIControl.Form;assembly=MedicalSystem.Pf.UIControl.FormMedicalSystem.Pf.UIControl.Form  5      v rInfragistics3.Windows.DataPresenter.v7.1, Version=7.1.20071.2001, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb�bclr-namespace:Infragistics.Windows.DataPresenter;assembly=Infragistics3.Windows.DataPresenter.v7.1"Infragistics.Windows.DataPresenter 5
   5   $  MedicalSystem.Pf.MainScreen.Form1   +MedicalSystem.Pf.MainScreen.Form.MainScreen   5      W SPresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    8x,http://schemas.microsoft.com/winfx/2006/xaml    5      �MedicalSystem_Pf_UIControl_FormVclr-namespace:MedicalSystem.Pf.UIControl.Form;assembly=MedicalSystem.Pf.UIControl.Form    5      JCustom;http://schemas.microsoft.com/winfx/2006/xaml/composite-font   5      <d2http://schemas.microsoft.com/expression/blend/2006   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6B   mmybclr-namespace:Infragistics.Windows.DataPresenter;assembly=Infragistics3.Windows.DataPresenter.v7.1   5
   5   -   5          � Title$  MEDICALSYSTEM��5	       � WindowStyle$
 None=�6   $��Stretch=�6/    � WindowStartupLocation$ CenterScreen=�6M   
�������$	��768��5
      $
��1024��6    � 
ResizeMode$ NoResize=�6    � 	Resources 5      ��%    5      .��5      � -   5        $��grid1��5      $	��768��6   $
��1024��6%   
������� � RowDefinitions 5   
   �� 5      $
��459* �6   �� 5      $
��118* �6   �� 5      $��0* �6   .+�5   
   �� -   5        $��image1��5      $
��Fill=�6   $��Images\BackGroundImg.jpg��6-   $��
-22,0,0,-8q�6O   $��3��6c   � 5   
   -   5        $��grid2��5      
������ $��	-14,0,0,0q�65   $��2��6H    5      �� 5      $
��640* �6    �� 5      $
��128* �6    .+�5      1   +MedicalSystem.Pf.UIControl.Form.SubMenuArea  -   5          Name$ subMenuArea��5   :   $
��Left=�6O   $��21,107,0,111q�6j   $	��154��6�   $��2��6�   � 5      -   5        $��GridSubScreen��5   +   $��195,107,20,111q�6   
������ $��2��6Y   6l   4   .MedicalSystem.Pf.UIControl.Form.GlobalMenuArea  5       -   5          Name$ globalMenuArea��5    =   $��43��6U   $	��Top=�6a   $��	14,58,0,0q�6y   1   +MedicalSystem.Pf.UIControl.Form.MessageArea  5!      -   5          Name$ messageArea��5!   :   $��1��6O   $��47��6\   $��Bottom=�6h   $��14,0,0,0q�6�   5   /MedicalSystem.Pf.UIControl.Form.FunctionKeyArea  5"      -	   5        	  Name$	 functionKeyArea��5"   >   $��1��6W   $��
14,26,0,46q�6d   5#      0   *MedicalSystem.Pf.UIControl.Form.HeaderArea  5$   
   -
   5        
  Name$
 
headerArea��5$   5   $��49��6I   $	��Top=�6U   $��0,10,0,0q�6m   5%      5&      