   M S B A M L   `   `   `  ���� B  >Bedrock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:BedrockBedrock      Bedrock.ClaimWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     'localclr-namespace:Bedrock       � Title$  Жалоба��$	��803��$	��453�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterOwner=�
������  � AllowsTransparency . .��� .+��� $	��803��$	��453��$��Center=�$��Center=�$��0,0,0,0q�
���   � �� CornerRadius$ 14��$��2q�
�������._�� .+��� $	��720��$	��453��$��Center=�$��Center=�$��0,0,0,0q����#1f1f1f._�� .+��� $��Center=�$��Center=�$��-550,-400,0,0q�$��Ваш никнейм:��$��16(�$��Google Sans)�
��������� $	��320��$��45��$��Center=�$��Center=�$��-350,-325,0,0q����#2e2e2e$ 10��$��3q�
�������._�� .+��� -    ��Name$ NicknameTextBox��$
��Left=�$��Center=�$��10,0,0,0q�$	��293��
������ $��0q�
�������$��Google Sans)�$��22(��� $��Center=�$��Center=�$��170,-400,0,0q�$ ��Вид нарушения:��$��16(�$��Google Sans)�
��������� $	��320��$��45��$��Center=�$��Center=�$��350,-325,0,0q����#e06b15$ 10��$��3q�
�������._�� .+��� -    ��Name$ ViolationComboBox��$	��275��$��Center=�$��Center=�$��0,0,0,0q����#e06b15#��["�|�.   �� SelectedIndex$ 0��
������ $��0q�
�������$��Google Sans Medium)�$��24(�����  �� 
TargetType" ��.��� 	 �� Property	 � ��
 �� Value
 �#e06b15�� 	 � ��
 �#e06b15.@��� $+��%Использование читов���� $+��%Использование багов���� $+��%Токсичное поведение���� $+��%Недоработка проекта���� $��Center=�$��Center=�$��-490,-230,0,0q�$(��"Опишите нарушение:��$��16(�$��Google Sans)�
��������� -    ��Name$ 	Violation��$	��670��$	��300��$��Center=�$��Center=�$��	0,100,0,0q����#2e2e2e$ 10��$��0q�
�������._�� .+��� -   $ ViolationTextBox��$	��650��$	��280��$
��Left=�$	��Top=�$��8,7,0,0q�
������ $��0q�$��Google Sans)�$��15(�
��������� -   $ Dispatch��$	��120��$��38��$��Center=�$��Center=�$��520,332,0,0q����#e06b15
�������$��2q�$ 10�� J� Opacity$ 0Q�{�.  ._�� .+��� -    ��Name$ DispatchButtonLabel��$��Center=�$��Center=�$��0,0,0,0q�$��Отправить��
�������$��18(�$��Google Sans Medium)��� -    ��Name$ DispatchButton��$	��100��$��34��$��Center=�$��Center=�$��0,0,0,0q�$ 0Q��� -   $ UIExit��$��Center=�$��Center=�$��760,-410,0,0q�._�� .+�(� -	    (�Name$ 
UIExitIcon��$��28��$��28��.���� $��24��$��24��.+�F� ���#e06b15����� z ��- � $� ��- �@A��- @o@��O @o@ z �@o@ $� �@o@@A@A@o@ $� @o@� z @o@���O @o@��- @A��-  $� ���-  z ���- ��O ��O ��-  z ��- 	(� $��18��$��18��.���� $��24��$��24��.+�F� 
�������|���� -10pi ��� 	= � � г� �0pi  	= � 	= 0pi �г�  � � 	= ���0pi  -1� � 0�� ��� -1� -1���0��  � � -10pi 	�� -
   $ UIExitButton��$��22��$��22��$��Center=�$��Center=�$��0,0,0,0q�$ 0Q� � 	Resources    
CursorMain � Cursor�� %$   &	        �� $ MainCursor.cur��