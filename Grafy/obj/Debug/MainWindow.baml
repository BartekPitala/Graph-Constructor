   M S B A M L   `   `   `  ����@  <Grafy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GrafyGrafy  5   	       Grafy.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Grafy     5   	     � Title$  
MainWindow��5   	   $	��768��6   $
��1024��6)   .��5      � -   5        $��Najlepszy_grid��5      $
�� 768��6!   $
��1024��6/   ���	#FFCE0C0C.+�5   
   �� -   5         ��Name$ Info_o_liczbie��5      $
��Left=�6,   $��	21,27,0,0q�6G   $
��Wrap=�6Z   $,��&Poniżej wpisz liczbę wierzchołków:��6n   $	��Top=�6�   $��43��6�   $	��144��6�   $��Segoe UI Black)�6�   $��14(�6�   ���	#FF3CAD186�   �� 5   
   -   5         ��Name$ illosc_wierzcholkow��5      $
��Left=�6/   $��23��6J   $��
26,112,0,0q�6V    �� TextWrapping$
 Wrap=�6j   $�� ��6~   $	��Top=�6�   $	��120��6�   6�   �� 5   
   -   5         ��Name$ restart_button��5      $��RESTART��6)   $
��Left=�6;   $��
21,517,0,0q�6V   $	��Top=�6j   $��98��6�   $��42��6�   6�   �� 5   
   -   5        $ confirm_button��5      $��
Zatwierdź��6)   $
��Left=�6=   $��165,112,0,0q�6X   $	��Top=�6m   $��75��6�   $��23��6�   
���   ����	#FF0EE00E��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#    � Offset$ 0Q�61   � 5      $ 	#FFC5BB28��6#   $ 1Q�65   5      5      �� 5   
   -   5        $ sasiedzi_wierzcholka��5      $
��Left=�62   $��
25,153,0,0q�6M   $
��Wrap=�6a   $0��*Poniżej wpisz sąsiadów wierzchołka nr ��6u   $	��Top=�6�   $��70��6�   $	��313��6�   $��Segoe UI Black)�6�   $��14(�6�   ���	#FF83CA27	 J� RenderTransformOrigin$	 0.5,0.5&�6  z�5      V� 5      .~�5      �� �� 5      
 �� AngleX$
 -4.574Q�6$   �� 5      T� 5       T� X$
 1.92Q�6)   5      5       �� 5!   
   -   5        $ sasiedzi��5!      $
��Left=�6$   $��23��6?   $��
29,225,0,0q�6K   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   6�   �� 5"   
   -   5        $ confirm_button_2��5"      $��Zatwierdź sąsiada��6+   $
��Left=�6G   $��165,225,0,0q�6b   $	��Top=�6w   $	��118��6�   $��23��6�   6�   �� 5#   
   -	   5        $  kolejny_wierzcholek_button��5#      $(��"Przejdź do kolejnego wierzchołka��65   $
��Left=�6`   $��
85,253,0,0q�6{   $	��Top=�6�   $	��198��6�   $��23��6�   6�   �� 5$   
   -
   5        $ draw_connections_button��5$      $��RYSUJ POŁĄCZENIA��62   $
��Left=�6M   $��
10,308,0,0q�6h   $	��Top=�6|   $	��139��6�   $��23��6�   6�   �� 5%   
   -   5        $ wczytywanie_z_pliku��5%      $��Wczytaj z pliku��6.   $
��Left=�6H   $��
21,394,0,0q�6c   $	��Top=�6w   $��88��6�   $��26��6�   6�   5'      5+      