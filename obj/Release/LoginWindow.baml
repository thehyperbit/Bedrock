   M S B A M L   `   `   `  ���� B  >Bedrock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BedrockBedrock      Bedrock.LoginWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Bedrock     -     � Title$  Авторизация��$	��280��$	��500�� � WindowStyle$
 None=� � AllowsTransparency . 
������  � WindowStartupLocation$ CenterOwner=�.��� .+��� -   $	��280��$	��500��$��Center=�$��Center=�$��0,0,0,0q� �� CornerRadius$ 14�����#1f1f1f
�������$��2q�._�� .+��� -    ��Name$ LoginPrompt��$��Center=�$��Center=�$��-165,-380,0,0q�$��Логин:��
�������$��10(��� -    ��Name$ LoginBackground��$	��220��$��40��$��Center=�$��Center=�$��
0,-320,0,0q����#2e2e2e$ 6��._�� .+��� -    ��Name$ 	LoginTEXT��$	��200��$
��Left=�$��Center=�$��10,0,0,0q�$�� ��
�������
������ $,��&/Bedrock;component/#Google Sans Medium)�$��18(�$��0q� �� 	MaxLength$ 18���� -   $ PasswordPrompt��$��Center=�$��Center=�$��-160,-250,0,0q�$��Пароль:��
�������$��10(��� -   $ PasswordBackground��$	��220��$��40��$��Center=�$��Center=�$��
0,-190,0,0q����#2e2e2e$ 6��._�� .+�G� -   	 G�Name$	 PasswordTEXT��$	��200��$
��Left=�$��Center=�$��10,0,0,0q�
 G� PasswordChar$	
 •��
�������
������ $,��&/Bedrock;component/#Google Sans Medium)�$��18(�$��0q� G� 	MaxLength$ 20���� -	   $ EmailPrompt��$��Center=�$��Center=�$��-169,-250,0,0q�$��E-mail��
�������$��10(�$y�Hidden=� J� Opacity$ 0Q��� -
   $ EmailBackground��$	��220��$��40��$��Center=�$��Center=�$��
0,-190,0,0q����#2e2e2e$ 6��$y�Hidden=�$ 0Q�._�� .+��� -   $ 	EmailTEXT��$	��200��$
��Left=�$��Center=�$��10,0,0,0q�
�������
������ $,��&/Bedrock;component/#Google Sans Medium)�$��18(�$��0q�$ 40���� -   $ PasswordRepeatPrompt��$��Center=�$��Center=�$��-125,10,0,0q�$ ��Повтор пароля:��
�������$��10(�$y�Hidden=�$ 0Q��� -   $ PasswordRepeatBackground��$	��220��$��40��$��Center=�$��Center=�$��0,70,0,0q����#2e2e2e$ 6��$y�Hidden=�$ 0Q�._�� .+�G� -   $	 PasswordRepeatTEXT��$	��200��$
��Left=�$��Center=�$��10,0,0,0q�$	
 •��
�������
������ $,��&/Bedrock;component/#Google Sans Medium)�$��18(�$��0q�$ 20���� -   $ RegisterPrompt��$��Center=�$��Center=�$��	0,445,0,0q�$%��Уже есть аккаунт?��
�������$ 0Q��� -    ��Name$ RegisterPromptButton��$	��100��$��10��$��Center=�$��Center=�$��	0,450,0,0q�
������ $ 0Q�$y�Hidden=��� -   $ RegisterButtonBackground��$	��170��$��40��$��Center=�$��Center=�$��	0,380,0,0q����#e06b15
�������$��2q�$ 10��._�� .+��� -    ��Name$ RegisterButtonLabel��$��Center=�$��Center=�$��0,0,0,0q�$��Регистрация��
�������$��20(�$��Google Sans Medium)��� -   $ RegisterButton��$	��170��$��40��$��Center=�$��Center=�$��0,0,0,0q�$ 0Q��� -   $ Decorations��._�� .+��� $��Center=�$��Center=�$��	0,299,0,0q�$��или��$��20(�
�������$,��&/Bedrock;component/#Google Sans Medium)��� $��80��$��2��$��Center=�$��Center=�$��140,300,0,0q�
�������$ 1���� $��80��$��2��$��Center=�$��Center=�$��-140,300,0,0q�
�������$ 1���� -   $ LoginButtonBackground��$	��170��$��40��$��Center=�$��Center=�$��	0,220,0,0q����#e06b15
�������$��2q�$ 10��._�� .+��� -   $ LoginButtonLabel��$��Center=�$��Center=�$��0,0,0,0q�$��
Войти��
�������$��20(�$��Google Sans Medium)��� -   $ LoginButton��$	��170��$��40��$��Center=�$��Center=�$��0,0,0,0q�$ 0Q��� -   $ UIExit��$��Center=�$��Center=�$��240,-460,0,0q�._�� .+�(� -    (�Name$ 
UIExitIcon��$��28��$��28��.���� $��24��$��24��.+�F� ���#e06b15����� z ��- � $� ��- �@A��- @o@��O @o@ z �@o@ $� �@o@@A@A@o@ $� @o@� z @o@���O @o@��- @A��-  $� ���-  z ���- ��O ��O ��-  z ��- 	(� $��18��$��18��.���� $��24��$��24��.+�F� 
�������|���� -10pi ��� 	= � � г� �0pi  	= � 	= 0pi �г�  � � 	= ���0pi  -1� � 0�� ��� -1� -1���0��  � � -10pi 	�� -   $ UIExitButton��$��22��$��22��$��Center=�$��Center=�$��0,0,0,0q�$ 0Q�