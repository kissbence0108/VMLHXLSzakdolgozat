   M S B A M L   `   `   `  ���� B  >ChatApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ChatAppChatApp      ChatApp.View.Login   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:ChatApp     [ WWPFLocalizeExtension, Version=0.0.0.0, Culture=neutral, PublicKeyToken=c726e0262981a1eb2lex(http://wpflocalizeextension.codeplex.com  -   4  .WPFLocalizeExtension.Engine.LocalizeDictionary    DesignCulture$  en��=  7WPFLocalizeExtension.Providers.ResxLocalizationProvider   DefaultAssembly$ ChatApp��   DefaultDictionary$ Strings�� � Title$ Login��$	��450��$	��600�� � WindowStyle$
 None=�
������  � AllowsTransparency$
 True��.���� ���#363a40 �� CornerRadius$ 20��._��  � ColumnDefinitions �� $	��100 ��� $��* ��� $	��300 ��� $��* ��� $	��100 � � RowDefinitions �� $��30 ��� $��30 ��� $��50 ��� $��30 ��� $��50 ��� $��30 ��� $��50 ��� $��50 ��� $��50 ��� $��50 �.+��� -   $��LogintextTextBlock��$��Center=�$
��Left=�$��0��$��0��$��2��$��2��$��12,0,0,0q�$��Dosis)�   	fontStyle#��[  ��2  ,WPFLocalizeExtension.Extensions.LocExtension  �� -   $��UsernameTextblock��$��Center=�$��Center=�$��2��$��1��$��Dosis)�#��[  ��  �� $��2��$��2��.+��� 	 �� Orientation$	 
Horizontal=�$��Center=�$��Center=�.+��� -   
 ��Name$
 	LoginUser��$��20(�$��Center=�$��Center=�
�������$��2��$��2�����#363a40$��Dosis)�$��0q�$	��250��$��Center=� J� Opacity$	 0.5Q�$��25������ *
Username+ �� Mode$ TwoWay=��� $	��100��$��2��
�������$	 0.5Q��� -   $��PasswordTextBlock��$��Center=�$��Center=�$��2��$��3��$��#Dosis)�#��[  ��  �� $��4��$��2��.+��� $	 
Horizontal=�$��Center=�$��Center=�.+�G� -    G�Name$ LoginPasswordBox��$��20(�$��Center=�$��Center=�
�������$��2��$��4�����#363a40$��Dosis)�$��0q�$	��250��$��Center=�$	 0.5Q�$��25���� $	��100��$��2��
�������$	 0.5Q��� -   $��ConnectionTextblock��$��Center=�$��Center=�$��2��$��5��$��Dosis)�#��[  ��  �� -    ��Name$ btnTestConnection��$��Center=�$��Center=�$��2��$��6��$	��120��$��40��$��Dosis)���  ���� *TestConnectionCommand+�� -	   $ btnLogin��$��Center=�$��Center=�$��2��$��7��$	��120��$��40��$��Dosis)���  ���� *LoginCommand+{��� *IsLoginButtonEnabled+�� -
   $��QuestionTextBlock��$��Center=�$��Center=�$��2��$��8��$��Dosis)�#��[  ��  �� -   $ Register_Page��$��Center=�$��Center=�$��2��$��9��$	��120��$��40��$��Dosis)���  {��� *IsRegisterButtonEnabled+�� -   $ exitBttn��$��Center=�$��4��$��0��$��50��$��20��$��20,0,0,0q�$��Dosis)���  �� -   $
 RegisterUser��$
��Left=�$��23��$��652,153,0,0q� �� TextWrapping$
 Wrap=�$��username��$	��Top=�$	��120���� -   $
 RegisterPass��$
��Left=�$��23��$��652,201,0,0q�$
 Wrap=�$��password��$	��Top=�$	��120���� -   $
 RegisterPassC��$
��Left=�$��24��$��652,255,0,0q�$
 Wrap=�$��confirmpassword��$	��Top=�$	��120��