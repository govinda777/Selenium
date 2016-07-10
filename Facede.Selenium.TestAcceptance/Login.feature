Funcionalidade: Login
				Para um usario e senha verificamos se he efetuado o login

Cenário: Login na aplicacao com dados validos
	Dado Que possuo usuario e senha validos
	Quando For me logar na aplicacao com os dados
		| Usuario                     | Senha          |
		| luan_govinda777@hotmail.com | Hermeserenato1 |
		| luan_govinda777@hotmail.com | Hermeserenato1 |
		| luan_govinda777@hotmail.com | Hermeserenato1 |
		| luan_govinda777@hotmail.com | Hermeserenato1 |
		| luan_govinda777@hotmail.com | Hermeserenato1 |
	Então Conseguirei me logar
