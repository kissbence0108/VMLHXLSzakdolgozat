   M S B A M L   `   `   `  ���� B  >ChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ChatAppChatApp  5clr-namespace:ChatApp.ViewModelChatApp.ViewModel  D @Emoji.Wpf, Version=0.3.3.0, Culture=neutral, PublicKeyToken=null8*clr-namespace:Emoji.Wpf;assembly=Emoji.Wpf	Emoji.Wpf     ChatApp.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:ChatApp     /asdclr-namespace:ChatApp.ViewModel     <emoji*clr-namespace:Emoji.Wpf;assembly=Emoji.Wpf     [ WWPFLocalizeExtension, Version=0.0.0.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  -   4  .WPFLocalizeExtension.Engine.LocalizeDictionary    DesignCulture$  en��=  7WPFLocalizeExtension.Providers.ResxLocalizationProvider   DefaultAssembly$ ChatApp��   DefaultDictionary$ Strings�� � Title$ 
MainWindow��$	��450��$	��800�� � WindowStyle$
 None=� � 
ResizeMode$ CanResizeWithGrip=� � 	Resources    ChatApp.BoolToBrush   BoolToBrushConverter  MyImageSource  Emoji.Wpf.Image   Source��%)   &	        &	        H� $
 👻��.��� .+�� .+�� ���� *
DarkMode+ �� UpdateSourceTrigger$ PropertyChanged=�	 �� 	Converter#	 [  .+�� 
 � ColumnDefinitions
 �� $��* ��� $��60 ��� $��60 ��� $��60 ��� $��5 � � RowDefinitions �� $��5 ��� $��60 ��� $��* �.+��� $��0��$��2��$��5��$��70,0,0,0q����� *SelectedViewModel+�� -    ��Name$ CloseBtn��$��3��$��1��$��40��$��40��$��0q�  	closeBttn#��[ $��10q�����  �� ImageSource$' !Assets/icons8-close-window-96.png���� -   $ DayNightbttn��$��2��$��1��$��40��$��40��$��0q�$��10q����� $ Assets/daynight.png��� -    �Name$ navigationPanel��$
��Left=�$��60������ -   slidebarbckgrnd��$ Assets/greyslidebar.jpg�� j� Stretch$
 None=�
 �� $	��11* ��� $	��49* � �� $��* ��� $
��Auto ��� $
��Auto �.+��� $��0��$��2��.+�� $	��120��.+��� -   $��MenuTextblock��$��1��$��0��$��
75,-20,0,0q�
�������$��20(�
������ $
��Left=�$��Center=�  	fontStyle#��[ ��2  ,WPFLocalizeExtension.Extensions.LocExtension   J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   ShadowDepth$ 1Q�   	Direction$	 -90Q�   Color$ White��d� -    d�Name$ tgglBttn��$��0��$��Center=�$
��Left=�$��
18,-20,0,0q�$��30��$��30��$��0q�  toggleButtonStyle#��[ ���� $ Assets/tgBtn_default.png��$
 Fill=� � Triggers :�  :� RoutedEvent$ ToggleButton.Unchecked��.[��� .���� -    ��Name$ HideStackPanel��.��W�  �� 
TargetName$ navigationPanel�� �� TargetProperty$ Width� g� 	BeginTime	 0:0:0 W� From 150	 W� To 60 g� Duration$ 0:0:0.2D�:� $ ToggleButton.Checked��.[��� .���� -	   $ ShowStackPanel��.��W� $ navigationPanel��$ Width�	 0:0:0 60 150$ 0:0:0.2D��� -
    ��Name$ listView��
������ 
������ $��Disabled=�.@��� -   $
��Left=�$��0,0,0,20q�.����   �� Orientation$  
Horizontal=�$	��230��.+��� $ ��Assets/icons8-house-96.png��$
��Fill=�$��5,0,0,0q�$��42��$��42��$��Stretch=�! J� InputBindings! d� " d� Gesture$" 	LeftClicka�# �� CommandParameter$
# Home��$ �� Command$ �� *UpdateViewCommand+�� -   $��HomeTextBlock��$��25,0,0,0q�#��[ ��  % � ToolTip% _� -   & _�Name$& tooltip_home��$
��Home��  	tltpStyle#��[ �� -   $
��Left=�$��0,0,0,20q�.���� $  
Horizontal=�$	��230��.+��� $#��Assets/icons8-messages-96.png��$
��Fill=�$��5,0,0,0q�$��42��$��42��! d� $" 	LeftClicka�$# Messages��$ �� *UpdateViewCommand+�� -   $��MessagesTextBlock��$��25,0,0,0q�#��[ ��  % _� -   $& tooltip_messages��$��Messages��#��[ �� -   $
��Left=�$��0,0,0,20q�.���� $  
Horizontal=�$	��230��.+��� $$��Assets/icons8-pie-chart-96.png��$
��Fill=�$��5,0,0,0q�$��42��$��42��! d� $" 	LeftClicka�$# Graphs��$ �� *UpdateViewCommand+�� -   $��GraphsTextBlock��$��25,0,0,0q�#��[ ��  % _� -   $& tooltip_graphs��$��Graphs��#��[ 